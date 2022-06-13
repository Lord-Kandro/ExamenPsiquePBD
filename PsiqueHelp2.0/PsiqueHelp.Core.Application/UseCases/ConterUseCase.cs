using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class ConterUseCase : IBaseUseCase<ConTer, Guid>
    {
        private readonly IBaseRepository<ConTer, Guid> repository;
        public ConterUseCase(IBaseRepository<ConTer, Guid> repository)
        {
            this.repository = repository;
        }
        public ConTer Create(ConTer entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, el contenido no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<ConTer> GetAll()
        {
            return repository.GetAll();
        }

        public ConTer GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public ConTer Update(ConTer entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
