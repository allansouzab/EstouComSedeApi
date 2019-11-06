using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstouComSede.Domain.Entities;
using EstouComSede.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstouComSedeApi.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RevisaoController : ControllerBase
    {
        private readonly IRevisaoService revisaoService;

        public RevisaoController(IRevisaoService _revisaoService)
        {
            revisaoService = _revisaoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Revisao>> ObterTodas()
        {
            return revisaoService.ObterTodas();
        }

        [HttpPost]
        public ActionResult<RetornoRevisao> Cadastrar([FromBody] Revisao solicitacao)
        {
            return revisaoService.Inserir(solicitacao);
        }

        [HttpPut]
        public ActionResult<RetornoRevisao> Aprovar([FromBody] int id)
        {
            return revisaoService.Aprovar(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<RetornoRevisao> Recusar(int id)
        {
            return revisaoService.Recusar(id);
        }
    }
}