using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
  [Table("guests")]
  public class Guest
  {
    [Column("idguest")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IdGuest { get; set; }
    public Guid IdEvent { get; set; }
    public int Status { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }

  }
}
