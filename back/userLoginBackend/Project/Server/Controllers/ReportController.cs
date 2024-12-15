using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BLL.functions.Report_bll;
namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IReport_bll _IReport_bll;
        public ReportController(IReport_bll IReport_bll)
        {
            this._IReport_bll = IReport_bll;
        }
        [HttpGet("getReports")]
        public ActionResult<List<Report_modelBll>> GetAll()
        {
            return Ok(_IReport_bll.getall());
        }
        [HttpGet("GetSearchLogsBorrowRequests")]
        public ActionResult<List<SearchLogBorrowRequestDto>> GetSearchLogsBorrowRequests([FromQuery] string reportName, [FromQuery] string type, [FromQuery] int userId)
        {
            var result = _IReport_bll.GetSearchLogsBorrowRequests(reportName, type, userId);
            return Ok(result);
        }
        [HttpGet("getCountByDate")]
        public ActionResult<List<UserCount>> getCountByDate([FromQuery] string reportName, [FromQuery] string type, [FromQuery] int userId)
        {
            var result = _IReport_bll.getCountByDate(reportName, type, userId);
            return Ok(result);
        }

        [HttpGet("aaa")]
        public ActionResult<List<UserLoginReport>> aaa([FromQuery] DateTime loginDate, [FromQuery] string reportName, [FromQuery] string type, [FromQuery] int userId)
        {
            var result = _IReport_bll.GetLoginActivityReport(loginDate, reportName, type, userId);
            return Ok(result);
        }


        [HttpGet("activity-report")]
        public ActionResult<List<UserActivityCount>> GetActivityLogs([FromQuery] string reportName, [FromQuery] string type, [FromQuery] int userId)
        {
            var activityLogs = _IReport_bll.GetActivityLogs(reportName, type, userId);
            return Ok(activityLogs);
        }
    }
}

