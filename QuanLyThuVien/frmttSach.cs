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
    public partial class frmttSach : Form
    {
        private LibraryEntities db;


        public frmttSach()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien.Class.clsDatabase();
        private void ttSach_Load(object sender, EventArgs e)
        {
            /* cls.LoadData2DataGridView(dataGridView1,"Select *from tblSach");*/
            db.tblSaches.Load();
            dataGridView1.DataSource = db.tblSaches.Local.ToBindingList();
        }
    }
}
