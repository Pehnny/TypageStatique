namespace TechTalk
{
    class Parent(string nom)
    {
        protected string nom = nom;

        //  Méthode d'instance sans argument ni retour
        public void DireNom()
        {
            Console.WriteLine(nom);
        }
    }

    class Enfant(string nom, int age) : Parent(nom)
    {
        private int age = age;

        public void DireAge()
        {
            Console.WriteLine(age);
        }
    }
}
