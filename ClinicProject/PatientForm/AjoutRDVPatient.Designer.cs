namespace ClinicProject.PatientForm
{
    partial class AjoutRDVPatientt
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
            this.dtpDateHeure = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedecinNom = new System.Windows.Forms.TextBox();
            this.labelprenom = new System.Windows.Forms.Label();
            this.labelnom = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDateHeure
            // 
            this.dtpDateHeure.CalendarMonthBackground = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtpDateHeure.CustomFormat = "\"dd/MM/yyyy HH:mm\"";
            this.dtpDateHeure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateHeure.Location = new System.Drawing.Point(299, 200);
            this.dtpDateHeure.MaxDate = new System.DateTime(2029, 12, 25, 23, 59, 59, 0);
            this.dtpDateHeure.MinDate = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            this.dtpDateHeure.Name = "dtpDateHeure";
            this.dtpDateHeure.ShowUpDown = true;
            this.dtpDateHeure.Size = new System.Drawing.Size(208, 22);
            this.dtpDateHeure.TabIndex = 43;
            this.dtpDateHeure.Value = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(42, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 65);
            this.button1.TabIndex = 37;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(569, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 65);
            this.button2.TabIndex = 42;
            this.button2.Text = "Confirmer";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 114);
            this.panel1.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(211, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 54);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ajouter un RDV";
            // 
            // txtMedecinNom
            // 
            this.txtMedecinNom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMedecinNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtMedecinNom.Location = new System.Drawing.Point(299, 254);
            this.txtMedecinNom.Name = "txtMedecinNom";
            this.txtMedecinNom.Size = new System.Drawing.Size(208, 36);
            this.txtMedecinNom.TabIndex = 40;
            // 
            // labelprenom
            // 
            this.labelprenom.AutoSize = true;
            this.labelprenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelprenom.Location = new System.Drawing.Point(59, 252);
            this.labelprenom.Name = "labelprenom";
            this.labelprenom.Size = new System.Drawing.Size(152, 36);
            this.labelprenom.TabIndex = 39;
            this.labelprenom.Text = "Medecin : ";
            // 
            // labelnom
            // 
            this.labelnom.AutoSize = true;
            this.labelnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelnom.Location = new System.Drawing.Point(59, 200);
            this.labelnom.Name = "labelnom";
            this.labelnom.Size = new System.Drawing.Size(180, 36);
            this.labelnom.TabIndex = 38;
            this.labelnom.Text = "DateHeure : ";
            // 
            // AjoutRDVPatientt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpDateHeure);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMedecinNom);
            this.Controls.Add(this.labelprenom);
            this.Controls.Add(this.labelnom);
            this.Name = "AjoutRDVPatientt";
            this.Text = "AjoutRDVPatient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateHeure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMedecinNom;
        private System.Windows.Forms.Label labelprenom;
        private System.Windows.Forms.Label labelnom;
    }
}