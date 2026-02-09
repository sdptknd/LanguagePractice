// See https://aka.ms/new-console-template for more information

using System.Text;

namespace SimpleTest;

public class Employee // Base
{
    public string Name { get; set; }
    public virtual void CalculatePay()
    {
        Console.WriteLine("Calculating pay for employee.");
    }
}

public class Manager : Employee // Derived
{
    public override void CalculatePay() 
    {
        Console.WriteLine("Calculating pay for manager with bonus.");
    }
}

public class SeniorManager : Manager // Derived from Manager
{
    public override sealed void CalculatePay()
    {
        Console.WriteLine("Calculating pay for senior manager with higher bonus.");
    }
}

// Abstract Class: Defines Identity and Shared State
public abstract class GameObject
{
    public int X { get; set; } // State
    public int Y { get; set; } // State

    public GameObject(int x, int y) 
    {
        X = x; Y = y;
    }

    public void Render() 
    {
        Console.WriteLine($"Rendering at {X},{Y}"); // Shared Logic
    }

    // Force children to implement this
    public abstract void Update(); 
}

// Interface: Defines Capability
public interface IDamageable
{
    void TakeDamage(int amount)
    {
        Console.WriteLine($"Taking {amount} damage.");        
    }
}

// Concrete Class
// "Player IS A GameObject AND CAN BE Damaged"
public class Player : GameObject, IDamageable
{
    public int Health { get; private set; } = 100;

    public Player(int x, int y) : base(x, y) { }

    public override void Update()
    {
        // Player specific update logic
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        Console.WriteLine($"Player took {amount} damage, health now {Health}.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Employee emp = new Employee();
        // emp.CalculatePay();

        // Manager mgr = new Manager();
        // mgr.CalculatePay();

        // Employee empAsMgr = new Manager();
        // empAsMgr.CalculatePay();

        // SeniorManager srMgr = new SeniorManager();
        // srMgr.CalculatePay();

        // Employee empAsSrMgr = new SeniorManager();
        // empAsSrMgr.CalculatePay();

        // Manager mgrAsSrMgr = new SeniorManager();
        // mgrAsSrMgr.CalculatePay();

        // Player player = new Player(10, 20);
        // player.TakeDamage(30);

        // IDamageable damageablePlayer = player;
        // damageablePlayer.TakeDamage(20);

        // List<Employee> empls = new List<Manager>();
    }

    // static int Main()
    // {
    //     return 0;
    // }
    
}