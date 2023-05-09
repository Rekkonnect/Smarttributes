using RoseLynn;

namespace Smarttributes;

public static class KnownSymbolNames
{
    public const string BaseNamespace = nameof(Smarttributes);
    public const string BaseConstraintsNamespace = "Constraints";

    public static class Full
    {
        private static readonly string[] constraintsNamespace
            = { BaseNamespace, BaseConstraintsNamespace };

        // RequiresPresenceAttribute
        public static readonly FullSymbolName RequiresPresenceAttribute = new(
            nameof(Smarttributes.Constraints.RequiresPresenceAttribute),
            constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttributeT1 = new(
            new IdentifierWithArity(
                nameof(Smarttributes.Constraints.RequiresPresenceAttribute<Attribute>),
                1),
            constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttributeT2 = new(
            new IdentifierWithArity(
                nameof(Smarttributes.Constraints.RequiresPresenceAttribute<Attribute, Attribute>),
                2),
            constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttributeT3 = new(
            new IdentifierWithArity(
                nameof(Smarttributes.Constraints.RequiresPresenceAttribute<Attribute, Attribute, Attribute>),
                3),
            constraintsNamespace);

        public static readonly FullSymbolName RequiresPresenceAttributeT4 = new(
            new IdentifierWithArity(
                nameof(Smarttributes.Constraints.RequiresPresenceAttribute<Attribute, Attribute, Attribute, Attribute>),
                4),
            constraintsNamespace);

        // ParameterTypeMatchAttribute
        public static readonly FullSymbolName ParameterTypeMatchAttribute = new(
            nameof(Smarttributes.Constraints.ParameterTypeMatchAttribute),
            constraintsNamespace);

        // RestrictFunctionsAttribute
        public static readonly FullSymbolName RestrictFunctionsAttribute = new(
            nameof(Smarttributes.Constraints.RestrictFunctionsAttribute),
            constraintsNamespace);
    }
}
