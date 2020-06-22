namespace QuanLyCuaHangSach
{
    partial class FrmNN
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
            this.label1 = new System.Windows.Forms.Label();
            this.MA = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMNN = new System.Windows.Forms.ComboBox();
            this.txtTNN = new System.Windows.Forms.TextBox();
            this.dataGridViewNgonngu = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNgonngu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(209, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NGÔN NGỮ SÁCH";
            // 
            // MA
            // 
            this.MA.AutoSize = true;
            this.MA.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MA.Location = new System.Drawing.Point(99, 77);
            this.MA.Name = "MA";
            this.MA.Size = new System.Drawing.Size(70, 13);
            this.MA.TabIndex = 1;
            this.MA.Text = "Mã ngôn ngữ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên ngôn ngữ";
            // 
            // cboMNN
            // 
            this.cboMNN.FormattingEnabled = true;
            this.cboMNN.Location = new System.Drawing.Point(178, 77);
            this.cboMNN.Name = "cboMNN";
            this.cboMNN.Size = new System.Drawing.Size(287, 21);
            this.cboMNN.TabIndex = 3;
            // 
            // txtTNN
            // 
            this.txtTNN.Location = new System.Drawing.Point(178, 115);
            this.txtTNN.Name = "txtTNN";
            this.txtTNN.Size = new System.Drawing.Size(287, 20);
            this.txtTNN.TabIndex = 4;
            // 
            // dataGridViewNgonngu
            // 
            this.dataGridViewNgonngu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNgonngu.Location = new System.Drawing.Point(102, 185);
            this.dataGridViewNgonngu.Name = "dataGridViewNgonngu";
            this.dataGridViewNgonngu.Size = new System.Drawing.Size(363, 150);
            this.dataGridViewNgonngu.TabIndex = 5;
            this.dataGridViewNgonngu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNgonngu_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(510, 115);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(510, 214);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(510, 265);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 9;
            this.btnsearch.Text = "Tìm kiếm";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(510, 312);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(510, 162);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FrmNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewNgonngu);
            this.Controls.Add(this.txtTNN);
            this.Controls.Add(this.cboMNN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MA);
            this.Controls.Add(this.label1);
            this.Name = "FrmNN";
            this.Text = "Ngôn ngữ sách";
            this.Load += new System.EventHandler(this.FrmNN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNgonngu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMNN;
        private System.Windows.Forms.TextBox txtTNN;
        private System.Windows.Forms.DataGridView dataGridViewNgonngu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
    }
}