using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
  [Table("employeeServices")]
  public class EmployeeService
  {
    [Column("idemployee")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IdEmployee { get; set; }
    public Guid IdEventService { get; set; }
    public double Salary { get; set; }
    public int Status { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }
  }
}
