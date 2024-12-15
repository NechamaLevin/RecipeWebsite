using AutoMapper;
using BLL.functions;
using DAL.models;
using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.functions
{
    public class BorrowApprovalRequestBll : IBorrowApprovalRequestsBll
    {
        IBorrowApprovalRequests _IBorrowApprovalRequests;
        IMapper mapper;
        public BorrowApprovalRequestBll(IBorrowApprovalRequests IBorrowApprovalRequests)
        {
            _IBorrowApprovalRequests = IBorrowApprovalRequests;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }
        public List<BorrowApprovalRequestModelBLL> getall()
        {
            List<BorrowApprovalRequest> BorrowApprovalRequest = _IBorrowApprovalRequests.GetAll();
            return mapper.Map<List<BorrowApprovalRequestModelBLL>>(BorrowApprovalRequest);
        }
    }
}
