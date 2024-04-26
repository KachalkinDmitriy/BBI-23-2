
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

abstract class Task
{
    protected string text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }
    public override string ToString()
    {
        return ($"\n  Последние слова предложений:\n {LastWords()} \n");
    }

    private string LastWords()
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', ';', '!', '?', ':', '/' });
        string[] LastWord;

        for (int i = 0; i < words.Length; i++)
        {
            //я пытался
        }
    }
}
class Task2 : Task
{
    [JsonConstructor]
    public Task2(string text) : base(text) { }
    public override string ToString()
    {
        return $"\n Измененный текст:\n {UpperLower()}\n";
    }

    private string UpperLower()
    {
        string[] words = text.Split(new char[] { '/', ',', '.', '!', '?', ' ', ';', ':'});

        for (int i = 0; i < words.Length; i++)
        {
            if (i % 2 == 0)
            {
                words[i] = words[i].ToUpper();
            }
            else
            {
                words[i] = words[i].ToLower();
            }
        }
        return text;
    }
}
class Json
{
    public static void Write<T>(T obj, string filepath)
    {
        using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filepath)
    {
        using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}
class Program
{
    static void Main()
    {
        string text = "На вход подается текст. На выход - массив строк. Выписать последние слова всех преложений.";
        Task[] tasks = { new Task1(text), new Task2(text) };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2302100\Desktop";
        string folder_name = "Solution";
        path = Path.Combine(path, folder_name);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string file_name_1 = "task_1.json";
        string file_name_2 = "task_2.json";

        Console.Write("Десереализованные файлы: \n");

        file_name_1 = Path.Combine(path, file_name_1);
        file_name_2 = Path.Combine(path, file_name_2);

        if (!File.Exists(file_name_1))
        {
            Json.Write<Task1>((Task1)tasks[0], file_name_1);
            Json.Write<Task2>((Task2)tasks[1], file_name_2);
        }
        else
        {
            var t1 = Json.Read<Task1>(file_name_1);
            var t2 = Json.Read<Task2>(file_name_2);
            Console.WriteLine(t1);
            Console.WriteLine(t2);
        }
    }
}





