namespace JBU_RPG_Project;

public class Player:Character
{
    protected SortedSet<string> Backpack = new SortedSet<string>();
    private static int _level;
    private static int _xp;
    private static int _weapon;
    private static string _armour;

    public void player() //new player creation
    {
        Console.WriteLine("What is your Name");
        string name = Console.ReadLine();
        Name = name;
        _level = 1;
        _xp = 0;
        _weapon = 1;
        _armour = "To-Go Box";
        Head = 1;
        Heart = 1;
        Hand = 1;
    }
	
	public void player(string name, int level, int xp, int weapon, string armour, int head, int heart, int hand)
    //loading a player, for starting a save file
    {
        Name = name;
        _level = level;
        _xp = xp;
        _weapon = weapon;
        _armour = armour;
        Head = head;
        Heart = heart;
        Hand = hand;
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

    public int Weapon { get => _weapon; }
    
    public string Armour { get => _armour; }
    
    public int CalculateLevel(int xp)
    {
        return _level = xp / 100;
    }

    protected static void EquipWeapon(int item)
    {
        _weapon = item;
    }
    protected static void EquipArmour(string item)
    {
        _armour = item;
    }
    
    public override void Attack(Character target)
    {
        if (true) //haven't made block working yet, so it always lands
        {
            target.Heart -= Hand * _weapon;
        }
        else
        {
            Console.WriteLine(Name + " tried to attack " + target.Name + ", but missed");
        }
    }
}