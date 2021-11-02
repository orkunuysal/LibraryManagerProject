using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BasketManager.API.Entities;
using BasketManager.API.Service;
using EventBus.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketManager.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(IBasketService basketService, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _basketService = basketService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
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
        [Route("[action]", Name = "BasketCheckout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Basket>> BasketCheckout([FromBody]Basket basket )
        {
            var result = await _basketService.GetBasket(basket.UserId);
            if(basket == null)
            {
                return BadRequest();
            }

            var eventMessage = _mapper.Map<ReservationExecutedEvent>(basket);
            eventMessage.UserId = basket.UserId;

            await _publishEndpoint.Publish<ReservationExecutedEvent>(eventMessage);

            await _basketService.EmptyBasket(basket.UserId);

            return Accepted(result);
        }
    }
}
