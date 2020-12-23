namespace Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookWebDataProvider : DbContext
    {
        public BookWebDataProvider()
            : base("name=BookWebDataProvider")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.groupid)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.idCustomer);

            modelBuilder.Entity<AccountGroup>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<AccountGroup>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountGroup>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AccountGroup)
                .HasForeignKey(e => e.groupid);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Bill)
                .HasForeignKey(e => e.idBill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.idCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.Discount)
                .HasForeignKey(e => e.idDiscount);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.typeid);
        }

    }
}
