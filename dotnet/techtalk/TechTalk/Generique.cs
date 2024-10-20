namespace TechTalk
{
    class Cage<T>(T chien) where T : Chien
    {
        private T chien = chien;
        private bool plein = false; 

        public void Capturer()
        {
            if (!plein)
            {
                plein = true;
            }
        }

        public void CapturerAutreChien<U>(U chien) where U : T
        {
            if (!plein)
            {
                this.chien = chien;
                plein = true;
            }
        }

        public void Liberer()
        {
            plein = false;
        }

        public void VerifierRace()
        {
            chien.DemanderRace();
        }
    }
}
