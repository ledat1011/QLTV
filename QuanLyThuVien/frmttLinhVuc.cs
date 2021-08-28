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
    public partial class frmttLinhVuc : Form
    {
        private LibraryEntities db;
        public frmttLinhVuc()
        {

            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void ttLinhVuc_Load(object sender, EventArgs e)
        {
            /*   cls.LoadData2DataGridView(dataGridView1,"Select *from tblLinhVuc");*/
            db.tblLinhVucs.Load();
            dataGridView1.DataSource = db.tblLinhVucs.Local.ToBindingList();
        }
    }
}
