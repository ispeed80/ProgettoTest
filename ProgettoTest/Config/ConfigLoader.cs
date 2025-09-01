using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;

namespace ProgettoTest.ConfigPredefiniti
{
    public static class ConfigLoader
    {
        public static void CaricaConfigurazione()
        {
            string percorsoIni = Path.Combine(Application.StartupPath, "config.ini");

            if (!File.Exists(percorsoIni))
            {
                return; // Usa silenziosamente i valori di default
            }

            try
            {
                CaricaFileIni(percorsoIni);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento del file di configurazione:\n\n{ex.Message}\n\nIl programma utilizzerà i valori predefiniti.",
                               "Errore Configurazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void CaricaFileIni(string percorsoFile)
        {
            string[] righe = File.ReadAllLines(percorsoFile, System.Text.Encoding.UTF8);
            string sezioneCorrente = "";

            foreach (string riga in righe)
            {
                string rigaPulita = riga.Trim();

                // Ignora righe vuote e commenti
                if (string.IsNullOrEmpty(rigaPulita) || rigaPulita.StartsWith("#"))
                    continue;

                // È una sezione? [NomeSezione]
                if (rigaPulita.StartsWith("[") && rigaPulita.EndsWith("]"))
                {
                    sezioneCorrente = rigaPulita.Substring(1, rigaPulita.Length - 2).Trim();
                    continue;
                }

                // È una configurazione key=value?
                if (rigaPulita.Contains("=") && !string.IsNullOrEmpty(sezioneCorrente))
                {
                    ProcessaConfigurazione(sezioneCorrente, rigaPulita);
                }
            }
        }

        private static void ProcessaConfigurazione(string sezione, string riga)
        {
            try
            {
                // Dividi la riga in chiave=valore
                string[] parti = riga.Split(new char[] { '=' }, 2);
                if (parti.Length != 2) return;

                string nomeProprietà = parti[0].Trim();
                string valore = parti[1].Trim();

                // Rimuovi le virgolette se presenti
                if (valore.StartsWith("\"") && valore.EndsWith("\"") && valore.Length >= 2)
                {
                    valore = valore.Substring(1, valore.Length - 2);
                }

                // Cerca la classe corrispondente
                string nomeClasse = $"ProgettoTest.ConfigPredefiniti.Predefiniti_{sezione}";
                Type tipoClasse = Type.GetType(nomeClasse);
                if (tipoClasse == null) return;

                // Cerca la proprietà (case-insensitive per robustezza)
                PropertyInfo proprietà = tipoClasse.GetProperty(nomeProprietà,
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
                if (proprietà == null) return;

                // Converti e assegna il valore
                object valoreConvertito = ConvertiValore(valore, proprietà.PropertyType);
                proprietà.SetValue(null, valoreConvertito);
            }
            catch
            {
                // Ignora silenziosamente errori di configurazioni singole
                // per non interrompere il caricamento delle altre
            }
        }

        private static object ConvertiValore(string valore, Type tipoDestinazione)
        {
            if (tipoDestinazione == typeof(string))
                return valore ?? "";

            if (string.IsNullOrEmpty(valore))
            {
                // Restituisci valori di default per tipi vuoti
                if (tipoDestinazione == typeof(int)) return 0;
                if (tipoDestinazione == typeof(double)) return 0.0;
                if (tipoDestinazione == typeof(float)) return 0.0f;
                if (tipoDestinazione == typeof(bool)) return false;
                return Activator.CreateInstance(tipoDestinazione);
            }

            try
            {
                if (tipoDestinazione == typeof(int))
                    return Convert.ToInt32(valore, CultureInfo.InvariantCulture);

                if (tipoDestinazione == typeof(double))
                    return Convert.ToDouble(valore, CultureInfo.InvariantCulture);

                if (tipoDestinazione == typeof(float))
                    return Convert.ToSingle(valore, CultureInfo.InvariantCulture);

                if (tipoDestinazione == typeof(bool))
                {
                    string valoreLower = valore.ToLower();
                    return valoreLower == "1" || valoreLower == "true" ||
                           valoreLower == "si" || valoreLower == "yes";
                }

                // Per altri tipi, prova la conversione generica
                return Convert.ChangeType(valore, tipoDestinazione, CultureInfo.InvariantCulture);
            }
            catch
            {
                // In caso di errore di conversione, restituisci il valore di default
                return Activator.CreateInstance(tipoDestinazione);
            }
        }
    }
}