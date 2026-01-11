namespace ClinicProject.PatientForm
{
    partial class MessageriePatient
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
            this.listBoxMessages = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEnvoyer = new System.Windows.Forms.Button();
            this.lblConversation = new System.Windows.Forms.Label();
            this.listBoxContacts = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMessages.Location = new System.Drawing.Point(663, 166);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.ReadOnly = true;
            this.listBoxMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.listBoxMessages.Size = new System.Drawing.Size(307, 324);
            this.listBoxMessages.TabIndex = 27;
            this.listBoxMessages.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(730, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 26;
            this.label2.Text = "Historique :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 114);
            this.panel1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(404, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 54);
            this.label3.TabIndex = 3;
            this.label3.Text = "Messagerie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ecrire votre message : ";
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMessage.Location = new System.Drawing.Point(12, 172);
            this.txtMessage.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(300, 169);
            this.txtMessage.TabIndex = 23;
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEnvoyer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnvoyer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnvoyer.Location = new System.Drawing.Point(82, 357);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(123, 53);
            this.btnEnvoyer.TabIndex = 22;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = false;
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // lblConversation
            // 
            this.lblConversation.AutoSize = true;
            this.lblConversation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConversation.Location = new System.Drawing.Point(392, 127);
            this.lblConversation.Name = "lblConversation";
            this.lblConversation.Size = new System.Drawing.Size(150, 28);
            this.lblConversation.TabIndex = 21;
            this.lblConversation.Text = "A destination : ";
            // 
            // listBoxContacts
            // 
            this.listBoxContacts.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxContacts.FormattingEnabled = true;
            this.listBoxContacts.ItemHeight = 16;
            this.listBoxContacts.Location = new System.Drawing.Point(333, 166);
            this.listBoxContacts.Name = "listBoxContacts";
            this.listBoxContacts.Size = new System.Drawing.Size(278, 324);
            this.listBoxContacts.TabIndex = 20;
            this.listBoxContacts.SelectedIndexChanged += new System.EventHandler(this.listBoxContacts_SelectedIndexChanged);
            // 
            // MessageriePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 538);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnEnvoyer);
            this.Controls.Add(this.lblConversation);
            this.Controls.Add(this.listBoxContacts);
            this.Name = "MessageriePatient";
            this.Text = "MessageriePatient";
            this.Load += new System.EventHandler(this.MessageriePatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox listBoxMessages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.Label lblConversation;
        private System.Windows.Forms.ListBox listBoxContacts;
    }
}