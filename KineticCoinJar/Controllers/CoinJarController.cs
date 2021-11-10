using KineticCoinJar.DataAccess;
using KineticCoinJar.Messages;
using KineticCoinJar.Models;
using KineticCoinJar.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    
    {
        private ILogger<CoinJarController> _logger;

        public IMemoryCache MemoryCache { get; }

        private IMemoryCache memoryCache;
        private ApplicationDbContext context;
        private CoinJar coinJar;
        private IMediator mediator;

        public CoinJarController(ILogger<CoinJarController> logger, CoinJar coinJar, IMemoryCache memoryCache, ApplicationDbContext context, IMediator mediator)
        {
            this._logger = logger;
            this.MemoryCache = memoryCache;
            this.context = context;
            this.coinJar = coinJar;
            this.mediator = mediator;
        }
      
        [HttpGet]
        public decimal Amount()
        {
            return this.coinJar.GetTotalAmount();
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoin()
        {
            var cacheKey = "coinList";
            if (!memoryCache.TryGetValue(cacheKey, out List<Coin> coinList))
            {
                coinList = await context.Coins.ToListAsync();
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                memoryCache.Set(cacheKey, coinList, cacheExpiryOptions);
            }
            return Ok(coinList);
        }


        [HttpPost]
        public async Task<IActionResult> AddCoin([FromBody] Coin coin)
        {

            var cacheKey = "coinList";
            if (!memoryCache.TryGetValue(cacheKey, out List<Coin> coinList))
            {
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                memoryCache.Set(cacheKey, coinList, cacheExpiryOptions);
            }
            context.Coins.Add(coin);
            await context.SaveChangesAsync();
            return Ok(coinList);
        }
        [HttpPut]
        [Route("ResetJar")]
        public Task ResetJar()
        {
            return mediator.Send(new ResetCoinJarCommand());
        } 
    }
}