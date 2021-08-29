using QuanLyThuVien.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmcapnhatdocgia : Form
    {
        private LibraryEntities db;
        public frmcapnhatdocgia()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
    
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void capnhatdocgia_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1,"select *from tblDocGia");           
        }

        // create
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*                string strInsert = "Insert Into tblDocGia(MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU) " +
                                    "values ('" + txtMADG.Text + "','" + txtHOTEN.Text + "','"
                                    + maskedTextBox1.Text + "','" + cboGioiTinh.Text + "','" +
                                    txtLOP.Text + "','" + txtDIACHI.Text + "','" + txtemail.Text +
                                    "','" + rtbGHICHU.Text + "')";
                                cls.ThucThiSQLTheoPKN(strInsert);*/
                tblDocGia newDocGia = new tblDocGia()
                {
                    MADG = txtMADG.Text,
                    HOTEN = txtHOTEN.Text,
                    NGAYSINH = maskedTextBox1.Text,
                    GIOITINH = cboGioiTinh.Text,
                    LOP = txtLOP.Text,
                    DIACHI = txtDIACHI.Text,
                    EMAIL = txtemail.Text,
                    GHICHU = rtbGHICHU.Text,
                    
                };
                db.tblDocGias.Add(newDocGia);
                db.SaveChanges();
                this.reloadDataGridView();
               /* cls.LoadData2DataGridView(dataGridView1, "select *from tblDocGia");*/
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.GetBaseException().Message);
            };           
        }

        private void reloadDataGridView( )
        {
            db.tblDocGias.Load();
            dataGridView1.DataSource = db.tblDocGias.Local.ToBindingList();
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    /*    string strDelete = "Delete from tblDocGia where MADG='" + txtMADG.Text + "'";*/
                    tblDocGia getDocGia = db.tblDocGias.SingleOrDefault(c => c.MADG == txtMADG.Text);
                    if(getDocGia == null)
                    {
                        MessageBox.Show("Độc giả không tồn tại");
                    }
                    else
                    {
                        db.tblDocGias.Remove(getDocGia);
                       /* db.SaveChanges();*/
                        MessageBox.Show("Xóa thành công");
                        /*      db.tblDocGias.Load();
                              dataGridView1.DataSource = db.tblDocGias.Local.ToBindingList();*/
                        this.reloadDataGridView();
                    }
                  
                  
                }
                catch { MessageBox.Show("Phải xóa những thông tin liên quan đến nhà xuất bản này trước"); };
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMADG.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHOTEN.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtLOP.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDIACHI.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                rtbGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() ;
            }
            catch { };
        }
        int dem = 0;
        string madg;
        // update
        private void button2_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {
                madg = txtMADG.Text;
                dem = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    string strUpdate = "Update tblDocGia set MADG='" + txtMADG.Text + "',HOTEN='" + txtHOTEN.Text + "',NGAYSINH='" + maskedTextBox1.Text + "',GIOITINH='" + cboGioiTinh.Text + "',LOP='" + txtLOP.Text + "',DIACHI='" + txtDIACHI.Text + "',EMAIL='" + txtemail.Text + "',GHICHU='" + rtbGHICHU.Text + "' where MADG='" + madg + "'";
                    cls.ThucThiSQLTheoPKN(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select *from tblDocGia");
                    button1.Enabled = true;
                    button3.Enabled = true;
                    MessageBox.Show("Sửa thành công");
                    dem = 0;
                }
                catch { MessageBox.Show("Không thể sửa !!!"); };                
            }
        }     
    }
}
