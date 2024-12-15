using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLog : ControllerBase
    {
        ISearchLogBll _ISearchLogBll;
        public SearchLog(ISearchLogBll ISearchLogBll)
        {
            _ISearchLogBll = ISearchLogBll;
        }
        [HttpGet("GetAllBorrowApprovalRequests")]
        public ActionResult<List<searchLogModelBll>> GetAll()
        {
            return Ok(_ISearchLogBll.getall());
        }
    }
}
