using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Army army = new Army();

        army.Work();
    }
}

class Army
{
    private readonly SoldiersCreator _soldiersCreator = new SoldiersCreator();
    private List<Soldier> _alphaSquad;
    private List<Soldier> _bettaSquad;

    public Army()
    {
        _alphaSquad = _soldiersCreator.CreateAlphaSquad();
        _bettaSquad = _soldiersCreator.CreateBettaSquad();
    }

    public void Work()
    {
        Console.WriteLine("Отряд Альфа:");
        ShowSquad(_alphaSquad);

        Console.WriteLine("Отряд Бетта:");
        ShowSquad(_bettaSquad);

        Console.WriteLine($"\nПеремещаем солдат.\n");
        MoveSquads();

        Console.WriteLine("Отряд Альфа:");
        ShowSquad(_alphaSquad);

        Console.WriteLine("Отряд Бетта:");
        ShowSquad(_bettaSquad);
    }

    private void ShowSquad(List<Soldier> squads)
    {
        foreach (Soldier soldier in squads)
        {
            soldier.ShowInfo();
        }
    }

    private void MoveSquads()
    {
        string searchChar = "Б";

        var soldiers = _alphaSquad.Where(soldier => soldier.FullName.Contains(searchChar));

        _alphaSquad = _alphaSquad.Except(soldiers).ToList();
        _bettaSquad = _bettaSquad.Union(soldiers).ToList();
    }
}

class SoldiersCreator
{
    public List<Soldier> CreateAlphaSquad()
    {
        return new List<Soldier>()
        {
            new Soldier("Болдырев М. В."),
            new Soldier("Баранов А. А."),
            new Soldier("Кузнецов Д. А."),
            new Soldier("Шмелев Д. Д.."),
            new Soldier("Сидоров Д. И."),
        };
    }

    public List<Soldier> CreateBettaSquad()
    {
        return new List<Soldier>()
        {
            new Soldier("Сергеев Р. Е."),
            new Soldier("Комаров М. Ф."),
            new Soldier("Шевцов И. С."),
            new Soldier("Зотов Е. С."),
            new Soldier("Лосев А. А."),
        };
    }
}

class Soldier
{
    public Soldier(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Имя и Инициалы: {FullName}");
    }
}