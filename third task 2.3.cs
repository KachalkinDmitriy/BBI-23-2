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

        Team[] womenTeams = new Team[3];
        womenTeams[0] = new WomenTeam(new int[] { 7, 5, 6 });
        womenTeams[1] = new WomenTeam(new int[] { 2, 3, 16 });
        womenTeams[2] = new WomenTeam(new int[] { 4, 9, 11 });

        Team[] menTeams = new Team[3];
        menTeams[0] = new MenTeam(new int[] { 1, 8, 12 });
        menTeams[1] = new MenTeam(new int[] { 10, 5, 3 });
        menTeams[2] = new MenTeam(new int[] { 6, 4, 7 });

        Team winningWomenTeam = womenTeams[0];
        Team winningMenTeam = menTeams[0];

        for (int i = 1; i < womenTeams.Length; i++)
        {
            if (womenTeams[i].TotalPoints() > winningWomenTeam.TotalPoints())
            {
                winningWomenTeam = womenTeams[i];
            }
        }

        for (int i = 1; i < menTeams.Length; i++)
        {
            if (menTeams[i].TotalPoints() > winningMenTeam.TotalPoints())
            {
                winningMenTeam = menTeams[i];
            }
        }

        Team winningTeam;

        if (winningWomenTeam.TotalPoints() > winningMenTeam.TotalPoints())
        {
            winningTeam = winningWomenTeam;
        }
        else
        {
            winningTeam = winningMenTeam;
        }

        Console.WriteLine($"Результат команды победителя: {winningTeam.TotalPoints()}");
     
    }
}
