using System.Text.RegularExpressions;

namespace JBU_RPG_Project;

public static class MainMenu
{
    public static void Main(string[] args)
    {
        ConsoleKeyInfo userInput;
        List<string> slots = new List<string>() {"empty", "empty", "empty"};
        bool savedGame = false;
        Console.Write("Welcome to the (unofficial) JBU RPG");
        Console.Write(Art.AltShield);
        while(true)
        {
            Console.WriteLine("Press Escape to Exit at Any Time");
            Console.WriteLine("1. Start Game");
            Console.Write("2. Continue Game");
            if (savedGame)
                Console.WriteLine();
            else
            {
                Console.WriteLine(" - x");
            }

            userInput = Console.ReadKey();
            Console.WriteLine();
            switch (userInput.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    StartGame(ref slots);
                    savedGame = true;
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    if (savedGame)
                    {
                        ContinueGame(ref slots);
                    }
                    else
                    {
                        Console.WriteLine("No Saved Games");
                    }

                    break;
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid Input, Try Again");
                    break;
            }
        }
    }

    public static void StartGame(ref List<string> slots) 
        //TODO: change the call-by for the variables
    {
        Console.WriteLine("Choose A Save Slot");
        Console.WriteLine("1 - " + slots[0] + ", 2 - " + slots[1] + ", 3 - " + slots[2]);
        Console.WriteLine("Type 'X' to quit");
        string newSlot = Console.ReadLine().ToUpper();
        switch (newSlot)
        {
            case "1" or "2" or "3":
                int index = int.Parse(newSlot);
                if (!slots[index-1].Equals("empty"))
                {
                    Console.WriteLine("This will overwrite the saved data");
                    Console.WriteLine("Continue: Y/N");
                    string overwrite = Console.ReadLine().ToUpper();
                    if (overwrite == "N")
                    {
                        break;
                    }
                }
                slots[index - 1] = "saved game";
                Console.WriteLine("Starting Game " + newSlot);
                break;
            case "X":
                break;
        }
    }
    public static void ContinueGame(ref List<string> slots)
        //TODO: change the call-by for the variables
    {
        Console.WriteLine("Select Saved Game");
        Console.WriteLine("1 - " + slots[0] + ", 2 - " + slots[1] + ", 3 - " + slots[2]);
        Console.WriteLine("Type 'X' to quit");
        string saveSlot = Console.ReadLine().ToUpper();
        switch (saveSlot)
        {
            case "1" or "2" or "3":
                if (slots[int.Parse(saveSlot) - 1].Equals("empty"))
                {
                    Console.WriteLine("Starting Game");
                }
                else
                {
                    Console.WriteLine("Loading Game " + saveSlot);
                }
                break;
            case "X":
                break;
        }
        
    }
}