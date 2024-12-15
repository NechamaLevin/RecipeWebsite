using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class PhysicalItemTag
{
    public int Id { get; set; }

    public int PhysicalItemId { get; set; }

    public int TagId { get; set; }

    public virtual PhysicalItem PhysicalItem { get; set; }

    public virtual Tag Tag { get; set; }
}
