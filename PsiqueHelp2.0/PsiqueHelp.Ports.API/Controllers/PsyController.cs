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
    public class PsyController : ControllerBase
    {
        public PsyUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            PsyRepository repository = new PsyRepository(db);
            PsyUseCase service = new PsyUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Psy_Da>> Get()
        {
            PsyUseCase service = CreateService();
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Psy_Da> Get(Guid id)
        {
            PsyUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public ActionResult<Psy_Da> Post([FromBody] Psy_Da psy)
        {
            PsyUseCase service = CreateService();
            var result = service.Create(psy);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Psy_Da psy)
        {
            PsyUseCase service = CreateService();
            psy.Id_User_Psy = id;
            service.Update(psy);

            return Ok("Registro de psicólogo editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PsyUseCase service = CreateService();
            service.Delete(id);
            return Ok("Registro de psicólogo eliminado exitosamente");
        }
    }
}
