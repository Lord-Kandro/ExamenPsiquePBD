using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class PsyUseCase : IBaseUseCase<Psy_Da, Guid>
    {
        private readonly IBaseRepository<Psy_Da, Guid> repository;
        public PsyUseCase(IBaseRepository<Psy_Da, Guid> repository)
        {
            this.repository = repository;
        }
        public Psy_Da Create(Psy_Da entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, el Psicólogo no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Psy_Da> GetAll()
        {
            return repository.GetAll();
        }

        public Psy_Da GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Psy_Da Update(Psy_Da entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
