using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ItemTag> ItemTags { get; set; } = new List<ItemTag>();

    public virtual ICollection<PhysicalItemTag> PhysicalItemTags { get; set; } = new List<PhysicalItemTag>();
}
