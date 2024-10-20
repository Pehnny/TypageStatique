using System.Numerics;

namespace TechTalk
{
    class Arithmetique
    {
        public static T Somme<T>(T a, T b) where T : INumber<T>
        {
            return a + b;
        }
    }
}
