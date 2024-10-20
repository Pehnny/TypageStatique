namespace TechTalk
{
    //  Exemple de déclaration d'une classe avec une syntaxe complète et explicite
    class Exemple
    {
        private string name;
        private bool valid;

        //  Constructeur
        public Exemple(string name, bool valid)
        {
            this.name = name;
            this.valid = valid;
        }

        //  Méthode d'instance sans argument ni retour
        public void ExempleMethode()
        {
            if (this.valid)
            {
                Console.WriteLine(this.name);
                return;
            }

            this.name = "";
            this.valid = false;
        }
    }

    //  A titre indicatif pour ceux intéressés par C#
    //  Exemple de déclaration de la même classe avec une syntaxe moderne et concise
    class ExempleModerne(string name, bool valid)
    {
        private string name = name;
        private bool valid = valid;

        //  Méthode d'instance sans argument ni retour
        public void ExempleMethode()
        {
            if (valid)
            {
                Console.WriteLine(name);
                return;
            }

            name = "";
            valid = false;
        }
    }
}
