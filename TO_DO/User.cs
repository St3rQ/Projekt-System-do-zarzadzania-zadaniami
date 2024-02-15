using System;
using System.Collections.Generic;
using System.IO;

class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Haslo { get; set; }

    public User(int id, string login, string haslo)
    {
        Id = id;
        Login = login;
        Haslo = haslo;
    }

    public static void Logowanie()
    {
        string sciezkaPliku = "uzytkownicy.txt";

        Console.Clear();

        Console.WriteLine("Podaj login:");
        string login = Console.ReadLine();
        string haslo = GetPassword();

        Console.Clear();

        // Sprawdź, czy plik istnieje
        if (File.Exists(sciezkaPliku))
        {
            // Odczytaj dane z pliku
            string[] linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                string[] dane = linia.Split(',');

                // Sprawdź, czy login i hasło pasują do danych w pliku
                if (dane.Length == 3 && dane[1] == login && dane[2] == haslo)
                {
                    Console.WriteLine("Zalogowano pomyślnie!\n");
                    MenuTasks.Menu();
                    return;
                }
            }
        }

        Console.WriteLine("Błąd logowania. Sprawdź login i hasło.\n");
    }

    static string GetPassword()
    {
        string haslo = "";
        Console.Write("Podaj hasło: ");
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Jeśli wciśnięto klawisz Backspace, usuń ostatni znak z hasła
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                haslo += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && haslo.Length > 0)
            {
                haslo = haslo.Remove(haslo.Length - 1);
                Console.Write("\b \b"); // Usuń ostatni znak i przesuń kursor w lewo
            }
        }
        // Kontynuuj wpisywanie hasła do momentu naciśnięcia klawisza Enter
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Nowa linia po wprowadzeniu hasła
        return haslo;
    }

    public static void Rejestracja()
    {
        Console.Clear();

        Console.WriteLine("Podaj nowy login:");
        string nowyLogin = Console.ReadLine();
        Console.WriteLine("Podaj nowe hasło:");
        string noweHaslo = Console.ReadLine();

        Console.Clear();

        // Rejestracja użytkownika i zapis do pliku
        ZapiszDoPliku(new User(0, nowyLogin, noweHaslo));

        Console.WriteLine("Zarejestrowano pomyślnie!\n");
    }

    public static void ZapiszDoPliku(User user)
    {
        string sciezkaPliku = "uzytkownicy.txt";

        // Sprawdź, czy plik istnieje, jeśli nie, utwórz nowy
        if (!File.Exists(sciezkaPliku))
        {
            File.Create(sciezkaPliku).Close();
        }

        // Sprawdź ostatnie ID użytkownika w pliku
        int ostatnieId = OstatnieIdUzytkownika(sciezkaPliku);

        // Dodaj nowego użytkownika do pliku
        using (StreamWriter sw = File.AppendText(sciezkaPliku))
        {
            sw.WriteLine($"{ostatnieId + 1},{user.Login},{user.Haslo}");
        }
    }

    private static int OstatnieIdUzytkownika(string sciezkaPliku)
    {
        // Sprawdź, czy plik istnieje
        if (!File.Exists(sciezkaPliku))
        {
            return 0;
        }

        // Odczytaj ostatnie ID z pliku
        using (StreamReader sr = new StreamReader(sciezkaPliku))
        {
            string ostatniaLinia = string.Empty;

            while (!sr.EndOfStream)
            {
                ostatniaLinia = sr.ReadLine();
            }

            if (!string.IsNullOrEmpty(ostatniaLinia))
            {
                string[] dane = ostatniaLinia.Split(',');
                if (dane.Length > 0)
                {
                    return Convert.ToInt32(dane[0]);
                }
            }
        }

        return 0;
    }
}