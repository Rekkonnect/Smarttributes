using Microsoft.CodeAnalysis;
using RoseLynn;
using Smarttributes.Constraints;
using System.Collections.Immutable;

namespace Smarttributes.AnalyzerTests.Helpers;

public static class SmarttributesMetadataReferences
{
    public static readonly ImmutableArray<MetadataReference> BaseReferences = ImmutableArray.Create(new MetadataReference[]
    {
        // Smarttributes.Core
        MetadataReferenceFactory.CreateFromType<RequiresPresenceAttribute>(),
    });
}
