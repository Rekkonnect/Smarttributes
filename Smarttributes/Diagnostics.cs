using Microsoft.CodeAnalysis;
using RoseLynn.CSharp;
using Smarttributes.Constraints;

namespace Smarttributes;

internal static class Diagnostics
{
    private static SmarttributesDiagnosicDescriptorStorage Storage
        => SmarttributesDiagnosicDescriptorStorage.Instance;

    #region Creators
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

    public static Diagnostic CreateSMTTR0005(
        AttributeData sourceAttribute,
        FunctionTargets functionTargets)
    {
        var validTargets = BuildFunctionTargetListString(functionTargets);
        return Diagnostic.Create(
            Storage[0005]!,
            sourceAttribute.GetAttributeApplicationSyntax()?.GetLocation(),
            sourceAttribute.AttributeClass!.ToDisplayString(),
            validTargets);
    }
    #endregion

    #region Function targets
    private static string BuildFunctionTargetListString(FunctionTargets functionTargets)
    {
        var result = string.Empty;
        foreach (var functionTargetFlag in validFunctionTargets)
        {
            if (!functionTargets.HasFlag(functionTargetFlag))
                continue;

            if (result.Length > 0)
                result += ", ";

            result += GetFunctionTargetStringRepresentation(functionTargetFlag);
        }
        return result;
    }

    private static readonly FunctionTargets[] validFunctionTargets =
    {
        FunctionTargets.Method,
        FunctionTargets.LocalMethod,
        FunctionTargets.Lambda,
        FunctionTargets.AnonymousMethod,
    };

    private static string GetFunctionTargetStringRepresentation(FunctionTargets functionTarget)
    {
        return functionTarget switch
        {
            FunctionTargets.Method => "method",
            FunctionTargets.LocalMethod => "local method",
            FunctionTargets.Lambda => "lambda",
            FunctionTargets.AnonymousMethod => "anonymous method",
            _ => "invalid target"
        };
    }
    #endregion
}
