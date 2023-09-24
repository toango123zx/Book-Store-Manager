using PBL3_Book_Store_Manager.BLL;
using PBL3_Book_Store_Manager.DTO;
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
    public partial class ChiTietDeXuatHH_Ad : Form
    {
        string MaDeXuat { get; set; }
       
        public ChiTietDeXuatHH_Ad(string maDX)
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
            if (CheckPH())
            {
                txtPhanHoi.Text = BLL_DeXuat.Instance.GetListPhanHoiByMaDeXuat(MaDeXuat).NoiDung;
            }
           // txtPhanHoi.Text = BLL_DeXuat.Instance.GetListPhanHoiByMaDeXuat(MaDeXuat).NoiDung;
            txtTrangThai.Text = BLL_DeXuat.Instance.GetDeXuatByMaDeXuat(MaDeXuat).TinhTrang;

            txtTenHH.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).TenHangHoa;
            txtSoLuongKho.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).SoLuongTrongKho.ToString();
            txtSoLuongKhu.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).SoLuongTrenKhuTrungBay.ToString();
            txtNhaSX.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).NhaSanXuat;
            txtNamSX.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).NamSanXuat;
            txtGiaBan.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).GiaBan.ToString();
            txtGiaNhap.Text = BLL_HangHoa.Instance.GetHHByMaHH(BLL_DeXuat.Instance.GetChiTietDeXuatHHByMaDX(MaDeXuat).MaHangHoa).GiaNhap.ToString();
            //txtKhu.Text = THÊM KHU KHI MERGE HÀNG HÓA CỦA TOÀN VÀO

        }

        private void btQuayLai_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bt_QuayLai_ChiTietDeXuatHangHoa_NV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTuChoi_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Bạn có muốn xác nhận từ chối đề xuất không ?", "Xác nhận ", MessageBoxButtons.YesNo);
            if (results == DialogResult.Yes)
            {
                if (!CheckPH())
                {
                    if (txtPhanHoi.Text.Replace(" ", "").Trim() == "" )
                    {
                        MessageBox.Show("Vui lòng phản hồi lại cho đề xuất này");
                    } else
                    {
                        PhanHoi news = new PhanHoi()
                        {
                            MaDeXuat = MaDeXuat,
                            MaNhanVien = txtMaNhanVien.Text,
                            MaPhanHoi = "",
                            NoiDung = txtPhanHoi.Text,
                            ThoiGian = DateTime.Now
                        };
                        BLL_DeXuat.Instance.AddPhanHoi(news);
                        BLL_DeXuat.Instance.UpdateTrangThaiDX_BLL("Không chấp nhận", MaDeXuat);
                        MessageBox.Show("Xét duyệt đề xuất thành công");
                        this.Close();
                    }
                       
                        
                }
                else
                {
                    MessageBox.Show("Bạn đã cập nhật tình trạng cho đề xuất này");
                } 
                    
            }
        }

        private void btXetDuyet_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Bạn có muốn xác nhận xét duyệt đề xuất không ?", "Xác nhận ", MessageBoxButtons.YesNo);
            if (results == DialogResult.Yes)
            {
                if (!CheckPH())
                {
                    if (txtPhanHoi.Text.Replace(" ", "").Trim() == "")
                    {
                        MessageBox.Show("Vui lòng phản hồi lại cho đề xuất này");
                    }
                    else
                    {
                        PhanHoi news = new PhanHoi()
                        {
                            MaDeXuat = MaDeXuat,
                            MaNhanVien = txtMaNhanVien.Text,
                            MaPhanHoi = "",
                            NoiDung = txtPhanHoi.Text,
                            ThoiGian = DateTime.Now
                        };
                        BLL_DeXuat.Instance.AddPhanHoi(news);
                        BLL_DeXuat.Instance.UpdateTrangThaiDX_BLL("Chấp nhận", MaDeXuat);

                        //THAY ĐỔI TÌNH TRẠNG CỦA HÀNG HÓA SAU KHI MERGE HÀNG HÓA VÀO
                        MessageBox.Show("Xét duyệt đề xuất thành công");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã cập nhật tình trạng cho đề xuất này");
                } 
                    
            }
        }

       
    }
}
