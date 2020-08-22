using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingMicroservice.Models;
using OrderProcessingMicroservice.Repositories;

namespace OrderProcessingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessOrderController : BaseController
    {
        private IProcessOrderRepository _repository;

        public ProcessOrderController(IProcessOrderRepository processOrderRepository)
        {
            _repository = processOrderRepository;

        }
        // GET: api/ProcessOrder
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllOrders();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return HttpMessage(ex.Message);
            }

        }

        // GET: api/ProcessOrder/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {

                var result = await _repository.GetOrderByID(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return HttpMessage(ex.Message);
            }
        }

        // POST: api/ProcessOrder
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order orderRuequest)
        {
            try
            {

                var result = await _repository.Add(orderRuequest);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return HttpMessage(ex.Message);
            }
        }

        // PUT: api/ProcessOrder/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Order orderRuequest)
        {
            try
            {

                var result = await _repository.Update(orderRuequest);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return HttpMessage(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _repository.Delete(id);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return HttpMessage(ex.Message);
            }
        }
    }
}