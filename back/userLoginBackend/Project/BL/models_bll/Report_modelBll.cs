using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class Report_modelBll
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportData { get; set; }
        public string GeneratedBy { get; set; }
        public DateTime? GeneratedAt { get; set; }
        public int? GeneratedByNavigationUserId { get; set; }
    }
}
