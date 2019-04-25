using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using UssdLibrary.Helpers;
namespace UssdLibrary.Controller
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ContractController
    {
        static readonly string FILE_PATH = "configuration.json";
        public Contract CurrentContract { get; set; } = new Contract();
        public Router CurrentRouter { get; private set; } = default;
        public bool IsNewContract { get; private set; } = false;
        public bool IsNewRouter { get; private set; } = false;

        [JsonProperty]
        public List<Contract> Contracts { get; private set; } //= new List<Contract>();

        public ContractController()
        {
            if (Contracts == null)
            {
                Contracts = GetContractData();
            }
        }
        public ContractController(string contractName): this ()
        {
            GetContract(contractName);
        }

        public void AddNewRouter(string ip, string password, string nameGSM, string oktellServer, Typecontract typeContracts, Modelslot modelSlots)
        {
            GetRouter(ip);
            if (IsNewRouter)
            {
                Contracts.Remove(CurrentContract);
                CurrentContract.Routers.Add(new Router(ip, password, nameGSM, oktellServer, typeContracts, modelSlots));
                AddContract(CurrentContract);
            }
            else
            {
                //TODO: Запрос на изменение данных старого Роутера
            }
        }
        public void AddNewRouter(Router router)
        {
            AddNewRouter(router.IP, router.Password, router.NameGSM, router.OktellServer, router.TypeContracts, router.ModelSlots);
        }

        public void AddContract(Contract itemContract)
        {
            if (itemContract == null)
            {
                throw new ArgumentNullException(nameof(itemContract));
            }

            if (Contracts.Contains(itemContract))
            {
                //TODO : Запрос на изменение данных старого Контракта
            }
            else
            {
                Contracts.Add(itemContract);
                Save();
            }
        }
        public void AddContract(Contract[] itemsContract)
        {
            if (itemsContract == null)
            {
                throw new ArgumentNullException(nameof(itemsContract));
            }
            foreach (var item in itemsContract)
            {
                Contracts.Add(item);
            }
        }

        /// <summary>
        /// Удаление роутера у текущего экземпляра контракта
        /// </summary>
        /// <param name="ip">IP Роутера</param>
        /// <returns>bool</returns>
        public bool DeleteRouter(string ip)
        {
            GetRouter(ip);
            try
            {
                if (!IsNewRouter)
                {
                    CurrentContract.Routers.Remove(CurrentRouter);
                    Contracts.Remove(CurrentContract);
                    Contracts.Add(CurrentContract);
                    Save();
                    return true;
                }
                //else
                //{
                    throw new ArgumentException("Роутера с таким IP в этом контракте не существует", nameof(ip));
                    //TODO: DoSomeThing();
                //}
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Удаление текущего экземпляра контракта
        /// </summary>
        /// <returns>bool</returns>
        public bool DeleteContract()
        {
            try
            {
                if (CurrentContract != null)
                {
                    Contracts.Remove(CurrentContract);
                    Save();
                    return true;
                }
                else
                {
                    throw new ArgumentNullException("Этот контракт уже был удалён", nameof(CurrentContract));
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Получаем Контракт по Имени договора.
        /// Если он не найден то возвращает новый. IsNewContract = true
        /// </summary>
        /// <param name="nameContract"></param>
        /// <returns>Контракт</returns>
        public Contract GetContract(string nameContract)
        {
            if (string.IsNullOrWhiteSpace(nameContract))
            {
                throw new ArgumentException("message", nameof(nameContract));
            }

            CurrentContract = Contracts.SingleOrDefault(m => m.NameContract == nameContract);

            if (CurrentContract != null)
            {
                IsNewContract = false;
            }
            if (CurrentContract == null)
            {
                CurrentContract = new Contract(nameContract);
                Contracts.Add(CurrentContract);
                IsNewContract = true;
                Save();
            }
            return CurrentContract;
        }
        /// <summary>
        /// Получаем Роутер по IP адресу
        /// </summary>
        /// <param name="ip">IP адрес роутера</param>
        /// <returns>Router</returns>
        public Router GetRouter(string ip)
        {
            if (ip.CheckIP())
            {
                CurrentRouter = (from contract in Contracts
                          let routers = contract.Routers
                          let router = (from item in routers
                                        where item.IP == ip
                                        select item).SingleOrDefault()
                          where router != null
                          select router).SingleOrDefault();

                if (CurrentRouter != null)
                {
                    IsNewRouter = false;
                }
                else
                {
                    IsNewRouter = true;
                    CurrentRouter = new Router();
                }
                return CurrentRouter;
            }
            throw new ArgumentException("Неправильно задан IP адрес", nameof(ip));
        }
        /// <summary>
        /// Загрузить Контракты из JSON файла
        /// </summary>
        /// <returns>Список Контрактов</returns>
        private List<Contract> GetContractData()
        {
            using (FileStream fs = new FileStream(FILE_PATH, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (JsonConvert.DeserializeObject<List<Contract>>(sr.ReadToEnd()) is List<Contract> contracts)
                    {
                        return contracts;
                    }
                    else
                    {
                        return new List<Contract>();
                    }
                }
            }
        }
        public void Save()
        {
            using (FileStream fs = new FileStream(FILE_PATH, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(Contracts));
                }
            }
        }
        /// <summary>
        /// Очистка файла сохранений всех контрактов
        /// </summary>
        public void ClearContracts()
        {
            Contracts = default;
            Save();
        }
    }
}
