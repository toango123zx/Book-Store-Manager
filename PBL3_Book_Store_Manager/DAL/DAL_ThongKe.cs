using PBL3_Book_Store_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Book_Store_Manager.DAL
{
    public class DAL_ThongKe
    {
        private static DAL_ThongKe _Instance;
        public static DAL_ThongKe Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_ThongKe();
                }
                return _Instance;
            }
            private set { }
        }
        private DAL_ThongKe() { }

        public int GetSoLuongHoaDon_DAL()
        {
            int SoHoaDon = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecords("select count(MaHoaDon) from HOADON").Rows)
            {
                if (i[0].ToString() != "")
                {
                    SoHoaDon = Convert.ToInt32(i[0]);
                }
            }
            return SoHoaDon;
        }

        public int GetSoLuongHHBan_DAL()
        {
            int SoHH = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecords("select sum(SoLuong) from CHITIETHOADON").Rows)
            {
                if (i[0].ToString() != "")
                {
                    SoHH = Convert.ToInt32(i[0]);
                }
            }
            return SoHH;
        }
        public int GetSoLuongHhBanByTG_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select sum(SoLuong) " +
               "from CHITIETHOADON, HOADON where HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon and ThoiGian >= '{0}' and ThoiGian <= '{1}' ", dateFrom, dateTo);
            int SoHH = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                if (i[0].ToString() != "")
                {
                    SoHH = Convert.ToInt32(i[0]);
                }
            }
            return SoHH;
        }

        public int GetSoSachBan_TG_DAL(DateTime dateFrom, DateTime dateTo)
        {
            int soluong = 0;
            string query = string.Format("select SUM(SoLuong) from CHITIETHOADON, HOADON where ThoiGian >= '{0}' and ThoiGian <= '{1}' and CHITIETHOADON.MaHoaDon = HOADON.MaHoaDon", dateFrom, dateTo);
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                if (i[0].ToString() != "")
                {
                    soluong = Convert.ToInt32(i[0]);
                }
            }
            return soluong;
        }
        public int GetSoHoaDon_TG_DAL(DateTime dateFrom, DateTime dateTo)
        {
            int soluong = 0;
            string query = string.Format("select COUNT(MaHoaDon) from HOADON where ThoiGian >= '{0}' and ThoiGian <= '{1}'", dateFrom, dateTo);
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                if (i[0].ToString() != "")
                {
                    soluong = Convert.ToInt32(i[0]);
                }
            }
            return soluong;
        }

        public List<HoaDon> GetListHoaDonByTG_DAL(DateTime dateFrom, DateTime dateTo)
        {
            List<HoaDon> data = new List<HoaDon> ();
            string query = string.Format("select * from HOADON where  ThoiGian >= '{0}' and ThoiGian <= '{1}' ",dateFrom,dateTo);
            foreach(DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(DAL_HD.Instance.GetHDBH(i));
            }  
            return data;
        }

        public List<ChiTietHD> GetListCTHDByTG_DAL(DateTime dateFrom, DateTime dateTo)
        {
            List<ChiTietHD> data = new List<ChiTietHD> ();
            string query = string.Format("select CHITIETHOADON.MaHoaDon, MaHangHoa, SoLuong " +
               "from CHITIETHOADON, HOADON where HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon and ThoiGian >= '{0}' and ThoiGian <= '{1}' ", dateFrom, dateTo);
            foreach(DataRow i in DBHelper.Instance.GetRecords (query).Rows)
            {
                data.Add(DAL_HD.Instance.GetChiTietHD(i));
            }    
            return data;
        }


    }
    
}
