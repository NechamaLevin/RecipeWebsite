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
    public class reportDal : Ireport
    {
        LiberiansDbContext LiberiansDbContext;

        public reportDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }

        public List<Report> GetAll()
        {
          return LiberiansDbContext.Reports.ToList();
        }

        public Report Add(Report report)
        {
            LiberiansDbContext.Reports.Add(report);
            LiberiansDbContext.SaveChanges();
            return report;
        }

        public bool Update(Report report)
        {
            var existingReport = LiberiansDbContext.Reports.Find(report.ReportId);
            if (existingReport == null)
            {
                return false;
            }
            // עדכני תכונות נוספות לפי הצורך

            LiberiansDbContext.Reports.Update(existingReport);
            LiberiansDbContext.SaveChanges();
            return true;
        }

        public bool Delete(Report report)
        {
            var existingReport = LiberiansDbContext.Reports.Find(report.ReportId);
            if (existingReport == null)
            {
                return false;
            }

            LiberiansDbContext.Reports.Remove(existingReport);
            LiberiansDbContext.SaveChanges();
            return true;
        }
    }
}

