namespace TechTalk
{
    class Chien : Animal
    {
        protected string species = "chien";
        protected string race = "";

        public override void Cri()
        {
            Console.WriteLine("Waf !");
        }
    }

    class Golden_Retriever : Chien
    {
        private string race = "golden retriever";
    }

    class Rottweiler : Chien
    {
        private string race = "rottweiler";
    }

    class Trick
    {
        public static void Aboyer<T>(T chien) where T : Chien
        {
            chien.Cri();
        }
    }
}
