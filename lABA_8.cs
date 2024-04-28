
using System;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

public abstract class Task
{
    protected string text;

    public Task(string text)
    {
        this.text = text;
    }

    public abstract string Encrypt();
    public abstract string Decrypt();

    public override string ToString()
    {
        return text;
    }

}

public class Task_2 : Task
{
    public Task_2(string text) : base(text)
    {
    }

    public override string Encrypt()
    {
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
        return string.Join(" ", words).ToString();
    }


    public override string Decrypt()
    {
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
        return string.Join(" ", words).ToString();
    }

}

public class Task_4 : Task
{
    public Task_4(string text) : base(text)
    {
    }

    public override string Encrypt()
    {
        return text;
    }

    public override string Decrypt()
    {
        return text;
    }

    public int GetSentenceComplexity()
    {
        int wordCount = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int punctuationCount = text.Count(char.IsPunctuation);

        return wordCount + punctuationCount;
    }

    public override string ToString()
    {
        return GetSentenceComplexity().ToString();
    }
}

public class Task_6 : Task
{
    public Task_6(string text) : base(text)
    {
    }
    public override string Encrypt()
    {
        return text;
    }

    public override string Decrypt()
    {
        return text;
    }

    public int CountSyllables(string word)
    {
        string vowels = "аеёиоуыэюяaeiouy";
        int syllableCount = 0;
        bool isVowel = false;

        for (int i = 0; i < word.Length; i++)
        {
            if (vowels.IndexOf(char.ToLower(word[i])) >= 0)
            {
                if (!isVowel)
                {
                    syllableCount++;
                    isVowel = true;
                }
            }
            else
            {
                isVowel = false;
            }
        }

        return syllableCount;
    }

    public void CountWordsBySyllables()
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, int> syllableCounts = new Dictionary<int, int>();

        foreach (string word in words)
        {
            int syllableCount = CountSyllables(word);
            if (syllableCounts.ContainsKey(syllableCount))
            {
                syllableCounts[syllableCount]++;
            }
            else
            {
                syllableCounts[syllableCount] = 1;
            }
        }

        foreach (var pair in syllableCounts)
        {
            Console.WriteLine($"Количество слогов: {pair.Key} | Слов: {pair.Value}");
        }
    }
}

public class Task_8 : Task
{
    public Task_8(string text) : base(text)
    {
    }
    public override string Encrypt()
    {
        return text;
    }

    public override string Decrypt()
    {
        return text;
    }
    public int CountSyllables(string word)
    {
        string vowels = "аеёиоуыэюяaeiouy";
        int syllableCount = 0;
        bool isVowel = false;

        for (int i = 0; i < word.Length; i++)
        {
            if (vowels.IndexOf(char.ToLower(word[i])) >= 0)
            {
                if (!isVowel)
                {
                    syllableCount++;
                    isVowel = true;
                }
            }
            else
            {
                isVowel = false;
            }
        }

        return syllableCount;
    }

    public void CountWordsBySyllables()
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, int> syllableCounts = new Dictionary<int, int>();

        foreach (string word in words)
        {
            int syllableCount = CountSyllables(word);
            if (syllableCounts.ContainsKey(syllableCount))
            {
                syllableCounts[syllableCount]++;
            }
            else
            {
                syllableCounts[syllableCount] = 1;
            }
        }

        foreach (var pair in syllableCounts)
        {
            Console.WriteLine($"{pair.Key} слог(а): {pair.Value} слов");
        }
    }

    public void SplitTextByLines()
    {
        StringBuilder result = new StringBuilder();
        int charCount = 0;

        foreach (char c in text)
        {
            if (charCount == 50)
            {
                result.Append("\n");
                charCount = 0;
            }

            if (char.IsWhiteSpace(c) && charCount > 45)
            {
                result.Append("\n");
                charCount = 0;
            }

            result.Append(c);
            charCount++;
        }

        Console.WriteLine(result);
    }
}


public class Task_9 : Task
{
    public Dictionary<string, char> codeTable;

    public Task_9(string text) : base(text)
    {
        codeTable = new Dictionary<string, char>();
    }

    public override string Encrypt()
    {
        string encryptedText = text;
        List<string> sequences = FindRepeatedSequences(2);

        char code = 'A'; 

        foreach (string sequence in sequences)
        {
            if (!codeTable.ContainsKey(sequence))
            {
                codeTable.Add(sequence, code);
                encryptedText = encryptedText.Replace(sequence, code.ToString());
                code++;
            }
        }

        return encryptedText;
    }
    public override string Decrypt()
    {
        return text;
    }


    private List<string> FindRepeatedSequences(int sequenceLength)
    {
        List<string> sequences = new List<string>();

        for (int i = 0; i < text.Length - sequenceLength; i++)
        {
            string sequence = text.Substring(i, sequenceLength);
            if (text.Count(c => c == sequence[0]) == sequenceLength)
            {
                sequences.Add(sequence);
            }
        }

        return sequences.Distinct().ToList();
    }

    public void PrintCodeTable()
    {
        foreach (var pair in codeTable)
        {
            Console.WriteLine($"{pair.Key} > {pair.Value}");
        }
    }
}
public class Task_10 : Task
{
    public Dictionary<char, string> reverseCodeTable;

    public Task_10(string text, Dictionary<string, char> codeTable) : base(text)
    {
        reverseCodeTable = new Dictionary<char, string>();
        foreach (var pair in codeTable)
        {
            reverseCodeTable.Add(pair.Value, pair.Key);
        }
    }

    public override string Encrypt()
    {
        return text;
    }

    public override string Decrypt()
    {
        string decryptedText = text;

        foreach (var pair in reverseCodeTable)
        {
            decryptedText = decryptedText.Replace(pair.Value, pair.Key.ToString());
        }

        return decryptedText;
    }
}

class Program
{
    static void Main()
    {
        string original_message = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";
        string encrypted_message = "А и Б иледис ан .ебурт А ,алапу Б ,алапорп отк яслатсо ан ?ебурт";

        Task_2 task2 = new Task_2(original_message);
        string encryptedMessage = task2.Encrypt();

        Task_2 second_task2 = new Task_2(encrypted_message);
        string decryptedMessage = second_task2.Decrypt();

        Task_4 task4 = new Task_4(original_message);
        Task_6 task6 = new Task_6(original_message);
        Task_8 task8 = new Task_8(original_message);
        Task_9 task = new Task_9(original_message);
        string encryptedText = task.Encrypt();

        Task_10 task10 = new Task_10(encryptedText, task.codeTable);
        string decrypted_text = task10.Decrypt();

        Console.WriteLine("Зашифрованное сообщение: " + encryptedMessage);
        Console.WriteLine();
        Console.WriteLine("Расшифрованное сообщение: " + decryptedMessage);
        Console.WriteLine();
        Console.WriteLine("Cложность предложения: " + task4);
        Console.WriteLine();
        Console.WriteLine("Количество слов и слогов:");
        task6.CountWordsBySyllables();
        Console.WriteLine();
        Console.WriteLine("Разделенный текст:");
        task8.SplitTextByLines();
        Console.WriteLine();
        Console.WriteLine("Текст с кодос: " + encryptedText);
        Console.WriteLine();
        Console.WriteLine("Таблица кодов:");
        task.PrintCodeTable();
        Console.WriteLine();
        Console.WriteLine("Расшифрованный текст:");
        Console.WriteLine(decrypted_text);
        Console.WriteLine();
    }
}



