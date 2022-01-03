using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Account()
        {

        }
        public Account(int id, string name, decimal balance)
        {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
        }
    }
}
