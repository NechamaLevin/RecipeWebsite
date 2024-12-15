using BLL.functions;
using BLL.models_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface ILibrarianPermissionsBll
    {
        Task UpdatePermissionsAsync(int userId, string[] permissions);
    } 
}
