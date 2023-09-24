using PBL3_Book_Store_Manager.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Book_Store_Manager.GUI.GUI_Form
{
    public partial class ChiTietDeXuatHangHoa_NV : Form
    {
        string MaDeXuat { get; set; }
        public ChiTietDeXuatHangHoa_NV(string maDX)
        {
            InitializeComponent();
            MaDeXuat = maDX;
            setGUI();
        }
        public bool CheckPH()
        {
            if (BLL_DeXuat.Instance.GetListPhanHoiByMaDeXuat(MaDeXuat) != null)  //co
            {
                txtPhanHoi.Enabled = false;
                return true;
            }
            else                          //chua co phan hoi
            {
                txtPhanHoi.Enabled = true;
                return false;
            }
        }
        public void setGUI()
        {
            txtMaNhanVien.Text = BLL_DeXuat.Instance.GetDeXuatByMaDeXuat(MaDeXuat).MaNhanVien;
            txtTenNV.Text = BLL_DeXuat.Instance.GetDeXuatViewByMaDeXuat(MaDeXuat).MaNhanVien;
            txtThoiGian.Text = BLL_DeXuat.Instance.GetDeXuatViewByMaDeXuat(MaDeXuat).ThoiGian.ToString();
            txtLoaiDX.Text = BLL_DeXuat.Instance.GetDeXuatViewByMaDeXuat(MaDeXuat).LoaiDeXuat.ToString();
            //if (CheckPH())
            //{
            //    txtPhanHoi.Text = BLL_DeXuat.Instance.GetListPhanHoiByMaDeXuat(MaDeXuat).NoiDung;
            //}
            txtPhanHoi.Text = BLL_DeXuat.Instance.GetListPhanHoiByMaDeXuat(MaDeXuat).NoiDung;
            txtTrangThai.Text = BLL_DeXuat.Instance.GetDeXuatByMaDeXuat(MaDeXuat).TinhTrang;

            txtTenHH.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).TenHangHoa;
            txtSoLuongKho.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).SoLuongTrongKho.ToString();
            txtSoLuongKhu.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).SoLuongTrenKhuTrungBay.ToString();
            txtNhaSX.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).NhaSanXuat;
            txtNamSX.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).NamSanXuat;
            txtGiaBan.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).GiaBan.ToString();
            txtGiaNhap.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).GiaNhap.ToString();
            //txtKhu.Text = 

        }

        private void bt_QuayLai_ChiTietDeXuatHangHoa_NV_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
