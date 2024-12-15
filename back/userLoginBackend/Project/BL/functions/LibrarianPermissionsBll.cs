using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class LibrarianPermissionsBll:ILibrarianPermissionsBll
    {
        private readonly ILibrarianPermissions _dal;
        static IMapper mapper;

        public LibrarianPermissionsBll(ILibrarianPermissions dal)
        {
            _dal = dal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }

        public async Task UpdatePermissionsAsync(int userId, string[] permissions)
        {
            await _dal.UpdatePermissionsAsync(userId,permissions);
        }
    }
}
