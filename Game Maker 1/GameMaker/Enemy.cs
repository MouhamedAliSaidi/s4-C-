class Enemy
{
    string name;
    public string _name { get { return name; } }

    int health = 100;
    public int _health { get { return health; } }

    public List<Attack> attackList = new List<Attack>();

    static Random rand = new Random();

    public Enemy(string n)
    {
        name = n;
    }

    public void AddAttack(Attack a)
    {
        attackList.Add(a);
    }

    public void RandomAttack()
    {
        if (attackList.Count == 0)
        {
            System.Console.WriteLine(name + " has no attacks!");
            return;
        }

        int index = rand.Next(attackList.Count);
        Attack chosen = attackList[index];
        System.Console.WriteLine(name + " uses " + chosen._name + " and deals " + chosen._damageAmount + " damage!");
    }
}
