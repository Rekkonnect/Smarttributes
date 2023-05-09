namespace Smarttributes.Constraints;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
[RequiredAttributeTargets(AttributeTargets.Method, RestrictionKind.Exact)]
public class RestrictFunctionsAttribute : Attribute
{
    public FunctionTargets Targets { get; }

    public RestrictFunctionsAttribute(FunctionTargets targets)
    {
        Targets = targets;
    }
}
