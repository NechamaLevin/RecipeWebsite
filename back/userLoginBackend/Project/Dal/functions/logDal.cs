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
    public class logDal : Ilog
    {
        LiberiansDbContext LiberiansDbContext;

        public logDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }
        public ActivityLog Add(ActivityLog log)
        {
            try
            {
                LiberiansDbContext.ActivityLogs.Add(log);
                LiberiansDbContext.SaveChanges();
                //החזרת הקוד האוטומטי שנוסף
                return log;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(ActivityLog log)
        {
            try
            {
                LiberiansDbContext.Remove(log);
                LiberiansDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ActivityLog> GetAll()
        {
            return LiberiansDbContext.ActivityLogs.Include(k=>k.UserId1NavigationUser).ToList();
        }


        bool Ilog.Update(ActivityLog log)
        {
            try
            {
                LiberiansDbContext.ActivityLogs.Update(log);
                LiberiansDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
