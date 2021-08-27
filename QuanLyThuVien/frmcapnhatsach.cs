using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmcapnhatsach : Form
    {
        LibraryEntities db = new LibraryEntities();
        public frmcapnhatsach()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void capnhatsach_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblSach");
            cls.LoadData2Combobox(cboMATG, "select MATG from tblTacGia");
            cls.LoadData2Combobox(cboMANXB, "select MANXB from tblNXB");
            cls.LoadData2Combobox(cboMALv, "select MaLv from tblLinhVuc");
            cls.LoadData2Combobox(cbotenLV, "select TenLv from tblLinhVuc");
            cls.LoadData2Combobox(cbotenTG,"Select TENTG from tblTacGia");
            cls.LoadData2Combobox(cbotenNXB,"Select TENNXB from tblNXB");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                /*  string strInsert = "Insert Into tblSach(MASACH,TENSACH,MATG,MANXB,MALv,NAMXB,
                 *  SOTRANG,SOLUONG,NGAYNHAP,GHICHU,SOSACHHONG) 
                 *  values ('" + txtMASACH.Text + "','" + txtTENSACH.Text + "','" + cboMATG.Text + "','" + cboMANXB.Text + "',
                 *  '" + cboMALv.Text + "','" + txtNAMXB.Text + "','" + txtSOTRANG.Text + "',
                 *  '" + txtSOLUONG.Text + "','" + maskedTextBox1.Text + "',
                 *  '" + richTextBox1.Text + "','" + txtsachhong.Text + "')";
                  cls.ThucThiSQLTheoPKN(strInsert);*/
                tblSach insertSach = new tblSach()
                {
                    MASACH = txtMASACH.Text,
                    TENSACH = txtTENSACH.Text,
                    MATG = cboMATG.Text,
                    NAMXB = txtNAMXB.Text,
                    SOTRANG = Int32.Parse(txtSOTRANG.Text),
                    MaLv = cboMALv.Text,
                    NGAYNHAP = maskedTextBox1.Text,
                    GHICHU = richTextBox1.Text,
                    MANXB = cbotenNXB.Text,
                    SOLUONG = Int32.Parse(txtSOLUONG.Text),
                    SOSACHHONG = Int32.Parse(txtsachhong.Text)

                };
                db.tblSaches.Add(insertSach);
                db.SaveChanges();
                
                cls.LoadData2DataGridView(dataGridView1, "select *from tblSach");
            }
            catch { MessageBox.Show("Trùng mã"); };
        }

        int dem = 0;
        string masach;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {
                masach = txtMASACH.Text;
                dem = 1;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                try
                {
                    /* string strUpdate = "Update tblSach set MASACH='" + txtMASACH.Text + "',TENSACH='" + txtTENSACH.Text + "',MATG='" + cboMATG.Text + "',MANXB='" + cboMANXB.Text + "',MaLv='" + cboMALv.Text + "',NAMXB='" + txtNAMXB.Text + "',SOTRANG='" + txtSOTRANG.Text + "',SOLUONG='" + txtSOLUONG.Text + "',NGAYNHAP='" + maskedTextBox1.Text + "',GHICHU='" + richTextBox1.Text + "',SOSACHHONG='" + txtsachhong.Text + "' where MASACH='" + masach + "'";
                     cls.ThucThiSQLTheoPKN(strUpdate);*/

                    tblSach getDetailBook = db.tblSaches.SingleOrDefault(c => c.MASACH == txtMASACH.Text);

                    // if book not exsit
                    if(getDetailBook == null)
                    {
                        MessageBox.Show("Mã sách không tồn tại");
                    }
                    else
                    {
                        tblSach insertSach = new tblSach()
                        {
                            TENSACH = txtTENSACH.Text,
                            MATG = cboMATG.Text,
                            NAMXB = txtNAMXB.Text,
                            SOTRANG = Int32.Parse(txtSOTRANG.Text),
                            MaLv = cboMALv.Text,
                            NGAYNHAP = maskedTextBox1.Text,
                            GHICHU = richTextBox1.Text,
                            MANXB = cbotenNXB.Text,
                            SOLUONG = Int32.Parse(txtSOLUONG.Text),
                            SOSACHHONG = Int32.Parse(txtsachhong.Text)

                        };

                        getDetailBook.TENSACH = txtTENSACH.Text;
                        getDetailBook.MATG = cboMATG.Text;
                        getDetailBook.NAMXB = txtNAMXB.Text;
                        getDetailBook.SOTRANG = Int32.Parse(txtSOTRANG.Text);
                        getDetailBook.MaLv = cboMALv.Text;
                        getDetailBook.NGAYNHAP = maskedTextBox1.Text;
                        getDetailBook.GHICHU = richTextBox1.Text;
                        getDetailBook.MANXB = cboMANXB.Text;
                        getDetailBook.SOLUONG = Int32.Parse(txtSOLUONG.Text);
                        getDetailBook.SOSACHHONG = Int32.Parse(txtsachhong.Text);


                        db.SaveChanges();
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblSach");
                        button1.Enabled = true;
                        button3.Enabled = true;
                        dem = 0;
                        MessageBox.Show("Sửa thành công");
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTENSACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboMATG.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboMANXB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboMALv.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNAMXB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSOTRANG.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSOLUONG.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtsachhong.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            catch { };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /* string strDelete = "Delete from tblSach where MASACH='" + txtMASACH.Text + "'";
                 cls.ThucThiSQLTheoKetNoi(strDelete);*/

                tblSach bookNeedToDelete = db.tblSaches.SingleOrDefault(c => c.MASACH == txtMASACH.Text);
                if (bookNeedToDelete == null)
                {
                    MessageBox.Show("Sách không tồn tại");
                }
                else
                {
                    db.tblSaches.Remove(bookNeedToDelete);
                           cls.LoadData2DataGridView(dataGridView1, "select *from tblSach");
                    MessageBox.Show("Xóa thành công !!!");
                }
              
             
            }
        }

        private void txtsachhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbotenLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMALv.SelectedIndex = cbotenLV.SelectedIndex;
        }

        private void cboMALv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenLV.SelectedIndex = cboMALv.SelectedIndex;
        }

        private void cbotenTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMATG.SelectedIndex = cbotenTG.SelectedIndex;
        }

        private void cboMATG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenTG.SelectedIndex = cboMATG.SelectedIndex;
        }

        private void cbotenNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMANXB.SelectedIndex = cbotenNXB.SelectedIndex;
        }

        private void cboMANXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenNXB.SelectedIndex = cboMANXB.SelectedIndex;
        }

    }
}
