using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    [Table("users")]
    public class User
    {
        //[Column("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //[Column("firstname")]
        [BsonElement("firstname")]
        [Display(Name = "firstname")]
        public string FirstName { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("confirmPassword")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
