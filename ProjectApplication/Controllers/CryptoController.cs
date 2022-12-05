using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Contexts;
using ProjectApplication.Contexts.Model;
using ProjectApplication.Repositories;
using ProjectApplication.Services.Model;

namespace ProjectApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]

    public class CryptoController : ControllerBase
    {
        private readonly CryptoCoinService _cryptoService;

        public CryptoController(CryptoContext CryptoContext)
        {
            _cryptoService = new CryptoCoinService(CryptoContext);
        }

        [HttpGet]
        public async Task<IEnumerable<Coin>> GetCoins()
        {
            return await _cryptoService.Get();
        }

        [HttpGet("symbol")]
        public async Task<ActionResult<Coin>> GetCoins(string symbol)
        {
            var response = await _cryptoService.Get(symbol);

            if (response == null)
                return BadRequest();

            return await _cryptoService.Get(symbol);
        }

        [HttpPost]
        public async Task<ActionResult<Coin>> PostCoins([FromBody] CoinBody coin)
        {
            var coinBody = new Coin
            {
                Current_Price= coin.Current_Price,
                ImageLink= coin.ImageLink,
                Market_Cap = coin.Market_Cap,
                Name = coin.Name,
                Symbol= coin.Symbol,
            };

            var newCoin = await _cryptoService.Create(coinBody);
            return CreatedAtAction(nameof(PostCoins),new {id = newCoin.Id},newCoin);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete (int id)
        {
            var bookToDelete = await _cryptoService.Get(id);

            if (bookToDelete == null)
                return NotFound();

            await _cryptoService.Delete(bookToDelete.Id);
            return StatusCode(200);
        }

        [HttpPut]
        public async Task<ActionResult> PutCoins(int id, [FromBody] Coin coin)
        {
            if (id != coin.Id)
                return BadRequest();

            await _cryptoService.Update(coin);
            return StatusCode(200);
        }




    };
}