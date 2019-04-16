using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UssdLibrary.Model
{
    public class RoutersModel// : IEnumerable
    {
        public List<Router> Routers { get; set; }

        public Router this[int number]
        {
            get
            {
                return Routers[number];
            }
            set
            {
                Routers[number] = value;
            }
        }

        public RoutersModel()
        {
            Routers = new List<Router>();
        }

        //public IEnumerator GetEnumerator()
        //{
        //    foreach (var item in Routers)
        //    {
        //        yield return $"{item.IP} {item.NameGSM} {item.MedicalClinics}";
        //    }
        //}

    }

    public class Router
    {
        public string IP { get; set; }
        public string Password { get; set; }
        public string MedicalClinics { get; set; }
        public string NameGSM { get; set; }
        public string OktellServer { get; set; }
        public Typecontract TypeContracts { get; set; }
        public List<MobileOperator> ModelSlots { get; set; }
    }

    public class Typecontract
    {
        public MTS MTSSlot { get; set; }
        public Megafon MegafonSlot { get; set; }
        public Tele2 Tele2Slot { get; set; }
        public Beeline BeelineSlot { get; set; }

    }

    public class Modelslot : IEnumerable
    {
        public List<string> Lines { get; set; }

        public string this[int number]
        {
            get
            {
                return Lines[number];
            }
            set
            {
                Lines[number] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Lines)
            {
                yield return item;
            }
        }

        //public override string ToString()
        //{
        //    var stringResult = "";
        //    foreach(var item in Lines)
        //    {
        //        stringResult += $"{item}, " ;
        //    }

        //    return stringResult;
        //}
    }

    public enum MobileOperator
    {
        MTC,
        Megafon,
        Tele2,
        Beeline,
        Empty,
    }
}

