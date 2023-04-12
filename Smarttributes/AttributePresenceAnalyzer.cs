﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using RoseLynn;
using RoseLynn.CSharp.Syntax;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Smarttributes;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AttributePresenceAnalyzer : SmarttributesDiagnosticAnalyzer
{
    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.ReportDiagnostics);

        RegisterNodeActions(context);
    }

    private void RegisterNodeActions(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzeAttributedSymbol, SyntaxKind.Attribute);
    }

    private void AnalyzeAttributedSymbol(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not AttributeSyntax attributeNode)
        {
            Debug.Fail("Visited not an attribute node");
            return;
        }

        var attributedNode = attributeNode.GetAttributeDeclarationParent();
        var declaredSymbol = context.SemanticModel.GetDeclaredSymbol(attributedNode);
        if (declaredSymbol is null)
            return;

        var declaredSymbolAttributes = declaredSymbol.GetAttributes();

        var missingAttributes = new List<ITypeSymbol>();

        foreach (var declaredSymbolAttribute in declaredSymbolAttributes)
        {
            var declaredSymbolAttributeClass = declaredSymbolAttribute.AttributeClass;
            if (declaredSymbolAttributeClass is null)
                continue;

            var attributePresenceAttributes = GetAttributePresenceAttributes(declaredSymbolAttributeClass);
            if (attributePresenceAttributes.Length is 0)
                continue;

            missingAttributes.Clear();

            foreach (var attributePresenceAttribute in attributePresenceAttributes)
            {
                foreach (var type in attributePresenceAttribute.Types)
                {
                    bool containsRequiredAttribute = declaredSymbolAttributes
                        .Any(a => type.Equals(a.AttributeClass, SymbolEqualityComparer.Default));

                    if (!containsRequiredAttribute)
                    {
                        missingAttributes.Add(type);
                    }
                }
            }

            var diagnostic = Diagnostics.CreateSMTTR0001(
                declaredSymbol,
                declaredSymbolAttribute,
                missingAttributes);

            context.ReportDiagnostic(diagnostic);
        }
    }

    private static ImmutableArray<RequiresPresenceAttributeData> GetAttributePresenceAttributes(ISymbol symbol)
    {
        var attributes = symbol.GetAttributes();
        return RequiresPresenceAttributeData.ParseRange(attributes);
    }

    private sealed record RequiresPresenceAttributeData(AttributeData Attribute, ImmutableArray<ITypeSymbol> Types)
    {
        public static ImmutableArray<RequiresPresenceAttributeData> ParseRange(ImmutableArray<AttributeData> attributes)
        {
            return attributes
                .Select(Parse)
                .Where(r => r is not null)
                .ToImmutableArray()!;
        }

        public static RequiresPresenceAttributeData? Parse(AttributeData attribute)
        {
            if (attribute.AttributeClass is null)
                return null;

            var attributeClassFullName = attribute.AttributeClass.GetFullSymbolName()!;

            bool matchesGeneric = attributeClassFullName.MatchesAny(
                SymbolNameMatchingLevel.Namespace,
                KnownSymbolNames.Full.RequiresPresenceAttributeT1,
                KnownSymbolNames.Full.RequiresPresenceAttributeT2,
                KnownSymbolNames.Full.RequiresPresenceAttributeT3,
                KnownSymbolNames.Full.RequiresPresenceAttributeT4);

            if (matchesGeneric)
            {
                var types = attribute.AttributeClass.TypeArguments;
                return new(attribute, types);
            }

            bool matchesBaseAttribute = attributeClassFullName.Matches(
                KnownSymbolNames.Full.RequiresPresenceAttribute,
                SymbolNameMatchingLevel.Namespace);

            if (matchesBaseAttribute)
            {
                var types = attribute.ConstructorArguments[0].Values
                    .Select(d => d.Type!)
                    .ToImmutableArray();

                return new(attribute, types);
            }

            return null;
        }
    }
}
