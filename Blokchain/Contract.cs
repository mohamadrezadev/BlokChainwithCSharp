using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blokchain
{
    /// <summary>
	/// BlockChain
	/// </summary>
	public class Contract : object
    {


        public Contract(int initialDifficulty = 0,
            double currentMiningReward = 0,
            double currentMinimumTransactionFee = 0) : base()
        {
            CurrentDifficulty = initialDifficulty;
            CurrentMinimumTransactionFee = currentMinimumTransactionFee;
            CurrentMiningReward = currentMiningReward;
            _blocks =
                new List<Block>();
        }
        public int CurrentDifficulty { get; set; }
        public double CurrentMiningReward { get; set; }

        public double CurrentMinimumTransactionFee { get; set; }

        // **********
        private readonly List<Block> _blocks;

        public IReadOnlyList<Block> Blocks
        {
            get
            {
                return _blocks.AsReadOnly();
            }
        }
        // **********
        private List<Transaction> _pendingTransactions;

        /// <summary>
        /// Memory Pool = MemPool
        /// </summary>
        public IReadOnlyList<Transaction> PendingTransactions
        {
            get
            {
                return _pendingTransactions.AsReadOnly();
            }
        }
        // **********

        public bool AddTransaction(Transaction transaction)
        {
            if (transaction.Fee < CurrentMinimumTransactionFee)
            {
                return false;
            }

            switch (transaction.Type)
            {
                case TransactionType.Withdrawing:
                case TransactionType.Transferring:
                    {
                        double senderBalance =
                            GetAccountBalance(accountAddress: transaction.SenderAccountAddress!);

                        if (senderBalance < transaction.Amount)
                        {
                            return false;
                        }

                        break;
                    }
            }

            _pendingTransactions.Add(transaction);

            return true;
        }
        private Block GetNewBlock()
        {
            Block? PreviousBlock = null;
            int blockNumber = Blocks.Count;

            if (blockNumber != 0)
            {
                PreviousBlock = Blocks[blockNumber - 1];
            }

            var newBlock =new Block(blockNumber: blockNumber,
                                difficulty: CurrentDifficulty, previousBlock: PreviousBlock?.MixHash);

            return newBlock;
        }
        // **********
        // **********
        public Block Mine()
        {
            var block =GetNewBlock();

            foreach (var transaction in PendingTransactions)
            {
                block.AddTransaction(transaction);
            }

            _pendingTransactions =new List<Transaction>();

            block.Mine();

            _blocks.Add(block);

            return block;
        }
        // **********
        public bool IsValid()
        {
           
            for (int index = 1; index <= Blocks.Count - 1; index++)
            {
                var currentBlock = Blocks[index];
                var PreviousBlock = Blocks[index - 1];
               
                var currentMixHash =currentBlock.CalculateMixHash();

                if (currentBlock.MixHash != currentMixHash)
                {
                    return false;
                }

                if (currentBlock.PreviousHash != PreviousBlock.MixHash)
                {
                    return false;
                }
            }

            return true;
        }

        public float GetAccountBalance(string accountAddress)
        {
            if (IsValid() == false)
            {
                return 0;
            }

            float balance = 0;

            foreach (var block in _blocks)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.RecipientAccountAddress == accountAddress)
                    {
                        balance +=transaction.Amount;
                    }

                    if (transaction.SenderAccountAddress == accountAddress)
                    {
                        balance -=transaction.Amount;
                    }
                }
            }

           
            // **********
            foreach (var transaction in _pendingTransactions)
            {
                if (transaction.SenderAccountAddress == accountAddress)
                {
                    balance -=transaction.Amount;
                }
            }
            // **********

            return balance;
        }


        public override string ToString()
        {
            string result =
                Infrastructure.Utility
                .ConvertObjectToJson(theObject: this);

            return result;
        }
    }
}
