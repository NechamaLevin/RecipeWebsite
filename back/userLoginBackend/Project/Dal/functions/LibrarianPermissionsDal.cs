using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class LibrarianPermissionsDal:ILibrarianPermissions
    {
        LiberiansDbContext LiberiansDbContext;
        public LibrarianPermissionsDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }

        public async Task UpdatePermissionsAsync(int userId, string[] permissions)
        {
            // אינסטנס חדש של DbContext עבור כל פעולה
            using var context = new LiberiansDbContext();

            var librarianPermission = await context.LibrarianPermissions.FirstOrDefaultAsync(lp => lp.UserId == userId);
            if (librarianPermission != null)
            {
                librarianPermission.Permissions = permissions;
                await context.SaveChangesAsync();
            }
        }

    }
}

