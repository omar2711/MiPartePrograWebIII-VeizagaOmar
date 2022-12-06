using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    [Table("Service")]
    public class Service
    {
        [Column("Id")]
        [Display(Name = "idService")]
        public Guid id { get; set; }
        [Column("serviceName")]
        [Display(Name = "serviceName")]
        public string serviceName { get; set; } = null!;

        [Column("description")]
        [Display(Name = "description")]
        public string description { get; set; } = null!;

        [Column("descriptionDetails")]
        [Display(Name = "descriptionDetails")]
        public string descriptionDetails { get; set; } = null!;

        [Column("contactService")]
        [Display(Name = "contactService")]
        public int contactService { get; set; }

        [Column("price")]
        [Display(Name = "price")]
        public decimal price { get; set; }

        [Column("email")]
        [Display(Name = "email")]
        public string email { get; set; } = null!;

        [Column("serviceType")]
        [Display(Name = "serviceType")]
        public string serviceType { get; set; } = null!;


        [Column("status")]
        [Display(Name = "status")]
        public byte status { get; set; } 

    }
}
