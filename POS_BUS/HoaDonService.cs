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
                using (var context = new POSContextDB())
                {
                    // Tìm hóa đơn theo mã
                    var hoaDon = context.HOADON.FirstOrDefault(h => h.MAHD == maHoaDon);

                    if (hoaDon != null)
                    {
                        // Xóa các chi tiết hóa đơn liên quan trước
                        context.CTHD.RemoveRange(hoaDon.CTHD);

                        // Xóa hóa đơn
                        context.HOADON.Remove(hoaDon);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa hóa đơn: {ex.Message}", ex);
            }
        }
    }
}
