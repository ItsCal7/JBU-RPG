namespace JBU_RPG_Project;

public class Player:Character
{
    public SortedSet<string> _backpack = new SortedSet<string>();
    private static int _level;
    private static int _xp;
    private static string _weapon;
    private static string _armour;

    public void player()
    {
        _level = 1;
        _xp = 0;
        _weapon = "Fist";
        _armour = "To-Go Box";
        Head = 1;
        Heart = 1;
        Hand = 1;
    }
    
    public int XP
    {
        get => _xp;
        set
        {
            _xp = value;
            CalculateLevel(_xp);
        }
    }

    private static void CalculateLevel(int xp)
    {
        _xp = xp / 100;
    }

    public static void Equip(string item)
    {
        _item = item;
    }
    
    public override void Attack(Character target)
    {
        if (Hand > target.Heart)//add weapon mod
        {
            target.Heart -= Hand;
        }
        else
        {
            Console.WriteLine(Name + " tried to attack " + target.Name + ", but missed");
        }
    }
}