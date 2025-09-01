using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Prompt;

namespace ProgettoTest
{
    public partial class AdminDbForm : Form
    {
        #region Costanti e Variabili

        private readonly string connectionString;

        // Costanti per migliorare la leggibilità
        private const string MESSAGGIO_CONFERMA_ELIMINAZIONE = "Sei sicuro di voler eliminare il record selezionato?";
        private const string TITOLO_CONFERMA = "Conferma eliminazione";
        private const string MESSAGGIO_SELEZIONE_RICHIESTA = "Seleziona prima un record da eliminare.";
        private const string MESSAGGIO_ESAME_AGGIUNTO = "Esame aggiunto con successo!";
        private const string TITOLO_SUCCESSO = "Successo";
        private const string TITOLO_ERRORE = "Errore";

        // Query SQL come costanti
        private const string QUERY_AMBULATORI = "SELECT * FROM Ambulatori";
        private const string QUERY_PARTI_CORPO = "SELECT * FROM PartiDelCorpo";
        private const string QUERY_ESAMI = @"
            SELECT e.Id AS Id,
                   e.CodiceMinisteriale,
                   e.CodiceInterno,
                   e.DescrizioneEsame,
                   p.NomeParte AS ParteCorpo,
                   ISNULL(STUFF(
                       (SELECT ', ' + a.NomeAmbulatorio
                        FROM EsamiAmbulatori ea
                        JOIN Ambulatori a ON ea.AmbulatorioId = a.Id
                        WHERE ea.EsameId = e.Id
                        FOR XML PATH('')), 1, 2, ''), '') AS Ambulatori
            FROM Esami e
            JOIN PartiDelCorpo p ON e.ParteDelCorpoId = p.Id";

        #endregion

        #region Eventi

        // Evento che notifica al MainForm che i dati sono stati modificati
        public event Action DatiModificati;

        #endregion

        #region Costruttori e Inizializzazione  

        public AdminDbForm(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;
            AssociaEventi();
        }

        private void AssociaEventi()
        {
            this.FormClosed += AdminDbForm_FormClosed;
        }

        private void AdminDbForm_Load(object sender, EventArgs e)
        {
            try
            {
                CaricaDati();
                ImpostaLarghezzeColonne();
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante il caricamento: {ex.Message}");
            }
        }

        private void ImpostaLarghezzeColonne()
        {
            // Configurazione larghezze colonne Esami
            ImpostaLarghezzeColonneEsami();

            // Configurazione larghezze altre tabelle
            ImpostaLarghezzeColonneAltreTabelle();
        }

        private void ImpostaLarghezzeColonneEsami()
        {
            if (dataGridViewEsami.Columns.Count > 4)
            {
                dataGridViewEsami.Columns[0].Width = 35;  // Id
                dataGridViewEsami.Columns[1].Width = 80;  // Codice Ministeriale
                dataGridViewEsami.Columns[2].Width = 80;  // Codice Interno
                dataGridViewEsami.Columns[4].Width = 120; // Parte Corpo
            }
        }

        private void ImpostaLarghezzeColonneAltreTabelle()
        {
            dataGridViewAmbulatori.Columns[0].Width = 35;
            dataGridViewParti.Columns[0].Width = 35;
        }

        #endregion

        #region Database Operations

