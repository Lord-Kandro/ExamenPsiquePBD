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
    public class NotesController : ControllerBase
    {
        public NotesUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            NotesRepository repository = new NotesRepository(db);
            NotesUseCase service = new NotesUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Notes>> Get()
        {
            NotesUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Notes> Get(Guid id)
        {
            NotesUseCase service = CreateService();
            return Ok(service.GetById(id));
        }


        [HttpPost]
        public ActionResult<Notes> Post([FromBody] Notes nota)
        {
            NotesUseCase service = CreateService();
            var result = service.Create(nota);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Notes nota)
        {
            NotesUseCase service = CreateService();
            nota.id_Note = id;
            service.Update(nota);

            return Ok("La nota se ha editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            NotesUseCase service = CreateService();
            service.Delete(id);
            return Ok("La nota se ha eliminado satisfactoriamente");
        }
    }
}
