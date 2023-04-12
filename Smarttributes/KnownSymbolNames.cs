using RoseLynn;

namespace Smarttributes;

public static class KnownSymbolNames
{
    public const string BaseNamespace = nameof(Smarttributes);
    public const string BaseConstraintsNamespace = "Constraints";

    public static class Base
    {
        public const string RequiresPresenceAttribute = nameof(RequiresPresenceAttribute);
        public const string ParameterTypeMatchAttribute = nameof(ParameterTypeMatchAttribute);
        public const string RestrictToLambdasAttribute = nameof(RestrictToLambdasAttribute);
    }

    public static class Full
    {
        private static readonly string[] constraintsNamespace
            = { BaseNamespace, BaseConstraintsNamespace };

        public static readonly FullSymbolName ParameterTypeMatchAttribute
            = new(Base.ParameterTypeMatchAttribute, constraintsNamespace);

        public static readonly FullSymbolName RestrictToLambdasAttribute
            = new(Base.RestrictToLambdasAttribute, constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttribute
            = new(Base.RequiresPresenceAttribute, constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttributeT1
            = new(new IdentifierWithArity(Base.RequiresPresenceAttribute, 1), constraintsNamespace);
        public static readonly FullSymbolName RequiresPresenceAttributeT2
            = new(new IdentifierWithArity(Base.RequiresPresenceAttribute, 2), constraintsNamespace);
        public static readonly FullSymbolName RequiresPresenceAttributeT3
            = new(new IdentifierWithArity(Base.RequiresPresenceAttribute, 3), constraintsNamespace);
        public static readonly FullSymbolName RequiresPresenceAttributeT4
            = new(new IdentifierWithArity(Base.RequiresPresenceAttribute, 4), constraintsNamespace);
    }
}
