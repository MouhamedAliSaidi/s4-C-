class Program
{
    static void Main()
    {
        Enemy bandit = new Enemy("Bandit");

        Attack fireball = new Attack("Fireball", 20);
        Attack punch = new Attack("Punch", 10);
        Attack scream = new Attack("Scream", 15);

        bandit.AddAttack(fireball);
        bandit.AddAttack(punch);
        bandit.AddAttack(scream);

        bandit.RandomAttack();
        bandit.RandomAttack();
        bandit.RandomAttack();

        System.Console.WriteLine("Enemy health: " + bandit._health);
    }
}
