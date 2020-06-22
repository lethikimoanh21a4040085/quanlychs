using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FrmKhoSach : Form
    {
        DataTable KhoSach;
        public FrmKhoSach()
        {
            InitializeComponent();
        }
        public void LoadDataToGridview()
        {
            DAO.OpenConnection();
            string sql = "SELECT * FROM KhoSach";
            KhoSach = DAO.GetDataToTable(sql);
            dataGridViewKhosach.DataSource = KhoSach;
            DAO.CloseConnetion();
        }
        private void FrmKhoSach_Load(object sender, EventArgs e)
        {
            LoadDataToGridview();
            DAO.FillDataToCombo("SELECT MaSach, TenSach FROM KhoSach", cboMS, "MaSach", "MaSach");
            cboMS.SelectedIndex = -1;
        }

        private void dataGridViewKhosach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMS.Text = dataGridViewKhosach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTS.Text = dataGridViewKhosach.CurrentRow.Cells["TenSach"].Value.ToString();
            txtSL.Text = dataGridViewKhosach.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDGN.Text = dataGridViewKhosach.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDGB.Text = dataGridViewKhosach.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            cboMLS.Text = dataGridViewKhosach.CurrentRow.Cells["MaLoaiSach"].Value.ToString();
            cboMTG.Text = dataGridViewKhosach.CurrentRow.Cells["MaTG"].Value.ToString();
            cboMNXB.Text = dataGridViewKhosach.CurrentRow.Cells["MaNXB"].Value.ToString();
            cboMLV.Text = dataGridViewKhosach.CurrentRow.Cells["MaLinhVuc"].Value.ToString();
            cboMNN.Text = dataGridViewKhosach.CurrentRow.Cells["MaNgonNgu"].Value.ToString();
            txtAnh.Text = dataGridViewKhosach.CurrentRow.Cells["Anh"].Value.ToString();
            txtSoTrang.Text = dataGridViewKhosach.CurrentRow.Cells["SoTrang"].Value.ToString();
        }
        private void ResetValues()
        {
            cboMS.Text = "";
            txtTS.Text = "";
            txtSL.Text = "";
            txtDGN.Text = "";
            txtDGB.Text = "";
            cboMLS.Text = "";
            cboMTG.Text = "";
            cboMNXB.Text = "";
            cboMLV.Text = "";
            txtAnh.Text = "";
            txtSoTrang.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            int count = 0;
            count = dataGridViewKhosach.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dataGridViewKhosach.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            if (chuoi2 + 1 < 100)
            {
                cboMS.Text = "MS0" + (chuoi2 + 1).ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (cboMS.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã sách!");
                cboMS.Focus();
                return;
            }
            if (txtTS.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên sách!");
                txtTS.Focus();
                return;
            }
            if (txtSL.Text == "")
            {
                MessageBox.Show("Bạn cần nhập số lượng!");
                txtSL.Focus();
                return;
            }
            if (txtDGN.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đơn giá nhập!");
                txtDGN.Focus();
                return;
            }
            if (txtDGB.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đơn giá bán!");
                txtDGB.Focus();
                return;
            }
            if (cboMLS.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã loại sách!");
                cboMLS.Focus();
                return;
            }
            if (cboMTG.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã tác giả!");
                cboMTG.Focus();
                return;
            }
            if (cboMNXB.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã NXB!");
                cboMNXB.Focus();
                return;
            }
            if (cboMLV.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã lĩnh vực!");
                cboMLV.Focus();
                return;
            }
            if (cboMNN.Text == "")
            {
                MessageBox.Show("Bạn cần chọn mã ngôn ngữ!");
                cboMNN.Focus();
                return;
            }
            if (txtAnh.Text == "")
            {
                MessageBox.Show("Bạn cần nhập ảnh!");
                txtAnh.Focus();
                return;
            }
            if (txtSoTrang.Text == "")
            {
                MessageBox.Show("Bạn cần nhập số trang!");
                txtSoTrang.Focus();
                return;
            }
            sql = "SELECT MaSach FROM KhoSach WHERE MaSach = '" + cboMS.Text + "'";
            if (DAO.checkKeyExit(sql))
            {
                MessageBox.Show("Mã sách này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMS.Focus();
                cboMS.Text = "";
                return;
            }
            sql = "INSERT INTO KhoSach VALUES ('" + cboMS.Text + "', N'" + txtTS.Text + "', '" + txtSL.Text +
                "', '" + txtDGN.Text + "', '" + txtDGB + "', '" + cboMLS.Text + "', '" + cboMTG + "', '" + cboMNXB + "', '" + cboMLV + "' ,'" + txtAnh.Text + "', '" + txtSoTrang.Text + "')";
            DAO.RunSql(sql);
            DAO.CloseConnetion();
            LoadDataToGridview();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (KhoSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMS.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE KhoSach SET TenSach = N'" + txtTS.Text + "', SoLuong = '" + txtSL.Text +
                "', DonGiaNhap = '" + txtDGN.Text + "', DonGiaBan = '" + txtDGB + "', MaLoaiSach = '" + cboMLS.Text +
                "', MaTG = '" + cboMTG + "', MaNXB = '" + cboMNXB + "', MaLinhVuc = '" + cboMLV + "' , Anh = '" + txtAnh.Text + "', SoTrang = '" + txtSoTrang.Text + "' WHERE MaSach = '" + cboMS + "'";
            DAO.RunSql(sql);
            DAO.CloseConnetion();
            LoadDataToGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (KhoSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMS.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM KhoSach WHERE MaSach = '" + cboMS.Text + "'";
                DAO.RunSql(sql);
                DAO.CloseConnetion();
                LoadDataToGridview();
            }
        }
    }
}
