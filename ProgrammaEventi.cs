using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        public string Titolo;
        public List<Evento> Eventi { get; set; }

        public void AggiungiEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiFiltrati = Eventi.Where(evento => evento.Data == data).ToList();

            return eventiFiltrati;
        }
        public static string FormattaEvento(List<Evento> eventi)
        {
            List<string> eventiFormattati = new List<string>();

            foreach (Evento evento in eventi)
            {
                string eventoFormattato = $"{evento.Data.ToString("dd/MM/yyyy")} - {evento.Titolo}";
                eventiFormattati.Add(eventoFormattato);
            }

            return string.Join(", ", eventiFormattati);
        }
        public int NumeroEventi()
        {
            return Eventi.Count;
        }
        public void SvuotaEventi()
        {
            Eventi.Clear();
        }
        public string RiepilogoProgrammaEventi()
        {
            StringBuilder listaEventi = new StringBuilder();

            foreach (Evento evento in Eventi)
            {
                listaEventi.AppendLine($"{evento.Data} - {evento.Titolo}");
            }
            return $"{Titolo}:{Environment.NewLine}{listaEventi}";
        }
        public string RiepilogoProgrammaEventi2()
        {
            string listaEventi = "";

            foreach (Evento evento in Eventi)
            {
                listaEventi += evento.ToString() + Environment.NewLine;
            }

            return $"{Titolo}{Environment.NewLine}{listaEventi}";
        }

    }
}
