namespace LoginExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ProjectModels : DbContext
    {
        public ProjectModels()
            : base("name=ProjectEntities")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Category> Catagories { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
    }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(10000000, 19999999)]
        public int Id { get; set; }
        public string Email { get; set; }
        [Required, MinLength(4), MaxLength(50)]
        public string DisplayName { get; set; }
        [Required] // NOT NULL
        [Column(TypeName = "char"), StringLength(1)] // CHAR(1)
        public string Gender { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfRegistration { get; set; }
        [Required, Column(TypeName = "char"), StringLength(10)]
        public string PhoneNumber { get; set; }
    }

    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(30000000, 39999999)]
        public int Id { get; set; }
        [Required]
        public virtual User User { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsEmailMarketingAllowed { get; set; }
        public int StripeID { get; set; }
        //public virtual List<WishList> WishList { get; set; }
    }

    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(200000, 299999)]
        public int Id { get; set; }
        [Required]
        public virtual User User { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        [Required]
        public virtual Member Member { get; set; }
        [Required, MinLength(1), MaxLength(255)]
        public string StreetAddress { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string City { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Region { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Country { get; set; }
        [Required, StringLength(5), Column(TypeName = "char")]
        public string PostalCode { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Member Member { get; set; }
        public virtual Employee Aprover { get; set; }
        public DateTime? OrderPlacementDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class OrderItem
    {
        [Key, Column("Game_Id", Order = 0)]
        public int GameId { get; set; }
        [Key, Column("Order_Id", Order = 1)]
        public int OrderId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
        [Required, Range(0, (double)decimal.MaxValue)]
        public decimal SalePrice { get; set; }
    }

    public class WishList
    {
        [Key, Column("Member_Id", Order = 0)]
        public int MemberId { get; set; }
        [Key, Column("Game_Id", Order = 1)]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Member Member { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal SuggestedRetailPrice { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Review> Reviews { get; set; }
        [Required]
        public virtual Platform Platform { get; set; }
        //public virtual List<WishList> WishList { get; set; }
    }

    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(900000000, 999999999)]
        public int Id { get; set; }
        [Required]
        public virtual Game Game { get; set; }
        [Required]
        public virtual Member Author { get; set; }
        public virtual Employee Aprover { get; set; }
        [Required]
        public float Rating { get; set; }
        [MinLength(1), MaxLength(500)]
        public string Subject { get; set; }
        [MinLength(0), MaxLength(4000)]
        public string Body { get; set; }
    }

    public class Friendship
    {
        [Key, Column("Friendee_Id", Order = 0)]
        public int FriendeeId { get; set; }
        [Key, Column("Friender_Id", Order = 1)]
        public int FrienderId { get; set; }
        public virtual Member Friendee { get; set; }
        public virtual Member Friender { get; set; }
        [Required]
        public bool IsFamilyMember { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
    }

    public class Platform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(800, 899)]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(1)]
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
    }

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(8000, 8999)]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(1)]
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
    }

    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Range(4000000, 4999999)]
        public int Id { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [MinLength(0), MaxLength(2000)]
        public string Location { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [MinLength(0), MaxLength(4000)]
        public string Description { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Capacity { get; set; }
    }
}