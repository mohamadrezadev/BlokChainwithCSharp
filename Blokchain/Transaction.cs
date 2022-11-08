using Blokchain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokchain
{
    public class Transaction : object
    {
        public Transaction
            (double fee,
            float amount,
            TransactionType type,
            string? senderAccountAddress = null,
            string? recipientAccountAddress = null) : base()
        {
            // **********
            switch (type)
            {
                // گیرنده مهم است
                case TransactionType.Mining:

                case TransactionType.Charging:
                    {
                        senderAccountAddress = null;

                        if (recipientAccountAddress == null)
                        {
                            throw new ArgumentNullException
                                (paramName: nameof(recipientAccountAddress));
                        }

                        break;
                    }

                // فرستنده مهم است
                case TransactionType.Withdrawing:
                    {
                        recipientAccountAddress = null;

                        if (senderAccountAddress == null)
                        {
                            throw new System.ArgumentNullException
                                (paramName: nameof(senderAccountAddress));
                        }

                        break;
                    }

                // هر دو مهم هستند
                case TransactionType.Transferring:
                    {
                        if (senderAccountAddress == null)
                        {
                            throw new System.ArgumentNullException
                                (paramName: nameof(senderAccountAddress));
                        }
                        else
                        {
                            if (recipientAccountAddress == null)
                            {
                                throw new System.ArgumentNullException
                                    (paramName: nameof(recipientAccountAddress));
                            }
                        }

                        break;
                    }
            }
            // **********

            Id =Guid.NewGuid();

            Timestamp =Utility.Now;
            Type = type;
            Amount = amount;
            SenderAccountAddress = senderAccountAddress;
            RecipientAccountAddress = recipientAccountAddress;
        }
        

        public Guid Id { get; }

        public float Amount { get; set; }
        public double Fee { get; }

        public DateTime Timestamp { get; }

        public TransactionType Type { get; }

        public string? SenderAccountAddress { get; }

        public string? RecipientAccountAddress { get; }

        public override string ToString()
        {
            string result =
                Infrastructure.Utility
                .ConvertObjectToJson(theObject: this);

            return result;
        }
    }
}
