using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        public Conferenza(string titolo, DateTime data, int capienzaMassima, string relatore, double prezzo) : base(titolo, data, capienzaMassima)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }

        public string Relatore { get; set; }
        public double Prezzo { get; set; }

        public string PrezzoFormattato ()
        {
            return Prezzo.ToString("00:00");
        }

        public override string ToString()
        {
            return $"        {Data:dd/MM/yyyy} - {Titolo} - {Relatore} - {Prezzo} euro";
        }

    }
}
