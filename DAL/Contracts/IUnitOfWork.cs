using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUnitOfWork
    {
        public CSContext databaseContext { get; }

        public ICoinRepository coinRepository { get; }

        public IWalletRepository walletRepository { get; }

        public IFollowerRepository followerRepository { get; }

        public ILikeRepository likeRepository { get; }

        public IUserRepository userRepository { get; }

        public ICommentRepository commentRepository { get; }

        public INewsRepository newsRepository { get; }

        public IPostRepository postRepository { get; }

        public IRoleRepository roleRepository { get; }

        Task SaveChangesAsync();
    }
}
