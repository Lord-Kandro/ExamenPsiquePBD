using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class MediumsUseCase : IBaseUseCase<mediums, Guid>
    {
        private readonly IBaseRepository<mediums, Guid> repository;
        public MediumsUseCase(IBaseRepository<mediums, Guid> repository)
        {
            this.repository = repository;
        }
        public mediums Create(mediums entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, este medio no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<mediums> GetAll()
        {
            return repository.GetAll();
        }

        public mediums GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public mediums Update(mediums entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
