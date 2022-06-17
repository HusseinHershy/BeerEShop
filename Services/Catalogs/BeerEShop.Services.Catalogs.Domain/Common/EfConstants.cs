using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.Common
{
    public static class EfConstants
    {
       

        public static class ColumnTypes
        {
            public const string PriceDecimal = "decimal(18,2)";
            public const string RegularDecimal = "decimal(5,2)";
            public const string TinyText = "varchar(15)";
            public const string ShortText = "varchar(25)";
            public const string NormalText = "varchar(50)";
            public const string MediumText = "varchar(100)";
            public const string LongText = "varchar(250)";
            public const string ExtraLongText = "varchar(500)";
            public const string BigInteger = "bigint";
        }

        public static class Lenght
        {
            public const int Tiny = 15;
            public const int Short = 25;
            public const int Normal = 50;
            public const int Medium = 50;
            public const int Long = 250;
            public const int ExtraLong = 500;
        }
    }
}
