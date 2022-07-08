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
    public class ForumController : ControllerBase
    {
        public ForumUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            ForumRepository repository = new ForumRepository(db);
            ForumUseCase service = new ForumUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Forum>> Get()
        {
            ForumUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Forum> Get(Guid id)
        {
            ForumUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public ActionResult<Forum> Post([FromBody] Forum foro)
        {
            ForumUseCase service = CreateService();
            var result = service.Create(foro);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Forum foro)
        {
            ForumUseCase service = CreateService();
            foro.Id_Forum = id;
            service.Update(foro);

            return Ok("Se ha hecho una correcta edición del foro");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ForumUseCase service = CreateService();
            service.Delete(id);
            return Ok("El Foro se ha eliminado satisfactoriamente");
        }
    }
}
