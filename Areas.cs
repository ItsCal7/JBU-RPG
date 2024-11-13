namespace JBU_RPG_Project;

public class Areas
{
    //This doesn't work properly, might just make it a rock paper scissors thing
    //if you both block, nothing happens
    //if you attack and he blocks, he gets a free attack
    //if he attacks and you block, you get a free attack
    //if you both attack, nothing happens
    public static void Opening(Player player)
    {
        Character monster = new Character();
        Console.WriteLine(Art.BearSharkTopus);
        Console.WriteLine("The Bearsharktopus");
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
        if (player.Heart <= 0){ Console.WriteLine("Game Over");}
        else if (monster.Heart <= 0) {Console.WriteLine("You Win");}
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