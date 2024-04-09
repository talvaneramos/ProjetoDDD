using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApplicationService _funcionarioApplicationService;

        public FuncionarioController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            _funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                _funcionarioApplicationService.Add(model);
                return Ok("Funcionário(a) cadastrado(a) com sucesso. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioEdicaoModel model)
        {
            try
            {
                _funcionarioApplicationService.Update(model);
                return Ok("Funcionário(a) atualizado(a) com sucesso. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _funcionarioApplicationService.Delete(id);
                return Ok("Funcionário(a) excluído(a) com sucesso. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_funcionarioApplicationService.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_funcionarioApplicationService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
