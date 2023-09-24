using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Book_Store_Manager.DTO;

namespace PBL3_Book_Store_Manager.DAL
{
    public class DAL_KhuTrungBay
    {
        private static DAL_KhuTrungBay _Instance;
        public static DAL_KhuTrungBay Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DAL_KhuTrungBay();
                return _Instance;
            }
            private set { }
        }

        private DAL_KhuTrungBay()
        {

        }
        public List<DTO.KhuTrungBay> getListKhuTrungBay()
        {
            List<DTO.KhuTrungBay> KhuTrungBay = new List<DTO.KhuTrungBay>();
            string query = "Select * from KHUTRUNGBAY;";
            foreach (DataRow item in DBHelper.Instance.GetRecords(query).Rows)
            {
                string MaKhuTrungBay = item["MaKhuTrungBay"].ToString();
                string TenKhuTrungBay = item["TenKhuTrungBay"].ToString();
                short SoLuongToiDa = (short)item["SoLuongToiDa"];

                DTO.KhuTrungBay newKhuTrungBay = new DTO.KhuTrungBay(MaKhuTrungBay, TenKhuTrungBay, SoLuongToiDa);
                KhuTrungBay.Add(newKhuTrungBay);
            }
            return KhuTrungBay;
        }
        public List<DTO.KhuTrungBay> getListKhuTrungBay(string ThuocTinh, string TimKiem)
        {
            List<DTO.KhuTrungBay> KhuTrungBay = new List<DTO.KhuTrungBay>();
            string query = "Select * from KHUTRUNGBAY WHERE " + @ThuocTinh + " = N'" + @TimKiem + "';";
            foreach (DataRow item in DBHelper.Instance.GetRecords(query).Rows)
            {
                string MaKhuTrungBay = item["MaKhuTrungBay"].ToString();
                string TenKhuTrungBay = item["TenKhuTrungBay"].ToString();
                short SoLuongToiDa = (short)item["SoLuongToiDa"];

                DTO.KhuTrungBay newKhuTrungBay = new DTO.KhuTrungBay(MaKhuTrungBay, TenKhuTrungBay, SoLuongToiDa);
                KhuTrungBay.Add(newKhuTrungBay);
            }
            return KhuTrungBay;
        }
        public void ThemKhuTrungBay(DTO.KhuTrungBay KhuTrungBay)
        {
            string query = "INSERT INTO KHUTRUNGBAY (TenKhuTrungBay, SoLuongToiDa) VALUES(N'" + @KhuTrungBay.TenKhuTrungBay + "', " + @KhuTrungBay.SoLuongToiDa + ");";
            DBHelper.Instance.ExecuteDB(query);
        }
        public void CapNhatKhuTrungBay(DTO.KhuTrungBay KhuTrungBay)
        {
            string query = "UPDATE KHUTRUNGBAY SET TenKhuTrungBay = N'" + @KhuTrungBay.TenKhuTrungBay + "', SoLuongToiDa = " + @KhuTrungBay.SoLuongToiDa + " WHERE MaKhuTrungBay = N'" + @KhuTrungBay.MaKhuTrungBay + "';";
            DBHelper.Instance.ExecuteDB(query);
        }
        /*public List<HangHoa> TimKiemHangHoa(string ThuocTinh, string TenTimKiem, string Ke)
        {
            List<DTO.HangHoa> HangHoa = new List<DTO.HangHoa>();
            string query = "Select * from HANGHOA where @ThuocTinh = @TenTimKiem AND MaKhuTrungBay = Ke;
            DataTable data = DBHelper.Instance.GetRecords(query);
            foreach (DataRow item in data.Rows)
            {
                string MaHangHoa = item["MaHangHoa"].ToString();
                string TenHangHoa = item["TenHangHoa"].ToString();
                string MaTheLoaiHangHoa = item["MaTheLoaiHangHoa"].ToString();
                string NhaSanXuat = item["NhaSanXuat"].ToString();
                string MaNhaCungUng = item["MaNhaCungUng"].ToString();
                string NamSanXuat = item["NamSanXuat"].ToString();
                string MaKhuTrungBay = item["MaKhuTrungBay"].ToString();
                short SoLuongTrenKhuTrungBay = (short)item["SoLuongTrenKhuTrungBay"];
                string MaKho = item["MaKho"].ToString();
                short SoLuongTrongKho = (short)item["SoLuongTrongKho"];
                decimal GiaNhap = (decimal)item["GiaNhap"];
                decimal GiaBan = (decimal)item["GiaBan"];
                string TrangThai = item["TrangThai"].ToString();
                DTO.HangHoa newHangHoa = new DTO.HangHoa(MaHangHoa, TenHangHoa, MaTheLoaiHangHoa, NhaSanXuat, MaNhaCungUng, NamSanXuat, MaKhuTrungBay, SoLuongTrenKhuTrungBay, MaKho, SoLuongTrongKho, GiaNhap, GiaBan, TrangThai);
                HangHoa.Add(newHangHoa);
            }
            return HangHoa;
        }*/
    }
}