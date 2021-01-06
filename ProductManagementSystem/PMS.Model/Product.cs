using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PMS.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Name")]
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        [Display(Name = "Category")]
        
        public string CategoryName { get; set; }
        [Required(ErrorMessage ="Please select category.")]
        public int CategoryId { get; set; }
        public List<Models.Category> CategoryList { get; set; } 

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        
        [Display(Name = "Small Image")]
        public string SmallImageURL { get; set; }
        [Display(Name = "Large Image")]
        public string LargeImageURL { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }

        
        [Display(Name = "Small Image")]
        public HttpPostedFileBase SmallImageFile { get; set; }
        [Display(Name = "Large Image")]
        public HttpPostedFileBase LargeImageFile { get; set; }
    }



}
