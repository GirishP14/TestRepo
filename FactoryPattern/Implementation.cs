using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    /// <summary>
    /// Product
    /// </summary>
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString() => GetType().Name;
    }

    /// <summary>
    /// Concreate Product
    /// </summary>
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;
        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch(_countryIdentifier)
                {
                    case "IN":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }


    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _codeIdentifier;
        public CodeDiscountService(Guid countryIdentifier)
        {
            _codeIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get => 15;
        }
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CountryDiscountFactory: DiscountFactory
    {
        private readonly string _countryIdentifier;

        public CountryDiscountFactory(string CountryIdentifier)
        {
            _countryIdentifier = CountryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }


    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}
