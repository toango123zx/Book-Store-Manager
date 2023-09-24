using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Book_Store_Manager.DTO;
using PBL3_Book_Store_Manager.DAL;
namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_HDNK
    {
        private static BLL_HDNK _Instance;
        public static BLL_HDNK Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_HDNK();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_HDNK()
        {

        }
        public List<HoaDon> GetListHoaDonNK_BLL()
        {
            List<HoaDon> data = new List<HoaDon>();
            data = DAL_HD.Instance.getListHDBH("select * from HOADON");
            return data;
        }

        public List<HoaDon> SearchListHDNKByMaHD(string maHD)
        {
            List<HoaDon> data = GetListHoaDonNK_BLL();
            List<HoaDon> result = new List<HoaDon>();
            if (maHD == null) result = data;
            else
            {
                foreach (HoaDon i in data)
                {
                    if (i.MaHoaDon.Contains(maHD))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }


        public List<HoaDon> SearchListHDNKByMaNV(string maNV)
        {
            List<HoaDon> data = GetListHoaDonNK_BLL();
            List<HoaDon> result = new List<HoaDon>();
            if (maNV == null) result = data;
            else
            {
                foreach (HoaDon i in data)
                {
                    if (i.MaNhanVien.Contains(maNV))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }
        public List<HoaDon> GetListHoaDonTheoMaDeXuat(string MaDeXuat)
        {

            DeXuat deXuatTheoMaDX = BLL_DeXuat.Instance.GetDeXuatByMaDeXuat(MaDeXuat);
            List<HoaDon> dataHD = GetListHoaDonNK_BLL();
            List<HoaDon> result = new List<HoaDon>();
            if (MaDeXuat == null) result = dataHD;
            else
            {
                foreach (HoaDon i in dataHD)
                {
                    if (i.MaNhanVien == deXuatTheoMaDX.MaNhanVien)
                    {
                        result.Add(i);
                    }
                }

            }
            return result;
        }

        public HoaDon GetHoaDon_ByMaHD(string ma)
        {
            HoaDon s = new HoaDon();
            foreach (HoaDon i in GetListHoaDonNK_BLL())
            {
                if (i.MaHoaDon == ma) s = i;
            }
            return s;
        }
        public HoaDon GetHoaDonByThoiGian(HoaDon s)
        {
            HoaDon hd = new HoaDon();
            foreach (HoaDon i in GetListHoaDonNK_BLL())
            {
                if (i.ThoiGian.ToString() == s.ThoiGian.ToString())
                {
                    hd = i;
                    return hd;
                }
            }
            return null;

        }

        public List<ChiTietHD> GetListChiTietHD_BLL()
        {
            List<ChiTietHD> data = new List<ChiTietHD>();
            data = DAL_HD.Instance.GetListChiTietHD("select * from CHITIETHOADON");
            return data;
        }

        public ChiTietHD getChiTietHD_BLL(string maHD)
        {
            ChiTietHD chiTietHD = new ChiTietHD();
            List<ChiTietHD> data = GetListChiTietHD_BLL();
            foreach (ChiTietHD i in data)
            {
                if (maHD == i.MaHoaDon)
                {
                    chiTietHD = i;
                    return chiTietHD;
                }
            }
            return null;
        }

        public void AddHD_BLL(HoaDon s)
        {
            DAL_HD.Instance.AddHD_DAL(s);
        }
        public void AddCTHD_BLL(ChiTietHD s)
        {
            DAL_HD.Instance.AddCTHD_DAL(s);
        }
        // add chi tiết hóa đơn nhập kho 
        public void AddCTHDNK_BLL(ChiTietDeXuatHD s)
        {
            DAL_DeXuat.Instance.AddCTDeXuatHoaHonNhapKho(s);
        }

        public List<HoaDonView> SearchListHDNKViewByMaHd(string MaHD)
        {
            List<HoaDonView> data = GetListHDView();
            List<HoaDonView> result = new List<HoaDonView>();
            if (MaHD == null) result = data;
            else
            {
                foreach (HoaDonView i in data)
                {
                    if (i.MaHoaDon.Contains(MaHD))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }
        public List<HoaDonView> SearchListHDNKViewByTenNV(string TenNV)
        {
            List<HoaDonView> data = GetListHDView();
            List<HoaDonView> result = new List<HoaDonView>();
            if (TenNV == null) result = data;
            else
            {
                foreach (HoaDonView i in data)
                {
                    if (i.TenNhanVien.Contains(TenNV))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public List<HoaDonView> GetListHDView()
        {
            List<HoaDon> data = GetListHoaDonNK_BLL();
            List<HoaDonView> result = new List<HoaDonView>();

            foreach (HoaDon hoaDon in data)
            {
                HoaDonView hd = new HoaDonView
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    ThoiGian = hoaDon.ThoiGian,
                    TenNhanVien = BLL_NV.Instance.GetNVByMaNV(hoaDon.MaNhanVien).TenNhanVien,
                };
                result.Add(hd);
            }
            return result;
        }
    }
}