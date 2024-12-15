using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class ActivityLog_modelBll
    {
        public int LogId { get; set; }

        public string UserId { get; set; }

        public string Activity { get; set; }

        public DateTime? Timestamp { get; set; }

        public int? UserId1 { get; set; }
        public int UserId1NavigationUserId { get; set; }

    }
}
