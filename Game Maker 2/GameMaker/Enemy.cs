using System;
using System.Collections.Generic;

class Enemy
{
    public string Name;
    private int health;
    public int Health { get { return health; } }
    public List<Attack> AttackList;

    public Enemy(string name, int startingHealth)
    {
        Name = name;
        health = startingHealth;
        AttackList = new List<Attack>();
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    public void PerformAttack(Enemy target, Attack chosenAttack)
    {
        target.ReceiveDamage(chosenAttack.DamageAmount);
        Console.WriteLine($"{Name} attacks {target.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!!");
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;
    }

    public void ReceiveHealing(int amount)
    {
        health += amount;
        
    }
}

class MeleeFighter : Enemy
{
    private Random rand = new Random();

    public MeleeFighter(string name) : base(name, 120)
    {
        AddAttack(new Attack("Punch", 20));
        AddAttack(new Attack("Kick", 15));
        AddAttack(new Attack("Tackle", 25));
    }

    public void Rage(Enemy target)
    {
        int index = rand.Next(AttackList.Count);
        Attack baseAttack = AttackList[index];
        Attack rageAttack = new Attack(baseAttack.Name, baseAttack.DamageAmount + 10);

        PerformAttack(target, rageAttack);
    }
}

class RangedFighter : Enemy
{
    public int Distance;

    public RangedFighter(string name) : base(name, 100)
    {
        Distance = 5; 
        AddAttack(new Attack("Shoot an Arrow", 20));
        AddAttack(new Attack("Throw a Knife", 15));
    }

    public new void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} is too close to attack with {chosenAttack.Name}. Distance is {Distance}.");
            return;
        }
        base.PerformAttack(target, chosenAttack);
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashes forward, increasing distance to {Distance}.");
    }
}

class MagicCaster : Enemy
{
    public MagicCaster(string name) : base(name, 80)
    {
        AddAttack(new Attack("Fireball", 25));
        AddAttack(new Attack("Lightning Bolt", 20));
        AddAttack(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy target)
    {
        target.ReceiveHealing(40);
        Console.WriteLine($"{Name} heals {target.Name}, increasing health to {target.Health}.");
    }
}
