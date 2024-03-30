//2.3

using System;

class Team
{
    private int[] results;

    public Team(int[] results)
    {
        this.results = results;
    }

    public virtual int TotalPoints()
    {
        int points = 0;
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] == 1)
            {
                points += 5;
            }
            else if (results[i] == 2)
            {
                points += 4;
            }
            else if (results[i] == 3)
            {
                points += 3;
            }
            else if (results[i] == 4)
            {
                points += 2;
            }
            else if (results[i] == 5)
            {
                points += 1;
            }
        }
        return points;
    }
}

class WomenTeam : Team
{
    public WomenTeam(int[] results) : base(results) { }

    public override int TotalPoints()
    {
        return base.TotalPoints();
    }
}

class MenTeam : Team
{
    public MenTeam(int[] results) : base(results) { }

    public override int TotalPoints()
    {
        return base.TotalPoints();
    }
}

class Program
{
    static void Main()
    {
        int[] results_team1 = { 7, 2, 5, 3, 6, 16 };
        int[] results_team2 = { 1, 8, 9, 10, 11, 12 };

        Team womenTeam = new WomenTeam(results_team1);
        Team menTeam = new MenTeam(results_team2);


        int points_womenTeam = womenTeam.TotalPoints();
        int points_menTeam = menTeam.TotalPoints();


        Console.WriteLine($"Результат первой команды: {points_womenTeam}");
        Console.WriteLine($"Результат второй команды: {points_menTeam}");


        if (points_womenTeam > points_menTeam)
        {
            Console.WriteLine("Первая команда становится победителем");
        }
        else if (points_menTeam > points_womenTeam)
        {
            Console.WriteLine("Вторая команда становится победителем");
        }
        else
        {
            Console.WriteLine("Ничья");
        }
    }
}
