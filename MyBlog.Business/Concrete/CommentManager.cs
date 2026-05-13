using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
    public class CommentManager: ICommentService
    {

        private readonly IConmmentDal _commentDal;

        public CommentManager(IConmmentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<CommentDto> GetComments()
        {
            throw new NotImplementedException();
        }

        public List<CommentDto> GetCommentsByPostId(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
