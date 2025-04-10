using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            //1
            string text = "Mark bought 3 apples for 10$. Mike has 25.50$. Start 12345 End. @john, @mike are here. Цены начинаются от 20 грн и заканчиваются 150 грн.";

            // 1) Извлечь все слова длиной ровно 4 символа.
            Console.WriteLine("1) Слова длиной 4 символа:");
            Regex.Matches(text, @"\b\w{4}\b")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 2) Найти все слова, начинающиеся с большой буквы "М".
            Console.WriteLine("\n2) Слова на 'М':");
            Regex.Matches(text, @"\bМ\w*\b")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 3) Вывести все слова длиной более 4 символов.
            Console.WriteLine("\n3) Слова длиной >4 символов:");
            Regex.Matches(text, @"\b\w{5,}\b")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 4) Разбить строку по словам и вывести каждое слово на новой строке.
            Console.WriteLine("\n4) Разбивка по словам:");
            Regex.Split(text, @"\W+")
                .Where(word => !string.IsNullOrEmpty(word))
                .ToList()
                .ForEach(Console.WriteLine);
            // 5) Извлечь все цифры из текста.
            Console.WriteLine("\n5) Все цифры:");
            Regex.Matches(text, @"\d+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 6) Проверить, является ли введенная строка числом.
            Console.WriteLine("\n6) Является ли текст числом? " + Regex.IsMatch(text, @"^\d+$"));
            // 7) Вставить "Ок" после каждой буквы "о" в тексте.
            Console.WriteLine("\n7) Текст с 'Ок': " + Regex.Replace(text, "о", "оОк"));
            // 8) Удалить все цифры из текста.
            Console.WriteLine("\n8) Текст без цифр: " + Regex.Replace(text, @"\d", ""));
            // 9) Проверить, содержит ли текст цифры.
            Console.WriteLine("\n9) Содержит цифры? " + Regex.IsMatch(text, @"\d"));
            // 10) Определить, состоит ли строка только из букв или только из цифр.
            Console.WriteLine("\n10) Только буквы/цифры? " + (Regex.IsMatch(text, @"^[a-zA-Z]+$") || Regex.IsMatch(text, @"^\d+$")));
            // 11) Заменить последовательности точек на одну точку.
            Console.WriteLine("\n11) Замена точек: " + Regex.Replace(text, @"\.+", "."));
            // 12) Проверить надежность пароля.
            string password = "StrongPl4s5";
            Console.WriteLine("\n12) Надежный пароль? " + Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"));
            // 13) Удалить символ 'o' независимо от регистра.
            char charToRemove = 'o';
            Console.WriteLine("\n13) Текст без 'o': " + Regex.Replace(text, charToRemove.ToString(), "", RegexOptions.IgnoreCase));
            // 14) Извлечь вещественное число.
            Console.WriteLine("\n14) Вещественное число: " + Regex.Match(text, @"\b\d+\.\d+\b").Value);
            // 15) Заменить слово "рыба" на "123".
            Console.WriteLine("\n15) Замена 'рыба': " + Regex.Replace(text, @"\bрыба\b", "123"));
            // 16) Подсчитать количество слов.
            int wordCount = Regex.Split(text, @"\W+").Count(word => !string.IsNullOrEmpty(word));
            Console.WriteLine("\n16) Количество слов: " + wordCount);
            // 17) Извлечь цифры между "Start" и "End".
            var numbersBetween = Regex.Match(text, @"Start\D*(\d+)").Groups[1].Value;
            Console.WriteLine("\n17) Цифры между Start и End: " + numbersBetween);
            // 18) Извлечь имена пользователей.
            Console.WriteLine("\n18) Имена пользователей:");
            Regex.Matches(text, @"@\w+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 19) Найти все цены.
            Console.WriteLine("\n19) Цены:");
            Regex.Matches(text, @"\b\d+\.?\d*\s*(грн|\$)\b")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList()
                .ForEach(Console.WriteLine);
            // 20) Проверка корректности ло (не указано условие).
            string login = "User123";
            Console.WriteLine("\n20) Корректный логин? " + Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,9}$"));

        }
    }

}
