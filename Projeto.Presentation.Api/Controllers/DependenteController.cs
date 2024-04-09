using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenteController : ControllerBase
    {
        private readonly IDependenteApplicationService _dependenteApplicationService;

        public DependenteController(IDependenteApplicationService dependenteApplicationService)
        {
            _dependenteApplicationService = dependenteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(DepedenteCadastroModel model)
        {
            try
            {
                _dependenteApplicationService.Add(model);
                return Ok("Dependente adicionado(a) com sucesso. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(DependenteEdicaoModel model)
        {
            try
            {
                _dependenteApplicationService.Update(model);
                return Ok("Dependente atualizado(a) com sucesso. ");
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
                _dependenteApplicationService.Delete(id);
                return Ok("Dependente excluído(a) com sucesso");
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
                return Ok(_dependenteApplicationService.GetAll().ToList());                
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
                return Ok(_dependenteApplicationService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }    
        
    }
}
