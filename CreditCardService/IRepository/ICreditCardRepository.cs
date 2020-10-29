using CreditCardService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.IRepository
{
    public  interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> Get();
        Task<CreditCard> Get(string CardId);
        Task Add(CreditCard creditCard);
        Task<string> Update(string cardId, CreditCard creditCard);
        Task<DeleteResult> Remove(string cardId);


    }
}
