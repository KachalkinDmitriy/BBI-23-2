//2.1

using System;

class Person
{
    private string second_name;
    public Person(string second_name)
    {
        this.second_name = second_name;
    }

    public string GetSecondName()
    {
        return second_name;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Фамилия: {GetSecondName()}");
    }
}

class Student : Person
{
    private static int nextStudentId = 1000;
    private int studentId;
    private double averagePoints;

    public Student(string second_name, double first_exam, double second_exam, double third_exam, double fourth_exam) : base(second_name)
    {
        this.studentId = nextStudentId++;
        averagePoints = (first_exam + second_exam + third_exam + fourth_exam) / 4;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Фамилия: {GetSecondName()} | № студ.билета: {studentId} | Средний балл: {averagePoints}");
    }

    public double GetAveragePoints()
    {
        return averagePoints;
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[5];

        students[0] = new Student("Иванов", 5, 4, 3, 5);
        students[1] = new Student("Петров", 5, 3, 4, 4);
        students[2] = new Student("Сидоров", 3, 3, 3, 4);
        students[3] = new Student("Кузнецов", 5, 5, 4, 5);
        students[4] = new Student("Макаров", 5, 4, 3, 2);

        QuickSort(students, 0, students.Length - 1);

        foreach (var student in students)
        {
            student.DisplayInfo();
        }
    }

    static void QuickSort(Student[] stud, int min, int max)
    {
        if (min < max)
        {
            int pivot = quick(stud, min, max);

            QuickSort(stud, min, pivot - 1);
            QuickSort(stud, pivot + 1, max);
        }
    }

    static int quick(Student[] stud, int min, int max)
    {
        double pivot = stud[max].GetAveragePoints();
        int razdel = min - 1;

        for (int j = min; j < max; j++)
        {
            if (stud[j].GetAveragePoints() > pivot)
            {
                razdel++;
                Student temp = stud[razdel];
                stud[razdel] = stud[j];
                stud[j] = temp;
            }
        }

        Student temp2 = stud[razdel + 1];
        stud[razdel + 1] = stud[max];
        stud[max] = temp2;

        return razdel + 1;
    }
}

//3

//using System;

//class Team
//{
//    private int[] results;
//    private string gender; 

//    public Team(int[] results, string gender) 
//    {
//        this.results = results;
//        this.gender = gender;
//    }

//    public virtual int TotalPoints()
//    {
//        int points = 0;
//        for (int i = 0; i < results.Length; i++)
//        {
//            if (results[i] == 1)
//            {
//                points += 5;
//            }
//            else if (results[i] == 2)
//            {
//                points += 4;
//            }
//            else if (results[i] == 3)
//            {
//                points += 3;
//            }
//            else if (results[i] == 4)
//            {
//                points += 2;
//            }
//            else if (results[i] == 5)
//            {
//                points += 1;
//            }
//        }
//        return points;
//    }
//}

//class WomenTeam : Team
//{
//    public WomenTeam(int[] results) : base(results, "Женская") { }

//    public override int TotalPoints()
//    {
//        return base.TotalPoints();
//    }
//}

//class MenTeam : Team
//{
//    public MenTeam(int[] results) : base(results, "Мужская") { }

//    public override int TotalPoints()
//    {
//        return base.TotalPoints();
//    }
//}

//class Program
//{
//    static void Main()
//    {

//        Team[] womenTeams = new Team[3];
//        womenTeams[0] = new WomenTeam(new int[] { 7, 5, 6 });
//        womenTeams[1] = new WomenTeam(new int[] { 2, 3, 16 });
//        womenTeams[2] = new WomenTeam(new int[] { 4, 9, 11 });

//        Team[] menTeams = new Team[3];
//        menTeams[0] = new MenTeam(new int[] { 1, 8, 12 });
//        menTeams[1] = new MenTeam(new int[] { 10, 5, 3 });
//        menTeams[2] = new MenTeam(new int[] { 6, 4, 7 });

//        Team winningWomenTeam = womenTeams[0];
//        Team winningMenTeam = menTeams[0];

//        for (int i = 1; i < womenTeams.Length; i++)
//        {
//            if (womenTeams[i].TotalPoints() > winningWomenTeam.TotalPoints())
//            {
//                winningWomenTeam = womenTeams[i];
//            }
//        }

//        for (int i = 1; i < menTeams.Length; i++)
//        {
//            if (menTeams[i].TotalPoints() > winningMenTeam.TotalPoints())
//            {
//                winningMenTeam = menTeams[i];
//            }
//        }

//        Team winningTeam;

//        if (winningWomenTeam.TotalPoints() > winningMenTeam.TotalPoints())
//        {
//            winningTeam = winningWomenTeam;
//        }
//        else
//        {
//            winningTeam = winningMenTeam;
//        }

//        Console.WriteLine($"Результат команды победителя: {winningTeam.TotalPoints()}");

//    }
//}


