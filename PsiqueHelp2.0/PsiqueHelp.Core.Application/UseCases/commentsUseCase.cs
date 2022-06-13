using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Application.Interfaces;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;

namespace PsiqueHelp.Core.Application.UseCases
{
    public class commentsUseCase : IDetailUseCase<Forum, Guid>
    {
        private  readonly IBaseRepository<Forum, Guid> forumRepository;
        private readonly IDetailRepository<comments, Guid> commentRepository;
        
        public commentsUseCase(
            IBaseRepository<Forum, Guid> forumRepository,
            IDetailRepository<comments, Guid> commentRepository
        )
        {
            this.forumRepository = forumRepository;
            this.commentRepository = commentRepository;
        }
        public void Cancel(Guid entityId)
        {
            commentRepository.Cancel(entityId);
            commentRepository.saveAllChanges();
        }

        public Forum Create(Forum forum)
        {
            var createdForum = forumRepository.Create(forum);
            forum.Coments.ForEach(detail =>
            {
                commentRepository.Create(detail);

            });
            forumRepository.saveAllChanges();
            return createdForum;
        }
    }
}
