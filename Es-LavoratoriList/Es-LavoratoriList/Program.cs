using Es_LavoratoriList.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_LavoratoriList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database Inizializzato con lavoratori predefiniti"+Environment.NewLine+"---------------------------------");
            InitDb();

            DataSet ds = DbHelper.GetLavoratore();

            Console.WriteLine("Estrazione lavoratori predefiniti");
            PrintDataSet(ds);

            bool control = false;

            do
            {
                Console.WriteLine("Scegli operazione da eseguire:" + Environment.NewLine +
                "1 = Aggiungi lavoratore al database: " + Environment.NewLine +
                "2 = Modifica lavoratore sul database: " + Environment.NewLine +
                "3 = Cancella lavoratore dal database: " + Environment.NewLine +
                "4 = Svuotare la tabella del database: "+Environment.NewLine+
                "5 = Uscire dal programma: ");
                string x = Console.ReadLine();

                if (x == "1")
                {
                    Console.WriteLine(System.Environment.NewLine + "AGGIUNGI LAVORATORE" + System.Environment.NewLine +
                                  "-----------------------" + System.Environment.NewLine);

                    Lavoratore lav = new Lavoratore
                    {
                        Nome = "Rico",
                        Cognome = "Skrt",
                        Età = 40,
                        Tipo = TipoLavoratore.Dipendente,
                        DataDiAssunzione = new DateTime(2012, 5, 4),
                        Ral = 35000
                    };

                    DbHelper.InsertLavoratore(lav);

                    ds = DbHelper.GetLavoratore();

                    Console.WriteLine("Estrazione con nuovo lavoratore");
                    PrintDataSet(ds);

                    control = true;
                }

                if (x == "2")
                {
                    Console.WriteLine(System.Environment.NewLine + "MODIFICA LAVORATORE" + System.Environment.NewLine +
                                  "-----------------------" + System.Environment.NewLine);

                    Console.WriteLine("inserisci ID del lavoratore che si vuole modificare: ");
                    Guid guid = new Guid(Console.ReadLine());

                    Lavoratore lav = new Lavoratore
                    {
                        Lavoratore_ID = guid,
                        Nome = "Jack",
                        Cognome = "Young",
                        Età = 50,
                        Tipo = TipoLavoratore.Dipendente,
                        DataDiAssunzione = new DateTime(2002, 7, 9),
                        Ral = 15000

                    };

                    DbHelper.UpdateLavoratore(lav);

                    ds = DbHelper.GetLavoratore();

                    Console.WriteLine("Estrazione dopo la modifica del lavoratore");

                    PrintDataSet(ds);

                    control = true;
                }

                if (x == "3")
                {
                    Console.WriteLine(System.Environment.NewLine + "CANCELLA LAVORATORE" + System.Environment.NewLine +
                                  "-----------------------" + System.Environment.NewLine);
                    //cancello lavoratore
                    Console.WriteLine("inserisci ID del lavoratore che si vuole eliminare: ");
                    Guid lavId = new Guid(Console.ReadLine());

                    DbHelper.DeleteLavoratore(lavId);
                    ds = DbHelper.GetLavoratore();
                    Console.WriteLine("Estrazione dopo il delete");
                    PrintDataSet(ds);

                    control = true;
                }

                if (x == "4")
                {
                    Console.WriteLine(System.Environment.NewLine + "SVUOTA TABELLA" + System.Environment.NewLine +
                                  "-----------------------" + System.Environment.NewLine);
                    DbHelper.SvuotaTabella("Lavoratori");
                    ds = DbHelper.GetLavoratore();
                    Console.WriteLine("Estrazione dopo il delete della tabella");
                    PrintDataSet(ds);

                    control = true;
                }

                if (x == "5")
                {
                    return;                   
                }
                else
                {
                    Console.WriteLine("Inserire un valore valido ");
                    control = false;
                }
            } while (control == false);

            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private static void InitDb()
        {
            List<Lavoratore> listaL = new List<Lavoratore>
            {
                new Lavoratore
                {
                    Nome = "Don",
                    Cognome = "Joe",
                    Età = 21,
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(2010, 3, 17),
                    Ral = 3500
                },

                new Lavoratore
                {
                    Nome = "Pippo",
                    Cognome = "Baudo",
                    Età = 30,
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(1982, 3, 17),
                    Ral = 3500
                },

                new Lavoratore
                {
                    Nome = "Lord",
                    Cognome = "Voldermd",
                    Età = 100,
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(1955, 3, 17),
                    Ral = 350000
                },
            };

            foreach (var l in listaL)
            {
                DbHelper.InsertLavoratore(l);
            }

        }
    }
}
