using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.models;

public partial class LiberiansDbContext : DbContext
{
    public LiberiansDbContext()
    {
    }

    public LiberiansDbContext(DbContextOptions<LiberiansDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<AddNewRequest> AddNewRequests { get; set; }

    public virtual DbSet<BorrowApprovalRequest> BorrowApprovalRequests { get; set; }

    public virtual DbSet<BorrowRequest> BorrowRequests { get; set; }

    public virtual DbSet<Borrowing> Borrowings { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemTag> ItemTags { get; set; }

    public virtual DbSet<LibrarianPermission> LibrarianPermissions { get; set; }

    public virtual DbSet<PhysicalItem> PhysicalItems { get; set; }

    public virtual DbSet<PhysicalItemTag> PhysicalItemTags { get; set; }

    public virtual DbSet<RatingNote> RatingNotes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SearchLog> SearchLogs { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=dpg-cqr3eqbv2p9s73bdjt6g-a.oregon-postgres.render.com;Database=foyershteindb;Username=foyershtein;Password=WRfkTuKOhYDDJHXy1kwvPHa4fBdrrn4O;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Activity_Logs");

            entity.HasIndex(e => e.UserId1NavigationUserId, "IX_Activity_Logs_UserId1NavigationUserId");

            entity.Property(e => e.Activity).IsRequired();

            entity.HasOne(d => d.UserId1NavigationUser).WithMany(p => p.ActivityLogs).HasForeignKey(d => d.UserId1NavigationUserId);
        });

        modelBuilder.Entity<AddNewRequest>(entity =>
        {
            entity.Property(e => e.AccompanyingMaterial).IsRequired();
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Edition).IsRequired();
            entity.Property(e => e.HebrewPublicationYear).IsRequired();
            entity.Property(e => e.Language).IsRequired();
            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(225);
            entity.Property(e => e.Series).IsRequired();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<BorrowApprovalRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("Borrow_Approval_Requests");

            entity.HasIndex(e => e.UserId, "IX_Borrow_Approval_Requests_UserId");

            entity.Property(e => e.FromDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UntilDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowApprovalRequests).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BorrowRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("Borrow_Requests");

            entity.HasIndex(e => e.ItemId, "IX_Borrow_Requests_ItemId");

            entity.HasIndex(e => e.UserId, "IX_Borrow_Requests_UserId");

            entity.HasOne(d => d.Item).WithMany(p => p.BorrowRequests).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.User).WithMany(p => p.BorrowRequests).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Borrowing>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_Borrowings_BookId");

            entity.HasIndex(e => e.LibrarianId, "IX_Borrowings_LibrarianId");

            entity.HasIndex(e => e.StudentId, "IX_Borrowings_StudentID");

            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).IsRequired();
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrowings).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Librarian).WithMany(p => p.BorrowingLibrarians).HasForeignKey(d => d.LibrarianId);

            entity.HasOne(d => d.Student).WithMany(p => p.BorrowingStudents).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.ConversationId).HasName("pk_convesetion");

            entity.ToTable("Conversation");

            entity.HasIndex(e => e.UserId2, "fki_UserId2");

            entity.Property(e => e.Text).IsRequired();
            entity.Property(e => e.Time).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.UserId1Navigation).WithMany(p => p.ConversationUserId1Navigations)
                .HasForeignKey(d => d.UserId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user1");

            entity.HasOne(d => d.UserId2Navigation).WithMany(p => p.ConversationUserId2Navigations)
                .HasForeignKey(d => d.UserId2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userid2");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.FilePath).IsRequired();
            entity.Property(e => e.Note).HasMaxLength(225);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<ItemTag>(entity =>
        {
            entity.ToTable("ItemTag");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemTags).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.Tag).WithMany(p => p.ItemTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<LibrarianPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("librarian_permissions_pkey");

            entity.ToTable("librarian_permissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Permissions)
                .IsRequired()
                .HasColumnName("permissions");

            entity.HasOne(d => d.User).WithMany(p => p.LibrarianPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserId");
        });

        modelBuilder.Entity<PhysicalItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("physicalitem_pkey");

            entity.ToTable("PhysicalItem");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('physicalitem_id_seq'::regclass)");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<PhysicalItemTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("physicalitemtag_pkey");

            entity.ToTable("PhysicalItemTag");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('physicalitemtag_id_seq'::regclass)");

            entity.HasOne(d => d.PhysicalItem).WithMany(p => p.PhysicalItemTags)
                .HasForeignKey(d => d.PhysicalItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("physicalitemtag_physicalitemid_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.PhysicalItemTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("physicalitemtag_tagid_fkey");
        });

        modelBuilder.Entity<RatingNote>(entity =>
        {
            entity.ToTable("Rating_Notes");

            entity.HasIndex(e => e.ItemId, "IX_Rating_Notes_ItemId");

            entity.HasIndex(e => e.UserId, "IX_Rating_Notes_UserId");

            entity.HasOne(d => d.Item).WithMany(p => p.RatingNotes).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.User).WithMany(p => p.RatingNotes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasIndex(e => e.GeneratedByNavigationUserId, "IX_Reports_GeneratedByNavigationUserId");

            entity.Property(e => e.ReportData).IsRequired();
            entity.Property(e => e.ReportName).IsRequired();

            entity.HasOne(d => d.GeneratedByNavigationUser).WithMany(p => p.Reports).HasForeignKey(d => d.GeneratedByNavigationUserId);
        });

        modelBuilder.Entity<SearchLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Search_Logs");

            entity.HasIndex(e => e.UserId, "IX_Search_Logs_UserId");

            entity.Property(e => e.SearchQuery).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.SearchLogs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Activity).HasDefaultValueSql("true");
            entity.Property(e => e.Fname).IsRequired();
            entity.Property(e => e.Megama).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.PhoneNumber).IsRequired();
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.Sname).IsRequired();
            entity.Property(e => e.Tz)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("tz");
        });
        modelBuilder.HasSequence("librarian_permissions_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
