using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class NotesUseCase : IBaseUseCase<Notes, Guid>
    {
        private readonly IBaseRepository<Notes, Guid> repository;
        public NotesUseCase(IBaseRepository<Notes, Guid> repository)
        {
            this.repository = repository;
        }
        public Notes Create(Notes entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, la nota no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Notes> GetAll()
        {
            return repository.GetAll();
        }

        public Notes GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Notes Update(Notes entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
