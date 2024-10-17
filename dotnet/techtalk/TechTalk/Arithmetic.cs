using System.Numerics;

namespace TechTalk
{
    class Arithmetic<T> where T : INumber<T> 
    {
        private T[] numbers;

        public Arithmetic(T[] numbers)
        {
            this.numbers = numbers;
        }

        public T Somme()
        {
            var result = numbers[0];

            foreach (T number in numbers)
            {
                result += number;
            }
            
            return result;
        }

        public T Produit()
        {
            var result = numbers[0];

            foreach (T number in numbers)
            {
                result *= number;
            }

            return result;
        }
    }
}