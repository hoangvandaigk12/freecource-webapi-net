using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApilApp.Data;
using MyWebApilApp.Models;
using MyWebApilApp.Repositories;

namespace MyWebApilApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComputerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var computers = await _unitOfWork.Repository<Computer>().GetAll();
            if(computers == null)
            {
                return NotFound();
            }
            return Ok(computers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComputer(ComputerModel model) 
        {
            try
            {
                var computer = _mapper.Map<Computer>(model);
                var computerId = await _unitOfWork.Repository<Computer>().Add(computer);
                await _unitOfWork.CommitAsync();
                return Ok(computer);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
