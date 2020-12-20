using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProductManagementSystem.Models
{
    public class ProductDbContext : DbContext
    {
        // Your context has been configured to use a 'Product' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductManagementSystem.Models.Product' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Product' 
        // connection string in the application configuration file.
        public ProductDbContext()
            : base("name=Product")
        {
          
        }

        public System.Data.Entity.DbSet<ProductManagementSystem.Models.Product> Products { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        
    }
    public partial class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name ="Small Image")]
        public string SmallImageUrl { get; set; }
        public string LargeImageUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase SmallImageFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase LargeImageFile { get; set; }

    }
}