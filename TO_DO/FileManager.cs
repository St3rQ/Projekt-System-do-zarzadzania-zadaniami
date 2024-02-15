using System.Threading.Tasks;

class FileManager
{
    public static void WczytajZadaniaZPliku(List<Task> tasks)
    {
        if (File.Exists("zadania.txt"))
        {
            string[] lines = File.ReadAllLines("zadania.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                int id = int.Parse(parts[0]);
                string tytul = parts[1];
                string opis = parts[2];
                string dataStart = parts[3];
                string dataKoniec = parts[4];
                int priorytet = int.Parse(parts[5]);
                string status = parts[6];

                Task loadedTask = new Task(id, tytul, opis, dataStart, dataKoniec, priorytet, status);
                tasks.Add(loadedTask);
            }
        }
    }

    public static int GetLastIdFromFile()
    {
        int lastId = 0;

        try
        {
            // Sprawdź, czy plik istnieje
            if (File.Exists("zadania.txt"))
            {
                // Wczytaj wszystkie linie z pliku
                string[] lines = File.ReadAllLines("zadania.txt");

                // Sprawdź, czy istnieją linie w pliku
                if (lines.Length > 0)
                {
                    // Odczytaj ostatnią linię, która powinna zawierać ostatnie ID
                    string lastLine = lines[lines.Length - 1];

                    // Podziel linię na poszczególne części za pomocą separatora |
                    string[] parts = lastLine.Split('|');

                    // Spróbuj przekonwertować pierwszą część na liczbę całkowitą
                    if (parts.Length > 0 && int.TryParse(parts[0], out lastId))
                    {
                        // Pomyślnie wczytano ostatnie ID
                        Console.WriteLine("Ostatnie ID z pliku: " + lastId);
                    }
                    else
                    {
                        // W przypadku niepowodzenia konwersji
                        Console.WriteLine("Błąd konwersji pierwszej części linii na liczbę całkowitą.");
                    }
                }
                else
                {
                    // Plik jest pusty
                    Console.WriteLine("Plik jest pusty.");
                }
            }
            else
            {
                // Plik nie istnieje
                Console.WriteLine("Plik nie istnieje.");
            }
        }
        catch (Exception ex)
        {
            // Obsługa błędów
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }

        return lastId+1;
    }

    public static void ZapiszZadaniaDoPliku(List<Task> tasks)
    {
        using (StreamWriter writer = new StreamWriter("zadania.txt"))
        {
            foreach (var zadanie in tasks)
            {
                string linia = $"{zadanie.Id}|{zadanie.Tytul}|{zadanie.Opis}|{zadanie.DataStart}|{zadanie.DataKoniec}|{zadanie.Priorytet}|{zadanie.Status}";
                writer.WriteLine(linia);
            }
        }
    }
}