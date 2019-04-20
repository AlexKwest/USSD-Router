using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UssdLibrary.Model
{
    abstract public class SlotAbstract
    {
        public string MinBalance { get;  set; }
        public string RegexBalance { get;  set; }

        //public SlotAbstract(string minBalance, string regexBalance)
        //{
        //    this.MinBalance = minBalance;
        //    this.RegexBalance = RegexBalance;
        //}
    }
}
