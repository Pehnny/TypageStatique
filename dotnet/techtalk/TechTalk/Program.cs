using TechTalk;

class Program
{
    static void Main(string[] args)
    {
        //  Typage statique et polymorphisme
        //  Héritage
        {
            Console.WriteLine("Héritage");
            Console.WriteLine("--------------------------");
            
            var parent = new Parent("Parent");
            parent.DireNom();

            var enfant = new Enfant("Enfant", 10);
            enfant.DireNom();
            enfant.DireAge();

            Console.WriteLine("");
        }
        //  Polymorphisme avec héritage
        {
            Console.WriteLine("Polymorphisme avec héritage");
            Console.WriteLine("--------------------------");
            
            Animal[] animaux = [new Canard(), new Chat()];
            foreach (var animal in animaux)
            {
                animal.Cri();
            }

            Vehicule[] vehicules = [new Voiture(), new Moto()];
            foreach (var vehicule in vehicules)
            {
                vehicule.Demarrer();
            }

            Chien[] chiens = [new Golden_Retriever(), new Rottweiler()];
            foreach (var chien in chiens)
            {
                chien.DemanderRace();
            }

            Console.WriteLine("");
        }
        //  Programmation générique
        //  Mutation d'animaux
        {
            Console.WriteLine("Mutation d'animaux");
            Console.WriteLine("--------------------------");
            
            Animal animal = new Canard();
            animal.Cri();
            animal = new Chat();
            animal.Cri();

            Console.WriteLine("");
        }
        //  Appel de la méthode Somme<T>()
        {
            Console.WriteLine("Appel de la méthode Somme<T>()");
            Console.WriteLine("--------------------------");

            var sommeEntier = Arithmetique.Somme(2, 3);
            var sommeReel = Arithmetique.Somme(0.1, 0.2);
            Console.WriteLine(sommeEntier.ToString() + "\n" + sommeReel.ToString());
            
            Console.WriteLine("");
        }

        //  Classe générique Cage<T>
        {
            Console.WriteLine("Classe générique Cage<T>");
            Console.WriteLine("--------------------------");

            var golden_retriever = new Golden_Retriever();
            var rottweiler = new Rottweiler();

            var cage1 = new Cage<Golden_Retriever>(golden_retriever);
            var cage2 = new Cage<Rottweiler>(rottweiler);
            cage1.VerifierRace();
            cage2.VerifierRace();

            var cage3 = new Cage<Chien>(golden_retriever);
            cage3.VerifierRace();
            cage3.Liberer();
            cage3.CapturerAutreChien(rottweiler);
            cage3.VerifierRace();
            
            Console.WriteLine("");
        }
    }
}
