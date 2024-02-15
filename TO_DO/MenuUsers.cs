class MenuUsers
{
    public static void Menu()
    {
        int wybor;
        while (true)
        {
            Console.WriteLine("Aplikacja do zarządzania zadaniami:");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj się");
            Console.WriteLine("3. Wyjdź");

            if (int.TryParse(Console.ReadLine(), out wybor))
            {
                switch (wybor)
                {
                    case 1:
                        User.Logowanie();
                        break;
                    case 2:
                        User.Rejestracja();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.\n");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nieprawidłowy format. Wybierz ponownie.\n");
            }
        }
    }
}
