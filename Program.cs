using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JBU_RPG_Project;

public static class MainMenu
{
    public static void Main(string[] args)
    {
        ConsoleKeyInfo userInput;
        bool savedGame = false;
        while(true)
        {
            Console.Write("Welcome to the (unofficial) JBU RPG");
            Console.Write(Art.AltShield);
            //first gets the name attached to the save file
            string save1 = File.ReadLines(@"..\..\..\save1.txt").First();
            string save2 = File.ReadLines(@"..\..\..\save2.txt").First();
            string save3 = File.ReadLines(@"..\..\..\save3.txt").First();
            List<string> slots = [save1, save2, save3];
            
            Console.WriteLine("Press Escape to Exit at Any Time");
            Console.WriteLine("1. Start Game");
            if (!slots.All(s => s.Contains("empty")))
            {
                savedGame = true;
                Console.WriteLine("2. Continue Game");//if any of the slots are saved, continue game appears
            }
            
            //I use readkey so the user can use escape to exit the game
            userInput = Console.ReadKey(); 
            Console.WriteLine();
            switch (userInput.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    StartGame(ref slots, false);
                    break;
                
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    if (savedGame)
                    {
                        StartGame(ref slots, true);
                    }
                    else
                    {
                        Console.WriteLine("No Saved Games");
                    }
                    break;
                
                case ConsoleKey.Escape:
                    System.Environment.Exit(0); //I love this so much
                    return;
                
                case ConsoleKey.Delete: // developer option to clear all slots just in case
                    SaveGame.clearSave(1);
                    SaveGame.clearSave(2);
                    SaveGame.clearSave(3);
                    break;
                
                default:
                    Console.WriteLine("Invalid Input, Try Again");
                    break;
            }
            Console.WriteLine("o");
            //For whatever reason, on loops, the program submits a newline after the first character
            //but not every character, . # * and % are all safe. It appears to be alphanumeric.
            //underlines, much like not having the WriteLine here, cause the program to not loop to the beginning
            //It works, this is all that matters
            //Besides, you can't see the o unless you scroll up
        }
    }

    //was originally two different functions, but consolidated to remove repetition
    private static void StartGame(ref List<string> slots, bool cont) 
    {
        Console.WriteLine(cont ? "Select Saved Game" : "Choose A Save Slot");
        
        Console.WriteLine("1 - " + slots[0] + ", 2 - " + slots[1] + ", 3 - " + slots[2]);
        Console.WriteLine("Press escape at any time to quit to main menu");
        
        var slot = Console.ReadKey();
        Console.WriteLine();
        switch (slot.Key)
        {
            case ConsoleKey.D1 or ConsoleKey.D2 or ConsoleKey.D3 or ConsoleKey.NumPad1 or ConsoleKey.NumPad2 or ConsoleKey.NumPad3:
                int index = int.Parse(slot.KeyChar.ToString()); //Messy but works
                if (cont) //case where they are loading a game with no data handled within LoadGame.Load
                {
                    Console.WriteLine("Loading Game " + slot);
                    LoadGame.Load(index);
                    break;
                }
                
                else if (!slots[index-1].Equals("empty")) // checks if chosen slot is not empty
                {
                    Console.WriteLine("This will overwrite the saved data");
                    Console.WriteLine("Continue: Y/N");
                    var overwrite = Console.ReadKey();
                    if (overwrite.Key != ConsoleKey.Y) //if they do anything but agree, assume they meant to deny
                        break;
                }
                //if they overwrite, or if the slot is empty and they are not loading a game, they end up here
                Console.WriteLine("Starting Game " + index);
                SaveGame.StartSave(index);
                break;
            
            case ConsoleKey.Escape: //This takes back to main menu instead of exiting
                                    //makes more UX sense as a back button than a quit button
                break;
        }
    }
}