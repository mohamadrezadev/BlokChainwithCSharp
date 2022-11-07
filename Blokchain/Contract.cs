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


        public Contract(int initialDifficulty = 0) : base()
        {
            CurrentDifficulty = initialDifficulty;
            _blocks =
                new List<Block>();
        }
        public int CurrentDifficulty { get; set; }


        public Contract() : base()
        {
            _blocks =
                new List<Block>();
        }


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

        public void AddTransactionAndMineBlock(Transaction transaction)
        {
            Block? parentBlock = null;
            int blockNumber = Blocks.Count;

            if (blockNumber != 0)
            {
                parentBlock =
                    Blocks[blockNumber - 1];
            }

            //var newBlock =
            //    new Block(blockNumber: blockNumber,
            //    transaction: transaction, parentHash: parentBlock?.MixHash);
            // **********
            var newBlock =
                new Block(blockNumber: blockNumber, transaction: transaction,
                difficulty: CurrentDifficulty, parentHash: parentBlock?.MixHash);
            // **********



            newBlock.Mine();

            _blocks.Add(newBlock);
        }
        public bool IsValid()
        {
           
            for (int index = 1; index <= Blocks.Count - 1; index++)
            {
                var currentBlock = Blocks[index];
                var parentBlock = Blocks[index - 1];
               
                var currentMixHash =
                    currentBlock.CalculateMixHash();

                if (currentBlock.MixHash != currentMixHash)
                {
                    return false;
                }

                if (currentBlock.ParentHash != parentBlock.MixHash)
                {
                    return false;
                }
            }

            return true;
        }

        public float GetAccountBalance(string accountAddress)
        {
            float balance = 0;
            if (!IsValid())
            {
                return balance;
            }

            foreach (var block in Blocks)
            {
                if (block.Transaction.RecipientAccountAddress == accountAddress)
                {
                    balance +=
                        block.Transaction.Amount;
                }

                if (block.Transaction.SenderAccountAddress == accountAddress)
                {
                    balance -=
                        block.Transaction.Amount;
                }
            }

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
