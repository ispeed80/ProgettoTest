namespace ProgettoTest
{
    partial class AdminDbForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewAmbulatori = new System.Windows.Forms.DataGridView();
            this.dataGridViewParti = new System.Windows.Forms.DataGridView();
            this.dataGridViewEsami = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddAmb = new System.Windows.Forms.Button();
            this.buttonDelAmb = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.buttonDelPart = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelEx = new System.Windows.Forms.Button();
            this.buttonAddEx = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmbulatori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsami)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewAmbulatori, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewParti, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewEsami, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1422, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(990, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Esami";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parti del corpo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewAmbulatori
            // 
            this.dataGridViewAmbulatori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAmbulatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAmbulatori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAmbulatori.Location = new System.Drawing.Point(3, 39);
            this.dataGridViewAmbulatori.Name = "dataGridViewAmbulatori";
            this.dataGridViewAmbulatori.ReadOnly = true;
            this.dataGridViewAmbulatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAmbulatori.Size = new System.Drawing.Size(207, 678);
            this.dataGridViewAmbulatori.TabIndex = 0;
            // 
            // dataGridViewParti
            // 
            this.dataGridViewParti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewParti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParti.Location = new System.Drawing.Point(216, 39);
            this.dataGridViewParti.Name = "dataGridViewParti";
            this.dataGridViewParti.ReadOnly = true;
            this.dataGridViewParti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewParti.Size = new System.Drawing.Size(207, 678);
            this.dataGridViewParti.TabIndex = 1;
            // 
            // dataGridViewEsami
            // 
            this.dataGridViewEsami.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEsami.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEsami.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEsami.Location = new System.Drawing.Point(429, 39);
            this.dataGridViewEsami.Name = "dataGridViewEsami";
            this.dataGridViewEsami.ReadOnly = true;
            this.dataGridViewEsami.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEsami.Size = new System.Drawing.Size(990, 678);
            this.dataGridViewEsami.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ambulatori";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonAddAmb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDelAmb, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 763);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(210, 42);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonAddAmb
            // 
            this.buttonAddAmb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddAmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddAmb.ForeColor = System.Drawing.Color.Lime;
            this.buttonAddAmb.Location = new System.Drawing.Point(108, 3);
            this.buttonAddAmb.Name = "buttonAddAmb";
            this.buttonAddAmb.Size = new System.Drawing.Size(99, 36);
            this.buttonAddAmb.TabIndex = 3;
            this.buttonAddAmb.Text = "+";
            this.buttonAddAmb.UseVisualStyleBackColor = true;
            this.buttonAddAmb.Click += new System.EventHandler(this.buttonAddAmb_Click);
            // 
            // buttonDelAmb
            // 
            this.buttonDelAmb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelAmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelAmb.ForeColor = System.Drawing.Color.Red;
            this.buttonDelAmb.Location = new System.Drawing.Point(3, 3);
            this.buttonDelAmb.Name = "buttonDelAmb";
            this.buttonDelAmb.Size = new System.Drawing.Size(99, 36);
            this.buttonDelAmb.TabIndex = 2;
            this.buttonDelAmb.Text = "-";
            this.buttonDelAmb.UseVisualStyleBackColor = true;
            this.buttonDelAmb.Click += new System.EventHandler(this.buttonDelAmb_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonAddPart, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonDelPart, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(229, 763);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(207, 42);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPart.ForeColor = System.Drawing.Color.Lime;
            this.buttonAddPart.Location = new System.Drawing.Point(106, 3);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(98, 36);
            this.buttonAddPart.TabIndex = 5;
            this.buttonAddPart.Text = "+";
            this.buttonAddPart.UseVisualStyleBackColor = true;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // buttonDelPart
            // 
            this.buttonDelPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelPart.ForeColor = System.Drawing.Color.Red;
            this.buttonDelPart.Location = new System.Drawing.Point(3, 3);
            this.buttonDelPart.Name = "buttonDelPart";
            this.buttonDelPart.Size = new System.Drawing.Size(97, 36);
            this.buttonDelPart.TabIndex = 4;
            this.buttonDelPart.Text = "-";
            this.buttonDelPart.UseVisualStyleBackColor = true;
            this.buttonDelPart.Click += new System.EventHandler(this.buttonDelPart_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonDelEx, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonAddEx, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(442, 763);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(990, 42);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // buttonDelEx
            // 
            this.buttonDelEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelEx.ForeColor = System.Drawing.Color.Red;
            this.buttonDelEx.Location = new System.Drawing.Point(3, 3);
            this.buttonDelEx.Name = "buttonDelEx";
            this.buttonDelEx.Size = new System.Drawing.Size(489, 36);
            this.buttonDelEx.TabIndex = 5;
            this.buttonDelEx.Text = "-";
            this.buttonDelEx.UseVisualStyleBackColor = true;
            this.buttonDelEx.Click += new System.EventHandler(this.buttonDelEx_Click);
            // 
            // buttonAddEx
            // 
            this.buttonAddEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddEx.ForeColor = System.Drawing.Color.Lime;
            this.buttonAddEx.Location = new System.Drawing.Point(498, 3);
            this.buttonAddEx.Name = "buttonAddEx";
            this.buttonAddEx.Size = new System.Drawing.Size(489, 36);
            this.buttonAddEx.TabIndex = 3;
            this.buttonAddEx.Text = "+";
            this.buttonAddEx.UseVisualStyleBackColor = true;
            this.buttonAddEx.Click += new System.EventHandler(this.buttonAddEx_Click);
            // 
            // AdminDbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 817);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdminDbForm";
            this.Text = "AdminDbForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDbForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminDbForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmbulatori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEsami)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewAmbulatori;
        private System.Windows.Forms.DataGridView dataGridViewParti;
        private System.Windows.Forms.DataGridView dataGridViewEsami;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonAddAmb;
        private System.Windows.Forms.Button buttonDelAmb;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.Button buttonDelPart;
        private System.Windows.Forms.Button buttonDelEx;
        private System.Windows.Forms.Button buttonAddEx;
    }
}