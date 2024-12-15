using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingNoteController : ControllerBase
    {
        IRatingNote_bll IRatingNote_bll;
        public RatingNoteController(IRatingNote_bll iRatingNote_bll)
        {
            IRatingNote_bll = iRatingNote_bll;
        }
        [HttpGet("GetAllRatingNote")]
        public ActionResult<List<RatingNote_bll>> GetAll()
        {
            return Ok(IRatingNote_bll.GetAll());
        }
    }
}
