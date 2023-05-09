namespace Smarttributes.Constraints;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class RequiredAttributeTargetsAttribute : Attribute
{
    public AttributeTargets Targets { get; }
    public RestrictionKind RestrictionKind { get; }

    public RequiredAttributeTargetsAttribute(AttributeTargets targets, RestrictionKind restrictionKind)
    {
        Targets = targets;
        RestrictionKind = restrictionKind;
    }
}
