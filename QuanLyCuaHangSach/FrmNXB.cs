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
    public partial class FrmNXB : Form
    {
        public object NhaXuatBan { get; private set; }

        public FrmNXB()
        {
            InitializeComponent();
        }

        private void FrmNXB_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            LoadDataToGrivew();

            DAO.CloseConnetion();
        }
        private void LoadDataToGrivew()
        {

            try
            {
                DAO.OpenConnection();
                string sql = "select * from NhaXuatBan";
                SqlDataAdapter myAdapter = new SqlDataAdapter(sql, DAO.conn);
                DataTable NhaXuatBan = new DataTable();
                myAdapter.Fill(NhaXuatBan);
                dataGridViewNXB.DataSource = NhaXuatBan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnetion();
            }

        }


        private void dataGridViewNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMNXB.Text = dataGridViewNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
            txtNXB.Text = dataGridViewNXB.CurrentRow.Cells["TenNXB"].Value.ToString();
            txtdiachi.Text = dataGridViewNXB.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dataGridViewNXB.CurrentRow.Cells["DienThoai"].Value.ToString();
            txtMNXB.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            txtNXB.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txtMNXB.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txtMNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà sản xuất");
                return;
            }
            if (txtNXB.Text == "")
            {
                MessageBox.Show("Bạn không được để trống nhà xuất bản");
                txtNXB.Focus();
                return;
            }


            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn không được để trống địa chỉ");
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số điện thoại");
                txtsdt.Focus();
                return;
            }


            // - Mã nhà xuất bản ko được trùng
            string sql = "select * from NhaXuatBan where MaNXB = '" +
            txtMNXB.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.checkKeyExit(sql))
            {
                MessageBox.Show("mã nhà xuất bản đã tồn tại");
                txtMNXB.Focus();
                DAO.CloseConnetion();
                return;
            }
            else
            {
                sql = "insert into  NhaXuatBan (MaNXB, TenNXB, DiaChi, DienThoai)values ('" + txtMNXB.Text.Trim() + "',N'" + txtNXB.Text + "',N'" + txtdiachi.Text.Trim() + "'," + txtsdt.Text.Trim() + ")";

                DAO.RunSql(sql);


                LoadDataToGrivew();

                DAO.CloseConnetion();

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;

            if (txtMNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà xuất bản", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtMNXB.Focus();
                return;
            }
            if (txtNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà xuất bản", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNXB.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return;
            }
            sql = "UPDATE NhaXuatBan SET  MaNXB=N'" + txtMNXB.Text.Trim().ToString() +
                    "',TenNXB=N'" + txtNXB.Text.Trim().ToString() +
                    "',DiaChi='" + txtdiachi.Text +
                    "',DienThoai=N'" + txtsdt.Text + "' WHERE MaNXB=N'" + txtMNXB.Text + "'";
            DAO.RunSql(sql);
            LoadDataToGrivew();
            ResetValues();
            DAO.CloseConnetion();
            



        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ResetValues()
        {
            txtMNXB.Text = "";
            txtNXB.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (txtNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            sql = "UPDATE NhaXuatBan SET TenNXB = N'" + txtNXB.Text.Trim() + "' WHERE MaNXB = '" + txtMNXB.Text + "'";
            DAO.RunSql(sql);
            DAO.CloseConnetion();
            LoadDataToGrivew();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMNXB.Text == "") && (txtNXB.Text == "") && (txtdiachi.Text == "") && (txtsdt.Text == "")) ;
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

        }

       
    }
}
