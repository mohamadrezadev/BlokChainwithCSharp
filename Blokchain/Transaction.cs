using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokchain
{
    public class Transaction : object
    {
        public Transaction(
            float amount, string recipientAccountAddress,
            string? senderAccountAddress = null) : base()
        {
            Id = Guid.NewGuid(); 
            Amount = amount;
            SenderAccountAddress = senderAccountAddress;
            RecipientAccountAddress = recipientAccountAddress;
        }

        public Guid Id { get; }

        
        public float Amount { get; set; }

        public string? SenderAccountAddress { get; }

        public string RecipientAccountAddress { get; }

        public override string ToString()
        {
            string result =
                Infrastructure.Utility
                .ConvertObjectToJson(theObject: this);

            return result;
        }
    }
}
