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
    public class userDal : Iuser
    {
        LiberiansDbContext LiberiansDbContext;
        public userDal(LiberiansDbContext LiberiansDbContext)
        {

            this.LiberiansDbContext = LiberiansDbContext;

        }
        public List<User> GetAll()
        {
            return LiberiansDbContext.Users.ToList();
        }

        public User Add(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.Activity = true;
            LiberiansDbContext.Users.Add(user);
            LiberiansDbContext.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var existingUser = LiberiansDbContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Tz = user.Tz ?? existingUser.Tz;
            //existingUser.UserName = user.UserName ?? existingUser.UserName;
            existingUser.Fname = user.Fname ?? existingUser.Fname;
            existingUser.Sname = user.Sname ?? existingUser.Sname;
            existingUser.PasswordHash = user.PasswordHash ?? existingUser.PasswordHash;
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.Role = user.Role ?? existingUser.Role;
            existingUser.ProfilePicture = user.ProfilePicture ?? existingUser.ProfilePicture;
            existingUser.CreatedAt = user.CreatedAt != default ? user.CreatedAt : existingUser.CreatedAt;
            existingUser.UpdatedAt = user.UpdatedAt ?? DateTime.Now;
            existingUser.UserDob = user.UserDob != default ? user.UserDob : existingUser.UserDob;
            existingUser.PhoneNumber = user.PhoneNumber ?? existingUser.PhoneNumber;
            existingUser.Megama = user.Megama ?? existingUser.Megama;
            existingUser.Activity = user.Activity ?? existingUser.Activity;

            // עדכני תכונות נוספות לפי הצורך

            LiberiansDbContext.Users.Update(existingUser);
            LiberiansDbContext.SaveChanges();
            return existingUser;
        }

        public bool Delete(int userId)
        {
            User existingUser = LiberiansDbContext.Users.Find(userId);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.Activity=false;
            LiberiansDbContext.Users.Update(existingUser);
            LiberiansDbContext.SaveChanges();
            return true;
        }

        public User UpdatePassword(User user)
        {
            var existingUser = LiberiansDbContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.PasswordHash = user.PasswordHash;
            LiberiansDbContext.Users.Update(existingUser);
            LiberiansDbContext.SaveChanges();
            return existingUser;

        }

        public LibrarianPermission getPermissionForLibrarian(int id)
        {
            return LiberiansDbContext.LibrarianPermissions.FirstOrDefault(p => p.UserId == id);
        }

        public List<LibrarianPermission> GetAllPermissions()
        {
            return LiberiansDbContext.LibrarianPermissions.ToList();
        }
    }
}


