using CapitalGain.App.Models;

namespace CapitalGain.Test.Helpers
{
    public static class TributeSetup
    {
        public static IEnumerable<Tributes> GetTributesCase1() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase2() => [
                new Tributes(0.00M),
                new Tributes(10000.00M),
                new Tributes(0.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase3() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(1000.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase4() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase5() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(10000.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase6() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(3000.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase7() => [
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(3000.00M),
                new Tributes(0.00M),
                new Tributes(0.00M),
                new Tributes(3700.00M),
                new Tributes(0.00M),
            ];

        public static IEnumerable<Tributes> GetTributesCase8() => [
                new Tributes(0.00M),
                new Tributes(80000.00M),
                new Tributes(0.00M),
                new Tributes(60000.00M),
            ];

    }
}
