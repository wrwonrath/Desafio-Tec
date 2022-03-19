using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.DataStorePluginInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("/[controller]/[action]")]
    [ApiController]
    [LogAttribute]
    public class CardController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly ICardRepository cardRepository;

        public CardController(IJwtAuthenticationManager jwtAuthenticationManager, ICardRepository cardRepository)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.cardRepository = cardRepository;
        }

        // GET: api/<CardController>
        [HttpGet]
        [Route("~/cards")]
        public IEnumerable<Card> Get()
        {
            return cardRepository.GetCards();
        }

        // POST api/<CardController>
        [HttpPost("~/cards")]
        public Card Post([FromBody] CardDto card)
        {
            try
            {
                return cardRepository.AddCard(card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<CardController>/5
        [HttpPut("~/cards/{id}")]
        public ActionResult<Card> Put(Guid id, [FromBody] CardDto card)
        {
            try
            {
                return Ok(cardRepository.UpdateCard(id, card));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<CardController>/5
        [HttpDelete("~/cards/{id}")]
        public ActionResult<IEnumerable<Card>> Delete(Guid id)
        {
            try
            {
                cardRepository.DeleteCard(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(this.Get());
        }

        [AllowAnonymous]
        [HttpPost("~/login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var token = jwtAuthenticationManager.Login(userLoginDto.Login, userLoginDto.Senha);

            if (token == null)
                return Unauthorized();
            else
                return Ok(token);
        }
    }
}
