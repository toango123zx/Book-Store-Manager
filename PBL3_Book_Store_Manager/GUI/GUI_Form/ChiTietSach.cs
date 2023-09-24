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
    public partial class ChiTietSach : Form
    {
        string MaNhanVien;
        string MaSach;
        public ChiTietSach(string masach, string MaNhanVien)
        {
            InitializeComponent();
            this.MaNhanVien = MaNhanVien;
            Show(masach);
            this.MaSach = masach;
        }
        public void Show(string MaHangHoa)
        {
            DTO.Sach hh = BLL_Sach.Instance.getListSach("MaHangHoa", MaHangHoa)[0];
            txtSach.Text = hh.TenHangHoa.ToString();
            //cbbTheLoaiHangHoa.Text = BLL_TheLoaiHangHoa.Instance.getTheLoaiHangHoa(hh.MaTheLoaiHangHoa).TenTheLoaiHangHoa.ToString();
            txtNamSX.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).NamSanXuat;
            txtNXS.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).NhaSanXuat;
            txtSoLuongTrenKhu.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).SoLuongTrenKhuTrungBay.ToString();
            txtKho.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).SoLuongTrongKho.ToString();
            cbbKhuTrungBay.Text = BLL_KhuTrungBay.Instance.getKhuTrungBay(hh.MaKhuTrungBay).TenKhuTrungBay.ToString();
            cbbNCU.Text = BLL_NCU.Instance.getNhaCungUng(hh.MaNhaCungUng).TenNhaCungUng.ToString();
            txtGiaNhap.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).GiaNhap.ToString();
            txtGiaBan.Text = BLL_HangHoa.Instance.GetHangHoa_ByMaHangHoa(MaHangHoa).GiaBan.ToString();
            txtTacGia.Text = hh.TacGia;
            txtLanTaiBan.Text = hh.LanTaiBan.ToString();

            cbbTheLoaiSach.DisplayMember = "TenTheLoaisach";
            cbbTheLoaiSach.DataSource = BLL_TheLoaiSach.Instance.getListTheLoaiSach(); ;
            BLL_KhuTrungBay.Instance.getListKhuTrungBay(cbbKhuTrungBay);
            BLL_NCU.Instance.getListNCU(cbbNCU);
        }
        public bool Check_Sach()
        {
            if (BLL_KhuTrungBay.Instance.getKhuTrungBay_Ten(cbbKhuTrungBay.Text.ToString().Trim()) == null)
            {
                MessageBox.Show("Không tồn tại khu trung bay này");
                return false;
            }
            if (BLL_NCU.Instance.SearchListNCUByTenNCU(cbbNCU.Text.ToString().Trim()) == null)
            {
                MessageBox.Show("Không tồn tại nhà cung ứng này");
                return false;
            }
            if (txtSach.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Tên sách không hợp lệ");
                return false;
            }
            if (txtNamSX.Text.ToString().Trim() == "" || txtNamSX.Text.ToString().Length < 4)
            {
                MessageBox.Show("Năm sản xuất không hợp lệ");
                return false;
            }
            if (txtSoLuongTrenKhu.Text.ToString().Trim() == "" || Convert.ToInt16(txtSoLuongTrenKhu.Text.Trim()) < 0)
            {
                MessageBox.Show("Số lượng trong khu trưng bày không hợp lệ");
                return false;
            }
            if (txtKho.Text.ToString().Trim() == "" || Convert.ToInt16(txtKho.Text.Trim()) < 0)
            {
                MessageBox.Show("Số lượng trong kho không hợp lệ");
                return false;
            }
            if (txtNXS.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Nhà sản xuất không hợp lệ");
                return false;
            }
            if (txtGiaBan.Text.ToString().Trim() == "" || Convert.ToDecimal(txtGiaBan.Text.ToString().Trim()) < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ");
                return false;
            }
            if (txtGiaNhap.Text.ToString().Trim() == "" || Convert.ToDecimal(txtGiaNhap.Text.ToString().Trim()) < 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ");
                return false;
            }
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
        public void Check_NhanVien()
        {
            //neu la admin va ban hang thi se an cot
        }
        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btThemTLS_Click(object sender, EventArgs e)
        {
            TaoTheLoaiSach tTLS = new TaoTheLoaiSach();
            tTLS.ShowDialog();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            /*if (Check_Sach() == false)
                return;
            Check_NhanVien();*/

            //Them hang hoa
            DTO.HangHoa hanghoa = new DTO.HangHoa();
            hanghoa.MaHangHoa = this.MaSach;
            hanghoa.TenHangHoa = txtSach.Text.ToString().Trim();
            hanghoa.NamSanXuat = txtNamSX.ToString().Trim();
            hanghoa.NhaSanXuat = txtNXS.Text.ToString().ToString().Trim();
            hanghoa.SoLuongTrenKhuTrungBay = Convert.ToInt16(txtSoLuongTrenKhu.Text.Trim());
            hanghoa.SoLuongTrongKho = Convert.ToInt16(txtKho.Text.Trim());
            hanghoa.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text.Trim());
            hanghoa.GiaBan = Convert.ToDecimal(txtGiaBan.Text.Trim());
            hanghoa.TrangThai = "Đang chờ xét duyệt thêm";

            DTO.DeXuat DeXuat = new DTO.DeXuat("", MaNhanVien, "Đang chờ phê duyệt", "Đề xuất thêm hàng hóa", DateTime.Now);

            hanghoa.MaKho = "K000";
            string MaTheLoaiSach = BLL_TheLoaiSach.Instance.getTheLoaiSach_byTen(cbbTheLoaiSach.Text.ToString().Trim()).MaTheLoaiSach;
            DTO.Sach Sach = new Sach(hanghoa, txtTacGia.Text.ToString().Trim(), Convert.ToByte(txtLanTaiBan.Text.ToString().Trim()), MaTheLoaiSach);
            MessageBox.Show("Bạn sẽ đề xuất thêm sách này vào cửa hàng");
            BLL_HangHoa.Instance.DeXuatThemHangHoa(DeXuat, hanghoa, "Sách", cbbKhuTrungBay.Text.ToString().Trim(), cbbNCU.Text.ToString().Trim());
            BLL_Sach.Instance.DeXuatTheSach(Sach);
            MessageBox.Show("Đề xuất của bạn đã được gửi tới quản lý");
            this.Dispose();

        }
    }
}