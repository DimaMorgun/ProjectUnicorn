using System;

namespace IdentitySampleApi.BusinessLogicLayer.Helpers
{
    public static class NumberHelper
    {
        private static Random _random;

        static NumberHelper()
        {
            _random = new Random();
        }

        public static int GetRandomNumber(int endIndex)
        {
            var randomNumber = _random.Next(++endIndex);

            return randomNumber;
        }

        public static int GetRandomNumber(int startIndex, int endIndex)
        {
            var randomNumber = _random.Next(startIndex, ++endIndex);

            return randomNumber;
        }
    }
}
