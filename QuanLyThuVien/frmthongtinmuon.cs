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
    public partial class frmthongtinmuon : Form
    {
        private LibraryEntities db;
        public frmthongtinmuon()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        private void reloadDataGridView()
        {
            db.tblMuons.Load();
            dataGridView1.DataSource = db.tblMuons.Local.ToBindingList();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void muon_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblMuon");
           // cls.LoadData2Combobox(comboBox1,"Select MASACH from tblSach");
            
        }
        //create
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMADG, "");
            if(txtMADG.Text == "")
            {
                errorProvider1.SetError(txtMADG, "Chưa Nhập");
                return;
            }
            if (txtMASACH.Text == "")
            {
                errorProvider1.SetError(txtMASACH, "Chưa Nhập");
                return;
            }
            if (txtSOPHIEU.Text == "")
            {
                errorProvider1.SetError(txtSOPHIEU, "Chưa Nhập");
                return;
            }
            //try
            //{
            try
            {
                /* string strInsert = "Insert Into tblMuon(MADG,MASACH,SOPHIEUMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + txtMADG.Text + "','" + txtMASACH.Text + "','" + txtSOPHIEU.Text + "','" + mktNGAYMUON.Text + "','" + mktNGAYTRA.Text + "','" + cboXACNHAN.Text + "','" + rtbGHICHU.Text + "')";
                 cls.ThucThiSQLTheoPKN(strInsert);
                 cls.LoadData2DataGridView(dataGridView1, "select *from tblMuon");*/

                tblMuon newBorrow = new tblMuon()
                {
                    MADG = txtMADG.Text,
                    MASACH = txtMASACH.Text,
                    GHICHU = rtbGHICHU.Text,
                    NGAYMUON = DateTime.Parse(mktNGAYMUON.Text),
                    NGAYTRA = DateTime.Parse(mktNGAYTRA.Text),
                    SOPHIEUMUON = txtSOPHIEU.Text,
                    XACNHANTRA = cboXACNHAN.Text
                };
                db.SaveChanges();

                this.reloadDataGridView();

                MessageBox.Show("Thêm thành công");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
              
            //}
            //catch { MessageBox.Show("Trùng Mã"); };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    tblMuon getBorrow = db.tblMuons.SingleOrDefault(c => c.MADG == txtMADG.Text);

                    if (getBorrow == null)
                    {
                        MessageBox.Show("Mã độc giả không tồn tại");
                    }
                    else
                    {
                        /* string strDelete = "Delete from tblMuon where MADG='" + txtMADG.Text + "'";
              cls.ThucThiSQLTheoKetNoi(strDelete);
              cls.LoadData2DataGridView(dataGridView1, "select *from tblMuon");*/
                        db.tblMuons.Remove(getBorrow);
                        db.SaveChanges();
                        this.reloadDataGridView();
                        MessageBox.Show("Xóa thành công !!!");
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
                txtMADG.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSOPHIEU.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                mktNGAYMUON.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                mktNGAYTRA.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cboXACNHAN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                rtbGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { };
        }
        int dem = 0;
        string madg;
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
                    tblMuon getBorrow = db.tblMuons.SingleOrDefault(c => c.MADG == txtMADG.Text);

                    if (getBorrow == null)
                    {
                        MessageBox.Show("Mã độc giả không tồn tại");
                    }
                    else
                    {
                        /*          *string strUpdate = "Update tblMuon set MADG='" + txtMADG.Text + "',MASACH='" + txtMASACH.Text + "',SOPHIEUMUON='" + txtSOPHIEU.Text + "',NGAYMUON='" + mktNGAYMUON.Text + "',NGAYTRA='" + mktNGAYTRA.Text + "',XACNHANTRA='" + cboXACNHAN.Text + "',GHICHU='" + rtbGHICHU.Text + "' where MADG='" + madg + "'";
                                  cls.ThucThiSQLTheoPKN(strUpdate);
                                  cls.LoadData2DataGridView(dataGridView1, "select *from tblMuon");
                                  button1.Enabled = true; */

                        getBorrow.MADG = txtMADG.Text;
                        getBorrow.MASACH = txtMASACH.Text;
                        getBorrow.NGAYTRA = DateTime.Parse(mktNGAYTRA.Text);
                        getBorrow.SOPHIEUMUON = txtSOPHIEU.Text;
                        getBorrow.GHICHU = rtbGHICHU.Text;

                        db.SaveChanges();
                      
                        button1.Enabled = true;
                        button3.Enabled = true;
                        MessageBox.Show("Sửa thành công");
                        this.reloadDataGridView();
                        dem = 0;
                    }

                  
                    }
                    catch { MessageBox.Show("Không thể sửa !!!"); };
                }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cls.LoadData2Label(label9, "select count(*)from tblMuon where MASACH='" + comboBox1.Text + "'");
        //}
    }
}
