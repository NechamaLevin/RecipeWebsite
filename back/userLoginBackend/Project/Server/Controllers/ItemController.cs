using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItem_bll _IItem_bll;
        public ItemController(IItem_bll iItem_bll)
        {
            _IItem_bll = iItem_bll;
        }

        [HttpGet("GetAllItems")]
        public ActionResult<List<Item_bll>> GetAll()
        {
            return Ok(_IItem_bll.GetAll());
        }
    }
}