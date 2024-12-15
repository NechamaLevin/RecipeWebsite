using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class BorrowApprovalRequest
{
    public int RequestId { get; set; }

    public int? ItemId { get; set; }

    public int UserId { get; set; }

    public int RequestStatus { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public int LibrariansId { get; set; }

    public bool? IsReturned { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? UntilDate { get; set; }

    public virtual User User { get; set; }
}
