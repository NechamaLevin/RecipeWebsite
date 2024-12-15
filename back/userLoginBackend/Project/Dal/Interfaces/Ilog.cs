using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Ilog
    {
        List<ActivityLog> GetAll();
        ActivityLog Add(ActivityLog log);
        bool Update(ActivityLog log);
        bool Delete(ActivityLog log);

    }
}
