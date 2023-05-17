using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Smarttributes;

public static class ArrayCreationExpressionExtensions
{
    public static InitializerExpressionSyntax? GetArrayInitializerExpression(
        this ExpressionSyntax arrayExpression)
    {
        return arrayExpression switch
        {
            ArrayCreationExpressionSyntax arrayCreationExpression
                => arrayCreationExpression.Initializer,

            ImplicitArrayCreationExpressionSyntax arrayCreationExpression
                => arrayCreationExpression.Initializer,

            _ => null,
        };
    }
}