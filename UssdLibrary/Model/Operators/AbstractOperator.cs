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

        public override bool Equals(object obj)
        {
            var other = obj as SlotAbstract;
            if (
                       this.MinBalance == other.MinBalance
                    && this.RegexBalance == other.RegexBalance
                )
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} {MinBalance} {RegexBalance}";
        }
        //public SlotAbstract(string minBalance, string regexBalance)
        //{
        //    this.MinBalance = minBalance;
        //    this.RegexBalance = RegexBalance;
        //}
    }
}
