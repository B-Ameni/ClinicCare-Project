namespace ClinicProject.Auth
{
    partial class Authentification
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCreerCompte = new System.Windows.Forms.Button();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Saisir votre email : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 85);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(268, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "S\'authentifier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Saisir votre mot de passe : ";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(361, 145);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(301, 34);
            this.textBoxUsername.TabIndex = 10;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(361, 261);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(301, 34);
            this.textBoxPassword.TabIndex = 11;
            // 
            // buttonCreerCompte
            // 
            this.buttonCreerCompte.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonCreerCompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCreerCompte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCreerCompte.Location = new System.Drawing.Point(197, 400);
            this.buttonCreerCompte.Name = "buttonCreerCompte";
            this.buttonCreerCompte.Size = new System.Drawing.Size(388, 38);
            this.buttonCreerCompte.TabIndex = 13;
            this.buttonCreerCompte.Text = "Vous n\'avez pas de compte ? Créez un";
            this.buttonCreerCompte.UseVisualStyleBackColor = false;
            this.buttonCreerCompte.Click += new System.EventHandler(this.buttonCreerCompte_Click_1);
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnexion.Location = new System.Drawing.Point(277, 341);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(219, 53);
            this.buttonConnexion.TabIndex = 14;
            this.buttonConnexion.Text = "Se connecter";
            this.buttonConnexion.UseVisualStyleBackColor = false;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click_1);
            // 
            // Authentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonConnexion);
            this.Controls.Add(this.buttonCreerCompte);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Authentification";
            this.Text = "Authentification";
            this.Load += new System.EventHandler(this.Authentification_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCreerCompte;
        private System.Windows.Forms.Button buttonConnexion;
    }
}