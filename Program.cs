using System;

namespace progettoSettimanale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contribuente persona = new Contribuente();

            Console.WriteLine("Inserisci il nome:");
            string nome = ReadStringFromConsole("Nome");
            persona.Nome = nome;

            Console.WriteLine("Inserisci il cognome:");
            string cognome = ReadStringFromConsole("Cognome");
            persona.Cognome = cognome;

            Console.WriteLine("Inserisci la data di nascita (formato: AAAAMMGG):");
            DateTime dataDiNascita = ReadDateFromConsole();
            persona.DataDiNascita = dataDiNascita;

            Console.WriteLine("Inserisci il codice fiscale:");
            string codiceFiscale = ReadStringFromConsole("Codice Fiscale");
            persona.CodiceFiscale = codiceFiscale;

            Console.WriteLine("Inserisci il sesso:");
            string sesso = ReadStringFromConsole("Sesso");
            persona.Sesso = sesso;

            Console.WriteLine("Inserisci il comune di residenza:");
            string comuneDiResidenza = ReadStringFromConsole("Comune di Residenza");
            persona.ComuneDiResidenza = comuneDiResidenza;

            Console.WriteLine("Inserisci il reddito annuale:");
            int redditoAnnuale = ReadIntFromConsole();
            persona.RedditoAnnuale = redditoAnnuale;

            double imposta = persona.CalcolaImposta();

            Console.Clear();

            Console.WriteLine($"Contribuente: {persona.Nome} {persona.Cognome},");
            Console.WriteLine($"nato il {persona.DataDiNascita.ToString("dd/MM/yyyy")} ({persona.Sesso}),");
            Console.WriteLine($"residente in {persona.ComuneDiResidenza},");
            Console.WriteLine($"codice fiscale: {persona.CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: euro {persona.RedditoAnnuale:N2}");
            Console.WriteLine($"IMPOSTA DA VERSARE: euro {imposta:N2}");
        }

        static string ReadStringFromConsole(string fieldName)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"{fieldName} non può essere vuoto. Riprova:");
                }
            }
        }

        static DateTime ReadDateFromConsole()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Riprova:");
                }
            }
        }

        static int ReadIntFromConsole()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova:");
                }
            }
        }

        public class Contribuente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataDiNascita { get; set; }
            public string CodiceFiscale { get; set; }
            public string Sesso { get; set; }
            public string ComuneDiResidenza { get; set; }
            public int RedditoAnnuale { get; set; }

            public Contribuente(string nome, string cognome, DateTime dataDiNascita, string codiceFiscale, string sesso, string comuneDiResidenza, int redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataDiNascita = dataDiNascita;
                CodiceFiscale = codiceFiscale;
                Sesso = sesso;
                ComuneDiResidenza = comuneDiResidenza;
                RedditoAnnuale = redditoAnnuale;
            }

            public Contribuente()
            {
            }

            public double CalcolaImposta()
            {
                double imposta = 0;

                switch (RedditoAnnuale)
                {
                    case int impost when impost <= 15000:imposta = RedditoAnnuale * 0.23;break;

                    case int impost when impost <= 28000:imposta = 3450 + (RedditoAnnuale - 15000) * 0.27;break;

                    case int impost when impost <= 55000:imposta = 6960 + (RedditoAnnuale - 28000) * 0.38;break;

                    case int impost when impost <= 75000:imposta = 17220 + (RedditoAnnuale - 55000) * 0.41;break;

                    default:imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;break;
                }
                return imposta;
            }
        }
    }
}
