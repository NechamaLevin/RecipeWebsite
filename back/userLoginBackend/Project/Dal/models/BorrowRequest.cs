using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class BorrowRequest
{
    public int RequestId { get; set; }

    public int? ItemId { get; set; }

    public int UserId { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? UntilDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? IsWaiting { get; set; }

    public virtual Item Item { get; set; }

    public virtual User User { get; set; }
}
