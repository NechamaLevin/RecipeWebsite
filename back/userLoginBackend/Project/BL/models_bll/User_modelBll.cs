using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class User_modelBll
    {
        public int UserId { get; set; }

        public string Tz { get; set; }

        public string Sname { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime UserDob { get; set; }

        public string PhoneNumber { get; set; }

        public string Fname { get; set; }

        public string Megama { get; set; }
        public bool? Activity { get; set; }

    }




}
