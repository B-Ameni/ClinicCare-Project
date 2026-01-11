namespace ClinicProject.MedecinForm
{
    partial class ListePatientsMedecin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPatients = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 85);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulter dossier médical";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Séléctionner un patient : ";
            // 
            // listBoxPatients
            // 
            this.listBoxPatients.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxPatients.FormattingEnabled = true;
            this.listBoxPatients.ItemHeight = 16;
            this.listBoxPatients.Location = new System.Drawing.Point(295, 103);
            this.listBoxPatients.Name = "listBoxPatients";
            this.listBoxPatients.Size = new System.Drawing.Size(302, 324);
            this.listBoxPatients.TabIndex = 7;
            this.listBoxPatients.SelectedIndexChanged += new System.EventHandler(this.listBoxPatients_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(651, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Consulter ->";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListePatientsMedecin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxPatients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "ListePatientsMedecin";
            this.Text = "ListePatients";
            this.Load += new System.EventHandler(this.ListePatientsMedecin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPatients;
        private System.Windows.Forms.Button button1;
    }
}