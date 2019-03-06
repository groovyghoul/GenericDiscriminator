using System;

namespace GenericDiscriminator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var batman = new Batman();
            var robin = new Robin();
            
            SayIt(batman);
            SayIt(robin);

            Console.ReadKey();
        }

        private static void SayIt<T>(T crusader) where T: ICapedCrusader
        {
            Console.WriteLine(typeof(T));
            Console.WriteLine(crusader.GetType());
            
            Console.WriteLine(crusader.Catchphrase);

            if (crusader.GetType() == typeof(Robin))
            {
                var r = (crusader as Robin);
                r.Blah();
            }

            if (typeof(T) == typeof(Batman))
            {
                var b = (crusader as Batman);
                b.Zipper();
            }
        }
    }

    internal interface ICapedCrusader
    {
        string Catchphrase { get; set; }
    }

    internal class Batman : ICapedCrusader
    {
        public string Catchphrase { get; set; }

        public Batman()
        {
            Catchphrase = "To the Bat-Pole";
        }

        public void Zipper()
        {
            Console.WriteLine("I'm Batman!");
        }
    }

    internal class Robin : ICapedCrusader
    {
        public string Catchphrase { get; set; }

        public Robin()
        {
            Catchphrase = "Golly Gee, Batman!";
        }

        public void Blah()
        {
            Console.WriteLine("C'mon Batman, let's get groovin'!");
        }
    }
}