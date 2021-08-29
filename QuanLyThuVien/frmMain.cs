using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThuVien.model;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        private LibraryEntities db;
        public frmMain()
        {
            db = new LibraryEntities();
            InitializeComponent();
        }
        public static string TenDN, MatKhau, Quyen;
        SqlCommand sqlCommand;
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TenDN = txtTenDangNhap.Text;
            MatKhau = txtMatKhau.Text;
            if (TenDN != "")
            {
                object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN +
                    "' and MatKhau='" + MatKhau + "'");
                if (Q == null)
                {
                    MessageBox.Show("Sai tài khoản");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Quyen = Convert.ToString(Q);
                    if (Quyen == "user")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = false;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    if (Quyen == "admin")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        KiêmTratoolStripMenuItem1.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = true;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    grbDangNhap.Visible = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        string A, B, C, D, E, F,G;
        SqlConnection Con;
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                /*Con = new SqlConnection();
                Con.ConnectionString = @"Data Source=DESKTOP-ONTGILH\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
                Con.Open();*/
                db.Database.Exists();
            }
            catch { MessageBox.Show("Không thể kết nối"); }
                A = label1.Text;
                B = label5.Text;
                C = label6.Text;
              /*  D = label7.Text;*/
                E = label8.Text;
              /*  F = label9.Text;
                G = label10.Text;*/
               /* label10.Text = "";
                label9.Text = "";*/
                label8.Text = "";
               /* label7.Text = "";*/
                label6.Text = "";
                label5.Text = "";
                label1.Text = "";
                timer1.Start();
        }

        private void cậpNhậtSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcapnhatsach cnsach = new frmcapnhatsach();
            cnsach.Show();
        }

        private void cậpNhậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmcapnhatdocgia cndocgia = new frmcapnhatdocgia();
            cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cậpNhậtNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcapnhatnhanvien cnnhanvien = new frmcapnhatnhanvien();
            cnnhanvien.Show();
        }

        private void cậpNhậtTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcapnhatTG cnTG = new frmcapnhatTG();
            cnTG.Show();
        }

        private void cậpNhậtNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcapnhatNXB cnNXB = new frmcapnhatNXB();
            cnNXB.Show();
        }

        private void cậpNhậtLĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcapnhatLv cnLV = new frmcapnhatLv();
            cnLV.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau doimatkhau = new frmDoiMatKhau();
            doimatkhau.Show();
        }

        private void cậpNhậtThôngTinMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmthongtinmuon T = new frmthongtinmuon();
            T.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan TAO = new frmTaoTaiKhoan();
            TAO.Show();
        }

        private void tìnhTrạngSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCTinhTrangSach BCTTS = new frmBCTinhTrangSach();
            BCTTS.Show();
        }

        private void sốĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCDocGia BCDG = new frmBCDocGia();
            BCDG.Show();
        }
        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmttTacgia ttTG = new frmttTacgia();
            ttTG.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmttNXB ttnxb = new frmttNXB();
            ttnxb.Show();
        }

        private void lĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmttLinhVuc ttlv = new frmttLinhVuc();
            ttlv.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmttSach ttsach = new frmttSach();
            ttsach.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmttDocgia ttDG = new frmttDocgia();
            ttDG.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = A.Length;
            d++;
            string a = A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            label1.Text = label1.Text + a;
            if (d == x)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = B.Length;
            d++;
            string a = B.Substring(0, 1);
            B = B.Substring(1, B.Length - 1);
            label5.Text = label5.Text + a;
            if (d == x)
            {
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = C.Length;
            d++;
            string a = C.Substring(0, 1);
            C = C.Substring(1, C.Length - 1);
            label6.Text = label6.Text + a;
            if (d == x)
            {
                timer3.Stop();
                timer4.Start();
                timer5.Start();
                timer6.Start();
                timer7.Start();
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TenDN = txtTenDangNhap.Text;
            MatKhau = txtMatKhau.Text;
            if (TenDN != "")
            {
                /*object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN + "' and MatKhau='" + MatKhau + "'");*/
                tblNhanVien userLogin = db.tblNhanViens.FirstOrDefault(c => c.TaiKhoan == TenDN && c.MatKhau == MatKhau);
                if (userLogin ==null)
                {
                    MessageBox.Show("Sai tài khoản");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công","Account");
                    
                    if (userLogin.QUYENHAN == "user")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = false;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    if (userLogin.QUYENHAN == "admin")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        KiêmTratoolStripMenuItem1.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = true;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    grbDangNhap.Visible = false;
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan TAO = new frmTaoTaiKhoan();
            TAO.Show();
        }

        private void grbDangNhap_Enter(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
/*
            int d = 0, x;
            x = D.Length;
            d++;
            string a = D.Substring(0, 1);
            D = D.Substring(1, D.Length - 1);
            label7.Text = label7.Text + a;
            if (d == x)
            {
                timer4.Stop();
            }*/
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = E.Length;
            d++;
            string a = E.Substring(0, 1);
            E = E.Substring(1, E.Length - 1);
            label8.Text = label8.Text + a;
            if (d == x)
            {
                timer5.Stop();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
/*
            int d = 0, x;
            x = F.Length;
            d++;
            string a = F.Substring(0, 1);
            F = F.Substring(1, F.Length - 1);
            label9.Text = label9.Text + a;
            if (d == x)
            {
                timer6.Stop();
            }*/
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
          /*  int d = 0, x;
            x = G.Length;
            d++;
            string a = G.Substring(0, 1);
            G = G.Substring(1, G.Length - 1);
            label10.Text = label10.Text + a;
            if (d == x)
            {
                timer7.Stop();
            }*/
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbDangNhap.Visible = true;
            quảnLyToolStripMenuItem.Enabled = false;
            tìmKiếmToolStripMenuItem.Enabled = false;
            tìmKiếmSáchToolStripMenuItem.Enabled = false;
            KiêmTratoolStripMenuItem1.Enabled = false;
            tìmKiếmĐGToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem.Enabled = false;
            mượnSáchToolStripMenuItem.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;
            cậpNhậtSáchToolStripMenuItem.Enabled = false;
            cậpNhậtTácGiảToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem1.Enabled = false;
            cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = false;
            cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = false;
            cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = false;
            tácGiảToolStripMenuItem.Enabled = false;
            nhàXuấtBảnToolStripMenuItem.Enabled = false;
            lĩnhVựcToolStripMenuItem.Enabled = false;
            độcGiảToolStripMenuItem.Enabled = false;
            sáchToolStripMenuItem.Enabled = false;
            tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            cậpNhậtNhânViênToolStripMenuItem.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtimkiem Sach = new frmtimkiem();
            Sach.Show();
        }

        private void tìmKiếmĐGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemDG Dg = new frmTimkiemDG();
            Dg.Show();
        }

        private void KiêmTratoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKiemTraTTNhanVien K = new frmKiemTraTTNhanVien();
            K.Show();
        }

    }
}
