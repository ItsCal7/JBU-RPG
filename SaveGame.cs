namespace JBU_RPG_Project;

public class SaveGame
{
    public static void StartSave(int slot) //No saved player means this is a new game
    {
        string path;
        Player player = new Player();
        player.player();
        
        LoadGame.OpenArea(Save(slot, player), 0);
    }
    public static Player Save(int slot, Player player) //will be called whenever the player
                                                       //wants to save their current game state
    {
        string path;
        switch (slot)
        {
            case 1:
                path = @"..\..\..\save1.txt";
                break;
            case 2:
                path = @"..\..\..\save2.txt";
                break;
            case 3:
                path = @"..\..\..\save3.txt";
                break;
            default:
                Console.WriteLine("Error creating Save: file does not exist");
                return player;
        }
        using (StreamWriter tw = new StreamWriter(path))
        {
            tw.WriteLine(player.Name);
            tw.WriteLine(player.XP);
            tw.WriteLine(player.CalculateLevel(player.XP));
            tw.WriteLine(player.Weapon);
            tw.WriteLine(player.Armour);
            tw.WriteLine(player.Head);
            tw.WriteLine(player.Heart);
            tw.WriteLine(player.Hand);
            tw.WriteLine(0); //placeholder, only one area currently
        }
        return player;
    }

    public static void clearSave(int slot) //only used in admin menu rn
                                           //ensures empty files contain the word empty for proper funcitonality
    {
        string path;
        switch (slot)
        {
            case 1:
                path = @"..\..\..\save1.txt";
                break;
            case 2:
                path = @"..\..\..\save2.txt";
                break;
            case 3:
                path = @"..\..\..\save3.txt";
                break;
            default:
                Console.WriteLine("Error deleting Save: file does not exist"); //It could happen somehow
                return;
        }
        using (StreamWriter tw = new StreamWriter(path, false))      
            tw.WriteLine("empty");
    }
}