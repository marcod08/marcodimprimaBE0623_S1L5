namespace S1L5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci i dati per il calcolo dell'imposta da versare");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Cognome: ");
            string cognome = Console.ReadLine();

            Console.WriteLine("Data di nascita (GG/MM/AAAA): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Sesso (M/F): ");
            char sesso = char.ToUpper(char.Parse(Console.ReadLine()));

            Console.WriteLine("Residenza: ");
            string residenza = Console.ReadLine();

            Console.WriteLine("Codice Fiscale: ");
            string cf = Console.ReadLine().ToUpper();

            Console.WriteLine("Reddito annuale: ");
            double reddito = int.Parse(Console.ReadLine());

            Contribuente contribuente1 = new Contribuente(nome, cognome, data, sesso, residenza, cf, reddito);
            double imposta = contribuente1.ImpostaDaVersare();

            Console.WriteLine("==================================================");
            Console.WriteLine($"Contribuente:{contribuente1.Nome} {contribuente1.Cognome}");
            Console.WriteLine($"nato il {contribuente1.Data:dd/MM/yyyy} ({contribuente1.Sesso})");
            Console.WriteLine($"residente in {contribuente1.Residenza}");
            Console.WriteLine($"codice fiscale:{contribuente1.Cf} ");
            Console.WriteLine($"Reddito dichiarato: {contribuente1.Reddito} Euro");
            Console.WriteLine($"IMPOSTA DA VERSARE: {imposta} Euro");
        }
    }

    public class Contribuente
    {
        private string _nome;
        private string _cognome;
        private DateTime _data;
        private char _sesso;
        private string _residenza;
        private string _cf;
        private double _reddito;

        public string Nome
        {
            get { return _nome; }
        }

        public string Cognome
        {
            get { return _cognome; }
        }

        public DateTime Data
        {
            get { return _data; }
        }

        public char Sesso
        {
            get { return _sesso; }
        }

        public string Residenza
        {
            get { return _residenza; }
        }

        public string Cf
        {
            get { return _cf; }
        }

        public double Reddito
        {
            get { return _reddito; }
        }
        
        public Contribuente(string nome, string cognome, DateTime data, char sesso, string residenza, string cf, double reddito)
        {
            _nome = nome;
            _cognome = cognome;
            _data = data;
            _sesso = sesso;
            _residenza = residenza;
            _cf = cf;
            _reddito = reddito;
        }

        public double ImpostaDaVersare()
        {
            double reddito = Reddito;
            double imposta;

            switch (reddito) 
            {
                case double reddit when reddit <= 15000:
                    imposta = reddito * 0.23;
                    break;
                case double reddit when reddit <= 28000:
                    imposta = 3450 + (reddito - 15000) * 0.27;
                    break;
                case double reddit when reddit <= 55000:
                    imposta = 6960 + (reddito - 28000) * 0.38;
                    break;
                case double reddit when reddit <= 75000:
                    imposta = 17220 + (reddito - 55000) * 0.41;
                    break;
                default:
                    imposta = 25420 + (reddito - 75000) * 0.43;
                    break;
            }
            return imposta;
        }


    }


}
