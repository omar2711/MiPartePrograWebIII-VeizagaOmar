using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Integrador.Models
{
    [Table("Managements")]
    public class Management
    {
        [Column("Id")]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Column("nameManager")]
        [Display(Name = "nameManager")]
        public string NameManager { get; set; }
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
