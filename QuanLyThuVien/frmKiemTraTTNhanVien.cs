using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    public partial class frmKiemTraTTNhanVien : Form
    {
        public frmKiemTraTTNhanVien()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void KiemTraTTNhanVien_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select*from tblNhanVien");
        }
		
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtQuyenHan.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTenNhanVien.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtChucVu.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        string TenTK;
        int Dem = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Dem == 0)
            {
                TenTK = txtTenTaiKhoan.Text;
                button2.Enabled = false;
                Dem = 1;
                txtMatKhau.Text = txtQuyenHan.Text = txtTenNhanVien.Text = txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtChucVu.Text = txtTuoi.Text = "";
            }
            else
            {
                button2.Enabled = true;
                if (txtTenNhanVien.Text.Length - 1 == 0)
                    MessageBox.Show("Không được để trống tên nhân viên");
                else
                    if (txtMatKhau.Text.Length - 1 == 0 || txtQuyenHan.Text.Length - 1 == 0)
                        MessageBox.Show("Không được để trống mật khẩu");
                    else
                        if (txtQuyenHan.Text.Length - 1 == 0)
                            MessageBox.Show("Không được để trống quyền hạn");
                        else
                            if (txtDiaChi.Text.Length - 1 == 0)
                                MessageBox.Show("Không được để trống địa chỉ");
                            else
                                if (txtChucVu.Text.Length - 1 == 0)
                                    MessageBox.Show("Không được để trống chức vụ");
                                else
                                    if (txtTuoi.Text.Length - 1 == 0)
                                        MessageBox.Show("Không được để trống tuổi");
                                    else
                                        if (txtDienThoai.Text.Length - 1 <= 0 || txtDienThoai.Text.Length - 1 > 12)
                                            MessageBox.Show("Số điện thoại phải dài hơn 12 số và nhỏ hơn 0 số");
                                            else
                                            {
                                                string SQL = ("update tblNhanVien set MatKhau='" + txtMatKhau.Text + "',QUYENHAN='" + txtQuyenHan.Text + "',TENNV='" + txtTenNhanVien.Text + "',DiaChi='" + txtDiaChi.Text + "',DIENTHOAI='" + txtDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + txtChucVu.Text + "',Tuoi='" + txtTuoi.Text + "'where TaiKhoan='" + TenTK + "'");
                                                cls.ThucThiSQLTheoKetNoi(SQL);
                                                cls.LoadData2DataGridView(dataGridView1, "select*from tblNhanVien");
                                                MessageBox.Show("Đã Sửa thành công");
                                            }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = txtTenNhanVien.Text;
            if (txtQuyenHan.Text == "admin")
                MessageBox.Show("Không thể xóa tài khoản admin");
            else
                if (MessageBox.Show("Bạn có chắc chắn xóa thông tin nhân viên "+s,"Thông Báo Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string SQL = ("delete from tblNhanVien where TaiKhoan='" + txtTenTaiKhoan.Text + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    cls.LoadData2DataGridView(dataGridView1, "select*from tblNhanVien");
                    MessageBox.Show("Xóa thành công");
                }
                   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
