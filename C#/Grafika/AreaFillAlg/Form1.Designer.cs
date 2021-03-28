
namespace Wypelnianie_obszaru
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_r1 = new System.Windows.Forms.Button();
            this.btn_r2 = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_r1
            // 
            this.btn_r1.Location = new System.Drawing.Point(14, 14);
            this.btn_r1.Name = "btn_r1";
            this.btn_r1.Size = new System.Drawing.Size(75, 23);
            this.btn_r1.TabIndex = 1;
            this.btn_r1.Text = "K.Parz";
            this.btn_r1.UseVisualStyleBackColor = true;
            this.btn_r1.Click += new System.EventHandler(this.btn_r1_Click);
            // 
            // btn_r2
            // 
            this.btn_r2.Location = new System.Drawing.Point(14, 43);
            this.btn_r2.Name = "btn_r2";
            this.btn_r2.Size = new System.Drawing.Size(75, 23);
            this.btn_r2.TabIndex = 2;
            this.btn_r2.Text = "Rysuj 2";
            this.btn_r2.UseVisualStyleBackColor = true;
            this.btn_r2.Click += new System.EventHandler(this.btn_r2_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(14, 72);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Czyść";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_r1);
            this.panel2.Controls.Add(this.btn_clear);
            this.panel2.Controls.Add(this.btn_r2);
            this.panel2.Location = new System.Drawing.Point(814, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 106);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 353);
            this.panel1.TabIndex = 5;
            this.panel1.TabStop = false;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 378);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wypełnianie obszaru";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_r1;
        private System.Windows.Forms.Button btn_r2;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox panel1;
    }
}

