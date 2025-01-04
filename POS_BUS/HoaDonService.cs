using POS_DAL.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace POS_BUS
{
    public class HoaDonService
    {
        POSContextDB context = new POSContextDB();
        public List<HOADON> GetAll()
        {
            return context.HOADON.ToList();
        }
        public void Add(HOADON hoaDon)
        {
            context.HOADON.Add(hoaDon);
            context.SaveChanges();
        }

        public void Delete(string maHoaDon)
        {
            try
            {
                // Tìm hóa đơn theo mã
                var hoaDon = context.HOADON.FirstOrDefault(h => h.MAHD == maHoaDon);

                if (hoaDon != null)
                {
                    // Xóa hóa đơn
                    context.HOADON.Remove(hoaDon);
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
                else
                {
                    throw new Exception("Hóa đơn không tồn tại");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
        }
    }
}
