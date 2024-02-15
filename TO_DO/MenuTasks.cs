class MenuTasks
{
    public static void Menu()
    {
        int wybor;
        while (true)
        {
            Console.WriteLine("Menu operacji na zadaniach:");
            Console.WriteLine("1. Wyświetl zadania");
            Console.WriteLine("2. Dodaj zadanie");
            Console.WriteLine("3. Edytuj zadanie");
            Console.WriteLine("4. Usuń zadanie");
            Console.WriteLine("5. Zakończ zadanie");
            Console.WriteLine("6. Wyjdź");

            if (int.TryParse(Console.ReadLine(), out wybor))
            {
                switch (wybor)
                {
                    case 1:
                        TaskManager.WyswietlZadania();
                        break;
                    case 2:
                        TaskManager.DodajZadanie();
                        break;
                    case 3:
                        TaskManager.EdytujZadanie();
                        break;
                    case 4:
                        TaskManager.UsunZadanie();
                        break;
                    case 5:
                        TaskManager.ZakonczZadanie();
                        break;
                    case 6:
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
