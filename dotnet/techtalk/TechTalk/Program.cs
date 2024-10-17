using TechTalk;

class Example
{
    static void Main(string[] args)
    {
        //  Méthode Somme() sans générique
        var resultInt = Somme.SommeInt(2, 3);
        var resultFloat = Somme.SommeFloat(0.1, 0.2);

        //  Méthode Somme<T>() avec générique
        var result1 = SommeAvecGenerique.Somme(2, 3);
        var result2 = SommeAvecGenerique.Somme(0.1, 0.2);

        //  Classe générique Arithmetic<T>
        var arithmeric = new Arithmetique<int>([1, 2, 3]);
        arithmeric.AddNumber(resultInt);
        var somme = arithmeric.Somme();

        //  Conversion de types internes
        int number = 0;
        string numberString = number.ToString();

        //  Polymorphisme avec héritage
        var animaux = new List<Animal>();
        var canard = new Canard();
        var chat = new Chat();
        animaux.Add(canard);
        animaux.Add(chat);

        Animal animal = new Canard();
        animal = new Chat();
    }
}
