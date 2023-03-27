using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = capienzaMassima;
            NumeroPostiPrenotati = 0;
        }

        private string _titolo;
        private DateTime _data;
        private int _capienzaMassima;
        public string Titolo
        {
            get { return _titolo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Il titolo non può essere vuoto.");
                }
                
                _titolo = value;
            }
        }

        public DateTime Data
        {
            get { return _data; }
            set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("La data non può essere nel passato)");
                }

                _data = value;
            }
        }
        public int CapienzaMassima
        {
            get { return _capienzaMassima; }
            init
            {
                if (value <= 0)
                {
                    throw new ArgumentException("La capienza massima deve essere un numero positivo");
                }

                _capienzaMassima = value;
            }
        }
        public int NumeroPostiPrenotati { get; private set; }

        public void PrenotaPosti(int numPosti)
        {

            if (numPosti <= 0)
            {
                throw new ArgumentException("Il numero dei posti prenotati deve essere un numero positivo");
            }
            if (NumeroPostiPrenotati + numPosti > CapienzaMassima)
            {
                throw new ArgumentException("Non può essere superata la capienza massima");
            }
            if (Data < DateTime.Today)
            {
                throw new ArgumentException("Non può prenotare per un evento già passato");
            }

            NumeroPostiPrenotati += numPosti;
        }
        public void DisdiciPosti(int numPosti)
        {

            if (numPosti <= 0)
            {
                throw new ArgumentException("Il numero dei posti disdetti deve essere un numero positivo");
            }
            if (numPosti > NumeroPostiPrenotati)
            {
                throw new ArgumentException("Non ci sono sufficienti posti da disdire");
            }
            if (Data < DateTime.Today)
            {
                throw new ArgumentException("Non può disdire per un evento già passato");
            }

            NumeroPostiPrenotati -= numPosti;
        }
        public override string ToString()
        {
            return $"        {Data:dd/MM/yyyy} - {Titolo}";
        }
    }
}