        private void CaricaDati()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                CaricaAmbulatori(conn);
                CaricaPartiCorpo(conn);
                CaricaEsami(conn);
            }
        }

        private void CaricaAmbulatori(SqlConnection conn)
        {
            using (var adapter = new SqlDataAdapter(QUERY_AMBULATORI, conn))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAmbulatori.DataSource = dataTable;
            }
        }

        private void CaricaPartiCorpo(SqlConnection conn)
        {
            using (var adapter = new SqlDataAdapter(QUERY_PARTI_CORPO, conn))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewParti.DataSource = dataTable;
            }
        }

        private void CaricaEsami(SqlConnection conn)
        {
            using (var adapter = new SqlDataAdapter(QUERY_ESAMI, conn))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewEsami.DataSource = dataTable;
            }
        }

        #endregion

        #region Record Management - Eliminazione

        private void EliminaRecord(string tabella, string nomeIdColonna, int id, Action metodoRicarica)
        {
            if (!ConfermaEliminazione()) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    EseguiEliminazione(conn, tabella, nomeIdColonna, id);
                }

                EseguiPostEliminazione(metodoRicarica);
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante l'eliminazione: {ex.Message}");
            }
        }

        private bool ConfermaEliminazione()
        {
            var result = MessageBox.Show(
                MESSAGGIO_CONFERMA_ELIMINAZIONE,
                TITOLO_CONFERMA,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            return result == DialogResult.Yes;
        }

        private void EseguiEliminazione(SqlConnection conn, string tabella, string nomeIdColonna, int id)
        {
            // Per gli esami, elimina prima le relazioni
            if (tabella == "Esami")
                EliminaRelazioniEsame(conn, id);

            // Elimina il record principale
            var query = $"DELETE FROM {tabella} WHERE {nomeIdColonna} = @id";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminaRelazioniEsame(SqlConnection conn, int esameId)
        {
            var deleteRelazioni = "DELETE FROM EsamiAmbulatori WHERE EsameId = @id";
            using (var cmd = new SqlCommand(deleteRelazioni, conn))
            {
                cmd.Parameters.AddWithValue("@id", esameId);
                cmd.ExecuteNonQuery();
            }
        }

        private void EseguiPostEliminazione(Action metodoRicarica)
        {
            if (metodoRicarica != null)
                metodoRicarica.Invoke();

            NotificaCambiamenti();
        }

        #endregion

        #region Record Management - Aggiunta

        private void AggiungiAmbulatorio()
        {
            var nome = Prompt.ShowDialog("Inserisci il nome dell'ambulatorio:", "Nuovo Ambulatorio");
            if (string.IsNullOrEmpty(nome)) return;

            try
            {
                InserisciAmbulatorio(nome);
                EseguiPostAggiunta();
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante l'aggiunta dell'ambulatorio: {ex.Message}");
            }
        }

        private void AggiungiParteCorpo()
        {
            var nome = Prompt.ShowDialog("Inserisci il nome della parte del corpo:", "Nuova Parte del Corpo");
            if (string.IsNullOrEmpty(nome)) return;

            try
            {
                InserisciParteCorpo(nome);
                EseguiPostAggiunta();
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante l'aggiunta della parte del corpo: {ex.Message}");
            }
        }

        private void AggiungiEsame()
        {
            var esame = EsamePrompt.ShowDialog(connectionString);
            if (esame == null) return;

            try
            {
                InserisciEsame(esame);
                MostraSuccesso(MESSAGGIO_ESAME_AGGIUNTO);
                EseguiPostAggiunta();
            }
            catch (SqlException ex)
            {
                MostraErrore($"Errore SQL durante l'inserimento dell'esame:\n{ex.Message}");
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore imprevisto:\n{ex.Message}");
            }
        }

        private void InserisciAmbulatorio(string nome)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO Ambulatori (NomeAmbulatorio) VALUES (@nome)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InserisciParteCorpo(string nome)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO PartiDelCorpo (NomeParte) VALUES (@nome)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InserisciEsame(dynamic esame)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var esameId = InserisciRecordEsame(conn, esame);
                CollegaEsameAdAmbulatori(conn, esameId, esame.Ambulatori);
            }
        }

        private int InserisciRecordEsame(SqlConnection conn, dynamic esame)
        {
            var insertEsameQuery = @"
                INSERT INTO Esami (CodiceMinisteriale, CodiceInterno, DescrizioneEsame, ParteDelCorpoId)
                OUTPUT INSERTED.Id
                VALUES (@codMin, @codInt, @descr, (SELECT Id FROM PartiDelCorpo WHERE NomeParte = @parte))";

            using (var cmd = new SqlCommand(insertEsameQuery, conn))
            {
                cmd.Parameters.AddWithValue("@codMin", esame.CodiceMinisteriale);
                cmd.Parameters.AddWithValue("@codInt", esame.CodiceInterno);
                cmd.Parameters.AddWithValue("@descr", esame.DescrizioneEsame);
                cmd.Parameters.AddWithValue("@parte", esame.ParteCorpo);

                return (int)cmd.ExecuteScalar();
            }
        }

        private void CollegaEsameAdAmbulatori(SqlConnection conn, int esameId, dynamic ambulatori)
        {
            var insertAmbQuery = @"
                INSERT INTO EsamiAmbulatori (EsameId, AmbulatorioId)
                VALUES (@esameId, (SELECT Id FROM Ambulatori WHERE NomeAmbulatorio = @amb))";

            foreach (string amb in ambulatori)
            {
                using (var cmd = new SqlCommand(insertAmbQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@esameId", esameId);
                    cmd.Parameters.AddWithValue("@amb", amb);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EseguiPostAggiunta()
        {
            CaricaDati();
            NotificaCambiamenti();
        }

        #endregion

        #region Event Handlers - Eliminazione

        private void buttonDelAmb_Click(object sender, EventArgs e)
        {
            if (!ValidaSelezione(dataGridViewAmbulatori)) return;

            var id = OttieniIdSelezionato(dataGridViewAmbulatori);
            EliminaRecord("Ambulatori", "Id", id, CaricaDati);
        }

        private void buttonDelPart_Click(object sender, EventArgs e)
        {
            if (!ValidaSelezione(dataGridViewParti)) return;

            var id = OttieniIdSelezionato(dataGridViewParti);
            EliminaRecord("PartiDelCorpo", "Id", id, CaricaDati);
        }

        private void buttonDelEx_Click(object sender, EventArgs e)
        {
            if (!ValidaSelezione(dataGridViewEsami)) return;

            var id = OttieniIdSelezionato(dataGridViewEsami);
            EliminaRecord("Esami", "Id", id, CaricaDati);
        }

        #endregion

        #region Event Handlers - Aggiunta

        private void buttonAddAmb_Click(object sender, EventArgs e)
        {
            AggiungiAmbulatorio();
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            AggiungiParteCorpo();
        }

        private void buttonAddEx_Click(object sender, EventArgs e)
        {
            AggiungiEsame();
        }

        #endregion

        #region Event Handlers - Form

        private void AdminDbForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotificaCambiamenti();
        }

        #endregion

        #region Helper Methods

        private bool ValidaSelezione(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0) return true;

            MessageBox.Show(MESSAGGIO_SELEZIONE_RICHIESTA, "Avviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private int OttieniIdSelezionato(DataGridView dataGridView)
        {
            return Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
        }

        private void NotificaCambiamenti()
        {
            if (DatiModificati != null)
                DatiModificati.Invoke();
        }

        private void MostraErrore(string messaggio)
        {
            MessageBox.Show(messaggio, TITOLO_ERRORE,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostraSuccesso(string messaggio)
        {
            MessageBox.Show(messaggio, TITOLO_SUCCESSO,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}