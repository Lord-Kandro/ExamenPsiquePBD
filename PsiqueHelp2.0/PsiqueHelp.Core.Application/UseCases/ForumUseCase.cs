using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class ForumUseCase : IBaseUseCase<Forum, Guid>
    {
        private readonly IBaseRepository<Forum, Guid> repository;
        public ForumUseCase(IBaseRepository<Forum, Guid> repository)
        {
            this.repository = repository;
        }
        public Forum Create(Forum entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error, el foro no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Forum> GetAll()
        {
            return repository.GetAll();
        }

        public Forum GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Forum Update(Forum entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
