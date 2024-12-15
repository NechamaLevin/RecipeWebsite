using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class RatingNote
{
    public int RatingNoteId { get; set; }

    public int UserId { get; set; }

    public int? ItemId { get; set; }

    public string Note { get; set; }

    public int? Rating { get; set; }

    public bool SavedItem { get; set; }

    public virtual Item Item { get; set; }

    public virtual User User { get; set; }
}
