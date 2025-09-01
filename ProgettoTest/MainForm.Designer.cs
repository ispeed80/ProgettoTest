namespace ProgettoTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxAmbulatori = new System.Windows.Forms.ListBox();
            this.listBoxEsami = new System.Windows.Forms.ListBox();
            this.listBoxPartiCorpo = new System.Windows.Forms.ListBox();
            this.dataGridViewEsamiSelezionati = new System.Windows.Forms.DataGridView();
            this.CodiceMinisteriale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescrizioneEsame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ambulatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParteCorpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonConfermaEsame = new System.Windows.Forms.Button();
            this.buttonEliminaRiga = new System.Windows.Forms.Button();
            this.buttonSpostaGiu = new System.Windows.Forms.Button();
            this.buttonSpostaSu = new System.Windows.Forms.Button();
            this.textBoxRicerca = new System.Windows.Forms.TextBox();
            this.comboBoxCampoRicerca = new System.Windows.Forms.ComboBox();
            this.buttonCerca = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonApriAdminDb = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsamiSelezionati)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxAmbulatori, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxEsami, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxPartiCorpo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 46);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1429, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // listBoxAmbulatori
            // 
            this.listBoxAmbulatori.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxAmbulatori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAmbulatori.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAmbulatori.FormattingEnabled = true;
            this.listBoxAmbulatori.ItemHeight = 25;
            this.listBoxAmbulatori.Location = new System.Drawing.Point(3, 3);
            this.listBoxAmbulatori.Name = "listBoxAmbulatori";
            this.listBoxAmbulatori.Size = new System.Drawing.Size(470, 445);
            this.listBoxAmbulatori.TabIndex = 0;
            // 
            // listBoxEsami
            // 
            this.listBoxEsami.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxEsami.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEsami.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEsami.FormattingEnabled = true;
            this.listBoxEsami.ItemHeight = 25;
            this.listBoxEsami.Location = new System.Drawing.Point(955, 3);
            this.listBoxEsami.Name = "listBoxEsami";
            this.listBoxEsami.Size = new System.Drawing.Size(471, 445);
            this.listBoxEsami.TabIndex = 2;
            // 
            // listBoxPartiCorpo
            // 
            this.listBoxPartiCorpo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxPartiCorpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPartiCorpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPartiCorpo.FormattingEnabled = true;
            this.listBoxPartiCorpo.ItemHeight = 25;
            this.listBoxPartiCorpo.Location = new System.Drawing.Point(479, 3);
            this.listBoxPartiCorpo.Name = "listBoxPartiCorpo";
            this.listBoxPartiCorpo.Size = new System.Drawing.Size(470, 445);
            this.listBoxPartiCorpo.TabIndex = 1;
            // 
            // dataGridViewEsamiSelezionati
            // 
            this.dataGridViewEsamiSelezionati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEsamiSelezionati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewEsamiSelezionati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEsamiSelezionati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodiceMinisteriale,
            this.CodiceInterno,
            this.DescrizioneEsame,
            this.Ambulatorio,
            this.ParteCorpo});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEsamiSelezionati.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewEsamiSelezionati.Location = new System.Drawing.Point(12, 547);
            this.dataGridViewEsamiSelezionati.Name = "dataGridViewEsamiSelezionati";
            this.dataGridViewEsamiSelezionati.ReadOnly = true;
            this.dataGridViewEsamiSelezionati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEsamiSelezionati.Size = new System.Drawing.Size(1426, 222);
            this.dataGridViewEsamiSelezionati.TabIndex = 1;
            // 
            // CodiceMinisteriale
            // 
            this.CodiceMinisteriale.HeaderText = "Codice Ministeriale";
            this.CodiceMinisteriale.Name = "CodiceMinisteriale";
            this.CodiceMinisteriale.ReadOnly = true;
            // 
            // CodiceInterno
            // 
            this.CodiceInterno.HeaderText = "Codice Interno";
            this.CodiceInterno.Name = "CodiceInterno";
            this.CodiceInterno.ReadOnly = true;
            // 
            // DescrizioneEsame
            // 
            this.DescrizioneEsame.HeaderText = "Descrizione Esame";
            this.DescrizioneEsame.Name = "DescrizioneEsame";
            this.DescrizioneEsame.ReadOnly = true;
            // 
            // Ambulatorio
            // 
            this.Ambulatorio.HeaderText = "Ambulatorio";
            this.Ambulatorio.Name = "Ambulatorio";
            this.Ambulatorio.ReadOnly = true;
            // 
            // ParteCorpo
            // 
            this.ParteCorpo.HeaderText = "Parte del corpo";
            this.ParteCorpo.Name = "ParteCorpo";
            this.ParteCorpo.ReadOnly = true;
            // 
            // buttonConfermaEsame
            // 
            this.buttonConfermaEsame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfermaEsame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfermaEsame.Location = new System.Drawing.Point(964, 497);
            this.buttonConfermaEsame.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfermaEsame.Name = "buttonConfermaEsame";
            this.buttonConfermaEsame.Size = new System.Drawing.Size(474, 47);
            this.buttonConfermaEsame.TabIndex = 2;
            this.buttonConfermaEsame.Text = "CONFERMA SELEZIONE";
            this.buttonConfermaEsame.UseVisualStyleBackColor = true;
            this.buttonConfermaEsame.Click += new System.EventHandler(this.buttonConfermaEsame_Click);
            // 
            // buttonEliminaRiga
            // 
            this.buttonEliminaRiga.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonEliminaRiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminaRiga.ForeColor = System.Drawing.Color.Crimson;
            this.buttonEliminaRiga.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminaRiga.Location = new System.Drawing.Point(1403, 773);
            this.buttonEliminaRiga.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEliminaRiga.Name = "buttonEliminaRiga";
            this.buttonEliminaRiga.Size = new System.Drawing.Size(35, 35);
            this.buttonEliminaRiga.TabIndex = 6;
            this.buttonEliminaRiga.Text = "❌";
            this.buttonEliminaRiga.UseVisualStyleBackColor = true;
            this.buttonEliminaRiga.Click += new System.EventHandler(this.buttonEliminaRiga_Click);
            // 
            // buttonSpostaGiu
            // 
            this.buttonSpostaGiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpostaGiu.Location = new System.Drawing.Point(1368, 773);
            this.buttonSpostaGiu.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSpostaGiu.Name = "buttonSpostaGiu";
            this.buttonSpostaGiu.Size = new System.Drawing.Size(35, 35);
            this.buttonSpostaGiu.TabIndex = 7;
            this.buttonSpostaGiu.Text = "↓";
            this.buttonSpostaGiu.UseVisualStyleBackColor = true;
            this.buttonSpostaGiu.Click += new System.EventHandler(this.buttonSpostaGiu_Click);
            // 
            // buttonSpostaSu
            // 
            this.buttonSpostaSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpostaSu.Location = new System.Drawing.Point(1333, 773);
            this.buttonSpostaSu.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSpostaSu.Name = "buttonSpostaSu";
            this.buttonSpostaSu.Size = new System.Drawing.Size(35, 35);
            this.buttonSpostaSu.TabIndex = 8;
            this.buttonSpostaSu.Text = "↑";
            this.buttonSpostaSu.UseVisualStyleBackColor = true;
            this.buttonSpostaSu.Click += new System.EventHandler(this.buttonSpostaSu_Click);
            // 
            // textBoxRicerca
            // 
            this.textBoxRicerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRicerca.Location = new System.Drawing.Point(139, 500);
            this.textBoxRicerca.Name = "textBoxRicerca";
            this.textBoxRicerca.Size = new System.Drawing.Size(343, 26);
            this.textBoxRicerca.TabIndex = 9;
            this.textBoxRicerca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRicerca_KeyPress);
            // 
            // comboBoxCampoRicerca
            // 
            this.comboBoxCampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCampoRicerca.FormattingEnabled = true;
            this.comboBoxCampoRicerca.Location = new System.Drawing.Point(12, 500);
            this.comboBoxCampoRicerca.Name = "comboBoxCampoRicerca";
            this.comboBoxCampoRicerca.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCampoRicerca.TabIndex = 10;
            // 
            // buttonCerca
            // 
            this.buttonCerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerca.Location = new System.Drawing.Point(489, 497);
            this.buttonCerca.Name = "buttonCerca";
            this.buttonCerca.Size = new System.Drawing.Size(94, 29);
            this.buttonCerca.TabIndex = 11;
            this.buttonCerca.Text = "CERCA";
            this.buttonCerca.UseVisualStyleBackColor = true;
            this.buttonCerca.Click += new System.EventHandler(this.buttonCerca_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(589, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "VEDI TUTTI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1423, 31);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(477, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parti del corpo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ambulatori";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(951, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esami";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonApriAdminDb
            // 
            this.buttonApriAdminDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApriAdminDb.Location = new System.Drawing.Point(12, 775);
            this.buttonApriAdminDb.Name = "buttonApriAdminDb";
            this.buttonApriAdminDb.Size = new System.Drawing.Size(242, 32);
            this.buttonApriAdminDb.TabIndex = 14;
            this.buttonApriAdminDb.Text = "APRI ADMIN DB";
            this.buttonApriAdminDb.UseVisualStyleBackColor = true;
            this.buttonApriAdminDb.Click += new System.EventHandler(this.buttonApriAdminDb_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 817);
            this.Controls.Add(this.buttonApriAdminDb);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCerca);
            this.Controls.Add(this.comboBoxCampoRicerca);
            this.Controls.Add(this.textBoxRicerca);
            this.Controls.Add(this.buttonSpostaSu);
            this.Controls.Add(this.buttonSpostaGiu);
            this.Controls.Add(this.buttonEliminaRiga);
            this.Controls.Add(this.buttonConfermaEsame);
            this.Controls.Add(this.dataGridViewEsamiSelezionati);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Gestione Esami";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsamiSelezionati)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxAmbulatori;
        private System.Windows.Forms.ListBox listBoxPartiCorpo;
        private System.Windows.Forms.ListBox listBoxEsami;
        private System.Windows.Forms.DataGridView dataGridViewEsamiSelezionati;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceMinisteriale;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescrizioneEsame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ambulatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParteCorpo;
        private System.Windows.Forms.Button buttonConfermaEsame;
        private System.Windows.Forms.Button buttonEliminaRiga;
        private System.Windows.Forms.Button buttonSpostaGiu;
        private System.Windows.Forms.Button buttonSpostaSu;
        private System.Windows.Forms.TextBox textBoxRicerca;
        private System.Windows.Forms.ComboBox comboBoxCampoRicerca;
        private System.Windows.Forms.Button buttonCerca;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonApriAdminDb;
    }
}

