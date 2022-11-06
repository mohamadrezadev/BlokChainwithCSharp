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
            Transaction transaction, string? parentHash = null) : base()
        {
            ParentHash = parentHash;
            BlockNumber = Guid.NewGuid().ToString();
            Transaction = transaction;
        }

        /// <summary>
        /// Index
        /// </summary>
        public string BlockNumber { get; }

        /// <summary>
        /// PreviousHash
        /// </summary>
        public string? ParentHash { get; }

        /// <summary>
        /// Data
        /// </summary>
        public Transaction Transaction { get; }

        /// <summary>
        /// Hash
        /// </summary>
        public string? MixHash { get; protected set; }

        /// <summary>
        /// MineTime
        /// Note: It is Mining Time, NOT Creation Time!
        /// </summary>
        public DateTime? Timestamp { get; protected set; }

        public void Mine()
        {
            if (string.IsNullOrWhiteSpace(MixHash))
            {
                Timestamp =
                    Infrastructure.Utility.Now;

                MixHash =
                    CalculateMixHash();
            }
        }

        public string CalculateMixHash()
        {
            var stringBuilder =
                new System.Text.StringBuilder();

            stringBuilder.Append($"{nameof(Timestamp)}:{Timestamp}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(ParentHash)}:{ParentHash}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(BlockNumber)}:{BlockNumber}");
            stringBuilder.Append('|');
            stringBuilder.Append($"{nameof(Transaction)}:{Transaction}");

            var text =
                stringBuilder.ToString();

            string result =
                Infrastructure.Utility.GetSha256(text: text);

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

