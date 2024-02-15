using System.Text.Json;

class TaskManager
{
    private static List<Task> tasks = new List<Task>();

    static TaskManager()
    {
        // Load tasks from file when the program starts
        FileManager.WczytajZadaniaZPliku(tasks);
    }

    public static void DodajZadanie()
    {
        Console.Clear();
        Console.WriteLine("Podaj dane nowego zadania:");

        // Pobierz dane od użytkownika
        int id = FileManager.GetLastIdFromFile();

        Console.Write("Tytuł: ");
        string tytul = Console.ReadLine();

        Console.Write("Opis: ");
        string opis = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        string dataStart = currentDate.ToString("dd-MM-yyyy");

        string dataKoniec = "";

        Console.Write("Priorytet (1-3): ");
        int priorytet = int.Parse(Console.ReadLine());
        while (priorytet < 1 || priorytet > 3)
        {
            Console.Write("Podałeś niepoprawny priorytet.");
            Console.Write("Priorytet (1-3): ");
            priorytet = int.Parse(Console.ReadLine());
        }

        string status = "W trakcie";

        // Dodaj nowe zadanie do listy
        Task noweZadanie = new Task(id, tytul, opis, dataStart, dataKoniec, priorytet, status);
        tasks.Add(noweZadanie);
        Console.Clear();
        Console.WriteLine("Zadanie dodane pomyślnie.\n");

        FileManager.ZapiszZadaniaDoPliku(tasks);
    }

    public static void EdytujZadanie()
    {
        Console.Clear();
        Console.Write("Podaj ID zadania do edycji: ");
        int idDoEdycji = int.Parse(Console.ReadLine());

        Task zadanieDoEdycji = tasks.FirstOrDefault(t => t.Id == idDoEdycji);
        if (zadanieDoEdycji != null)
        {
            Console.Clear();
            Console.WriteLine("Podaj nowe dane zadania:");

            // Pobierz nowe dane od użytkownika
            Console.Write("Tytuł: ");
            zadanieDoEdycji.Tytul = Console.ReadLine();

            Console.Write("Opis: ");
            zadanieDoEdycji.Opis = Console.ReadLine();

            Console.Write("Priorytet (1-3): ");
            int priorytet = int.Parse(Console.ReadLine());
            while (priorytet < 1 || priorytet > 3)
            {
                Console.Write("Podałeś niepoprawny priorytet.");
                Console.Write("Priorytet (1-3): ");
                priorytet = int.Parse(Console.ReadLine());
            }
            zadanieDoEdycji.Priorytet = priorytet;

            Console.Clear();
            Console.WriteLine("Zadanie zaktualizowane pomyślnie.\n");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Nie znaleziono zadania o ID {idDoEdycji}.\n");
        }

        FileManager.ZapiszZadaniaDoPliku(tasks);
    }

    public static void UsunZadanie()
    {
        Console.Write("Podaj ID zadania do usunięcia: ");
        int idDoUsuniecia = int.Parse(Console.ReadLine());

        Task zadanieDoUsuniecia = tasks.FirstOrDefault(t => t.Id == idDoUsuniecia);
        if (zadanieDoUsuniecia != null)
        {
            tasks.Remove(zadanieDoUsuniecia);
            Console.Clear();
            Console.WriteLine($"Zadanie o ID {idDoUsuniecia} zostało usunięte.\n");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Nie znaleziono zadania o ID {idDoUsuniecia}.\n");
        }

        FileManager.ZapiszZadaniaDoPliku(tasks);
    }

    public static void WyswietlZadania()
    {
        Console.Clear();
        Console.WriteLine("Lista zadań:");
        foreach (var zadanie in tasks)
        {
            Console.WriteLine(
                $"ID: {zadanie.Id}\n" +
                $"Tytuł: {zadanie.Tytul}\n" +
                $"Opis: {zadanie.Opis}\n" +
                $"Data_start: {zadanie.DataStart}\n" +
                $"Data_end: {zadanie.DataKoniec}\n" +
                $"Priorytet: {zadanie.Priorytet}\n" +
                $"Status: {zadanie.Status}\n");
        }
    }

    public static void ZakonczZadanie()
    {
        Console.Clear();
        Console.Write("Podaj ID zadania do zakończenia: ");
        int idDoZakonczenia = int.Parse(Console.ReadLine());

        Task zadanieDoZakonczenia = tasks.FirstOrDefault(t => t.Id == idDoZakonczenia);
        if (zadanieDoZakonczenia != null)
        {
            DateTime currentDate = DateTime.Now;
            string dataEnd = currentDate.ToString("dd-MM-yyyy");

            zadanieDoZakonczenia.DataKoniec = dataEnd;
            zadanieDoZakonczenia.Status = "Zakończone";

            Console.Clear();
            Console.WriteLine("Zadanie zakończone pomyślnie.\n");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Nie znaleziono zadania o ID {idDoZakonczenia}.\n");
        }

        FileManager.ZapiszZadaniaDoPliku(tasks);
    }

}