using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using PsiqueHelp.Core.Application.UseCases;
using PsiqueHelp.Core.Infreaestructure.Repository.Concrete;
using PsiqueHelp.Core.Domain.Models;
using System.Collections.Generic;
using System;

namespace PsiqueHelp.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserUseCase CreateService()
        {
            PsiqueDB db = new PsiqueDB();
            UserDaRepository repository = new UserDaRepository(db);
            UserUseCase service = new UserUseCase(repository);

            return service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserDa>> Get()
        {
            UserUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDa> Get(Guid id) 
        {
            UserUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public ActionResult<UserDa> Post([FromBody] UserDa user)
        {
            UserUseCase service = CreateService();
            var result = service.Create(user);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] UserDa user)
        {
            UserUseCase service = CreateService();
            user.Id_UserDa = id;
            service.Update(user);

            return Ok("El registro de usuario fue editado exitosamente");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UserUseCase service = CreateService();
            service.Delete(id);
            return Ok("Usuario eliminado exitosamente");
        }
    }
}
