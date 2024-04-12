//using System;

//class Program
//{
//    struct Jump
//    {
//        private string second_name;
//        private double first_try;
//        private double second_try;
//        private double best_try;

//        public Jump(string second_name, double first_try, double second_try)
//        {
//            this.second_name = second_name;
//            this.first_try = first_try;
//            this.second_try = second_try;
//            if (first_try > second_try)
//            {
//                this.best_try = first_try;
//            }
//            else
//            {
//                this.best_try = second_try;
//            }
//        }

//        public string GetRaceInfo(int place)
//        {
//            return $"Место {place} | Фамилия {second_name} | Результат: {best_try} см \n";
//        }

//        public double GetResult()
//        {
//            return best_try;
//        }
//    }

//    static void Main()
//    {
//        Jump[] jumping = new Jump[5];

//        jumping[0] = new Jump("Иванов", 140, 150);
//        jumping[1] = new Jump("Петров", 155, 139);
//        jumping[2] = new Jump("Сидоров", 149, 151);
//        jumping[3] = new Jump("Кузнецов", 170, 160);
//        jumping[4] = new Jump("Макаров", 150, 157);

//        for (int i = 1; i < jumping.Length; i++)
//        {
//            Jump key = jumping[i];
//            int j = i - 1;

//            while (j >= 0 && jumping[j].GetResult() < key.GetResult())
//            {
//                jumping[j + 1] = jumping[j];
//                j--;
//            }

//            jumping[j + 1] = key;
//        }

//        for (int i = 0; i < jumping.Length; i++)
//        {
//            Console.Write(jumping[i].GetRaceInfo(i + 1));
//        }
//    }
//}


