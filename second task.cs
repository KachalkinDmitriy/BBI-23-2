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
}
class Student : Person
{
    private int studentId;
    private double averagePoints;

    public Student(string second_name, int studentId, double first_exam, double second_exam, double third_exam, double fourth_exam) : base(second_name)
    {
        this.studentId = studentId;
        averagePoints = (first_exam + second_exam + third_exam + fourth_exam) / 4;
    }

    public string GetStudentInfo()
    {
        if (averagePoints >= 4)
        {
            return $" Фамилия {GetSecondName()} \t| № студ.билета: {studentId} \t| Средний балл: {averagePoints} ";
        }
        else
        {
            return "";
        }
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

        students[0] = new Student("Иванов", 1235, 5, 4, 3, 5);
        students[1] = new Student("Петров", 6546, 5, 3, 4, 4);
        students[2] = new Student("Сидоров", 6571, 3, 3, 3, 4);
        students[3] = new Student("Кузнецов", 5347, 5, 5, 4, 5);
        students[4] = new Student("Макаров", 9450, 5, 4, 3, 2);

        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = 0; j < students.Length - 1 - i; j++)
            {
                if (students[j].GetAveragePoints() < students[j + 1].GetAveragePoints())
                {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(students[i].GetStudentInfo());
        }
    }
}
