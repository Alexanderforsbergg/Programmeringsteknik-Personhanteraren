using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;




namespace Personhanteraren
{
    class Program
    {
       static List<Person> persons = new List<Person>();

        static void Main(string[] args)
        {
            string menyVal = "";
            Init();
            do
            {
                
                Menu();
                menyVal = Console.ReadLine();

                switch (menyVal)
                {
                    case "1":
                        Person person1 = new Person();
                        Console.WriteLine("Ange namnet på den aställda");
                        person1.Namn = Console.ReadLine();
                        Console.WriteLine("Ange personnr Ex ÅÅMMDDXXXX");
                        person1.Personnr = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ange anställningstyp");
                        person1.Anställningstyp= Console.ReadLine();
                        persons.Add(person1);

                        Edit();


                        break;

                    case "2":
                        Console.WriteLine("Vad är namnet på personen du vill redigera");
                        string valNamn = Console.ReadLine();
                        Person newPerson = persons.Find(x => x.Namn == valNamn);
                        Console.WriteLine("Ange det nya namnet ");
                        newPerson.Namn = Console.ReadLine();
                        Console.WriteLine("Ange personnr");
                        newPerson.Personnr = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ange Anställningstyp");
                        newPerson.Anställningstyp = Console.ReadLine();
                        string jsonString = JsonConvert.SerializeObject(persons);
                        File.WriteAllText("persondata.txt", jsonString);
                        Edit();
                        break;

                        
                    case "3":
                        Console.WriteLine("Ange personnr på personen du vill ta bort Ex. ÅÅMMDDXXXX");
                        int personNr = Convert.ToInt32(Console.ReadLine());
                        Person deletePerson = persons.Find(x => x.Personnr == personNr);
                        persons.Remove(deletePerson);
                        Edit();
                        break;

                    case "4":
                        foreach (Person i in persons)
                        {
                            Console.WriteLine($"Namn:{i.Namn} Personnr:{i.Personnr} Anställningstyp:{i.Anställningstyp}");
                            
                        }
                        break;
                }

              

            } while (menyVal != "0");
        }

        private static void Init()
        {
            if (!File.Exists("persondata.txt"))
            {
                File.Create("persondata.txt");
            }
            string toBeDeSerialized = File.ReadAllText("persondata.txt");
            var loadedPersons = JsonConvert.DeserializeObject<List<Person>>(toBeDeSerialized);

            if (loadedPersons != null)
                persons.AddRange(loadedPersons);

        }

        public static void Menu()
        {
            Console.WriteLine("Gör ett val");
            Console.WriteLine("1. Lägg till person");
            Console.WriteLine("2. Redigera person");
            Console.WriteLine("3. Ta bort person");
            Console.WriteLine("4. Skriv ut lista på sparade personer");
        }
        public static void Edit()
        {
            string jsonString = JsonConvert.SerializeObject(persons);
            File.WriteAllText("persondata.txt", jsonString);
        }
    

    }


}
    
    

        
     


