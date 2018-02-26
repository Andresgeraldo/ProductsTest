namespace ProductsTest.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Requerido")]
        [MaxLength(50, ErrorMessage = "El Campo {0} solo puede tener {1} caracteres de longitud")]
        [Index("Product_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        public double Stock { get; set; }

        [Display(Name = "Ultima Compra?")]
        [DataType(DataType.Date)]
        public DateTime LastPurchase { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
