namespace Servidor.UI
{
    partial class VConsolaRemota
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
            this.rtResultado = new System.Windows.Forms.RichTextBox();
            this.tbComando = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtResultado
            // 
            this.rtResultado.BackColor = System.Drawing.Color.Black;
            this.rtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtResultado.ForeColor = System.Drawing.Color.Green;
            this.rtResultado.Location = new System.Drawing.Point(13, 13);
            this.rtResultado.Name = "rtResultado";
            this.rtResultado.ReadOnly = true;
            this.rtResultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtResultado.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtResultado.Size = new System.Drawing.Size(648, 394);
            this.rtResultado.TabIndex = 0;
            this.rtResultado.Text = "";
            // 
            // tbComando
            // 
            this.tbComando.Location = new System.Drawing.Point(13, 413);
            this.tbComando.Name = "tbComando";
            this.tbComando.Size = new System.Drawing.Size(552, 20);
            this.tbComando.TabIndex = 1;
            this.tbComando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbComando_KeyDown);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(571, 413);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(90, 23);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // VConsolaRemota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 450);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.tbComando);
            this.Controls.Add(this.rtResultado);
            this.Name = "VConsolaRemota";
            this.Text = "VConsolaRemota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbComando;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rtResultado;
    }
}