using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Borrowing
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int LibrarianId { get; set; }

    public int StudentId { get; set; }

    public int BookId { get; set; }

    public string Remarks { get; set; }

    public virtual Item Book { get; set; }

    public virtual User Librarian { get; set; }

    public virtual User Student { get; set; }
}
