using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdLibrary;
using UssdLibrary.Model;
using System.Collections;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            RoutersModel routersModel = new RoutersModel();
            routersModel.Routers.Add( new Router()
            {
                IP = "127.0.0.1",
                Password = "123",
                MedicalClinics = "ФитКлиник",
                NameGSM = "GSM1",
                OktellServer = "Ярославский",
                TypeContracts = new Typecontract
                {
                    BeelineSlot = new Beeline { MinBalance = "100", RegexBalance = "[0-9]" },
                    MegafonSlot = new Megafon { MinBalance = "100", RegexBalance = "[0-9]" },
                    MTSSlot = new MTS { MinBalance = "100", RegexBalance = "[0-9]" },
                    Tele2Slot = new Tele2 { MinBalance = "100", RegexBalance = "[0-9]" }
                },
                ModelSlots = new List<MobileOperator>()
                {
                    MobileOperator.Beeline,
                    MobileOperator.Megafon
                }
                //ModelSlots = new Modelslot()
                //{
                //    Lines = new List<string>
                //    {
                //        "qwe"
                //    }
                //},
            });

            //foreach (var item in routersModel)
            //{
            //    Console.WriteLine(item);
            //}

            var routersModelDeserialized = new RoutersModel();

            using (FileStream fileStream = new FileStream("resultUSSD.json", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var sw = new StreamWriter(fileStream))
                {
                    sw.Write(JsonConvert.SerializeObject(routersModel));
                }               
            }
            routersModelDeserialized = JsonConvert.DeserializeObject<RoutersModel>(File.ReadAllText(@"resultUSSD.json"));

            using (StreamReader sr = new StreamReader("resultUSSD.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                routersModelDeserialized = (RoutersModel)serializer.Deserialize(sr, typeof(RoutersModel));
            }

           
               Console.WriteLine(routersModelDeserialized.Routers[0].IP);
            
            Console.ReadLine();

        }
    }
}
