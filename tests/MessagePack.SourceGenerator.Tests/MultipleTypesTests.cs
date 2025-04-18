// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using VerifyCS = CSharpSourceGeneratorVerifier<MessagePack.SourceGenerator.MessagePackGenerator>;

public class MultipleTypesTests
{
    private readonly ITestOutputHelper testOutputHelper;

    public MultipleTypesTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Theory, PairwiseData]
    public async Task TwoTypes(bool usesMapMode)
    {
        string testSource = """
using MessagePack;

[MessagePackObject]
public class Object1
{
}

[MessagePackObject]
public class Object2
{
}
""";
        await VerifyCS.Test.RunDefaultAsync(this.testOutputHelper, testSource, options: new() { Generator = new() { Formatters = new() { UsesMapMode = usesMapMode } } }, testMethod: $"{nameof(TwoTypes)}({usesMapMode})");
    }

    [Fact]
    public async Task ZeroTypes()
    {
        string testSource = """
using MessagePack;
""";
        await VerifyCS.Test.RunDefaultAsync(this.testOutputHelper, testSource);
    }
}
