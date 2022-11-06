using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokchain
{

    public class Account : object
    {
        public Account( ) : base()
        {
            Address = Guid.NewGuid().ToString();
        }

        public string Address { get; }

        public string? FullName { get; set; }

        public override string ToString()
        {
            string result =
                Infrastructure.Utility
                .ConvertObjectToJson(theObject: this);

            return result;
        }
    }
}
