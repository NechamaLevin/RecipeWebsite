using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class AddNewRequest
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? PublishigYear { get; set; }

    public string Edition { get; set; }

    public string Series { get; set; }

    public int? NumOfSeries { get; set; }

    public string Language { get; set; }

    public string Note { get; set; }

    public string AccompanyingMaterial { get; set; }

    public string HebrewPublicationYear { get; set; }

    public int UserId { get; set; }

    public int Amount { get; set; }

    public int ItemType { get; set; }

    public int? ItemLevel { get; set; }
}
