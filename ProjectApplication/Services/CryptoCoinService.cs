using Microsoft.EntityFrameworkCore;
using ProjectApplication.Contexts;
using ProjectApplication.Contexts.Model;

namespace ProjectApplication.Repositories
{
    public class CryptoCoinService
    {
        public readonly CryptoContext _CryptoCoinContext;

        public CryptoCoinService(CryptoContext CryptoCoinContext)
        {
            _CryptoCoinContext = CryptoCoinContext;
        }

        public async Task<Coin> Create(Coin coin)
        {
            _CryptoCoinContext.Coins.Add(coin);
            await _CryptoCoinContext.SaveChangesAsync();
            return coin;
        }

        public async Task Delete(int id)
        {
            var coinToDelete = await _CryptoCoinContext.Coins.FindAsync(id);
            _CryptoCoinContext.Coins.Remove(coinToDelete);
            await _CryptoCoinContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Coin>> Get()
        {
           return await _CryptoCoinContext.Coins.ToListAsync();
        }

        public async Task<Coin> Get(string symbol)
        {
            var response = await _CryptoCoinContext.Coins.Where(x => x.Symbol == symbol).FirstOrDefaultAsync();

            if (response == null)
                return new Coin();
            else
                return response;
        }

        public async Task<Coin> Get(int id)
        {
            return await _CryptoCoinContext.Coins.FindAsync(id);
        }


        public async Task Update(Coin coin)
        {
            _CryptoCoinContext.Entry(coin).State = EntityState.Modified;
            await _CryptoCoinContext.SaveChangesAsync();
        }
    }
}
