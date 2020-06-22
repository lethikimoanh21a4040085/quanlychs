using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FrmNN : Form
    {
        DataTable NgonNgu;
        public FrmNN()
        {
            InitializeComponent();
        }
        public void LoadDataToGridview()
        {
            DAO.OpenConnection();
            string sql = "SELECT * FROM NgonNgu";
            NgonNgu = DAO.GetDataToTable(sql);
            dataGridViewNgonngu.DataSource = NgonNgu;
            DAO.CloseConnetion();
        }
        public void fillDataToCombo()
        {
            string sql = "Select * from NgonNgu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cboMNN.DataSource = table;
            cboMNN.ValueMember = "MaNgonNgu";
            cboMNN.DisplayMember = "MaNgonNgu";
        }

        private void FrmNN_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            LoadDataToGridview();
            fillDataToCombo();
            DAO.CloseConnetion();
        }

        private void dataGridViewNgonngu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMNN.Text = dataGridViewNgonngu.CurrentRow.Cells["MaNgonNgu"].Value.ToString();
            txtTNN.Text = dataGridViewNgonngu.CurrentRow.Cells["TenNgonNgu"].Value.ToString();
        }
        private void ResetValues()
        {
            cboMNN.Text = "";
            txtTNN.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetValues();
            int count = 0;
            count = dataGridViewNgonngu.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dataGridViewNgonngu.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            if (chuoi2 + 1 < 100)
            {
                cboMNN.Text = "NN" + (chuoi2 + 1).ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMNN.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã ngôn ngữ!");
                cboMNN.Focus();
                return;
            }
            if (txtTNN.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên ngôn ngữ!");
                txtTNN.Focus();
                return;
            }
            string sql = "SELECT MaNgonNgu FROM NgonNgu WHERE MaNgonNgu = '" + cboMNN.Text + "'";
            DAO.OpenConnection();
            if (DAO.checkKeyExit(sql))
            {
                MessageBox.Show("Mã ngôn ngữ này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMNN.Focus();
                cboMNN.Text = "";
                return;
            }
            sql = "INSERT INTO NgonNgu (MaNgonNgu, TenNgonNgu) VALUES ('" + cboMNN.SelectedValue.ToString() + "', N'" + txtTNN.Text + "')";
            DAO.RunSql(sql);
            DAO.CloseConnetion();
            LoadDataToGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (NgonNgu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMNN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NgonNgu SET TenNgonNgu = N'" + txtTNN.Text.Trim() + "' WHERE MaNgonNgu = '" + cboMNN.Text + "'";
            DAO.RunSql(sql);
            DAO.CloseConnetion();
            LoadDataToGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (NgonNgu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMNN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM NgonNgu WHERE MaNgonNgu = '" + cboMNN.Text + "'";
                DAO.RunSql(sql);
                DAO.CloseConnetion();
                LoadDataToGridview();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTNN.Text == "")
            {
                MessageBox.Show("Bạn cần nhập điều kiện tìm kiếm", "Yêu cầu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select * from NgonNgu where 1=1";
            if (txtTNN.Text != "")
            {
                sql = sql + "and TenNgonNgu like N'%" + txtTNN.Text + "%'";
            }
            NgonNgu = DAO.GetDataToTable(sql);
            if (NgonNgu.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có " + NgonNgu.Rows.Count + " bản ghi thỏa mãn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataGridViewNgonngu.DataSource = NgonNgu;
        }
    }
}
