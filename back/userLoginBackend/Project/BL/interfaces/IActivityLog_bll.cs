using BLL.models_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IActivityLog_bll
    {
        List<ActivityLog_modelBll> getall();
        int Add(ActivityLog_modelBll activity);
    }
}
