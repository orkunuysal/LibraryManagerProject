using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketManager.API.Entities;
using BasketManager.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketManager.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Route("[action]/{userId}", Name = "GetBasket")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> GetBasket(string userId)
        {
            var result = await _basketService.GetBasket(userId);

            return Ok(result);
        }
        [Route("[action]", Name = "AddToBasket")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> AddToBasket(Basket basket)
        {
            var result = await _basketService.AddToBasket(basket);

            return Ok(result);
        }
        [HttpDelete("[action]/{userId}", Name = "EmptyBasket")]
        public async Task<IActionResult> EmptyBasket(string userId)
        {
            await _basketService.EmptyBasket(userId);
            return Ok();
        }

    }
}
