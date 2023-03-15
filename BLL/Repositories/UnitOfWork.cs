using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public CSContext databaseContext { get; }

    public ICoinRepository coinRepository { get; }
    public ICommentRepository commentRepository { get; }
    public IFollowerRepository followerRepository { get; }
    public ILikeRepository likeRepository { get; }
    public INewsRepository newsRepository { get; }
    public IPostRepository postRepository { get; }
    public IRoleRepository roleRepository { get; }
    public IUserRepository userRepository { get; }
    public IWalletRepository walletRepository { get; }

    public UnitOfWork(
        CSContext databaseCOntext
        , ICoinRepository coinRepository
        , ICommentRepository commentRepository
        , IFollowerRepository followerRepository
        , ILikeRepository likeRepository
        , INewsRepository newsRepository
        , IPostRepository postRepository
        , IRoleRepository roleRepository
        , IUserRepository userRepository
        , IWalletRepository walletRepository
    )
    {
        this.databaseContext = databaseCOntext;
        this.coinRepository = coinRepository;
        this.commentRepository = commentRepository;
        this.followerRepository = followerRepository;
        this.likeRepository = likeRepository;
        this.newsRepository = newsRepository;
        this.postRepository = postRepository;
        this.roleRepository = roleRepository;
        this.userRepository = userRepository;
        this.walletRepository = walletRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}