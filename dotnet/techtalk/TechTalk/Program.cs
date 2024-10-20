using TechTalk;

class Example
{
    static void Main(string[] args)
    {
        //  Typage statique et polymorphisme
        //  Héritage
        {
            var parent = new Parent("Parent");
            parent.DireNom();

            var enfant = new Enfant("Enfant", 10);
            enfant.DireNom();
            enfant.DireAge();
        }

        //  Polymorphisme avec héritage
        {
            var animaux = new List<Animal>{new Canard(), new Chat()};
            foreach (var animal in animaux)
            {
                animal.Cri();
            }

            var vehicules = new List<Vehicule>{new Voiture(), new Moto()};
            foreach (var vehicule in vehicules)
            {
                vehicule.Demarrer();
            }

            var chiens = new List<Chien>{new Golden_Retriever(), new Rottweiler()};
            foreach (var chien in chiens)
            {
                chien.DemanderRace();
            }
        }

        //  Mutation d'animaux
        {
            Animal animal = new Canard();
            animal.Cri();
            animal = new Chat();
            animal.Cri();
        }

        //  Programmation générique
        //  Méthode Somme() sans générique
        {
            var resultInt = Somme.SommeInt(2, 3);
            var resultFloat = Somme.SommeFloat(0.1, 0.2);
            Console.WriteLine(resultInt.ToString() + "\n" + resultFloat.ToString());
        }
        
        //  Méthode Somme<T>() avec générique
        {
            var result1 = SommeAvecGenerique.Somme(2, 3);
            var result2 = SommeAvecGenerique.Somme(0.1, 0.2);
            Console.WriteLine(result1.ToString() + "\n" + result2.ToString());
        }

        //  Classe générique Arithmetic<T>
        {
            var arithmeric = new Arithmetique<int>([1, 2, 3]);
            arithmeric.AddNumber(4);
            var somme = arithmeric.Somme();
            Console.WriteLine(somme.ToString());
        }

        //  Conversion de types internes
        {
            int number = 0;
            string numberString = number.ToString();
            Console.WriteLine(numberString);
        }
    }
}
