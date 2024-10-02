namespace JBU_RPG_Project;

public class Areas
{
    public static void Opening()
    {
        Player player = new Player();
        player.player();
        Character monster = new Character();
        monster.character("Bearsharktopus",5, 1, 1);
        while (player.Heart > 0 && monster.Heart > 0)
        {
            Console.WriteLine("Type A to attack");
            if (PlayerAttack().Wait(TimeSpan.FromSeconds(3)))
            {
                player.Attack(monster);
            }
            else
            {
                var task2 = MonsterAttack();
                Task.WaitAny(task2);
                monster.Attack(player);
            }
        }
        if (player.Heart <= 0)
            Console.WriteLine("Game Over");
        else if (monster.Heart <= 0)
            Console.WriteLine("You Win");
    }
    public static async Task PlayerAttack()
    {
        await Task.Run(() =>
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            if (userInput.Key == ConsoleKey.A)
                Console.WriteLine("Player Attacks");
        });
    }
    
    public static async Task MonsterAttack()
    {
        await Task.Run(() =>
        {
            Console.WriteLine("Enemy Attacks");
        });
    }
}