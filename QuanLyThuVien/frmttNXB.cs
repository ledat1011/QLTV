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
    public partial class frmttNXB : Form
    {
        private LibraryEntities db;
        public frmttNXB()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void ttNXB_Load(object sender, EventArgs e)
        {
            /* cls.LoadData2DataGridView(dataGridView1,"Select *from tblNXB");*/
            db.tblNXBs.Load();
            dataGridView1.DataSource = db.tblNXBs.Local.ToBindingList();
        }
    }
}
