using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    [Table("eventroom")]
    public class EventRoom
    {
        public Guid Id { get; set; }
        public Guid OwnerID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Garage")]
        public short Garage { get; set; }
        public short Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
