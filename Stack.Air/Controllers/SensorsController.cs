using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private ILogger<SensorsController> _logger;

        public SensorsController(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger<SensorsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensorsAsync()
        {
            var sensors = await _repository.Sensors.GetAllIncludeAsync();
            var sensorsDto = _mapper.Map<IEnumerable<GetSensorDto>>(sensors);
            return Ok(sensorsDto);
        }
    }
}