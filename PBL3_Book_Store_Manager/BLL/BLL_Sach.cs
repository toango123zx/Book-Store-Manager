using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Book_Store_Manager.DAL;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_Sach
    {
        private static BLL_Sach _Instance;
        public static BLL_Sach Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_Sach();
                return _Instance;
            }
            private set { }
        }
        public List<DTO.Sach> getListSach()
        {
            return DAL_Sach.Instance.getListSach();
        }
        public List<DTO.Sach> getListSach(string ThuocTinh, string TimKiem)
        {
            return DAL_Sach.Instance.getListSach(ThuocTinh, TimKiem);
        }
        public void DeXuatTheSach(DTO.Sach Sach)
        {
            DTO.HangHoa HangHoa = new DTO.HangHoa();
            DAL_HH.Instance.getListHangHoa("SELECT MaHangHoa, TenHangHoa WHERE TenHangHoa = N'" + @Sach.TenHangHoa + "';").LastIndexOf(HangHoa);
            Sach.MaHangHoa = HangHoa.MaHangHoa;
            BLL_Sach.Instance.DeXuatTheSach(Sach);
        }
    }
}