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
    public class BorrowApprovalRequestsDal : IBorrowApprovalRequests
    {
        LiberiansDbContext LiberiansDbContext;
        public BorrowApprovalRequestsDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }
        public List<BorrowApprovalRequest> GetAll()
        {
            return LiberiansDbContext.BorrowApprovalRequests.Include(k => k.User).ToList();
        }
    }
}
