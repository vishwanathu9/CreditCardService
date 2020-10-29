using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CreditCardService.Models
{
    public class CreditCard
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
      
        public string  CardId { get; set; }
        [Required]
        [MaxLength(16), MinLength(16)]
        
        public string CardNumber { get; set; }
       
        public decimal InitialBalance { get; set; }
    }
}
