using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Ireport
    {
        List<Report> GetAll();
        Report Add(Report report);
        bool Update(Report report);
        bool Delete(Report report);
    }
}
