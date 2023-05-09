namespace Smarttributes.Constraints;

[Flags]
public enum TypeTargets
{
    Class = 1 << 0,
    Struct = 1 << 1,
    Interface = 1 << 2,
    Delegate = 1 << 3,
    Enum = 1 << 4,

    RecordClass = 1 << 8,
    RecordStruct = 1 << 9,

    AnyClass = Class | RecordClass,
    AnyStruct = Struct | RecordStruct,
}
