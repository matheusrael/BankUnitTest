using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccountResponse
    {
        public Account Account { get; set; }
        public bool Done { get; set; }

        public BankAccountResponse(Account account, bool done)
        {
            this.Account = account;
            this.Done = done;
        }
    }
}
