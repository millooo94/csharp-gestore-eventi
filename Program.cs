using csharp_gestore_eventi;
using System.Globalization;

while (true)
{
    Console.Write($"Inserisci il nome dell'evento: ");
    var titolo = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
    DateTime data;
    while (true)
    {
        try
        {
            data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci una data valida (gg/mm/yyyy)!");
        }
    }

    Console.Write("Inserisci il numero di posti totali: ");
    int capienzaMassima;
    while (true)
    {
        try
        {
            capienzaMassima = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido!");
        }
    }

    var evento = new Evento(titolo, data, capienzaMassima);

    Console.Write("Quanti posti desideri prenotare? ");
    Console.WriteLine();
    int postiPrenotati;
    while (true)
    {
        try
        {
            postiPrenotati = Convert.ToInt32(Console.ReadLine());
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido!");
        }
    }
    evento.PrenotaPosti(postiPrenotati);

    Console.WriteLine($"Numero di posti prenotati {postiPrenotati}");
    Console.WriteLine();
    Console.WriteLine($"Numero di posti disponibili {evento.CapienzaMassima - evento.NumeroPostiPrenotati}");
    Console.WriteLine();

    while (true)
    {
        Console.Write("Vuoi disdire dei posti? (si/no) ");
        var answer1 = Console.ReadLine();
        Console.WriteLine();
        if (answer1 == "si")
        {
            int postiDisdetti;
            while (true)
            {
                try
                {
                    Console.Write("Indica il numero di posti da disdire: ");
                    postiDisdetti = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Inserisci un numero valido!");
                }
            }
            evento.DisdiciPosti(postiDisdetti);
            Console.WriteLine($"Numero di posti prenotati {postiPrenotati}");
            Console.WriteLine($"Numero di posti disponibili {evento.CapienzaMassima - evento.NumeroPostiPrenotati}");
        }
        else if (answer1 == "no")
        {
            break;
        }
    }

    Console.Write("Inserisci il nome del tuo programma eventi: ");
    var titoloProgramma = Console.ReadLine();
    Console.WriteLine();
    var programmaEventi = new ProgrammaEventi(titoloProgramma);

    int numeroEventi;
    while (true)
    {
        try
        {
            Console.Write("Indica il numero di eventi da inserire: ");
            numeroEventi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido!");
        }
    }

    for (int i = 1; i <= numeroEventi; i++)
    {
        Console.Write($"Inserisci il nome del {i}° evento: ");
        var titoloEvento = Console.ReadLine();
        Console.WriteLine();

        DateTime dataEvento;
        while (true)
        {
            Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
            try
            {
                dataEvento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine();
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserisci una data valida (gg/mm/yyyy)!");
            }
        }

        int capienzaMassimaEvento;
        while (true)
        {
            Console.Write("Inserisci il numero di posti totali: ");
            try
            {
                capienzaMassimaEvento = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserisci un numero valido!");
            }
        }

        var eventoDiEventi = new Evento(titoloEvento, dataEvento, capienzaMassimaEvento);

        programmaEventi.AggiungiEvento(eventoDiEventi);
    }

    Console.WriteLine(programmaEventi.NumeroEventi());
    Console.WriteLine();
    Console.WriteLine("Ecco il tuo programma eventi:");
    Console.WriteLine();
    Console.WriteLine(programmaEventi.RiepilogoProgrammaEventi());

    DateTime dataUtente;
    while (true)
    {
        Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
        try
        {
            dataUtente = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci una data valida (gg/mm/yyyy)!");
        }
    }

    var eventiInData = programmaEventi.EventiInData(dataUtente);
    Console.WriteLine(ProgrammaEventi.FormattaEvento(eventiInData));
    Console.WriteLine();
    //programmaEventi.SvuotaEventi();

    Console.WriteLine("Aggiungiamo anche una conferenza!");
    Console.WriteLine();
    Console.Write("Inserisci il nome della conferenza: ");
    var titoloConferenza = Console.ReadLine();
    Console.WriteLine();

    DateTime dataConferenza;
    while (true)
    {
        Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
        try
        {
            dataConferenza = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci una data valida (gg/mm/yyyy)!");
        }
    }

    int postiConferenza;
    while (true)
    {
        Console.Write("Inserisci il numero di posti per la conferenza: ");
        try
        {
            postiConferenza = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido!");
        }
    }

    Console.Write("Inserisci il relatore della conferenza: ");
    var relatoreConferenza = Console.ReadLine();
    Console.WriteLine();

    int prezzoConferenza;
    while (true)
    {
        Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
        try
        {
            prezzoConferenza = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserisci un numero valido!");
        }
    }

    var conferenza = new Conferenza(titoloConferenza, dataConferenza, postiConferenza, relatoreConferenza, prezzoConferenza);
    programmaEventi.AggiungiEvento(conferenza);

    Console.WriteLine("Ecco il tuo programma eventi con anche le conferenze: ");
    Console.WriteLine();
    Console.WriteLine(programmaEventi.RiepilogoProgrammaEventi());
}





