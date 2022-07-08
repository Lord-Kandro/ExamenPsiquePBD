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
    public class LoginController : ControllerBase
    {
        public LoginUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            LoginUserRepository repository = new LoginUserRepository(db);
            LoginUseCase service = new LoginUseCase(repository);

            return service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LoginUsers>> Get()
        {
            LoginUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<LoginUsers> Get(Guid id)
        {
            LoginUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public ActionResult<LoginUsers> Post([FromBody] LoginUsers login)
        {
            LoginUseCase service = CreateService();
            var result = service.Create(login);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] LoginUsers login)
        {
            LoginUseCase service = CreateService();
            login.Id_Login = id;
            service.Update(login);

            return Ok("El login del usuario se ha editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            LoginUseCase service = CreateService();
            service.Delete(id);
            return Ok("El login de usuario se ha eliminado satisfactoriamente");
        }
    }
}
