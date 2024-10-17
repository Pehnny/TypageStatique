namespace TechTalk
{
    class Animal
    {
        protected string species;

        public virtual void Cri()
        {
            throw new NotImplementedException();
        }
    }

    class Canard : Animal
    {
        private string species = "canard";

        public override void Cri()
        {
            Console.WriteLine("Qwack !");
        }
    }

    class Chat : Animal
    {
        private string species = "chat";

        public override void Cri()
        {
            Console.WriteLine("Meow !");
        }
    }
}
