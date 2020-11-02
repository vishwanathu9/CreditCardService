using CreditCardService.IRepository;
using CreditCardService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;



namespace CreditCardService.Controllers
{
    [EnableCors("MyExposeResponseHeadersPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CreditCardController : Controller
    {
        private ICreditCardRepository _creditCardRepository;
        public CreditCardController(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("AllcardDetails")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var cards = await _creditCardRepository.Get();
            if (cards != null)
            {
                return new OkObjectResult(cards);
            }
            else
            {
                return new NotFoundObjectResult("No Card Details Available !");
            }
        }

        [HttpGet("{cardId}")]
        [Microsoft.AspNetCore.Mvc.Route("GetCardDetailById/{CardId}")]

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string CardId)
        {
            var cards = await _creditCardRepository.Get(CardId) ?? new CreditCard();
            if (cards.CardId != null)
            {
                return new OkObjectResult(cards);
            }
            else
            {
                return new NotFoundObjectResult("Card Not Found !");
            }
        }


        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("InsertCreditCardDetails")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post([FromBody] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                if (Mod10Check.LuhnCheckcompliant(creditCard.CardNumber))
                {
                    var result = await _creditCardRepository.Add(creditCard);
                    if (result != null)
                    {
                        return new OkObjectResult(creditCard);
                    }
                    else
                    {
                        return new BadRequestObjectResult("Bad Request");
                    }
                }
                else
                {
                    return new BadRequestObjectResult("Invalid CreditCard");
                }
            }
            else
            {
                return new BadRequestObjectResult("Invalid Input ");
            }

        }
        [HttpPut("{cardId}")]
        [Microsoft.AspNetCore.Mvc.Route("UpdateCreditCardDetails/{cardId}")]
        public async Task<IActionResult> Put(string cardId, [FromBody] CreditCard creditCard)
        {
            if (string.IsNullOrEmpty(cardId)) return new NotFoundObjectResult("Invalid CardID !");
            if (ModelState.IsValid)
            {
                if (Mod10Check.LuhnCheckcompliant(creditCard.CardNumber))
                {
                    var result = await _creditCardRepository.Update(cardId, creditCard);
                    if (result != null)
                    {
                        return new OkObjectResult(creditCard);
                    }
                    else
                    {
                        return new BadRequestObjectResult("Bad Request");
                    }
                }
                else
                {
                    return new BadRequestObjectResult("Invalid CreditCard");
                }
            }
            else
            {
                return new BadRequestObjectResult("Bad Request");
            }

        }

        [HttpDelete("{cardId}")]
        [Microsoft.AspNetCore.Mvc.Route("Delete/{cardId}")]
        public async Task<IActionResult> Delete([FromRoute] string cardId)
        {
            if (string.IsNullOrEmpty(cardId)) return new BadRequestObjectResult("Invalid CardID !");
            await _creditCardRepository.Remove(cardId);
            return new OkObjectResult("");
        }
    }
}
