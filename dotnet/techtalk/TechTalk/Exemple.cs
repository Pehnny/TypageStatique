namespace TechTalk
{
    //  Exemple de déclaration d'une classe avec une syntaxe complète et explicite
    class Exemple
    {
        private string nom;
        private bool valide;

        //  Constructeur
        public Exemple(string nom, bool valide)
        {
            this.nom = nom;
            this.valide = valide;
        }

        //  Méthode d'instance sans argument ni retour
        public void ExempleMethode()
        {
            if (this.valide)
            {
                Console.WriteLine(this.nom);
                return;
            }

            this.nom = "";
            this.valide = false;
        }
    }

    //  A titre indicatif pour ceux intéressés par C#
    //  Exemple de déclaration de la même classe avec une syntaxe moderne et concise
    class ExempleModerne(string nom, bool valide)
    {
        private string nom = nom;
        private bool valide = valide;

        //  Méthode d'instance sans argument ni retour
        public void ExempleMethode()
        {
            if (valide)
            {
                Console.WriteLine(nom);
                return;
            }

            nom = "";
            valide = false;
        }
    }
}
