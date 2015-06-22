using System;

namespace KosciApplication
{
    internal class Kostka
    {
        private readonly int _iloscScian;
        private readonly Random _random;

        public Kostka(int iloscScian)
        {
            _iloscScian = iloscScian;
            _random = new Random();
        }

        public int AktualnieWylosowano { get; protected set; }

        public void Przekulnij()
        {
            lock (_random)
            {
                this.AktualnieWylosowano = _random.Next(1, _iloscScian + 1);
            }
        }
    }
}
