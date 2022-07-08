using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using PsiqueHelp.Core.Application.UseCases;
using PsiqueHelp.Core.Infreaestructure.Repository.Concrete;
using PsiqueHelp.Core.Domain.Models;
using System.Collections.Generic;
using System;
using PsiqueHelp.Core.Infreastructure.Repository.Concrete;

namespace PsiqueHelp.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConTerController : ControllerBase
    {
        public ConterUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            ConTerRepository repository = new ConTerRepository(db);
            ConterUseCase service = new ConterUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConTer>> Get()
        {
            ConterUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ConTer> Get(Guid id)
        {
            ConterUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public ActionResult<ConTer> Post([FromBody] ConTer conte)
        {
            ConterUseCase service = CreateService();
            var result = service.Create(conte);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ConTer conte)
        {
            ConterUseCase service = CreateService();
            conte.ConTer_id = id;
            service.Update(conte);

            return Ok("El contenido fue editado");

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ConterUseCase service = CreateService();
            service.Delete(id);
            return Ok("El Contenido se ha eliminado satisfactoriamente");
        }
    }
}
