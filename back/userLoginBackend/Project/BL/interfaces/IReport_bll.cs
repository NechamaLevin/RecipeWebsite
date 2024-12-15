using BLL.functions;
using BLL.models_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.functions.Report_bll;
namespace BLL.interfaces
{
    public interface IReport_bll
    {
        List<Report_modelBll> getall();
        public List<SearchLogBorrowRequestDto> GetSearchLogsBorrowRequests(string reportName, string type, int userid);
        public List<UserCount> getCountByDate(string reportName, string type1, int userid);
        public List<UserActivityCount> GetActivityLogs(string reportName, string type, int userid);
        public List<UserLoginReport> GetLoginActivityReport(DateTime loginDate, string reportName, string type, int userid);
    }
}
