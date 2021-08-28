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
    public partial class frmttDocgia : Form
    {
        private LibraryEntities db;

       
        public frmttDocgia()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }

        Class.clsDatabase cls =new Class.clsDatabase();
        private void ttDocgia_Load(object sender, EventArgs e)
        {
            /*  cls.LoadData2DataGridView(dataGridView1,"Select * from tblDocGia");*/
            db.tblDocGias.Load();
            dataGridView1.DataSource = db.tblDocGias.Local.ToBindingList();

        }
    }
}
