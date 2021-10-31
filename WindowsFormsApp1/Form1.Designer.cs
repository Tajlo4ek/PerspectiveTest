
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbRotX = new System.Windows.Forms.TrackBar();
            this.tbRotY = new System.Windows.Forms.TrackBar();
            this.tbRotZ = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotZ)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(708, 426);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tbRotX
            // 
            this.tbRotX.Location = new System.Drawing.Point(726, 12);
            this.tbRotX.Maximum = 180;
            this.tbRotX.Minimum = -180;
            this.tbRotX.Name = "tbRotX";
            this.tbRotX.Size = new System.Drawing.Size(195, 45);
            this.tbRotX.TabIndex = 1;
            this.tbRotX.ValueChanged += new System.EventHandler(this.tbRot_ValueChanged);
            // 
            // tbRotY
            // 
            this.tbRotY.Location = new System.Drawing.Point(726, 63);
            this.tbRotY.Maximum = 180;
            this.tbRotY.Minimum = -180;
            this.tbRotY.Name = "tbRotY";
            this.tbRotY.Size = new System.Drawing.Size(195, 45);
            this.tbRotY.TabIndex = 2;
            this.tbRotY.ValueChanged += new System.EventHandler(this.tbRot_ValueChanged);
            // 
            // tbRotZ
            // 
            this.tbRotZ.Location = new System.Drawing.Point(726, 114);
            this.tbRotZ.Maximum = 180;
            this.tbRotZ.Minimum = -180;
            this.tbRotZ.Name = "tbRotZ";
            this.tbRotZ.Size = new System.Drawing.Size(195, 45);
            this.tbRotZ.TabIndex = 3;
            this.tbRotZ.ValueChanged += new System.EventHandler(this.tbRot_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.tbRotZ);
            this.Controls.Add(this.tbRotY);
            this.Controls.Add(this.tbRotX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar tbRotX;
        private System.Windows.Forms.TrackBar tbRotY;
        private System.Windows.Forms.TrackBar tbRotZ;
    }
}

