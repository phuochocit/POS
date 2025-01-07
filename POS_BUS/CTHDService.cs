using POS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POS_BUS
{
    public  class CTHDService
    {
        POSContextDB context = new POSContextDB();
        public List<CTHD> GetAll()
        {
            return context.CTHD.ToList();
        }
        public void Add(CTHD cthd)
        {
            context.CTHD.Add(cthd);
            context.SaveChanges();
        }
        public void AddMultiple(List<CTHD> cthdList)
        {
            context.CTHD.AddRange(cthdList);
            context.SaveChanges();
        }
        public List<CTHD> GetByInvoiceId(string maHoaDon)
        {
            //if (string.IsNullOrEmpty(maHoaDon))
            //{
            //    throw new System.ArgumentException("Mã hóa đơn không được để trống.");
            //}

            //return context.CTHD.Where(cthd => cthd.MAHD == maHoaDon).ToList();
            if (string.IsNullOrEmpty(maHoaDon))
            {
                throw new ArgumentException("Mã hóa đơn không được để trống.");
            }

            using (var context = new POSContextDB())
            {
                // Bao gồm bảng SANPHAM khi truy vấn
                return context.CTHD
                              .Include(cthd => cthd.SANPHAM) // Bao gồm thông tin sản phẩm
                              .Where(cthd => cthd.MAHD == maHoaDon)
                              .ToList();
            }
        }
    }
}
