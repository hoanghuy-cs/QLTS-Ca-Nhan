using QLTS.DAL.Transactions;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using System.Collections.Generic;

namespace QLTS.BLL.Transactions
{
    public class TransactionBLL
    {
        private readonly TransactionDAL _transactionDAL = new TransactionDAL();

        public List<TransactionItemDTO> GetTransactions(TransactionFilter filter = null)
        {
            if (filter == null)
            {
                filter = new TransactionFilter();
            }

            return _transactionDAL.GetTransactions(
                assetId: filter.AssetId,
                type: filter.Type,
                transactionDateFrom: filter.TransactionDateFrom,
                transactionDateTo: filter.TransactionDateTo);
        }

        public int Create(Transaction transaction)
        {
            return _transactionDAL.Create(transaction);
        }

        public int Update(Transaction transaction)
        {
            return _transactionDAL.Update(transaction);
        }

        public void Delete(int id)
        {
            _transactionDAL.Delete(id);
        }
    }
}
