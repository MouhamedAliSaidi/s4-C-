class Program
{
    static void Main()
    {
        MeleeFighter melee = new MeleeFighter("Grog");
        RangedFighter ranged = new RangedFighter("Artemis");
        MagicCaster magic = new MagicCaster("Merlin");

        // Kick attack from melee to ranged
        melee.PerformAttack(ranged, melee.AttackList.Find(a => a.Name == "Kick"));

        // Rage method from melee to magic
        melee.Rage(magic);

        // Shoot an Arrow attack from ranged to melee (should not work due to distance)
        ranged.PerformAttack(melee, ranged.AttackList.Find(a => a.Name == "Shoot an Arrow"));

        // Ranged dash to increase distance
        ranged.Dash();

        // Shoot an Arrow again (should work now)
        ranged.PerformAttack(melee, ranged.AttackList.Find(a => a.Name == "Shoot an Arrow"));

        // Fireball attack from magic to melee
        magic.PerformAttack(melee, magic.AttackList.Find(a => a.Name == "Fireball"));

        // Heal method from magic on ranged
        magic.Heal(ranged);

        // Heal method from magic on self
        magic.Heal(magic);
    }
}
