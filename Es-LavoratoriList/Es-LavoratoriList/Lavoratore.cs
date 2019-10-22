using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Es_LavoratoriList
{
    [Serializable]//attributo applicato alla classe sottostante
    public class Lavoratore
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }
        public int Ral { get; set; }


        public Lavoratore()
        {

        }

        public Lavoratore(string nome, string cognome, int età, int ral)
        {
            Nome = nome;
            Cognome = cognome;
            Età = età;
            Ral = ral;
        }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Età: {2}, Ral: {3}",
                Nome,
                Cognome,
                Età,
                Ral);
        }
    }
}
