using CreditCardService.DbModels;
using CreditCardService.IRepository;
using CreditCardService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardService.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ObjectContext _context = null;
        public CreditCardRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task<CreditCard> Add(CreditCard creditCard)
        {
            await _context.creditCard.InsertOneAsync(creditCard);
            return creditCard;
        }
        public async Task<IEnumerable<CreditCard>> Get()
        {
            return await _context.creditCard.Find(x => true).ToListAsync();
        }

        public async Task<CreditCard> Get(string cardId)
        {
            var creditCard = Builders<CreditCard>.Filter.Eq("CardId", cardId);
            return await _context.creditCard.Find(creditCard).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string cardId)
        {
            return await _context.creditCard.DeleteOneAsync(Builders<CreditCard>.Filter.Eq("CardId", cardId));
        }

        public async Task<CreditCard> Update(string cardId, CreditCard creditCard)
        {
            await _context.creditCard.ReplaceOneAsync(x => x.CardId == cardId, creditCard);
            return creditCard;
        }
    }

}
