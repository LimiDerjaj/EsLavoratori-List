using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Es_LavoratoriList
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\Users\\CORSO 52\\Desktop\\Es-Lavoratori";
            string fileName = "Esercizio.txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = Path.Combine(path, fileName);

            if (!File.Exists(fullPath))
            {
                File.Create(fullPath);
            }

            Lavoratore l3 = new Lavoratore("Joe", "Johnson", 32, 28000);
            List<Lavoratore> listL = new List<Lavoratore>();

            Lavoratore[] lavoratori = new Lavoratore[]
            {
                new Lavoratore("Cj", "Johnson", 22, 18000),
                new Lavoratore("Vlad", "Russo", 27, 21000),
                new Lavoratore("Nelson", "Rivas", 11, 28000),
                new Lavoratore("Diego", "Verdi", 2, 8000)
            };

            //aggiungo tutto l'array di persone nella lista
            listL.AddRange(lavoratori);
            listL.Add(l3);


            StringBuilder sb = new StringBuilder();

            foreach (var p in listL)
            {
                sb.AppendLine(p.ToString());
            }

            File.WriteAllText(fullPath, sb.ToString());
            string result = File.ReadAllText(fullPath);
            Console.WriteLine(result);

            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

            byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(Lavoratore));

            fullPath = Path.Combine(path, "Esercizio.xml");
            XmlSerializer listSerializer = new XmlSerializer(typeof(List<Lavoratore>));
            using (FileStream fs3 = File.Open(fullPath, FileMode.OpenOrCreate))
            {
                listSerializer.Serialize(fs3, listL);
                fs3.Close();
            }
            Console.ReadLine();
        }
    }
}
