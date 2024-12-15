using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowApprovalRequest : ControllerBase
    {
        IBorrowApprovalRequestsBll IBorrowApprovalRequestsBll;
        public BorrowApprovalRequest(IBorrowApprovalRequestsBll _IBorrowApprovalRequestsBll)
        {
            IBorrowApprovalRequestsBll = _IBorrowApprovalRequestsBll;
        }
        [HttpGet("GetAllBorrowApprovalRequests")]
        public ActionResult<List<BorrowApprovalRequestModelBLL>> GetAll()
        {
            return Ok(IBorrowApprovalRequestsBll.getall());
        }
    }
}
