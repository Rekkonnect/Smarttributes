using RoseLynn;

namespace Smarttributes.AnalyzerTests;

public sealed class SmarttributesUsingsProvider : UsingsProviderBase
{
    public static readonly SmarttributesUsingsProvider Instance = new();

    public const string DefaultUsings =
@"
using Smarttributes;
using Smarttributes.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
";

    public override string DefaultNecessaryUsings => DefaultUsings;

    private SmarttributesUsingsProvider() { }
}