
namespace AdaTech.AluguelCarros.ConsoleMenuLibrary
{
    public class ConsoleMenu
    {
        private readonly string[] items;
        private int selectedIndex;

        public ConsoleMenu(string[] menuItems)
        {
            items = menuItems;
            selectedIndex = 0;
        }

        public void ShowMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                DisplayMenu();

                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(items.Length - 1, selectedIndex + 1);
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine($"Selected option: {items[selectedIndex]}");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Select an option:");

            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = (i == selectedIndex) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.BackgroundColor = (i == selectedIndex) ? ConsoleColor.Gray : ConsoleColor.Black;

                Console.WriteLine($"{items[i]}");

                Console.ResetColor();
            }
        }
    }
}

