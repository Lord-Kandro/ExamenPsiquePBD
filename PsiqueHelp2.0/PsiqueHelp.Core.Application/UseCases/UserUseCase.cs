using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;


namespace PsiqueHelp.Core.Application.UseCases
{
    public class UserUseCase : IBaseUseCase<UserDa, Guid>
    {
        private readonly IBaseRepository<UserDa, Guid> repository;
        public UserUseCase(IBaseRepository<UserDa, Guid> repository)
        {
            this.repository = repository;
        }

        public UserDa Create(UserDa entity)
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

        public List<UserDa> GetAll()
        {
            return repository.GetAll();
        }

        public UserDa GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public UserDa Update(UserDa entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
