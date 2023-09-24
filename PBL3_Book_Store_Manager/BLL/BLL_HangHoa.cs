using PBL3_Book_Store_Manager.DAL;
using PBL3_Book_Store_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_HangHoa
    {
        private static BLL_HangHoa _Instance;

        public static BLL_HangHoa Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_HangHoa();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_HangHoa()
        {

        }

        public List<HangHoa> GetListHH_BLL()
        {
            List<HangHoa> data = new List<HangHoa>();
            data = DAL_HH.Instance.getListHH("select * from HANGHOA");
            return data;
        }
        public List<HangHoa> GetListHHByMaHH(string maHH)
        {
            List<HangHoa> data = GetListHH_BLL();
            List<HangHoa> result = new List<HangHoa>();
            foreach (HangHoa h in data)
            {
                if(h.MaHangHoa.Contains(maHH))
                {
                    result.Add(h);
                }
            }
            return result;
        }
        public List<HangHoa> GetListHHByTenHH(string TenHH)
        {
            List<HangHoa> data = GetListHH_BLL();
            List<HangHoa> result = new List<HangHoa>();
            foreach (HangHoa h in data)
            {
                if (h.TenHangHoa.Contains(TenHH) )
                {
                    result.Add(h);
                }
            }
            return result;
        }
        public List<HangHoa> GetListHHByTenHHvaTrangThai(string TenHH,string trangThai)
        {
            List<HangHoa> data = GetListHH_BLL();
            List<HangHoa> result = new List<HangHoa>();
            foreach (HangHoa h in data)
            {
                if (h.TenHangHoa.Contains(TenHH) && (h.TrangThai == trangThai))
                {
                    result.Add(h);
                }
            }
            return result;
        }

        public HangHoa GetHHByMaHH(string maHH)
        {
            HangHoa s = new HangHoa();
            foreach(HangHoa i in GetListHH_BLL())
            {
                if(i.MaHangHoa == maHH)
                {
                    s = i;
                    return s;
                }

            }
            return null;
        }
        public List<HangHoa> GetListHangHoaByMaHD(string maHD)
        {
            List<HangHoa> list = new List<HangHoa>();
            foreach(ChiTietHD i in BLL_HDBH.Instance.GetListChiTietHD_BLL())
            {
                if(i.MaHoaDon == maHD)
                {
                    HangHoa hh = new HangHoa();
                    hh.MaHangHoa = i.MaHangHoa;
                    hh.TenHangHoa = GetHHByMaHH(i.MaHangHoa).TenHangHoa;
                    hh.MaTheLoaiHangHoa = GetHHByMaHH(hh.MaHangHoa).MaTheLoaiHangHoa;
                    hh.NhaSanXuat = GetHHByMaHH(hh.MaHangHoa).NhaSanXuat;
                    hh.MaNhaCungUng = GetHHByMaHH(hh.MaHangHoa).MaNhaCungUng;
                    hh.NamSanXuat = GetHHByMaHH(hh.MaHangHoa).NamSanXuat;
                    hh.MaKhuTrungBay = GetHHByMaHH(hh.MaHangHoa).MaKhuTrungBay;
                    hh.SoLuongTrenKhuTrungBay = GetHHByMaHH(hh.MaHangHoa).SoLuongTrenKhuTrungBay;
                    hh.MaKho = GetHHByMaHH(hh.MaHangHoa).MaKho;
                    hh.SoLuongTrongKho = GetHHByMaHH(hh.MaHangHoa).SoLuongTrongKho;
                    hh.GiaNhap = GetHHByMaHH(hh.MaHangHoa).GiaNhap;
                    hh.GiaBan = GetHHByMaHH(hh.MaHangHoa).GiaBan;
                    hh.TrangThai = GetHHByMaHH(hh.MaHangHoa).TrangThai;
                    list.Add(hh);
                }
            }
            return list;
        }
        public List<TTHangHoa> GetListTTHHByMaHD(string maHD)
        {
            List<TTHangHoa> list = new List<TTHangHoa>();
            foreach (ChiTietHD i in BLL_HDBH.Instance.GetListChiTietHD_BLL())
            {
                if (i.MaHoaDon == maHD)
                {
                    TTHangHoa hh = new TTHangHoa();
                    hh.MaHangHoa = i.MaHangHoa;
                    hh.TenHangHoa = GetHHByMaHH(i.MaHangHoa).TenHangHoa;
                    hh.SoLuong = Convert.ToInt16(i.SoLuong);
                    hh.GiaBan = GetHHByMaHH(hh.MaHangHoa).GiaBan;
                    hh.GiaNhap = GetHHByMaHH(hh.MaHangHoa).GiaNhap;
                    hh.Discount = 0;  //luu y
                    hh.ThanhTien = hh.ThanhTien = Convert.ToDecimal(hh.SoLuong * hh.GiaBan - hh.GiaBan * (hh.Discount / 100));
                    list.Add(hh);
                }
            }
            return list;
        }

        public TTHangHoa GetTTHHByMaHH(string maHH)
        {
            
            foreach (HangHoa i in GetListHH_BLL())
            {
                if (i.MaHangHoa == maHH)
                {
                    TTHangHoa hh = new TTHangHoa();
                    hh.MaHangHoa = i.MaHangHoa;
                    hh.TenHangHoa = GetHHByMaHH(i.MaHangHoa).TenHangHoa;
                    hh.SoLuong = 0;
                    hh.GiaBan = GetHHByMaHH(hh.MaHangHoa).GiaBan;
                    hh.GiaNhap = GetHHByMaHH(hh.MaHangHoa).GiaNhap;
                    hh.Discount = 0;  //luu y
                    hh.ThanhTien = hh.ThanhTien = Convert.ToDecimal(hh.SoLuong * hh.GiaBan - hh.GiaBan * (hh.Discount / 100));
                    return hh;
                }
            }
           return null;
        }

        public List<Sach> GetListSach_BLL()
        {
            List<Sach> data = new List<Sach>();
            data = DAL_HH.Instance.GetListSach();
            return data;
        }

        public List<Sach> GetListSachByTenSach(string tenSach)
        {
            List<Sach> result = new List<Sach>();
            foreach(Sach s in GetListSach_BLL())
            {
                if(s.TenHangHoa.Contains(tenSach))
                {
                    result.Add(s);
                }    

            }
            return result;
        }

        public List<Sach> GetListSachByTenSachVaTrangThai(string tenSach,string TrangThai)
        {
            List<Sach> result = new List<Sach>();
            foreach (Sach s in GetListSach_BLL())
            {
                if (s.TenHangHoa.Contains(tenSach) && (s.TrangThai == TrangThai))
                {
                    result.Add(s);
                }

            }
            return result;
        }
        public void UpdateSoLuongHH(HangHoa h)
        {
            DAL_HH.Instance.UpdateSoLuongHH(h);
        }

        public void getListHangHoa(DataGridView dvg)
        {
            List<DTO.HangHoa> HangHoa = DAL_HH.Instance.getListHangHoa();
            dvg.DataSource = HangHoa;
        }
        public List<DTO.HangHoa> getListHangHoa()
        {
            List<DTO.HangHoa> HangHoa = new List<DTO.HangHoa>();
            HangHoa = DAL_HH.Instance.getListHangHoa("Select * from HangHoa");
            return HangHoa;
        }
        public void TimKiemHangHoa(string ThuocTinh1, string TimKiem1, string ThuocTinh2, string TimKiem2, DataGridView dvg)
        {
            List<DTO.HangHoa> listHangHoa = new List<DTO.HangHoa>();
            string MaKhuTrungBay = DAL_KhuTrungBay.Instance.getListKhuTrungBay("TenKhuTrungBay", TimKiem1)[0].MaKhuTrungBay.ToString();

            if (ThuocTinh1 == "TenKhuTrungBay")
                if (TimKiem2 == "")
                {
                    listHangHoa = DAL_HH.Instance.TimKiemHangHoa("MaKhuTrungBay", MaKhuTrungBay);
                }
                else
                {
                    if (ThuocTinh2 == "Mã Hàng Hóa")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("MaHangHoa", TimKiem2);
                    if (ThuocTinh2 == "Tên Hàng Hóa")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("TenHangHoa", TimKiem2);
                    if (ThuocTinh2 == "Mã Nhà Cung Ứng")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("MaNhaCungUng", TimKiem2);
                    if (ThuocTinh2 == "Mã Kho")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("MaKho", TimKiem2);
                    if (ThuocTinh2 == "Số Lượng Trong Kho")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("SoLuongTrongKho", TimKiem2);
                    if (ThuocTinh2 == "Giá Nhập")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("GiaNhap", TimKiem2);
                    if (ThuocTinh2 == "Giá Bán")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("GiaBan", TimKiem2);
                    if (ThuocTinh2 == "Trạng Thái")
                        listHangHoa = DAL_HH.Instance.TimKiemHangHoa("TrangThai", TimKiem2);
                    foreach (DTO.HangHoa item in listHangHoa)
                    {
                        if (item.MaKhuTrungBay == ThuocTinh1)
                            listHangHoa.Add(item);
                    }
                }
            dvg.DataSource = listHangHoa;
        }
        public void TimKiemHangHoa(string ThuocTinh, string TimKiem, DataGridView dgv)
        {
            List<DTO.HangHoa> HangHoa = new List<DTO.HangHoa>();
            if (TimKiem == "")
                HangHoa = DAL_HH.Instance.getListHangHoa();
            if (ThuocTinh == "Mã Hàng Hóa")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("MaHangHoa", TimKiem);
            if (ThuocTinh == "Tên Hàng Hóa")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("TenHangHoa", TimKiem);
            if (ThuocTinh == "Mã Nhà Cung Ứng")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("MaNhaCungUng", TimKiem);
            if (ThuocTinh == "Mã Kho")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("MaKho", TimKiem);
            if (ThuocTinh == "Số Lượng Trong Kho")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("SoLuongTrongKho", TimKiem);
            if (ThuocTinh == "Giá Nhập")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("GiaNhap", TimKiem);
            if (ThuocTinh == "Giá Bán")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("GiaBan", TimKiem);
            if (ThuocTinh == "Trạng Thái")
                HangHoa = DAL_HH.Instance.TimKiemHangHoa("TrangThai", TimKiem);
            dgv.DataSource = HangHoa;
        }
        public DTO.HangHoa GetHangHoa_ByMaHangHoa(string ma)
        {
            DTO.HangHoa hh = new DTO.HangHoa();
            foreach (DTO.HangHoa i in getListHangHoa())
            {
                if (i.MaHangHoa == ma)
                {
                    hh = i;
                }
            }
            return hh;
        }

        //TOAN
        public DTO.HangHoa GetLastListHangHoa()
        {
            List<DTO.HangHoa> hangHoa = new List<DTO.HangHoa>();
            hangHoa = DAL_HH.Instance.getListHangHoa("Select * from HangHoa");
            return hangHoa[hangHoa.Count - 1];
        }
        public bool NgungKinhDoanh(DataGridView dvg)
        {
            DataGridViewRow row = dvg.SelectedCells[0].OwningRow;
            string id = row.Cells["MaHangHoa"].Value.ToString();
            return DAL_HH.Instance.NgungKinhDoanh(id);

        }
        public void DeXuatThemHangHoa(DTO.HangHoa HangHoa, string TenTheLoaiHangHoa, string TenKhuTrungBay, string TenNhaCungUng)
        {
            List<DTO.TheLoaiHangHoa> listTLHH = DAL_TheLoaiHangHoa.Instance.getListTheLoaiHangHoa("TenTheLoaiHangHoa", TenTheLoaiHangHoa);
            HangHoa.MaTheLoaiHangHoa = listTLHH[0].MaTheLoaiHangHoa.ToString();
            List<DTO.KhuTrungBay> listKTB = DAL_KhuTrungBay.Instance.getListKhuTrungBay("TenKhuTrungBay", TenKhuTrungBay);
            HangHoa.MaKhuTrungBay = listKTB[0].MaKhuTrungBay.ToString();
            List<DTO.NhaCungUng> listNCU = DAL_NCU.Instance.getListNhaCungUng("TenNhaCungUng", TenNhaCungUng);
            HangHoa.MaNhaCungUng = listNCU[0].MaNhaCungUng.ToString();

            DAL_HH.Instance.DeXuatThemHangHoa(HangHoa);

        }
        public void DeXuatThemHangHoa(DTO.DeXuat DeXuat, DTO.HangHoa HangHoa, string TenTheLoaiHangHoa, string TenKhuTrungBay, string TenNhaCungUng)
        {
            List<DTO.TheLoaiHangHoa> listTLHH = DAL_TheLoaiHangHoa.Instance.getListTheLoaiHangHoa("TenTheLoaiHangHoa", TenTheLoaiHangHoa);
            HangHoa.MaTheLoaiHangHoa = listTLHH[0].MaTheLoaiHangHoa.ToString();
            List<DTO.KhuTrungBay> listKTB = DAL_KhuTrungBay.Instance.getListKhuTrungBay("TenKhuTrungBay", TenKhuTrungBay);
            HangHoa.MaKhuTrungBay = listKTB[0].MaKhuTrungBay.ToString();
            List<DTO.NhaCungUng> listNCU = DAL_NCU.Instance.getListNhaCungUng("TenNhaCungUng", TenNhaCungUng);
            HangHoa.MaNhaCungUng = listNCU[0].MaNhaCungUng.ToString();

            DAL_HH.Instance.DeXuatThemHangHoa(HangHoa);
            //DTO.DeXuat DeXuat = new DTO.DeXuat(MaNhanVien, "Đang chờ phê duyệt", "Đề xuất thêm hàng hóa", DateTime.Now);
            BLL_DeXuat.Instance.AddDeXuat_BLL(DeXuat);
            DTO.ChiTietDeXuatHH CTDXHangHoa = new DTO.ChiTietDeXuatHH(BLL_DeXuat.Instance.GetLasTestDeXuat().MaDeXuat, Instance.GetLastListHangHoa().MaHangHoa, HangHoa.MaHangHoa);
            BLL_DeXuat.Instance.AddChiTietDeXuatHH_BLL(CTDXHangHoa);
        }
        public void CapNhatHangHoa(DTO.HangHoa HangHoa)
        {
            DAL_HH.Instance.CapNhatHangHoa(HangHoa);
        }
    }
}
