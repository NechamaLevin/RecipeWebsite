using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Iuser
    {
        List<User> GetAll();
        List<LibrarianPermission> GetAllPermissions();
        LibrarianPermission getPermissionForLibrarian(int id);
        User Add(User user);
        User Update(User user);
        bool Delete(int userId);
        User UpdatePassword(User user);
      

    }
}
