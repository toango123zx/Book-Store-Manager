using PBL3_Book_Store_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Book_Store_Manager.DAL;
using _3Layers.DTO;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_NV
    {
        private static BLL_NV _Instance;
        public static BLL_NV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_NV();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_NV()
        {

        }
        public List<NhanVien> GetListNV()
        {
            List<NhanVien> list = new List<NhanVien>();
            list = DAL_NV.Instance.getListNV();
            return list;
        }

        public List<NhanVien> GetListNV(string ThuocTinh, string TenTimKiem)                 //search
        {
            List<NhanVien> list = new List<NhanVien>();
            if (ThuocTinh == "Tên nhân viên")
                list = DAL_NV.Instance.getListNV("TenNhanVien", TenTimKiem);
            if (ThuocTinh == "Giới tính")
                list = DAL_NV.Instance.getListNV("GioiTinh", TenTimKiem);
            if (ThuocTinh == "Số căn cước công dân")
                list = DAL_NV.Instance.getListNV("SoCanCuocCongDan", TenTimKiem);
            if (ThuocTinh == "Số điện thoại")
                list = DAL_NV.Instance.getListNV("SoDienThoai", TenTimKiem);
            if (ThuocTinh == "Địa chỉ")
                list = DAL_NV.Instance.getListNV("DiaChi", TenTimKiem);
            //if (ThuocTinh == "Tên Chức vụ") ;
            return list;
        }
        public NhanVien GetNVByMaNV(string maNV)
        {
            List<NhanVien> nv = GetListNV();
            foreach (NhanVien nvv in nv)
            {
                if (nvv.MaNhanVien == maNV)
                {
                    return nvv;
                }
            }
            return null;
        }
        public List<string> GetListTenNV()
        {

            List<String> list = new List<String>();
            foreach (NhanVien i in GetListNV())
            {
                list.Add(i.TenNhanVien.ToString());
            }
            return list;
        }

        public List<CBBItems> GetCBB()
        {
            List<CBBItems> data = new List<CBBItems>();
            foreach (NhanVien i in GetListNV())
            {
                if(i.TinhTrang == "Hoạt động")
                {
                    data.Add(new CBBItems
                    {
                        Value = i.MaNhanVien,
                        Text = i.TenNhanVien
                    });
                }    
            }
            return data;
        }
        public void AddNV(NhanVien s)
        {
            DAL_NV.Instance.AddNV(s);
        }
        public void UpdateNV(NhanVien s)
        {
            DAL_NV.Instance.UpdateNV(s);
        }
        public void UpdateTrangThaiNV(string MaNV)
        {
            DAL_NV.Instance.UpdateTrangThaiNV(MaNV);
        }
        public NhanVien GetLastestNV()
        {
            List<NhanVien> data = GetListNV();
            return data[data.Count - 1];
        }
        public bool CheckUpdateNV(NhanVien s)
        {
            foreach(NhanVien i in GetListNV())
            {
                if(s.MaNhanVien == i.MaNhanVien)
                {
                    if (s == i)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }    
                    
            }    
            return false;
        }
    }
}