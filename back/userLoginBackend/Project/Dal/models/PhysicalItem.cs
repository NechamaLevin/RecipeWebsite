using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class PhysicalItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public int? Amount { get; set; }

    public virtual ICollection<PhysicalItemTag> PhysicalItemTags { get; set; } = new List<PhysicalItemTag>();
}
