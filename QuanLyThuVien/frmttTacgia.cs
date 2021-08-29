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
    public partial class frmttTacgia : Form
    {
        private LibraryEntities db;
        public frmttTacgia()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void ttTacgia_Load(object sender, EventArgs e)
        {
            db.tblTacGias.Load();
            dataGridView1.DataSource = db.tblTacGias.Local.ToBindingList();
          /*  cls.LoadData2DataGridView(dataGridView1,"Select * from tblTacGia");*/
        }
    }
}
