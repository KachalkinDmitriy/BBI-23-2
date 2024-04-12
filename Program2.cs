using System;

class Program
{
    struct Exam
    {
        private string second_name;
        private double[] exams;
        private double points;

        public Exam(string second_name, double[] exams)
        {
            this = new Exam();
            this.second_name = second_name;
            this.exams = exams;
            CalculatePoints();
        }

        private void CalculatePoints()
        {
            double sum = 0;
            foreach (double exam in exams)
            {
                sum += exam;
            }
            points = sum / exams.Length;
        }

        public string GetExamInfo()
        {
            if (points >= 4)
            {
                return $"Фамилия {second_name} | Средний балл: {points}\n";
            }
            else
            {
                return "";
            }
        }

        public double GetResult()
        {
            return points;
        }
    }

    static void Main()
    {
        Exam[] students = new Exam[5];

        students[0] = new Exam("Иванов", new double[] { 5, 4, 3, 5 });
        students[1] = new Exam("Петров", new double[] { 5, 3, 4, 4 });
        students[2] = new Exam("Сидоров", new double[] { 3, 3, 3, 4 });
        students[3] = new Exam("Кузнецов", new double[] { 5, 5, 4, 5 });
        students[4] = new Exam("Макаров", new double[] { 5, 4, 3, 2 });

        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = 0; j < students.Length - 1 - i; j++)
            {
                if (students[j].GetResult() < students[j + 1].GetResult())
                {
                    Exam temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < students.Length; i++)
        {
            Console.Write(students[i].GetExamInfo());
        }
    }
}

