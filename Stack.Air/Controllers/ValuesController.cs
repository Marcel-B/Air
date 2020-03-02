using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IRepositoryWrapper _respository;
        private IMapper _mapper;
        private ILogger<ValuesController> _logger;

        public ValuesController(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger<ValuesController> logger)
        {
            _respository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{sensorId}/{hours}")]
        public async Task<IActionResult> GetValuesBySensorIdTimeSpanHouryAsync(
            [FromRoute] long sensorId,
            [FromRoute] long hours)
        {
            var values = await _respository.Values.GetBySensorIdByHoursAsync(sensorId, hours);
            var retValues = _mapper.Map<IEnumerable<ChartValueDto>>(values);
            return Ok(retValues);
        }
    }
}