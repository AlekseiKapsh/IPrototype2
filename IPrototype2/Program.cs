using System;
using System.Collections.Generic;

interface IPrototype { IPrototype Clone(); }

class Features
{
    public List<string> List = new List<string>();
    public override string ToString() => string.Join(", ", List);
}

abstract class Plan : IPrototype
{
    public string Name;
    public decimal Price;
    public Features Features;

    public Plan(string name, decimal price)
    {
        Name = name;
        Price = price;
        Features = new Features();
    }
    public abstract IPrototype Clone();
    public override string ToString() => $"{Name} ({Price}$): {Features}";
}

class BasicPlan : Plan
{
    public BasicPlan(string n, decimal p) : base(n, p) { }
    public override IPrototype Clone()
    {
        var c = (BasicPlan)this.MemberwiseClone();
        c.Features = new Features();
        c.Features.List = new List<string>(this.Features.List);
        return c;
    }
}

class ProPlan : Plan
{
    public ProPlan(string n, decimal p) : base(n, p) { }
    public override IPrototype Clone()
    {
        var c = (ProPlan)this.MemberwiseClone();
        c.Features = new Features();
        c.Features.List = new List<string>(this.Features.List);
        return c;
    }
}

class Program
{
    static void Main()
    {
        
        var original = new BasicPlan("Старт", 10.0m);
        original.Features.List.Add("Доступ к API");
        original.Features.List.Add("Поддержка 24/7");

        
        var clone = (BasicPlan)original.Clone();

        
        clone.Name = "Старт (Копия)";
        clone.Price = 12.0m;
        clone.Features.List.Add("Бонус");

        Console.WriteLine($"Оригинал: {original}");
        Console.WriteLine($"Клон: {clone}");

        Console.WriteLine($"Функции независимы: {original.Features.List.Count} vs {clone.Features.List.Count}");
        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey();
    }
}