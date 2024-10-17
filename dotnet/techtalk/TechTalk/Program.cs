using TechTalk;

class Example
{
    static void Main(string[] args)
    {
        var resultInt = Somme.SumInt(2, 3);
        var resultFloat = Somme.SumFloat(0.1, 0.2);

        var result1 = SommeAvecGenerique.Somme(2, 3);
        var result2 = SommeAvecGenerique.Somme(0.1, 0.2);

        var arithmeric = new Arithmetic<int>([1, 2, 3]);
        var somme = arithmeric.Somme();
    }
}
