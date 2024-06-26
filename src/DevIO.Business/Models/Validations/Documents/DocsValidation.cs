﻿namespace DevIO.Business.Models.Validations.Documents
{
    public class DocsValidation
    {
        public class CpfValidation
        {
            public const int CpfSize = 11;

            public static bool Validate(string cpf)
            {
                var cpfNumbers = Utils.OnlyNumbers(cpf);

                if (!ValidSize(cpfNumbers)) return false;

                return !HasRepeatedNumbers(cpfNumbers) && HasValidNumbers(cpfNumbers);
            }

            private static bool HasValidNumbers(string value)
            {
                var number = value.Substring(0, CpfSize - 2);
                var checkDigit = new CheckDigit(number)
                    .WithMultiplierUntil(2, 11)
                    .Replacing("0", 10, 11);

                var firstDigit = checkDigit.CalculateDigit();
                checkDigit.AddDigit(firstDigit);
                var secondDigit = checkDigit.CalculateDigit();

                return string.Concat(firstDigit, secondDigit) == value.Substring(CpfSize - 2, 2);
            }

            private static bool HasRepeatedNumbers(string value)
            {
                string[] invalidNumbers =
                {
                    "00000000000",
                    "11111111111",
                    "22222222222",
                    "33333333333",
                    "44444444444",
                    "55555555555",
                    "66666666666",
                    "77777777777",
                    "88888888888",
                    "99999999999"
                };

                return invalidNumbers.Contains(value);
            }

            private static bool ValidSize(string value)
            {
                return value.Length == CpfSize;
            }
        }

        public class CnpjValidation
        {
            public const int CnpjSize = 14;

            public static bool Validate(string cnpj)
            {
                var cnpjNumbers = Utils.OnlyNumbers(cnpj);

                if (!HasValidSize(cnpjNumbers)) return false;
                return !HasRepeatedNumbers(cnpjNumbers) && HasValidNumbers(cnpjNumbers);

            }

            private static bool HasValidNumbers(string value)
            {
                var number = value.Substring(0, CnpjSize - 2);

                var checkDigit = new CheckDigit(number)
                    .WithMultiplierUntil(2, 9)
                    .Replacing("0", 10, 11);

                var firstDigit = checkDigit.CalculateDigit();
                checkDigit.AddDigit(firstDigit);
                var seconfDigit = checkDigit.CalculateDigit();

                return string.Concat(firstDigit, seconfDigit) == value.Substring(CnpjSize - 2, 2);
            }

            private static bool HasRepeatedNumbers(string value)
            {
                string[] invalidNumbers =
                {
                    "00000000000000",
                    "11111111111111",
                    "22222222222222",
                    "33333333333333",
                    "44444444444444",
                    "55555555555555",
                    "66666666666666",
                    "77777777777777",
                    "88888888888888",
                    "99999999999999"
                };

                return invalidNumbers.Contains(value);
            }

            private static bool HasValidSize(string value)
            {
                return value.Length == CnpjSize;
            }
        }

        public class CheckDigit
        {
            private string _number;
            private const int Module = 11;
            private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
            private readonly IDictionary<int, string> _replaces = new Dictionary<int, string>();
            private bool _moduleComplement = true;

            public CheckDigit(string number)
            {
                _number = number;
            }

            public CheckDigit WithMultiplierUntil(int firstMultiplier, int lastMultiplier)
            {
                _multipliers.Clear();
                for(var i = firstMultiplier; i < lastMultiplier; i++)
                _multipliers.Add(i);

                return this;
            }

            public CheckDigit Replacing(string replaces, params int[] digits)
            {
                foreach(var i in digits)
                {
                    _replaces[i] = replaces;
                }

                return this;
            }

            public void AddDigit(string digit)
            {
                _number = string.Concat(_number, digit);
            }

            public string CalculateDigit()
            {
                return !(_number.Length > 0) ? "" : GetDigitSum();
            }

            private string GetDigitSum()
            {
                var sum = 0;
                for(int i = _number.Length - 1, m = 0; i >= 0; i--)
                {
                    var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                    sum += product;

                    if (++m >= _multipliers.Count) m = 0;
                }

                var mod = (sum % Module);
                var result = _moduleComplement ? Module - mod : mod;

                return _replaces.ContainsKey(result) ? _replaces[result] : result.ToString();
            }
        }

        public class Utils
        {
            public static string OnlyNumbers(string cpf)
            {
                var onlyNumbers = "";
                foreach(var n in cpf)
                {
                    if(char.IsDigit(n))
                        onlyNumbers += n;
                }

                return onlyNumbers.Trim();
            }
        }
    }
}
