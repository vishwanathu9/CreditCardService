using CreditCardService.IRepository;
using CreditCardService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService_Test
{
    class CreditCardControllerFake : ICreditCardRepository
    {
        private readonly List<CreditCard> _creditCard;
        public CreditCardControllerFake()
        {
            _creditCard = new List<CreditCard>()
            {
                new CreditCard() { CardId = "101",
                    CardNumber = "1234567812345678", InitialBalance=121,AccountNumber="9876567643" },
                 new CreditCard() { CardId = "102",
                    CardNumber = "1234676512345678", InitialBalance=123,AccountNumber="7676567643" },
                new CreditCard() { CardId = "103",
                    CardNumber = "1234989812345678", InitialBalance=124,AccountNumber="2346567643" },
            };
        }

        public async Task<IEnumerable<CreditCard>> Get()
        {
            return _creditCard;
        }

        public async Task<CreditCard> Get(string CardId)
        {
            return _creditCard.FirstOrDefault(x => x.CardId == CardId);
        }

        public async Task<DeleteResult> Remove(string cardId)
        {
            var existing = _creditCard.FirstOrDefault(x => x.CardId == cardId);
            if (existing != null)
            {
                _creditCard.Remove(existing);
            }
            return null;
        }
        public async Task<CreditCard> Add(CreditCard creditCard)
        {
            _creditCard.Add(creditCard);
            return creditCard;
        }

        public Task<CreditCard> Update(string cardId, CreditCard creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
