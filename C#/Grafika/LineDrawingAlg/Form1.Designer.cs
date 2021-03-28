namespace Bresenham_Przyrostowa
{
    partial class Form_Lab_2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox_obiekt = new System.Windows.Forms.ListBox();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox_metoda = new System.Windows.Forms.ListBox();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(572, 424);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox_obiekt
            // 
            this.listBox_obiekt.FormattingEnabled = true;
            this.listBox_obiekt.ItemHeight = 15;
            this.listBox_obiekt.Items.AddRange(new object[] {
            "Linia",
            "Okrag"});
            this.listBox_obiekt.Location = new System.Drawing.Point(591, 374);
            this.listBox_obiekt.Name = "listBox_obiekt";
            this.listBox_obiekt.Size = new System.Drawing.Size(46, 34);
            this.listBox_obiekt.TabIndex = 1;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 99;
            // 
            // ColumnPoint
            // 
            this.ColumnPoint.HeaderText = "Point";
            this.ColumnPoint.Name = "ColumnPoint";
            this.ColumnPoint.ReadOnly = true;
            this.ColumnPoint.Width = 98;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnPoint});
            this.dataGridView1.Location = new System.Drawing.Point(591, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(215, 355);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // listBox_metoda
            // 
            this.listBox_metoda.FormattingEnabled = true;
            this.listBox_metoda.ItemHeight = 15;
            this.listBox_metoda.Items.AddRange(new object[] {
            "Bresenhama",
            "Przyrostowa"});
            this.listBox_metoda.Location = new System.Drawing.Point(643, 374);
            this.listBox_metoda.Name = "listBox_metoda";
            this.listBox_metoda.Size = new System.Drawing.Size(72, 34);
            this.listBox_metoda.TabIndex = 5;
            // 
            // btn_Draw
            // 
            this.btn_Draw.Location = new System.Drawing.Point(721, 374);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(85, 63);
            this.btn_Draw.TabIndex = 6;
            this.btn_Draw.Text = "Draw";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(591, 414);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(124, 23);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form_Lab_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 439);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_Draw);
            this.Controls.Add(this.listBox_metoda);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox_obiekt);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Lab_2";
            this.Text = "Rysowanie odcinków i okręgów różnymi metodami";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox_obiekt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox_metoda;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.Button btn_clear;
    }
}

