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
    public class MediumsController : ControllerBase
    {
        public MediumsUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            mediumsRepository repository = new mediumsRepository(db);
            MediumsUseCase service = new MediumsUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<mediums>> Get()
        {
            MediumsUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<mediums> Get(Guid id)
        {
            MediumsUseCase service = CreateService();
            return Ok(service.GetById(id));
        }
        [HttpPost]
        public ActionResult<mediums> Post([FromBody] mediums medio)
        {
            MediumsUseCase service = CreateService();
            var result = service.Create(medio);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] mediums medio)
        {
            MediumsUseCase service = CreateService();
            medio.Id_Medios = id;
            service.Update(medio);

            return Ok("El medio se ha editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            MediumsUseCase service = CreateService();
            service.Delete(id);
            return Ok("El medio se ha eliminado satisfactoriamente");
        }
    }
}
