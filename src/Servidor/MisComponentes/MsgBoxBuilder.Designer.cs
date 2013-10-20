namespace Servidor.UI
{
    partial class MsgBoxBuilder
    {

        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

  
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBoxBuilder));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contTipoMsg = new System.Windows.Forms.GroupBox();
            this.rbError = new System.Windows.Forms.RadioButton();
            this.rbAlerta = new System.Windows.Forms.RadioButton();
            this.rbInformacion = new System.Windows.Forms.RadioButton();
            this.rbNinguno = new System.Windows.Forms.RadioButton();
            this.contBotones = new System.Windows.Forms.GroupBox();
            this.rbReintentarCancelar = new System.Windows.Forms.RadioButton();
            this.rbSiNoCancelar = new System.Windows.Forms.RadioButton();
            this.rbSiNo = new System.Windows.Forms.RadioButton();
            this.rbCancelarIntentarContinuar = new System.Windows.Forms.RadioButton();
            this.rbAnularReintentarIgnorar = new System.Windows.Forms.RadioButton();
            this.rbOkCancelar = new System.Windows.Forms.RadioButton();
            this.rbOK = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contTipoMsg.SuspendLayout();
            this.contBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titulo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(473, 20);
            this.textBox1.TabIndex = 1;
            // 
            // contTipoMsg
            // 
            this.contTipoMsg.Controls.Add(this.rbError);
            this.contTipoMsg.Controls.Add(this.rbAlerta);
            this.contTipoMsg.Controls.Add(this.rbInformacion);
            this.contTipoMsg.Controls.Add(this.rbNinguno);
            this.contTipoMsg.Location = new System.Drawing.Point(12, 117);
            this.contTipoMsg.Name = "contTipoMsg";
            this.contTipoMsg.Size = new System.Drawing.Size(172, 115);
            this.contTipoMsg.TabIndex = 2;
            this.contTipoMsg.TabStop = false;
            this.contTipoMsg.Text = "Tipo de Mensaje";
            // 
            // rbError
            // 
            this.rbError.AutoSize = true;
            this.rbError.Location = new System.Drawing.Point(7, 89);
            this.rbError.Name = "rbError";
            this.rbError.Size = new System.Drawing.Size(47, 17);
            this.rbError.TabIndex = 3;
            this.rbError.TabStop = true;
            this.rbError.Text = "Error";
            this.rbError.UseVisualStyleBackColor = true;
            // 
            // rbAlerta
            // 
            this.rbAlerta.AutoSize = true;
            this.rbAlerta.Location = new System.Drawing.Point(7, 66);
            this.rbAlerta.Name = "rbAlerta";
            this.rbAlerta.Size = new System.Drawing.Size(52, 17);
            this.rbAlerta.TabIndex = 2;
            this.rbAlerta.TabStop = true;
            this.rbAlerta.Text = "Alerta";
            this.rbAlerta.UseVisualStyleBackColor = true;
            // 
            // rbInformacion
            // 
            this.rbInformacion.AutoSize = true;
            this.rbInformacion.Location = new System.Drawing.Point(7, 43);
            this.rbInformacion.Name = "rbInformacion";
            this.rbInformacion.Size = new System.Drawing.Size(80, 17);
            this.rbInformacion.TabIndex = 1;
            this.rbInformacion.TabStop = true;
            this.rbInformacion.Text = "Informacion";
            this.rbInformacion.UseVisualStyleBackColor = true;
            // 
            // rbNinguno
            // 
            this.rbNinguno.AutoSize = true;
            this.rbNinguno.Checked = true;
            this.rbNinguno.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbNinguno.Location = new System.Drawing.Point(7, 20);
            this.rbNinguno.Name = "rbNinguno";
            this.rbNinguno.Size = new System.Drawing.Size(65, 17);
            this.rbNinguno.TabIndex = 0;
            this.rbNinguno.TabStop = true;
            this.rbNinguno.Text = "Ninguno";
            this.rbNinguno.UseVisualStyleBackColor = true;
            // 
            // contBotones
            // 
            this.contBotones.Controls.Add(this.rbReintentarCancelar);
            this.contBotones.Controls.Add(this.rbSiNoCancelar);
            this.contBotones.Controls.Add(this.rbSiNo);
            this.contBotones.Controls.Add(this.rbCancelarIntentarContinuar);
            this.contBotones.Controls.Add(this.rbAnularReintentarIgnorar);
            this.contBotones.Controls.Add(this.rbOkCancelar);
            this.contBotones.Controls.Add(this.rbOK);
            this.contBotones.Location = new System.Drawing.Point(190, 117);
            this.contBotones.Name = "contBotones";
            this.contBotones.Size = new System.Drawing.Size(350, 115);
            this.contBotones.TabIndex = 4;
            this.contBotones.TabStop = false;
            this.contBotones.Text = "Botones";
            // 
            // rbReintentarCancelar
            // 
            this.rbReintentarCancelar.AutoSize = true;
            this.rbReintentarCancelar.Location = new System.Drawing.Point(207, 66);
            this.rbReintentarCancelar.Name = "rbReintentarCancelar";
            this.rbReintentarCancelar.Size = new System.Drawing.Size(128, 17);
            this.rbReintentarCancelar.TabIndex = 6;
            this.rbReintentarCancelar.Text = "Reintentar  - Cancelar";
            this.rbReintentarCancelar.UseVisualStyleBackColor = true;
            // 
            // rbSiNoCancelar
            // 
            this.rbSiNoCancelar.AutoSize = true;
            this.rbSiNoCancelar.Location = new System.Drawing.Point(207, 43);
            this.rbSiNoCancelar.Name = "rbSiNoCancelar";
            this.rbSiNoCancelar.Size = new System.Drawing.Size(108, 17);
            this.rbSiNoCancelar.TabIndex = 5;
            this.rbSiNoCancelar.Text = "Si - No - Cancelar";
            this.rbSiNoCancelar.UseVisualStyleBackColor = true;
            // 
            // rbSiNo
            // 
            this.rbSiNo.AutoSize = true;
            this.rbSiNo.Location = new System.Drawing.Point(207, 19);
            this.rbSiNo.Name = "rbSiNo";
            this.rbSiNo.Size = new System.Drawing.Size(57, 17);
            this.rbSiNo.TabIndex = 4;
            this.rbSiNo.Text = "Si - No";
            this.rbSiNo.UseVisualStyleBackColor = true;
            // 
            // rbCancelarIntentarContinuar
            // 
            this.rbCancelarIntentarContinuar.AutoSize = true;
            this.rbCancelarIntentarContinuar.Location = new System.Drawing.Point(7, 89);
            this.rbCancelarIntentarContinuar.Name = "rbCancelarIntentarContinuar";
            this.rbCancelarIntentarContinuar.Size = new System.Drawing.Size(166, 17);
            this.rbCancelarIntentarContinuar.TabIndex = 3;
            this.rbCancelarIntentarContinuar.TabStop = true;
            this.rbCancelarIntentarContinuar.Text = "Cancelar - Intentar - Continuar";
            this.rbCancelarIntentarContinuar.UseVisualStyleBackColor = true;
            // 
            // rbAnularReintentarIgnorar
            // 
            this.rbAnularReintentarIgnorar.AutoSize = true;
            this.rbAnularReintentarIgnorar.Location = new System.Drawing.Point(7, 66);
            this.rbAnularReintentarIgnorar.Name = "rbAnularReintentarIgnorar";
            this.rbAnularReintentarIgnorar.Size = new System.Drawing.Size(155, 17);
            this.rbAnularReintentarIgnorar.TabIndex = 2;
            this.rbAnularReintentarIgnorar.TabStop = true;
            this.rbAnularReintentarIgnorar.Text = "Anular - Reintentar - Ignorar";
            this.rbAnularReintentarIgnorar.UseVisualStyleBackColor = true;
            // 
            // rbOkCancelar
            // 
            this.rbOkCancelar.AutoSize = true;
            this.rbOkCancelar.Location = new System.Drawing.Point(7, 43);
            this.rbOkCancelar.Name = "rbOkCancelar";
            this.rbOkCancelar.Size = new System.Drawing.Size(91, 17);
            this.rbOkCancelar.TabIndex = 1;
            this.rbOkCancelar.TabStop = true;
            this.rbOkCancelar.Text = "OK - Cancelar";
            this.rbOkCancelar.UseVisualStyleBackColor = true;
            // 
            // rbOK
            // 
            this.rbOK.AutoSize = true;
            this.rbOK.Checked = true;
            this.rbOK.Location = new System.Drawing.Point(7, 20);
            this.rbOK.Name = "rbOK";
            this.rbOK.Size = new System.Drawing.Size(40, 17);
            this.rbOK.TabIndex = 0;
            this.rbOK.TabStop = true;
            this.rbOK.Text = "OK";
            this.rbOK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mensaje";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(67, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(473, 61);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(528, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MsgBoxBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contBotones);
            this.Controls.Add(this.contTipoMsg);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsgBoxBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Constructor de MsgBox";
            this.contTipoMsg.ResumeLayout(false);
            this.contTipoMsg.PerformLayout();
            this.contBotones.ResumeLayout(false);
            this.contBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox contTipoMsg;
        private System.Windows.Forms.RadioButton rbError;
        private System.Windows.Forms.RadioButton rbAlerta;
        private System.Windows.Forms.RadioButton rbInformacion;
        private System.Windows.Forms.RadioButton rbNinguno;
        private System.Windows.Forms.GroupBox contBotones;
        private System.Windows.Forms.RadioButton rbSiNo;
        private System.Windows.Forms.RadioButton rbCancelarIntentarContinuar;
        private System.Windows.Forms.RadioButton rbAnularReintentarIgnorar;
        private System.Windows.Forms.RadioButton rbOkCancelar;
        private System.Windows.Forms.RadioButton rbOK;
        private System.Windows.Forms.RadioButton rbReintentarCancelar;
        private System.Windows.Forms.RadioButton rbSiNoCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}