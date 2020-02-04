using System;

namespace App2
{
    internal class Program
    {
        // Считываем 4 значное число с клавиатуры
        // greeting - Приветствие для ввода
        public static string getWord(String greeting)
        {
            string word;
            int wordInt;
            while (true)
            {
                Console.Write(greeting);
                word = Console.ReadLine();
                
                // Проверяем введеную строку на то, является ли она числом
                if (!Int32.TryParse(word, out wordInt))
                {
                    Console.WriteLine("Это не число");
                    continue;
                }
                
                // Проверяем число на 4-значность
                if (wordInt < 1000 || wordInt >= 10000)
                {
                    Console.WriteLine("Это не 4 значное число");
                    continue;
                }

                return word;
            }
        }


        // Одна партия игры
        // id1 - Имя игрока, который загадывает
        // id2 - Имя игрока, который отгадывает
        // Возвращает количество ходов, за которое отгадали слово
        public static int game(String id1, String id2)
        {
            string word = getWord($"{id1} | Загадайте 4 значное число: ");
            int numberOfTurns = 0;

            while (true)
            {
                string attemptWord = getWord($"{id2} | Введите 4 значное число: ");
                numberOfTurns++;
                // Проверяем на полное отгадываение
                if (attemptWord == word)
                {
                    Console.WriteLine($"{id2} | Отгадано за {numberOfTurns} ход(ов)");
                    return numberOfTurns;
                }

                int cows = 0;
                int bulls = 0;
                for (var i = 0; i < attemptWord.Length; i++)
                {
                    for (var j = 0; j < word.Length; j++)
                    {
                        // Если совпала цифра
                        if (attemptWord[j] == word[i])
                        {
                            // Если совпала цифра и позиция в числе (бык)
                            if (i == j)
                            {
                                bulls++;
                            }
                            // Если совпала цифра и не совпала позиция в числе (корова)
                            else
                            {
                                cows++;
                            }
                        }
                    }
                }

                Console.WriteLine($"{id2} | Быки: {bulls}, Коровы: {cows}");
            }
        }

        public static void Main(string[] args)
        {
            int player1Turns = game("Игрок 1", "Игрок 2");
            int player2Turns = game("Игрок 2", "Игрок 1");
            if (player1Turns < player2Turns)
            {
                Console.WriteLine("Выиграл первый игрок");
            }
            else if (player1Turns == player2Turns)
            {
                Console.WriteLine("Ничья");
            }
            else
            {
                Console.WriteLine("Выиграл второй игрок");
            }
        }
    }
}