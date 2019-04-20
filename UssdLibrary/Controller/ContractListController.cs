using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace UssdLibrary.Controller
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ContractListController
    {
        static readonly string FILE_PATH = "configuration.json";
        public Contract Contract { get; set; }

        [JsonProperty]
        public List<Contract> ContractArray { get; private set; } = new List<Contract>();

        public ContractListController()
        {
            using (FileStream fs = new FileStream(FILE_PATH, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (JsonConvert.DeserializeObject<List<Contract>>(sr.ReadToEnd()) is List<Contract> contracts)
                    {
                        ContractArray = contracts;
                    }
                    else
                    {
                       //TODO Что-то придумать //throw new ArgumentException($"Не получилось дессериализовать файл {FILE_PATH}", nameof(ContractArray));
                    }
                }
            }

            //ContractArray = new List<Contract>();
        }

        public ContractListController(Contract contract) : this()
        {
            Add(contract);
        }
        public ContractListController(Contract[] contracts) : this()
        {
            if (contracts == null)
            {
                throw new ArgumentNullException(nameof(contracts));
            }

            ContractArray.AddRange(contracts);
        }

        public void Add(Contract itemContract)
        {
            if (itemContract == null)
            {
                throw new ArgumentNullException(nameof(itemContract));
            }

            ContractArray.Add(itemContract);
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(FILE_PATH, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(ContractArray));
                }
            }
        }

        public void ClearSetting()
        {
            ContractArray = default;
            Save();
        }

        //private static List<Contract> Load()
        //{
           
        //}
    }
}
