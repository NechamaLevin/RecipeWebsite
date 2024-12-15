using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class ItemDal: Iitem
    {
        LiberiansDbContext LiberiansDbContext;
        public ItemDal(LiberiansDbContext LiberiansDbContext)
        {
           this.LiberiansDbContext = LiberiansDbContext;
        }
        public List<Item> GetAll()
        {
            return LiberiansDbContext.Items.ToList();
        }

    }
}
