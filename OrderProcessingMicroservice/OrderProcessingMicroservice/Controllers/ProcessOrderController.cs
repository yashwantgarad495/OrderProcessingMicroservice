using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingMicroservice.Repositories;

namespace OrderProcessingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessOrderController : ControllerBase
    {
        private IProcessOrderRepository _repository;

        public ProcessOrderController(IProcessOrderRepository processOrderRepository)
        {
            _repository = processOrderRepository;

        }
    }
}