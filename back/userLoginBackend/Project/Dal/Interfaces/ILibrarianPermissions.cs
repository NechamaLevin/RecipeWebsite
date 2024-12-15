using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILibrarianPermissions
    {
        Task UpdatePermissionsAsync(int userId, string[] permissions);
    }
}
