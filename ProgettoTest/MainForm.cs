using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using ProgettoTest.ConfigPredefiniti;

namespace ProgettoTest
{
    public partial class MainForm : Form
    {
        #region Fields

        private List<Esame> tuttiEsami = new List<Esame>();
        private List<Esame> esamiFiltrati = new List<Esame>();

        // Costanti per migliorare la leggibilità
        private const string CODICE_MINISTERIALE = "Codice Ministeriale";
        private const string CODICE_INTERNO = "Codice Interno";
        private const string DESCRIZIONE_ESAME = "Descrizione Esame";

        private readonly string connectionString;
        #endregion

        #region Constructor & Initialization

        private static string CreaConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Predefiniti_Database.Server,
                InitialCatalog = Predefiniti_Database.DatabaseName,
                ConnectTimeout = Predefiniti_Database.TimeoutConnessione
            };

            if (Predefiniti_Database.IntegratedSecurity)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = Predefiniti_Database.UserId;
                builder.Password = Predefiniti_Database.Password;
            }
            return builder.ConnectionString;

        }

        public MainForm()
        {
            InitializeComponent();

            // Carica configurazione
            ConfigLoader.CaricaConfigurazione();

            // Ora che i dati sono letti, crea la connection string
            connectionString = CreaConnectionString();

            InizializzaInterfaccia();
            AssociaEventi();

            // Applica configurazioni predefinite
            ApplicaConfigurazioniPredefinite();
        }

        private void InizializzaInterfaccia()
        {
            // Imposta campi di ricerca 
            comboBoxCampoRicerca.Items.AddRange(new[] { CODICE_MINISTERIALE, CODICE_INTERNO, DESCRIZIONE_ESAME });
            comboBoxCampoRicerca.SelectedIndex = 0;
        }

        private void AssociaEventi()
        {
            listBoxAmbulatori.SelectedIndexChanged += listBoxAmbulatori_SelectedIndexChanged;
            listBoxPartiCorpo.SelectedIndexChanged += listBoxPartiCorpo_SelectedIndexChanged;
            listBoxEsami.SelectedIndexChanged += listBoxEsami_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CaricaEsamiDalDB(); // Prima carica i dati
                AggiornaInterfaccia(); // Poi popola le ListBox

                // Usa un timer per applicare la configurazione quando tutto è pronto
                var configTimer = new System.Windows.Forms.Timer();
                configTimer.Interval = 200; // 200ms 
                configTimer.Tick += (s, args) => {
                    configTimer.Stop();
                    configTimer.Dispose();
                    ApplicaConfigurazioniPredefinite();
                };
                configTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento dei dati: {ex.Message}", "Errore",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplicaConfigurazioniPredefinite()
        {
            try
            {
                // Verifica che i dati siano stati caricati
                if (tuttiEsami == null || tuttiEsami.Count == 0)
                {
                    return; // Silenziosamente non applica se i dati non sono pronti
                }

                // 1. Applica il tipo di ricerca predefinito
                if (!string.IsNullOrEmpty(Predefiniti_Ricerca.TipoRicercaPredefinito))
                {
                    bool tipoTrovato = false;
                    for (int i = 0; i < comboBoxCampoRicerca.Items.Count; i++)
                    {
                        if (comboBoxCampoRicerca.Items[i].ToString().Equals(Predefiniti_Ricerca.TipoRicercaPredefinito, StringComparison.OrdinalIgnoreCase))
                        {
                            comboBoxCampoRicerca.SelectedIndex = i;
                            tipoTrovato = true;
                            break;
                        }
                    }

                    if (!tipoTrovato)
                    {
                        MessageBox.Show($"Tipo di ricerca '{Predefiniti_Ricerca.TipoRicercaPredefinito}' non trovato nella configurazione.\nVerrà utilizzato il tipo di ricerca di default.",
                                       "Configurazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Se non trova il tipo, non continua con la ricerca automatica
                    }
                }

                // 2. Applica la ricerca predefinita
                if (!string.IsNullOrEmpty(Predefiniti_Ricerca.RicercaPredefinita))
                {
                    var campoSelezionato = comboBoxCampoRicerca.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(campoSelezionato))
                    {
                        // Pulisci le interfacce prima della ricerca
                        ResetRicerca();
                        listBoxAmbulatori.Items.Clear();
                        listBoxPartiCorpo.Items.Clear();
                        listBoxEsami.Items.Clear();

                        // Imposta il testo e esegui la ricerca
                        textBoxRicerca.Text = Predefiniti_Ricerca.RicercaPredefinita;
                        AggiornaListBoxEsami(Predefiniti_Ricerca.RicercaPredefinita);
                    }
                    else
                    {
                        MessageBox.Show("Impossibile eseguire la ricerca predefinita: campo di ricerca non selezionato.",
                                       "Errore Configurazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetRicerca();
                        AggiornaInterfaccia();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'applicazione delle configurazioni predefinite: {ex.Message}",
                               "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Operazioni Database

        private void CaricaEsamiDalDB()
        {
            tuttiEsami.Clear();

            const string query = @"
                SELECT 
                    e.CodiceMinisteriale, 
                    e.CodiceInterno, 
                    e.DescrizioneEsame, 
                    p.NomeParte AS ParteCorpo, 
                    a.NomeAmbulatorio AS Ambulatorio
                FROM Ambulatori a
                LEFT JOIN EsamiAmbulatori ea ON a.Id = ea.AmbulatorioId
                LEFT JOIN Esami e ON ea.EsameId = e.Id
                LEFT JOIN PartiDelCorpo p ON e.ParteDelCorpoId = p.Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tuttiEsami.Add(CreaEsameDaReader(reader));
                    }
                }
            }
        }

        private static Esame CreaEsameDaReader(SqlDataReader reader)
        {
            return new Esame
            {
                CodiceMinisteriale = reader["CodiceMinisteriale"]?.ToString() ?? string.Empty,
                CodiceInterno = reader["CodiceInterno"]?.ToString() ?? string.Empty,
                DescrizioneEsame = reader["DescrizioneEsame"]?.ToString() ?? string.Empty,
                ParteCorpo = reader["ParteCorpo"]?.ToString() ?? string.Empty,
                Ambulatorio = reader["Ambulatorio"]?.ToString() ?? string.Empty
            };
        }

        #endregion

        #region Metodi ottenimento dati

        // Recupera lista unica ambulatori
        private List<string> OttieniAmbulatori()
        {
            return tuttiEsami.Select(e => e.Ambulatorio).Distinct().ToList();
        }

        // Recupera lista unica parti del corpo per ambulatorio selezionato
        private List<string> OttieniPartiCorpo(string ambulatorio)
        {
            return tuttiEsami
                .Where(e => e.Ambulatorio == ambulatorio && !string.IsNullOrEmpty(e.ParteCorpo))
                .Select(e => e.ParteCorpo)
                .Distinct()
                .ToList();
        }

        // Filtra esami in base a testo e campo selezionato
        private List<Esame> FiltraEsami(string filtro, string campo)
        {
            var testo = filtro.ToLower();

            return tuttiEsami.Where(ex =>
            {
                switch (campo)
                {
                    case CODICE_MINISTERIALE:
                        return ex.CodiceMinisteriale.ToLower().Contains(testo);
                    case CODICE_INTERNO:
                        return ex.CodiceInterno.ToLower().Contains(testo);
                    case DESCRIZIONE_ESAME:
                        return ex.DescrizioneEsame.ToLower().Contains(testo);
                    default:
                        return false;
                }
            }).ToList();
        }

        #endregion

        #region Update interfaccia

        private void AggiornaInterfaccia()
        {
            AggiornaListBoxAmbulatori();
            AggiornaListBoxPartiCorpo();
            AggiornaListBoxEsami();
        }

        private void AggiornaListBoxAmbulatori()
        {
            var ambulatori = OttieniAmbulatori();
            AggiornaListBox(listBoxAmbulatori, ambulatori);
        }

        private void AggiornaListBoxPartiCorpo()
        {
            listBoxPartiCorpo.Items.Clear();

            if (listBoxAmbulatori.SelectedItem == null) return;

            var ambulatorio = listBoxAmbulatori.SelectedItem.ToString();
            var parti = OttieniPartiCorpo(ambulatorio);
            AggiornaListBox(listBoxPartiCorpo, parti);
        }

        private void AggiornaListBoxEsami(string filtroRicerca = "")
        {
            listBoxEsami.Items.Clear();

            if (!string.IsNullOrWhiteSpace(filtroRicerca))
            {
                GestisciRicercaEsami(filtroRicerca);
                return;
            }
            // Logica normale cascata se non in ricerca
            GestisciSelezioneNormale();
        }

        private void GestisciRicercaEsami(string filtroRicerca)
        {
            esamiFiltrati.Clear();
            var campo = comboBoxCampoRicerca.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(campo)) return;

            esamiFiltrati = FiltraEsami(filtroRicerca, campo);

            if (esamiFiltrati.Count == 0)
            {
                MessageBox.Show("Nessun risultato trovato.", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetRicerca();
                AggiornaInterfaccia();
                return;
            }

            listBoxEsami.Items.AddRange(esamiFiltrati.ToArray());
            listBoxEsami.SelectedIndex = -1;

            listBoxAmbulatori.Items.Clear();
            listBoxPartiCorpo.Items.Clear();
        }

        private void GestisciSelezioneNormale()
        {
            if (listBoxAmbulatori.SelectedItem == null || listBoxPartiCorpo.SelectedItem == null)
                return;

            var ambulatorio = listBoxAmbulatori.SelectedItem.ToString();
            var parte = listBoxPartiCorpo.SelectedItem.ToString();

            var esamiDaMostrare = tuttiEsami
                .Where(e => e.Ambulatorio == ambulatorio && e.ParteCorpo == parte)
                .ToList();

            listBoxEsami.Items.AddRange(esamiDaMostrare.ToArray());
            if (listBoxEsami.Items.Count > 0)
                listBoxEsami.SelectedIndex = 0;
        }

        private void AggiornaListBox(ListBox listBox, List<string> items)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(items.ToArray());
            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }

        #endregion

        #region ListBox

        private void listBoxAmbulatori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAmbulatori.SelectedItem == null) return;

            var ambulatorioSelezionato = listBoxAmbulatori.SelectedItem.ToString();

            // Se in modalità ricerca, resetta
            if (IsModalitaRicerca())
                ResetRicerca();

            // Mantieni selezione durante l'aggiornamento
            MantieneSelezioneAmbulatorio(ambulatorioSelezionato);

            AggiornaListBoxPartiCorpo();
            AggiornaListBoxEsami();
        }

        private void listBoxPartiCorpo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPartiCorpo.SelectedItem == null) return;
            
            // Se in modalità ricerca, resetta
            if (IsModalitaRicerca())
                ResetRicerca();

            AggiornaListBoxEsami();
        }

        private void listBoxEsami_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEsami.SelectedItem == null) return;

            var esameSelezionato = (Esame)listBoxEsami.SelectedItem;

            // Aggiorna prime due listbox solo se in modalità ricerca
            if (IsModalitaRicerca())
                AggiornaListBoxPerRicerca(esameSelezionato);
        }

        private void MantieneSelezioneAmbulatorio(string ambulatorioSelezionato)
        {
            // Sospendi temporaneamente l'evento per evitare ricorsione
            listBoxAmbulatori.SelectedIndexChanged -= listBoxAmbulatori_SelectedIndexChanged;

            listBoxAmbulatori.Items.Clear();
            listBoxAmbulatori.Items.AddRange(OttieniAmbulatori().ToArray());
            listBoxAmbulatori.SelectedItem = ambulatorioSelezionato;

            // Riattiva l'evento
            listBoxAmbulatori.SelectedIndexChanged += listBoxAmbulatori_SelectedIndexChanged;
        }

        private void AggiornaListBoxPerRicerca(Esame esame)
        {
            // Sospendi eventi temporaneamente
            listBoxAmbulatori.SelectedIndexChanged -= listBoxAmbulatori_SelectedIndexChanged;
            listBoxPartiCorpo.SelectedIndexChanged -= listBoxPartiCorpo_SelectedIndexChanged;

            // Aggiorna le listbox con i dati dell'esame selezionato
            listBoxAmbulatori.Items.Clear();
            listBoxAmbulatori.Items.Add(esame.Ambulatorio);
            listBoxAmbulatori.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(esame.ParteCorpo))
            {
                listBoxPartiCorpo.Items.Clear();
                listBoxPartiCorpo.Items.Add(esame.ParteCorpo);
                listBoxPartiCorpo.SelectedIndex = 0;
            }

            // Riattiva eventi
            listBoxAmbulatori.SelectedIndexChanged += listBoxAmbulatori_SelectedIndexChanged;
            listBoxPartiCorpo.SelectedIndexChanged += listBoxPartiCorpo_SelectedIndexChanged;
        }

        #endregion

        #region Pulsanti

        private void buttonConfermaEsame_Click(object sender, EventArgs e)
        {
            if (!ValidaSelezioneCompleta()) return;

            var esameSelezionato = (Esame)listBoxEsami.SelectedItem;

            dataGridViewEsamiSelezionati.Rows.Add(
                esameSelezionato.CodiceMinisteriale,
                esameSelezionato.CodiceInterno,
                esameSelezionato.DescrizioneEsame,
                listBoxAmbulatori.SelectedItem?.ToString() ?? "",
                listBoxPartiCorpo.SelectedItem?.ToString() ?? ""
            );
        }

        private void buttonEliminaRiga_Click(object sender, EventArgs e)
        {
            var righeSelezionate = dataGridViewEsamiSelezionati.SelectedRows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToList();

            foreach (var row in righeSelezionate)
                dataGridViewEsamiSelezionati.Rows.Remove(row);
        }

        private void buttonSpostaGiu_Click(object sender, EventArgs e) => SpostaRiga(1);
        private void buttonSpostaSu_Click(object sender, EventArgs e) => SpostaRiga(-1);

        // Ricerca con click tasto
        private void buttonCerca_Click(object sender, EventArgs e)
        {
            var testo = textBoxRicerca.Text.Trim();
            if (!string.IsNullOrWhiteSpace(testo))
                AggiornaListBoxEsami(testo);
        }

        // Ricerca con invio
        private void textBoxRicerca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                buttonCerca_Click(sender, EventArgs.Empty);
            }
        }

        // "Vedi tutti" reset ricerca
        private void button1_Click(object sender, EventArgs e)
        {
            ResetRicerca();
            AggiornaInterfaccia();
        }

        // Apri pannello admin DB
        private void buttonApriAdminDb_Click(object sender, EventArgs e)
        {
            using (var admin = new AdminDbForm(connectionString))
            {
                admin.ShowDialog();
            }

            // Ricarica dati nel main form dopo eventuali modifiche
            CaricaEsamiDalDB();
            AggiornaInterfaccia();
        }

        #endregion

        #region Helper Methods

        private bool IsModalitaRicerca() => !string.IsNullOrWhiteSpace(textBoxRicerca.Text);

        private void ResetRicerca()
        {
            textBoxRicerca.Clear();
            esamiFiltrati.Clear();
        }

        private bool ValidaSelezioneCompleta()
        {
            return listBoxEsami.SelectedItem != null &&
                   listBoxAmbulatori.SelectedItem != null &&
                   listBoxPartiCorpo.SelectedItem != null;
        }

        private void SpostaRiga(int direzione)
        {
            if (dataGridViewEsamiSelezionati.SelectedRows.Count == 0) return;

            var row = dataGridViewEsamiSelezionati.SelectedRows[0];
            var currentIndex = row.Index;
            var newIndex = currentIndex + direzione;

            // Valida i limiti
            if (newIndex < 0 || newIndex >= dataGridViewEsamiSelezionati.Rows.Count - 1 || row.IsNewRow)
                return;

            // Esegui lo spostamento
            dataGridViewEsamiSelezionati.Rows.RemoveAt(currentIndex);
            dataGridViewEsamiSelezionati.Rows.Insert(newIndex, row);

            // Mantieni la selezione sulla riga spostata
            dataGridViewEsamiSelezionati.ClearSelection();
            dataGridViewEsamiSelezionati.Rows[newIndex].Selected = true;
        }

        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
