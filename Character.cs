namespace JBU_RPG_Project;

public class Character
{
    private string name;
    private static int _head;
    private static int _heart;
    private static int _hand;

    public string Name
    {
        get => name;
        set => name = value;
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
        if (_hand > target.Heart)
        {
            target.Heart -= _hand;
        }
        else
        {
            Console.WriteLine(name + " tried to attack " + target.Name + ", but missed");
        }
    }
}