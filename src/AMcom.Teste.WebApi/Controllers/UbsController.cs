using System.Collections.Generic;
using AMcom.Teste.Service.DTO;
using AMcom.Teste.Service.Interface;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AMcom.Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UbsController : Controller
    {
        // Implemente um método que seja acessível por HTTP GET e retorne a lista das 5 UBSs
        // (Unidades Básicas de Saúde) mas próximas de um ponto (latitude e longitude) e ordenada
        // por avaliação (da melhor para a pior). O retorno deve ser no formato JSON.
        private readonly IUbsService _ubsService;

        public UbsController(IUbsService ubsService)
        {
            _ubsService = ubsService;
        }

        [HttpGet]
        public IActionResult Get(double latitude, double longitude)
        {
            var result = _ubsService.ObterUbs(latitude, longitude);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }
    }
}
