using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Numerics;

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        IActivityLog_bll _IActivityLog_bll;
        public ActivityLogController(IActivityLog_bll _ActivityLog_bll)
        {
            this._IActivityLog_bll = _ActivityLog_bll;
        }
     

        [HttpGet("GetAllActivity")]
        public ActionResult<List<ActivityLog_modelBll>> GetAll()
        {
            return Ok(_IActivityLog_bll.getall());
        }

        [HttpPost("addActivity")]
        public ActionResult<bool> add1(ActivityLog_modelBll activity)
        {
            return Ok(_IActivityLog_bll.Add(activity));
        }
    }
}
