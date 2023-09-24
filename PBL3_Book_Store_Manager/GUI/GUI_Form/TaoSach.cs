using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Book_Store_Manager.BLL;
using PBL3_Book_Store_Manager.DTO;
using PBL3_Book_Store_Manager.GUI.GUI_Form;

namespace PBL3_Book_Store_Manager.GUI_Form
{
    public partial class TaoSach : Form
    {
        DTO.HangHoa HangHoa;
        string TenTheLoaiHangHoa;
        string TenKhuTrungBay;
        string TenNhaCungUng;
        public DTO.DeXuat DeXuat;
        public TaoSach(DTO.DeXuat DeXuat, DTO.HangHoa HangHoa, string TenTheLoaiHangHoa, string TenKhuTrungBay, string TenNhaCungUng)
        {
            InitializeComponent();
            show();
            this.HangHoa = HangHoa;
            this.TenTheLoaiHangHoa = TenTheLoaiHangHoa.ToString().Trim();
            this.TenKhuTrungBay = TenKhuTrungBay.ToString().Trim();
            this.TenNhaCungUng = TenNhaCungUng.ToString().Trim();
            this.DeXuat = DeXuat;
        }
        public void show()
        {
            cbbTheLoaiSach.DisplayMember = "TenTheLoaisach";
            cbbTheLoaiSach.DataSource = BLL_TheLoaiSach.Instance.getListTheLoaiSach();

        }
        public bool Check()
        {
            if (BLL_TheLoaiSach.Instance.getTheLoaiSach(cbbTheLoaiSach.Text.ToString().Trim()) == null)
            {
                MessageBox.Show("Không tồn tại tên thể loại sách này");
                return false;
            }
            if (txtTacGia.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Tên tác giả không hợp lệ");
                return false;
            }
            if (txtLanTaiBan.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Số lần tái bản này không hợp lệ");
                return false;
            }
            return true;
        }
        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btThemTLS_Click(object sender, EventArgs e)
        {
            TaoTheLoaiSach tTLS = new TaoTheLoaiSach();
            show();
            cbbTheLoaiSach.DisplayMember = "TenTheLoaisach";
            cbbTheLoaiSach.DataSource = BLL_TheLoaiSach.Instance.getListTheLoaiSach();
            tTLS.ShowDialog();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (Check() == false)
                return;

            txtSach.Text = HangHoa.TenHangHoa.ToString();
            txtGiaBan.Text = HangHoa.GiaBan.ToString();
            txtGiaNhap.Text = HangHoa.GiaNhap.ToString();

            string MaTheLoaiSach = BLL_TheLoaiSach.Instance.getTheLoaiSach_byTen(cbbTheLoaiSach.Text.ToString().Trim()).MaTheLoaiSach;
            DTO.Sach Sach = new Sach(HangHoa, txtTacGia.Text.ToString().Trim(), Convert.ToByte(txtLanTaiBan.Text.ToString().Trim()), MaTheLoaiSach);
            MessageBox.Show("Bạn sẽ đề xuất thêm sách này vào cửa hàng");
            BLL_HangHoa.Instance.DeXuatThemHangHoa(DeXuat, HangHoa, TenTheLoaiHangHoa, TenKhuTrungBay, TenNhaCungUng);
            BLL_Sach.Instance.DeXuatTheSach(Sach);
            MessageBox.Show("Đề xuất của bạn đã được gửi tới quản lý");
            this.Dispose();

        }
    }
}