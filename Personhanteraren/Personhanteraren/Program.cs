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
            bool boolVal = false;
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
                        while (!boolVal)
                        {
                            double persNr;
                            string input1 = Console.ReadLine();
                            boolVal = Double.TryParse(input1, out persNr);
                            person1.Personnr = persNr;
                            if (!boolVal)
                            {
                                Console.WriteLine("Skriv med siffror istället");
                            }
                        }
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
                        while (!boolVal)
                        {
                            double number1;
                            string input1 = Console.ReadLine();
                            boolVal = Double.TryParse(input1, out number1);
                            newPerson.Personnr = number1;
                            if (!boolVal)
                            {
                                Console.WriteLine("Skriv med siffror istället");
                            }
                        }
                        Console.WriteLine("Ange Anställningstyp");
                        newPerson.Anställningstyp = Console.ReadLine();
                        Edit();
                        break;

                        
                    case "3":
                        Console.WriteLine("Ange personnr på personen du vill ta bort Ex. ÅÅMMDDXXXX");
                        while (!boolVal)
                        {
                            double persNr;
                            string input1 = Console.ReadLine();
                            boolVal = Double.TryParse(input1, out persNr);
                            Person deletePerson = persons.Find(x => x.Personnr == persNr);
                            persons.Remove(deletePerson);
                            if (!boolVal)
                            {
                                Console.WriteLine("Skriv med siffror istället");
                            }
                        }
                        
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
            Console.WriteLine("0. Avsluta");
        }
        public static void Edit()
        {
            string jsonString = JsonConvert.SerializeObject(persons);
            File.WriteAllText("persondata.txt", jsonString);
        }
    

    }


}
    
    

        
     


