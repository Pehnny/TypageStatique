namespace TechTalk
{
    //  Polymorphisme avec héritage d'une classe
    class Animal(string espece)
    {
        protected string espece = espece;

        public virtual void Cri()
        {
            throw new NotImplementedException();
        }
    }

    class Canard(string espece = "canard") : Animal(espece)
    {
        public override void Cri()
        {
            Console.WriteLine("Coin !");
        }
    }

    class Chat(string espece = "chat") : Animal(espece)
    {
        public override void Cri()
        {
            Console.WriteLine("Miaou !");
        }
    }

    //  Polymorphisme avec héritage d'une classe abstraite
    abstract class Vehicule(int roues)
    {
        protected int roues = roues;

        public abstract void Demarrer();
    }

    class Voiture(int roues = 4) : Vehicule(roues)
    {
        public override void Demarrer()
        {
            Console.WriteLine("Vroum !");
        }
    }

    class Moto(int roues = 2) : Vehicule(roues)
    {
        public override void Demarrer()
        {
            Console.WriteLine("Broum !");
        }
    }

    //  Polymorphisme avec héritage d'une classe abstraite qui possède des implémentations par défaut.
    abstract class Chien(string race) : Animal("chien")
    {
        protected string race = race;

        public override void Cri()
        {
            Console.WriteLine("Waf !");
        }

        public void DemanderRace()
        {
            Console.WriteLine(race);
        }
    }

    class Golden_Retriever : Chien
    {
        public Golden_Retriever() : base("golden retriever") {}
    }
    class Rottweiler : Chien
    {
        public Rottweiler() : base("rottweiler") {}
    }

}
