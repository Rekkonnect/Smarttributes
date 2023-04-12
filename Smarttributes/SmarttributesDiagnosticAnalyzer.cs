using RoseLynn.Analyzers;

namespace Smarttributes;

public abstract class SmarttributesDiagnosticAnalyzer : StoredDescriptorDiagnosticAnalyzer
{
    protected override DiagnosticDescriptorStorageBase DiagnosticDescriptorStorage
        => SmarttributesDiagnosicDescriptorStorage.Instance;
}
