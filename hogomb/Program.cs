using System.Linq.Expressions;
using System.Text.Json.Serialization.Metadata;

namespace hogomb
{
    internal class Program
    {
        static List<string> elemek = new List<string>();
        static List<int> elemekSzama = new List<int>();
        static void Main(string[] args)
        {
            bool fut = true;
            while (fut)
            {
                Console.WriteLine("1. Elemek hozzáadása a hógömbhöz");
                Console.WriteLine("2. Tartalom megtekintése");
                Console.WriteLine("3. Elem eltávolítása a hógömbből");
                Console.WriteLine("4. Befejezés\n");
                Console.Write("Válasz egy opciót: ");
                
                try
                {
                    int opcio = Convert.ToInt32(Console.ReadLine());
                    if (opcio < 0)
                    {
                        throw new Exception("az opció nem lehet negatív szám");
                    }
                    switch (opcio)
                    {
                        case 1:
                            Console.Clear();
                            hozzaadas();
                            break;
                        case 2:
                            Console.Clear();
                            megtekintes();
                            break;
                        case 3:
                            Console.Clear();
                            eltavolitas();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Érvénytelen érték!");
                            break;

                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Csak számot adhatsz meg!");
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Hiba: {ex.Message}");
                }
                
                
            }
        }

        static void hozzaadas()
        {
            
            Console.Write("Adja meg az elem nevét: ");
            try
            {
                string elem = Console.ReadLine();
                bool szamE = int.TryParse(elem, out int eredmeny);
                if (szamE == true)
                {
                    throw new ArgumentException("Az elem nem lehet csak szám!");
                }
                if (string.IsNullOrEmpty(elem))
                {
                    throw new ArgumentException("Az elem nem lehet üres!");
                }

                Console.Write("Adja meg az elem darabszámát: ");
                int elemSzam = int.Parse(Console.ReadLine());
                if (elemSzam < 0)
                {
                    throw new ArgumentException("A darabszámnak pozitívnak kell lennie!");
                }
                Console.Clear();
                Console.WriteLine("Az elem sikeresen hozzá lett adva a hógömbhöz!");
                elemek.Add(elem);
                elemekSzama.Add(elemSzam);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Az elemek számát csak számként lehet megadni!");
            }
            
        }

        static void megtekintes()
        {
            if (elemek.Count == 0)
            {
                Console.WriteLine("A lista üres!");
                return;
            }
            for (int i = 0; i < elemek.Count; i++)
            {
                Console.WriteLine($"{elemek[i]} : {elemekSzama[i]}");
            }
        }

        static void eltavolitas()
        {
            Console.Write("Adja meg az eltávolítandó elemet: ");
            try
            {
                string eltavolitas = Console.ReadLine();
                if (string.IsNullOrEmpty(eltavolitas))
                {
                    throw new Exception("Az elem nem lehet üres!");
                }
                else if (!elemek.Contains(eltavolitas))
                {
                    Console.WriteLine("Az elem nincs a listában!");
                }
                else
                {
                    Console.WriteLine("Az elem sikeresen eltávolítva!");
                    int index = elemek.IndexOf(eltavolitas);
                    elemek.RemoveAt(index);
                    elemekSzama.RemoveAt(index);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
    }
}
