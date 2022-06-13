using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class LoginUseCase : IBaseUseCase<LoginUsers, Guid>
    {
        private readonly IBaseRepository<LoginUsers, Guid> repository;
        public LoginUseCase(IBaseRepository<LoginUsers, Guid> repository)
        {
            this.repository = repository;
        }
        public LoginUsers Create(LoginUsers entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, el usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<LoginUsers> GetAll()
        {
            return repository.GetAll();
        }

        public LoginUsers GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public LoginUsers Update(LoginUsers entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
