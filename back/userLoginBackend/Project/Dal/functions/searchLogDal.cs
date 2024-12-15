using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.functions
{
    public class searchLogDal : IsearchLog
    {
        LiberiansDbContext LiberiansDbContext;
        public searchLogDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }
        public List<SearchLog> GetAll()
        {
            return LiberiansDbContext.SearchLogs.Include(k => k.User).ToList();
        }
    }
}
