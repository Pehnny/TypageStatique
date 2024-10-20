namespace TechTalk
{
    //  Polymorphisme avec héritage d'une classe et composition d'une interface.
    interface IVoler
    {
        public void Voler();
        public void Atterrir();
    }

    class Pigeon(string espece = "pigeon") : Animal(espece), IVoler
    {
        public void Atterrir()
        {
            Console.WriteLine("Se pose sur un batiment !");
        }

        public void Voler()
        {
            Console.WriteLine("Déploie ses ailes !");
        }
    }

    class Avion(int roues) : Vehicule(roues), IVoler
    {
        public override void Demarrer()
        {
            Console.WriteLine("Bruit de turbine !");
        }

        public void Atterrir()
        {
            Console.WriteLine("Se pose sur la piste d'atterrissage !");
        }

        public void Voler()
        {
            Console.WriteLine("Redresse son nez !");
        }
    }
}
