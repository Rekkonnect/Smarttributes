using Microsoft.CodeAnalysis;
using RoseLynn.CSharp;

namespace Smarttributes;

internal static class Diagnostics
{
    private static SmarttributesDiagnosicDescriptorStorage Storage
        => SmarttributesDiagnosicDescriptorStorage.Instance;

    public static Diagnostic CreateSMTTR0001(
        ISymbol attributedSymbol,
        AttributeData sourceAttribute,
        IEnumerable<ITypeSymbol> missingAttributes)
    {
        var missingAttributeList = string.Join(
            "\n",
            missingAttributes.Select(m => m.ToDisplayString()));

        return Diagnostic.Create(
            Storage[0001]!,
            sourceAttribute.GetAttributeApplicationSyntax()?.GetLocation(),
            sourceAttribute.AttributeClass!.ToDisplayString(),
            attributedSymbol.ToDisplayString(),
            "\n" + missingAttributeList);
    }
}
