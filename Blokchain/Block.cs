using Blokchain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokchain
{
    public class Block : object
    {
        public Block(int blockNumber,
             int difficulty = 0, string? previousBlock = null) : base()
        {
            PreviousHash =previousBlock;
            BlockNumber = Guid.NewGuid().ToString();
            _transactions =new List<Transaction>();
            Difficulty = difficulty;
        }
        /// <summary>
        /// Index
        /// </summary>
        public string BlockNumber { get; }
        /// <summary>
        /// PreviousHash
        /// </summary>
        public string? PreviousHash { get; }
        /// <summary>
        /// Hash
        /// </summary>
        public string? MixHash { get; protected set; }

        /// <summary>
        /// MineTime
        /// Note: It is Mining Time, NOT Creation Time!
        /// </summary>
        public DateTime? Timestamp { get; protected set; }
        public int Difficulty { get; }
        public int Nonce { get; protected set; }
        public TimeSpan? Duration { get; protected set; }
        /// <summary>
        /// Data
        /// </summary>
        private readonly List<Transaction> _transactions;

        public IReadOnlyList<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }
        // **********
        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
        // **********
        public bool IsMined()
        {
            if (string.IsNullOrWhiteSpace(MixHash))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Mine()
        {

            if (IsMined())
            {
                return;
            }

            Timestamp =Utility.Now;
            var leadingZeros =new string(c: '0', count: Difficulty);

            var startTime =Utility.Now;

            Nonce = -1;
            string mixHash;

            do
            {
                Nonce++;

                mixHash =
                    MixHash =CalculateMixHash();
            } while (mixHash.StartsWith(leadingZeros) == false);

            MixHash = mixHash;

            var finishTime =Utility.Now;

            Duration =finishTime - startTime;
            // **********
        }
        

        public string CalculateMixHash()
        {
            var stringBuilder =new StringBuilder();

            // **********
            stringBuilder.Append($"{nameof(Nonce)}:{Nonce}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(Difficulty)}:{Difficulty}");
            stringBuilder.Append('|');
            // **********

            stringBuilder.Append($"{nameof(Timestamp)}:{Timestamp}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(PreviousHash)}:{PreviousHash}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(BlockNumber)}:{BlockNumber}");
            // **********
            var transactionsString =Utility.ConvertObjectToJson(Transactions);
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(Transactions)}:{transactionsString}");
            // **********
            var text =
                stringBuilder.ToString();
            string result =Utility.GetSha256(text: text);
            return result;
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


