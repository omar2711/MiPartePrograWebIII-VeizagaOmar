using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Integrador.Models
{
    [Table("Owners")]
    public class Owner
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public Guid Id { get; set; }
        [Column("description")]
        [Display(Name = "description")]
        public string Description { get; set; }
        [Column("status")]
        [Display(Name = "status")]
        public byte Status { get; set; }
        [Column("registerDate")]
        [Display(Name = "registerDate")]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        [Column("updateDate")]
        [Display(Name = "updateDate")]
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }
    }
}
