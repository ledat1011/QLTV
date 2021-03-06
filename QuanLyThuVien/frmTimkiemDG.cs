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
    public partial class frmTimkiemDG : Form
    {
        public frmTimkiemDG()
        {
            InitializeComponent();
        }
        Class.clsDatabase Cls = new QuanLyThuVien.Class.clsDatabase();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
            if(comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Chưa Chọn!");
                return;
            }
            errorProvider1.SetError(textBox1, "");
            if(textBox1.Text=="")
            {
                errorProvider1.SetError(textBox1, "Chưa nhập" +" "+ comboBox1.Text+"!");
                return; 
            }
            else
            {
                Cls.LoadData2DataGridView(dataGridView1, "select*from tblDocGia where " + comboBox1.Text + " like'%" + textBox1.Text + "%'");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dataGridView2, "select*from tblDocGia where MADG like'%" + textBox2.Text + "%'or HOTEN like'%" + textBox3.Text + "%'or NGAYSINH='" + maskedTextBox1.Text + "'or GIOITINH='" + textBox4.Text + "'or LOP like'%" + textBox5.Text + "%'or DIACHI like'%"+textBox6.Text+"%'");
        }

        private void TimkiemDG_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimkiemDG_Load(object sender, EventArgs e)
        {
            //Cls.KetNoi();
        }
    }
}
