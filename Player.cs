namespace JBU_RPG_Project;

public class Player:Character
{
    protected SortedSet<string> Backpack = new SortedSet<string>();
    private static int _level;
    private static int _xp;
    private static int _weapon;
    private static string _armour;

    public void player()
    {
        Name = "Volen";
        _level = 1;
        _xp = 0;
        _weapon = 1;
        _armour = "To-Go Box";
        Head = 1;
        Heart = 1;
        Hand = 1;
    }
	
	public void player(string name, int level, int xp, SortedSet<string> backpack, int weapon, string armour, int head, int heart, int hand)
    {
        Name = name;
        _level = level;
        _xp = xp;
		foreach(string item in backpack)
		{
			Backpack.Add(item);
		}
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

    private static void CalculateLevel(int xp)
    {
        _xp = xp / 100;
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
        if (Hand > target.Heart/2)
        {
            target.Heart -= Hand * _weapon;
        }
        else
        {
            Console.WriteLine(Name + " tried to attack " + target.Name + ", but missed");
        }
    }
}