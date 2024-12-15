using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.models_bll
{
    public class BorrowApprovalRequestModelBLL
    {
        public int searchDate { get; set; }

        public int RequestId { get; set; }

        public int? ItemId { get; set; }

        public int UserId { get; set; }

        public int RequestStatus { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int LibrariansId { get; set; }

    }
}