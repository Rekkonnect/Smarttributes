using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Smarttributes;

internal static class SemanticModelExtensions
{
    public static ISymbol? GetDeclaredOrAnonymousSymbol(this SemanticModel semanticModel, SyntaxNode node)
    {
        var declaredSymbol = semanticModel.GetDeclaredSymbol(node);
        if (declaredSymbol is not null)
            return declaredSymbol;

        if (node is AnonymousFunctionExpressionSyntax)
            return semanticModel.GetSymbolInfo(node).Symbol;

        return null;
    }
}