using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.MDSService;

namespace Common.Utils
{
    public static class IdentifierUtils
    {
        public static Identifier NewFromName(string name)
        {
            return new Identifier { Name = name };
        }

        public static List<Identifier> ToList(this Identifier id)
        {
            return new List<Identifier> { id };
        }
    }
}
