namespace JBU_RPG_Project;

public class Character
{
    private string _name;
    private static int _head;
    private static int _heart;
    private static int _hand;

    public void character(string name, int head, int heart, int hand)
    {
        Name = name;
        Head = head;
        Heart = heart;
        Hand = hand;
    }
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Head
    {
        get => _head;
        set
        {
            _head = value;
        }
    }
    
    public int Heart
    {
        get => _heart;
        set
        {
            _heart = value;
        }
    }
    
    public int Hand
    {
        get => _hand;
        set
        {
            _hand = value;
        }
    }
    
    public virtual void Attack(Character target)
    {
        if (_hand > target.Heart/2) //aaaaaaaaaaa
        {
            target.Heart -= _hand;
        }
        else
        {
            Console.WriteLine(_name + " tried to attack " + target.Name + ", but missed");
        }
    }
}