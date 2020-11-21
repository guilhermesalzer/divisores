using DivisoresNumerosPrimosLocalizaApi.Fronteiras;
using DivisoresNumerosPrimosLocalizaApi.Fronteiras.CalcularDivisoresExecutor;
using DivisoresNumerosPrimosLocalizaApi.Fronteiras.CalcularDivisoresPrimosExecutor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DivisoresNumerosPrimosLocalizaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisoresController : ControllerBase
    {
        private readonly ICalcularDivisoresExecutor calcularDivisoresExecutor;
        private readonly ICalcularDivisoresPrimosExecutor calcularDivisoresPrimosExecutor;
        
        public DivisoresController(ICalcularDivisoresExecutor calcularDivisoresExecutor, ICalcularDivisoresPrimosExecutor calcularDivisoresPrimosExecutor)
        {
            this.calcularDivisoresExecutor = calcularDivisoresExecutor;
            this.calcularDivisoresPrimosExecutor = calcularDivisoresPrimosExecutor;
        }

        [HttpGet("{numeroEscolhido}/divisoresPrimos")]
        public ActionResult Get(int numeroEscolhido)
        {
            if (numeroEscolhido < 0)
            {
                return BadRequest("Numero deve ser maior que zero!");
            }

            var requisicaoCalcularPrimosDivisores = new CalcularDivisoresPrimosRequisicao { NumeroEscolhido = Convert.ToInt32(numeroEscolhido) };
            CalcularDivisoresPrimosResultado resultadoCalcularDivisoresPrimos = calcularDivisoresPrimosExecutor.Executar(requisicaoCalcularPrimosDivisores);

            if (resultadoCalcularDivisoresPrimos.DivisoresPrimosDoNumeroEscolhido.Any() && resultadoCalcularDivisoresPrimos.DivisoresPrimosDoNumeroEscolhido.Count > 0)
            {
                return Ok(resultadoCalcularDivisoresPrimos.DivisoresPrimosDoNumeroEscolhido);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{numeroEscolhido}/todosDivisores")]
        public ActionResult GetAll(int numeroEscolhido)
        {
            if (numeroEscolhido < 0)
            {
                return BadRequest("Numero deve ser maior que zero!");
            }

            var requisicaoCalcularDivisores = new CalcularDivisoresRequisicao { NumeroEscolhido = Convert.ToInt32(numeroEscolhido) };
            CalcularDivisoresResultado resultadoCalcularDivisores = calcularDivisoresExecutor.Executar(requisicaoCalcularDivisores);

            if (resultadoCalcularDivisores.DivisoresDoNumeroEscolhido.Any() && resultadoCalcularDivisores.DivisoresDoNumeroEscolhido.Count > 0)
            {
                return Ok(resultadoCalcularDivisores.DivisoresDoNumeroEscolhido);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
