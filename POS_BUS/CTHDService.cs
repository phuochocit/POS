using POS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
