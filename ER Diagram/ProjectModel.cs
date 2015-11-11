namespace LoginExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class ProjectModels : DbContext
    {
        public ProjectModels()
            : base("name=ProjectEntities")
        {
        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Category> Catagories { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string DisplayName { get; set; }
        [Required] // NOT NULL
        [Column(TypeName = "char"), StringLength(1)] // CHAR(1)
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsEmailMarketingAllowed { get; set; }
        public int StripeID { get; set; }
        public virtual Game WishList { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public virtual Member Member { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Member Member { get; set; }
        public virtual Employee Aprover { get; set; }
        public DateTime OrderPlacementDate { get; set; }
        public DateTime ShipDate { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class OrderItem
    {
        [Key]
        public virtual Game Game { get; set; }
        [Key]
        public virtual Order Order { get; set; }
        public decimal SalePrice { get; set; }
    }

    public class WishList
    {
        [Key, Column(Order = 0)]
        public int MemberId { get; set; }
        [Key, Column(Order = 1)]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Member Member { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal SuggestedRetailPrice { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual Platform Platform { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Member Author { get; set; }
        public virtual Employee Aprover { get; set; }
        public float Rating { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public virtual Member Friendee { get; set; }
        public virtual Member Friender { get; set; }
        public bool IsFamilyMember { get; set; }
        public bool IsAccepted { get; set; }
    }

    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}