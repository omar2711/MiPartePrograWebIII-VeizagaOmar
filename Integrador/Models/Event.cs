using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    [Table("events")]
    public class Event
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        public double TotalCost { get; set; }
        public short Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
