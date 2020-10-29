using CreditCardService.IRepository;
using CreditCardService.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace CreditCardService.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CreditCardController
    {
        private ICreditCardRepository _creditCardRepository;
        public CreditCardController(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetCreditcard();
        }
        public async Task<string> GetCreditcard()
        {
            var cards = await _creditCardRepository.Get();
            return JsonConvert.SerializeObject(cards);

        }
        [HttpGet("{cardId}")]
        public Task<string> Get(string CardId)
        {
            return this.GetCreditcardbyId(CardId);
        }
        public async Task<string> GetCreditcardbyId(string CardId)
        {
            var cards = await _creditCardRepository.Get(CardId) ?? new CreditCard();
            return JsonConvert.SerializeObject(cards);

        }

        [HttpPost]
        public async Task<string> Post([FromBody] CreditCard creditCard)
        {
            await _creditCardRepository.Add(creditCard);
            return "";
        }
        [HttpPut("{cardId}")]
        public async Task<string> Put(string cardId, [FromBody] CreditCard creditCard)
        {
            if (string.IsNullOrEmpty(cardId)) return "Invalid CardID !";
            return await _creditCardRepository.Update(cardId, creditCard);

        }

        [HttpDelete("{cardId}")]
        public async Task<string>Delete(string  cardId)
        {
            if (string.IsNullOrEmpty(cardId)) return "Invalid CardID !";
             await _creditCardRepository.Remove(cardId);
            return "";
        }
    }
}
