using System.Numerics;

namespace TechTalk
{
    class Arithmetique<T> where T : INumber<T> 
    {
        private List<T> numbers;

        public Arithmetique(List<T> numbers)
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

        public void AddNumber(T number)
        {
            numbers.Add(number);
        }
    }
}
