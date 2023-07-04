using System;

namespace Praktika2023
{
    /// <summary>Статический класс генератор случайных чисел</summary>
    static class Randomizer //
    {
        /// <summary>статический объект класса Random</summary>
        private static Random rand = new Random();

        /// <summary>
        /// статический метод генерации случайного числа
        /// </summary>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <returns>случайное число из диапазона [min, max]</returns>
        public static int Rand(int min, int max)
        {
            lock (rand)
            {
                return rand.Next(min, max + 1);
            }
        }
    }
}
