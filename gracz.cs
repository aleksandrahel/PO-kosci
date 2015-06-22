
namespace KosciApplication
{
    internal class Gracz
    {
        public int LiczbaPunktow {get; protected set;}
        public int LiczbaOczekWRundzie {get; set;}

        public Gracz() {
            ZerujLiczbePunktow();
        }

        public void DodajPunkt() {
            LiczbaPunktow++;
        }

        public void ZerujLiczbePunktow() { 
            LiczbaPunktow = 0;
        }
    }
}
