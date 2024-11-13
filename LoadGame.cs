using System.Linq.Expressions;

namespace JBU_RPG_Project;

public class LoadGame
{
    public static void Load(int slot)
    {
        string path;
        switch (slot)//maybe a better way to do this, but it works
        {
            default:
                path = @"..\..\..\save1.txt";
                break;
            case 2:
                path = @"..\..\..\save2.txt";
                break;
            case 3:
                path = @"..\..\..\save3.txt";
                break;
        }
        
        List<string> data = new List<string>();
        using (StreamReader tr = new StreamReader(path))
        {
            string line;
            while((line = tr.ReadLine()) != null)
            {
                data.Add(line); //Fill data list with each line in the save file
            }
        }

        Player player = new Player();
        try
        {
            player.player(data[0], int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[3]), data[4],
                int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7])); 
            OpenArea(player, int.Parse(data[8])); //not the cleanest way of dealing with it, but it works
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("Slot Has no Saved Data"); //if player tries to load an empty save file, they don't do that
        }
    }

    public static void OpenArea(Player player, int area) //makes sense in this class rather than areas
    //areas is for the code for the actual areas, loading into one is a part of the loading class
    {
        switch (area)
        {
            case 0:
                Areas.Opening(player);
                break;
        }
    }
}