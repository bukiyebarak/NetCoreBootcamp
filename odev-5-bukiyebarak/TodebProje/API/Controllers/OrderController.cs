﻿using Business.Abstract;
using DTO.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService orderService)
        {
            _service = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }


        [HttpPost]
        public IActionResult Post(CreateOrderRequest order)
        {
            var response = _service.Insert(order);
            return Ok(response);
        }

     
        [HttpPut]
        public IActionResult Put(UpdateOrderRequest order)
        {
            var response = _service.Update(order);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Order order)
        {
            var response = _service.Delete(order);
            return Ok(response);
        }

    }
}
