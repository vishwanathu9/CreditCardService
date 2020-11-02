using CreditCardService.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardService.IRepository
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> Get();
        Task<CreditCard> Get(string CardId);
        Task<CreditCard> Add(CreditCard creditCard);
        Task<CreditCard> Update(string cardId, CreditCard creditCard);
        Task<DeleteResult> Remove(string cardId);


    }
}
