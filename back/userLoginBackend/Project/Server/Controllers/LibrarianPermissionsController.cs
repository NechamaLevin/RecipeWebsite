using BLL.interfaces;
using DAL.models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LibrarianPermissionsController : ControllerBase
{
    private readonly ILibrarianPermissionsBll _librarianPermissionsBll;

    public LibrarianPermissionsController(ILibrarianPermissionsBll librarianPermissionsBll)
    {
        _librarianPermissionsBll = librarianPermissionsBll;
    }

    [HttpPut("updatePermissions")]
    public async Task<IActionResult> UpdatePermissions(libper libper)
    {
        try
        {
            await _librarianPermissionsBll.UpdatePermissionsAsync(libper.UserId, libper.Permissions);
            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            // הוסיפי לוגיקה של טיפול בשגיאות
            return StatusCode(500, new { success = false, message = "Internal Server Error", details = ex.Message });
        }
    }
    public class libper
    {
        public int UserId { get; set; }
        public String [] Permissions { get; set; }
    }
}
