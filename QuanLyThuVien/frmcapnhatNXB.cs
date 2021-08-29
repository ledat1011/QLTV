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
    public partial class frmcapnhatNXB : Form
    {
        private LibraryEntities db;
        public frmcapnhatNXB()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase(); 
        private void capnhatNXB_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");           
        }       

        private void reloadDataGridView()
        {
            db.tblNXBs.Load();
            dataGridView1.DataSource = db.tblNXBs.Local.ToBindingList();
        }

        //create
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /* string strInsert = "Insert Into tblNXB(MANXB,TENNXB,DIACHI,SODIENTHOAI,GHICHU) values ('" + txtMANXB.Text + "','" + txtTENNXB.Text + "','" + txtDIACHI.Text + "','" + txtSODIENTHOAI.Text + "','" + rtbGHICHU.Text + "')";
                 cls.ThucThiSQLTheoPKN(strInsert);
                 cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");*/

                tblNXB createNXB = new tblNXB()
                {
                    MANXB = txtMANXB.Text,
                    TENNXB = txtTENNXB.Text,
                    DIACHI = txtDIACHI.Text,
                    GHICHU = rtbGHICHU.Text,
                    SODIENTHOAI = txtSODIENTHOAI.Text
                };
                db.tblNXBs.Add(createNXB);
                db.SaveChanges();
                this.reloadDataGridView();
                MessageBox.Show("Thêm thành công");
            }
            catch(Exception ex) { MessageBox.Show("Trùng Mã" + ex.Message); };           
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    /* string strDelete = "Delete from tblNXB where MANXB='" + txtMANXB.Text + "'";
                     cls.ThucThiSQLTheoKetNoi(strDelete);
                     cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");*/
                    tblNXB getNXB = db.tblNXBs.SingleOrDefault(c => c.MANXB == txtMANXB.Text);
                    if(getNXB == null)
                    {
                        MessageBox.Show("mã nhà xuất bản không tồn tại");
                    }
                    else
                    {
                        db.tblNXBs.Remove(getNXB);
                        this.reloadDataGridView();
                        MessageBox.Show("Xóa thành công");
                    }
                  

                }
                catch (Exception ex ) { MessageBox.Show("Phải xóa những thông tin liên quan đến nhà xuất bản này trước " +ex.Message); };
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMANXB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTENNXB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDIACHI.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSODIENTHOAI.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                rtbGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { };
        }

        int dem = 0;
        string manxb;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {
                manxb = txtMANXB.Text;
                dem = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                   
                    tblNXB getNXB = db.tblNXBs.SingleOrDefault(c => c.MANXB == txtMANXB.Text);
                    if (getNXB == null)
                    {
                        MessageBox.Show("mã nhà xuất bản không tồn tại");
                    }
                    else
                    {
                        /* string strUpdata = "Update tblNXB set MANXB='" + txtMANXB.Text + "',TENNXB='" + txtTENNXB.Text + "',DIACHI='" + txtDIACHI.Text + "',SODIENTHOAI='" + txtSODIENTHOAI.Text + "',GHICHU='" + rtbGHICHU.Text + "' where MANXB='" + manxb + "'";
                    cls.ThucThiSQLTheoPKN(strUpdata);
                    cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");*/
                        /*  db.tblNXBs.Remove(getNXB);*/
                        getNXB.DIACHI = txtDIACHI.Text;
                        getNXB.GHICHU = rtbGHICHU.Text;
                        getNXB.MANXB = txtMANXB.Text;
                        getNXB.SODIENTHOAI = txtSODIENTHOAI.Text;

                        db.SaveChanges();
                         
                        this.reloadDataGridView();

                        button1.Enabled = true;
                        button3.Enabled = true;
                        dem = 0;
                        MessageBox.Show("Sửa thành công");

                    }
                  
                }
                catch { MessageBox.Show("Trùng mã"); };
            }
        }

        private void txtSODIENTHOAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
