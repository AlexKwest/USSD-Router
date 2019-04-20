using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary.Helpers;

namespace UssdLibrary.Model
{
    /// <summary>
    /// Список Контрактов
    /// </summary>
    public class ContractList
    {
        public Contract[] Contracts { get; set; }

        public ContractList()
        {

        }
        /// <summary>
        /// Список
        /// </summary>
        /// <param name="contracts">Массив контрактов с сотовыми операторами</param>
        public ContractList(Contract[] contracts)
        {
            Contracts = contracts ?? throw new ArgumentNullException(nameof(contracts));
        }
    }
    /// <summary>
    /// Контракт
    /// </summary>
    public class Contract
    {
        public string NameContract { get; set; }
        public Router[] Routers { get; set; }

        public Contract()
        {

        }
        /// <summary>
        /// Конкретный контракт с сотовым оператором
        /// </summary>
        /// <param name="nameContract"></param>
        /// <param name="routers">Список Роутеров</param>
        public Contract(string nameContract, Router[] routers)
        {
            #region CheckParameter
            if (string.IsNullOrWhiteSpace(nameContract))
            {
                throw new ArgumentNullException("Имя Договора на обслуживание сотовым оператором не может быть пустым", nameof(nameContract));
            }
            if (routers == null)
            {
                throw new ArgumentNullException(nameof(routers));
            }
            #endregion

            NameContract = nameContract;
            Routers = routers;
        }
    }

    //public class RoutersModel// : IEnumerable
    //{
    //    public Router Routers { get; set; } = new List<Router>();

    //    //public Router this[int number]
    //    //{
    //    //    get
    //    //    {
    //    //        return Routers[number];
    //    //    }
    //    //    set
    //    //    {
    //    //        Routers[number] = value;
    //    //    }
    //    //}

    //    //public RoutersModel()
    //    //{
    //    //    Routers = new List<Router>();
    //    //}

    //    //public IEnumerator GetEnumerator()
    //    //{
    //    //    foreach (var item in Routers)
    //    //    {
    //    //        yield return $"{item.IP} {item.NameGSM} {item.MedicalClinics}";
    //    //    }
    //    //}

    //}

    public class Router
    {
        public string IP { get; set; } 
        public string Password { get; set; }
        public string MedicalClinics { get; set; } 
        public string NameGSM { get; set; } 
        public string OktellServer { get; set; } 
        public Typecontract TypeContracts { get; set; }
        public Modelslot ModelSlots { get; set; }

        /// <summary>
        /// Модель Роутера
        /// </summary>
        /// <param name="ip">IP адрес</param>
        /// <param name="password">Пароль</param>
        /// <param name="medicalClinics">МЦ</param>
        /// <param name="nameGSM">Имя GSM</param>
        /// <param name="oktellServer">Сервер Oktell</param>
        /// <param name="typeContracts">Тип договора по Операторам связи</param>
        /// <param name="modelSlots">В каких слотах какие симкарты</param>
        public Router(string ip, string password, string nameGSM, string oktellServer , Typecontract typeContracts, Modelslot modelSlots)
        {
            #region CheckParametrs
            if (!ip.CheckIP())
            {
                throw new ArgumentException("Неверно задан IP адрес роутера", nameof(ip));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Пароль не может быть пустым", nameof(password));
            }

            if (string.IsNullOrWhiteSpace(nameGSM))
            {
                throw new ArgumentNullException("Название GSM порта не может быть пустым", nameof(nameGSM));
            }

            if (string.IsNullOrWhiteSpace(oktellServer))
            {
                throw new ArgumentNullException("Название сервера Oktell не может быть пустым", nameof(oktellServer));
            }

            if (typeContracts == null)
            {
                throw new ArgumentNullException("Контракт не может быть пустым", nameof(typeContracts));
            }

            if (modelSlots == null)
            {
                throw new ArgumentNullException("Модель симкарт не может быть пустой", nameof(modelSlots));
            }
            #endregion

            IP = ip;
            Password = password;
            NameGSM = nameGSM;
            OktellServer = oktellServer;
            TypeContracts = typeContracts;
            ModelSlots = modelSlots;
        }
    }

    public class Typecontract
    {
        public MTS MTSSlot { get; set; }
        public Megafon MegafonSlot { get; set; }
        public Tele2 Tele2Slot { get; set; }
        public Beeline BeelineSlot { get; set; }

    }

    public class Modelslot //: IEnumerable
    {
        public SotOperator[] Lines { get; set; } 

        public IEnumerator GetEnumerator()
        {
            return new MobileOperator(Lines);
        }
    }

    public class MobileOperator: IEnumerator<SotOperator>
    {
        public SotOperator[] sotOperators;
        int position = -1;
        public MobileOperator(SotOperator[] sotOperators)
        {
            this.sotOperators = sotOperators;
        }

        public SotOperator Current
        {
            get
            {
                if (position == -1 || position >= sotOperators.Length)
                    throw new InvalidOperationException();
                return sotOperators[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return $"{Current}";
            }
        }

        public bool MoveNext()
        {
            if (position < sotOperators.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }
    }

    public enum SotOperator
    {
        MTS,
        Megafon,
        Tele2,
        Beeline,
        Empty
    }

}

