namespace Smarttributes.Constraints;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class RequiresPresenceAttribute : Attribute
{
    public virtual Type[] Types { get; }

    public RequiresPresenceAttribute(params Type[] types)
    {
        Types = types;
    }
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class RequiresPresenceAttribute<T> : RequiresPresenceAttribute
    where T : Attribute
{
    private static readonly Type[] types = new[] { typeof(T) };

    public override Type[] Types => types;
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class RequiresPresenceAttribute<T1, T2> : RequiresPresenceAttribute
    where T1 : Attribute
    where T2 : Attribute
{
    private static readonly Type[] types = new[] { typeof(T1), typeof(T2) };

    public override Type[] Types => types;
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class RequiresPresenceAttribute<T1, T2, T3> : RequiresPresenceAttribute
    where T1 : Attribute
    where T2 : Attribute
    where T3 : Attribute
{
    private static readonly Type[] types = new[] { typeof(T1), typeof(T2), typeof(T3) };

    public override Type[] Types => types;
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class RequiresPresenceAttribute<T1, T2, T3, T4> : RequiresPresenceAttribute
    where T1 : Attribute
    where T2 : Attribute
    where T3 : Attribute
    where T4 : Attribute
{
    private static readonly Type[] types = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };

    public override Type[] Types => types;
}

// Any more than 4 could become ugly
