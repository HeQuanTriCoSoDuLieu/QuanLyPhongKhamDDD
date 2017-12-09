namespace QuanLyPhongKham.Winform
{
    partial class fLichSuKhamBacSi
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
            this.dgvdsphieukham = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxtimkiem = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsphieukham)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvdsphieukham
            // 
            this.dgvdsphieukham.AllowUserToAddRows = false;
            this.dgvdsphieukham.AllowUserToDeleteRows = false;
            this.dgvdsphieukham.AllowUserToResizeColumns = false;
            this.dgvdsphieukham.AllowUserToResizeRows = false;
            this.dgvdsphieukham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvdsphieukham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdsphieukham.Location = new System.Drawing.Point(29, 87);
            this.dgvdsphieukham.Name = "dgvdsphieukham";
            this.dgvdsphieukham.ReadOnly = true;
            this.dgvdsphieukham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdsphieukham.Size = new System.Drawing.Size(531, 360);
            this.dgvdsphieukham.TabIndex = 3;
            this.dgvdsphieukham.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvdsphieukham_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh sách phiếu khám";
            // 
            // cbxtimkiem
            // 
            this.cbxtimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtimkiem.FormattingEnabled = true;
            this.cbxtimkiem.Items.AddRange(new object[] {
            "Mã bệnh nhân",
            "Họ tên bệnh nhân",
            "Mã phiếu khám",
            "Ngày khám (yyyy-mm-dd)"});
            this.cbxtimkiem.Location = new System.Drawing.Point(124, 25);
            this.cbxtimkiem.Name = "cbxtimkiem";
            this.cbxtimkiem.Size = new System.Drawing.Size(149, 21);
            this.cbxtimkiem.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Tìm kiếm theo";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(485, 24);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.TabIndex = 36;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(279, 25);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(190, 20);
            this.txttimkiem.TabIndex = 35;
            // 
            // fLichSuKhamBacSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 471);
            this.Controls.Add(this.cbxtimkiem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvdsphieukham);
            this.Name = "fLichSuKhamBacSi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLichSuKhamBacSi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsphieukham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvdsphieukham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxtimkiem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
    }
}