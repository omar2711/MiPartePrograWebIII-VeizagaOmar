using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
  [Table("employees")]
  public class Employee
  {
    [Column("idemployee")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IdEmployee { get; set; }
    public string EmployeeProfile { get; set; }
    public int Status { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }

  }
}
