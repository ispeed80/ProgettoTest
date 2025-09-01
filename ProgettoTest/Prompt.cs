using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 400,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen,
            MinimizeBox = false,
            MaximizeBox = false
        };

        Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
        TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };

        Button confirmation = new Button() { Text = "OK", Left = 200, Width = 80, Top = 80, DialogResult = DialogResult.OK };
        Button cancel = new Button() { Text = "Annulla", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

        confirmation.Click += (sender, e) => { prompt.Close(); };
        cancel.Click += (sender, e) => { textBox.Text = ""; prompt.Close(); };

        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(cancel);
        prompt.Controls.Add(textLabel);

        prompt.AcceptButton = confirmation;
        prompt.CancelButton = cancel;

        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }

    public class EsameInputResult
    {
        public string CodiceMinisteriale { get; set; }
        public string CodiceInterno { get; set; }
        public string DescrizioneEsame { get; set; }
        public List<string> Ambulatori { get; set; } = new List<string>();
        public string ParteCorpo { get; set; }
    }

    public static class EsamePrompt
    {
        public static EsameInputResult ShowDialog(string connectionString)
        {
            EsameInputResult result = null;

            Form prompt = new Form()
            {
                Width = 450,
                Height = 425,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Aggiungi Esame",
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label lblCodMin = new Label() { Left = 20, Top = 20, Text = "Codice Ministeriale:", AutoSize = true };
            TextBox txtCodMin = new TextBox() { Left = 20, Top = 45, Width = 380 };

            Label lblCodInt = new Label() { Left = 20, Top = 80, Text = "Codice Interno:", AutoSize = true };
            TextBox txtCodInt = new TextBox() { Left = 20, Top = 105, Width = 380 };

            Label lblDescr = new Label() { Left = 20, Top = 140, Text = "Descrizione Esame:", AutoSize = true };
            TextBox txtDescr = new TextBox() { Left = 20, Top = 165, Width = 380 };

            Label lblAmb = new Label() { Left = 20, Top = 200, Text = "Ambulatori:", AutoSize = true };
            CheckedListBox clbAmb = new CheckedListBox() { Left = 20, Top = 225, Width = 180, Height = 145, CheckOnClick = true };

            Label lblParte = new Label() { Left = 220, Top = 200, Text = "Parte del Corpo:", AutoSize = true };
            ComboBox cmbParte = new ComboBox() { Left = 220, Top = 225, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

            // Carico ambulatori e parti del corpo dal DB
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdAmb = new SqlCommand("SELECT NomeAmbulatorio FROM Ambulatori", conn);
                using (SqlDataReader readerAmb = cmdAmb.ExecuteReader())
                {
                    while (readerAmb.Read()) clbAmb.Items.Add(readerAmb["NomeAmbulatorio"].ToString());
                }

                SqlCommand cmdParti = new SqlCommand("SELECT NomeParte FROM PartiDelCorpo", conn);
                using (SqlDataReader readerParti = cmdParti.ExecuteReader())
                {
                    while (readerParti.Read()) cmbParte.Items.Add(readerParti["NomeParte"].ToString());
                }
            }

            Button confirmation = new Button() { Text = "OK", Left = 220, Width = 80, Top = 340, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Annulla", Left = 310, Width = 80, Top = 340, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCodMin.Text) ||
                    string.IsNullOrWhiteSpace(txtCodInt.Text) ||
                    string.IsNullOrWhiteSpace(txtDescr.Text) ||
                    clbAmb.CheckedItems.Count == 0 ||
                    cmbParte.SelectedItem == null)
                {
                    MessageBox.Show("Compila tutti i campi e seleziona almeno un ambulatorio e la parte del corpo.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                result = new EsameInputResult()
                {
                    CodiceMinisteriale = txtCodMin.Text.Trim(),
                    CodiceInterno = txtCodInt.Text.Trim(),
                    DescrizioneEsame = txtDescr.Text.Trim(),
                    Ambulatori = clbAmb.CheckedItems.Cast<string>().ToList(),
                    ParteCorpo = cmbParte.SelectedItem.ToString()
                };

                prompt.Close();
            };

            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(lblCodMin);
            prompt.Controls.Add(txtCodMin);
            prompt.Controls.Add(lblCodInt);
            prompt.Controls.Add(txtCodInt);
            prompt.Controls.Add(lblDescr);
            prompt.Controls.Add(txtDescr);
            prompt.Controls.Add(lblAmb);
            prompt.Controls.Add(clbAmb);
            prompt.Controls.Add(lblParte);
            prompt.Controls.Add(cmbParte);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            prompt.ShowDialog();
            return result;
        }
    }
}

