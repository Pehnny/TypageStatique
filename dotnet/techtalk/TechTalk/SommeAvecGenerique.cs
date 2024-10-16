using System.Numerics;

namespace TechTalk
{
    class SommeAvecGenerique
    {
        public static T Somme<T>(T a, T b) where T : INumber<T>
        {
            return a + b;
        }
    }
}
