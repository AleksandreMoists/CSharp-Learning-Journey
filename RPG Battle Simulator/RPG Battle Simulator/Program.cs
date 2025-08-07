
public class Program
{
    public static void Main(string[] args)
    {
        Person player = new Person("Sir C-Sharp");
        Goblin monster = new Goblin();
        Console.WriteLine($"A wild {monster.Name} appears!");
        Console.WriteLine($"{player.Name} ({player.Health} HP) vs. {monster.Name} ({monster.Health} HP)");
        while (player.IsAlive && monster.IsAlive)
        {
            player.PerformAttack(monster);
            monster.PerformAttack(player);
            Console.WriteLine($"{player.Name} attacked {monster.Name} and now monster's health is: {monster.Health}!");
            Console.WriteLine($"No! {monster.Name} attacked back, person health is: {player.Health}");
            player.PerformAttack(monster);
            if(!monster.IsAlive) break;

            monster.PerformAttack(player);
            if(!player.IsAlive) break;

            Console.WriteLine("--- End of Turn ---");
            Console.ReadKey();
        }
    }





abstract class Character
{
    public string Name { get; private set; }
    public int Health { get; protected set; }
    public int MaxHealth { get; private set; }
    public int AttackDamage { get; private set; }

    protected Character(string name, int health, int attackDamage)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        AttackDamage = attackDamage;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if(Health < 0)
        {
            Health = 0;
        }
        Console.WriteLine($"{Name} takes {amount} damage, and now health is: {Health}");
    }

    public bool IsAlive
    {
        get { return Health > 0; } 

    }


    public abstract void PerformAttack(Character character);
}

class Person : Character
{
    public Person(string name) : base(name, 100, 20) { }

    public override void PerformAttack(Character target)
    {
        Console.WriteLine($"{Name} strikes {target.Name} with their sword!");
        target.TakeDamage(this.AttackDamage);
    }
}

class Dragon : Character
{
    public Dragon(string name) : base(name, 300, 50);

    public override void PerformAttack(Character target)
    {
        Console.WriteLine($"{Name} viciously attacks {target.Name}!");
        target.PerformAttack(this.AttackDamage);
    }
}

class Goblin : Character
{
    public Goblin(string name) : base(name, 200, 75);

    public override void PerformAttack(Character target)
    {
        Console.WriteLine($"{Name} viciously attacks {target.Name}!");
        target.PerformAttack(this.AttackDamage);
    }
}