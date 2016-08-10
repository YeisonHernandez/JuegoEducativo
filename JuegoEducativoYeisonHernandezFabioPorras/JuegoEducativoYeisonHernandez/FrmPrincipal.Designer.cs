namespace JuegoEducativoYeisonHernandez
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.imgBxCam = new Emgu.CV.UI.ImageBox();
            this.btnActiv = new System.Windows.Forms.Button();
            this.picBoxReflejo = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBxCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReflejo)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBxCam
            // 
            this.imgBxCam.Location = new System.Drawing.Point(14, 28);
            this.imgBxCam.Name = "imgBxCam";
            this.imgBxCam.Size = new System.Drawing.Size(503, 471);
            this.imgBxCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBxCam.TabIndex = 2;
            this.imgBxCam.TabStop = false;
            // 
            // btnActiv
            // 
            this.btnActiv.Location = new System.Drawing.Point(1073, 28);
            this.btnActiv.Name = "btnActiv";
            this.btnActiv.Size = new System.Drawing.Size(119, 471);
            this.btnActiv.TabIndex = 4;
            this.btnActiv.Text = "Activar";
            this.btnActiv.UseVisualStyleBackColor = true;
            this.btnActiv.Click += new System.EventHandler(this.btnActiv_Click);
            // 
            // picBoxReflejo
            // 
            this.picBoxReflejo.Location = new System.Drawing.Point(523, 28);
            this.picBoxReflejo.Name = "picBoxReflejo";
            this.picBoxReflejo.Size = new System.Drawing.Size(544, 471);
            this.picBoxReflejo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxReflejo.TabIndex = 2;
            this.picBoxReflejo.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 522);
            this.Controls.Add(this.picBoxReflejo);
            this.Controls.Add(this.btnActiv);
            this.Controls.Add(this.imgBxCam);
            this.Name = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBxCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReflejo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBxCam;
        private System.Windows.Forms.Button btnActiv;
        private Emgu.CV.UI.ImageBox picBoxReflejo;
    }
}