using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CreditCardService.Models
{
    public class CreditCard
    {
        [BsonId]
        [Required]
        public string CardId { get; set; }
        [Required]
        [MaxLength(16), MinLength(16)]
        public string CardNumber { get; set; }
        public decimal InitialBalance { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [Required]
        [MaxLength(10), MinLength(10)]
        public string AccountNumber { get; set; }
    }
}
