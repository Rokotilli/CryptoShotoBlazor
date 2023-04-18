using AutoMapper;
using BLL.Contracts;
using BLL.DTO;
using DAL.Contracts;
using DAL.Models;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class WalletManager : IWalletManager
    {
        private IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public WalletManager(IUnitOfWork unitOfWork, DTOService _mapperService)
        {
            this.unitOfWork = unitOfWork;
            _mapperService.CreateMapperWallet(ref mapper);
        }

        public async Task<bool> AddCoinForUser(WalletDTO wallet)
        {
            Wallet model = mapper.Map<Wallet>(wallet);

            try
            {
                await unitOfWork.walletRepository.AddAsync(model);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddCountOfCointForUser(WalletDTO wallet, int id)
        {
            try
            {
                Wallet model = mapper.Map<Wallet>(wallet);
                model.Id = id;
                await unitOfWork.walletRepository.UpdateAsync(model);
                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> GetIdByUserNameAndCoin(int UserId, int CoinId)
        {
            var a = await unitOfWork.walletRepository.GetIdByUserNameAndCoin(UserId, CoinId);

            return a;
        }

        public async Task<Pagination<Wallet>> GetWalletsPaginated(int page, int userid)
        {
            var wallets = await unitOfWork.walletRepository.GetWalletsByUserIdPaginated(page, userid);

            return wallets;
        }

        public async Task<List<Wallet>> GetWalletsAllByUser(int userid)
        {
            var wallets = await unitOfWork.walletRepository.GetWalletsByUserId(userid);

            List<Wallet> temp = wallets.ToList();

            return temp;
        }

        public async Task<float> CheckCountOfCoin(int userid, int coinid)
        {
            var count = await unitOfWork.walletRepository.GetCountOfCoin(userid, coinid);

            return count;
        }        
    }
}
