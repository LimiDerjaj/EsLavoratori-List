using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Es_LavoratoriList
{
    public enum TipoLavoratore
    {
        Autonomo,
        Dipendente
    }

    [Serializable]//attributo applicato alla classe sottostante
    public class Lavoratore
    {
        public Guid Lavoratore_ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }
        public int Ral { get; set; }
        public DateTime? DataDiAssunzione { get; set; }
        public TipoLavoratore Tipo { get; set; }


        public Lavoratore()
        {
            Lavoratore_ID = Guid.NewGuid();
        }

        public Lavoratore(string nome, string cognome, int età, int ral, DateTime? dataAssunzione, TipoLavoratore tipo)
        {
            Nome = nome;
            Cognome = cognome;
            Età = età;
            Ral = ral;
            DataDiAssunzione = dataAssunzione;
            Tipo = tipo;
            Lavoratore_ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Età: {2}, Ral: {3}, Tipo: {4}",
                Nome,
                Cognome,
                Età,
                Ral,
                Tipo);
        }
    }
}
