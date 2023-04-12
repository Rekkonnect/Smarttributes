using Microsoft.CodeAnalysis;
using RoseLynn.Analyzers;
using System.Resources;

namespace Smarttributes;

public sealed class SmarttributesDiagnosicDescriptorStorage : DiagnosticDescriptorStorageBase
{
    public static readonly SmarttributesDiagnosicDescriptorStorage Instance = new();

    protected override string BaseRuleDocsURI => "https://github.com/Rekkonnect/Smarttributes/blob/master/docs/rules";
    protected override string DiagnosticIDPrefix => "SMTTR";
    protected override ResourceManager ResourceManager => DiagnosticResources.ResourceManager;

    #region Category Constants
    public const string APIRestrictionsCategory = "API Restrictions";
    public const string BrevityCategory = "Brevity";
    public const string DesignCategory = "Design";
    public const string InformationCategory = "Information";
    public const string ValidityCategory = "Validity";
    #endregion

    #region Rules
    private SmarttributesDiagnosicDescriptorStorage()
    {
        SetDefaultDiagnosticAnalyzer<AttributePresenceAnalyzer>();

        CreateDiagnosticDescriptor(0001, APIRestrictionsCategory, DiagnosticSeverity.Error);
    }
    #endregion
}
