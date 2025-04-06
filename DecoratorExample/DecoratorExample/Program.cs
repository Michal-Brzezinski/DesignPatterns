using System;

namespace DecoratorExample
{
    // Interfejs reprezentujący podstawową funkcjonalność kawy
    public interface IKawa
    {
        string PobierzOpis();
        double Koszt();
    }

    // Prosta implementacja kawy
    public class ProstaKawa : IKawa
    {
        public string PobierzOpis() => "Prosta kawa";
        public double Koszt() => 5.0;
    }

    // Abstrakcyjny dekorator, który implementuje interfejs IKawa
    public abstract class KawaDecorator : IKawa
    {
        protected IKawa _kawa;

        public KawaDecorator(IKawa kawa)
        {
            _kawa = kawa;
        }

        public virtual string PobierzOpis() => _kawa.PobierzOpis();
        public virtual double Koszt() => _kawa.Koszt();
    }

    // Dekorator dodający mleko do kawy
    public class MlekoDecorator : KawaDecorator
    {
        public MlekoDecorator(IKawa kawa) : base(kawa) { }

        public override string PobierzOpis() => _kawa.PobierzOpis() + ", mleko";
        public override double Koszt() => _kawa.Koszt() + 1.5;
    }

    // Dekorator dodający czekoladę do kawy
    public class CzekoladaDecorator : KawaDecorator
    {
        public CzekoladaDecorator(IKawa kawa) : base(kawa) { }

        public override string PobierzOpis() => _kawa.PobierzOpis() + ", czekolada";
        public override double Koszt() => _kawa.Koszt() + 2.0;
    }


    class Program
    {
        static void Main(string[] args)
        {
            IKawa kawa = new ProstaKawa();
            Console.WriteLine($"{kawa.PobierzOpis()} - koszt: {kawa.Koszt()} zł");

            // Dodaj mleko do kawy
            kawa = new MlekoDecorator(kawa);
            Console.WriteLine($"{kawa.PobierzOpis()} - koszt: {kawa.Koszt()} zł");

            // Dodaj czekoladę do kawy
            kawa = new CzekoladaDecorator(kawa);
            Console.WriteLine($"{kawa.PobierzOpis()} - koszt: {kawa.Koszt()} zł");
        }
    }
}
