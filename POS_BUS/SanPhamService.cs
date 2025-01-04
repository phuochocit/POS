using POS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_BUS
{
    public class SanPhamService
    {   
        POSContextDB context = new POSContextDB();
        public List<SANPHAM> GetProducts()
        {
            return context.SANPHAM.ToList();
        }

        public List<SANPHAM> GetProductsByID(string id)
        {
            return context.SANPHAM.Where(sp => sp.MASP == id).ToList();
        }
    }
}
