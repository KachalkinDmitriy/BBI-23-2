//2.4

using System;

class Jump
{
    private string second_name;
    private double first_try;
    private double second_try;
    private double best_try;
    private bool isDisqualified;

    public Jump(string second_name, double first_try, double second_try)
    {
        this.second_name = second_name;
        this.first_try = first_try;
        this.second_try = second_try;
        this.best_try = (first_try > second_try) ? first_try : second_try;
        this.isDisqualified = false;
    }

    public string GetRaceInfo(int place)
    {
        return $"Место {place} \t| Фамилия {second_name} \t| Результат: {best_try} см";
    }

    public double GetResult()
    {
        return best_try;
    }

    public void Disqualify()
    {
        isDisqualified = true;
    }

    public bool IsDisqualified()
    {
        return isDisqualified;
    }
}

class Program
{
    static void Main()
    {
        Jump[] jumping = new Jump[5];

        jumping[0] = new Jump("Иванов", 140, 150);
        jumping[1] = new Jump("Петров", 155, 139);
        jumping[2] = new Jump("Сидоров", 149, 151);
        jumping[3] = new Jump("Кузнецов", 170, 160);
        jumping[4] = new Jump("Макаров", 150, 157);

        jumping[4].Disqualify();


        int count_ne_disqualified = 0;
        foreach (Jump jumping_ in jumping)
        {
            if (jumping_.IsDisqualified() == false)
            {
                count_ne_disqualified++;
            }
        }


        Jump[] filteredjumping = new Jump[count_ne_disqualified];
        int index = 0;
        foreach (Jump jumping_ in jumping)
        {
            if (jumping_.IsDisqualified() == false)
            {
                filteredjumping[index] = jumping_;
                index++;
            }
        }

        for (int i = 0; i < filteredjumping.Length - 1; i++)
        {
            for (int j = 0; j < filteredjumping.Length - 1 - i; j++)
            {
                if (filteredjumping[j].GetResult() < filteredjumping[j + 1].GetResult())
                {
                    Jump temp = filteredjumping[j];
                    filteredjumping[j] = filteredjumping[j + 1];
                    filteredjumping[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < filteredjumping.Length; i++)
        {
            Console.WriteLine(filteredjumping[i].GetRaceInfo(i + 1));
        }
    }
}
