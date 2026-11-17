// Jakar.Extensions :: Jakar.Core.Tests
// 11/16/2026

using System.ComponentModel;



namespace Jakar.Extensions.Tests;


[TestFixture]
public sealed class Core_Tests
{
    private sealed class Model : BaseClass<Model>
    {
        public override bool Equals( Model?    other ) => ReferenceEquals(this, other);
        public override int  CompareTo( Model? other ) => ReferenceEquals(this, other) ? 0 : 1;
    }



    private sealed record Item( int Value ) : BaseRecord;


    [Test] public void WithAdditionalData_MergesAndClones()
    {
        JObjectNode first  = new() { ["a"] = 1 };
        JObjectNode second = new() { ["b"] = 2, ["a"] = 3 };
        Model       model  = new Model().WithAdditionalData(first).WithAdditionalData(second);

        Assert.That((int)model.AdditionalData!["a"]!, Is.EqualTo(3), "later keys replace earlier ones");
        Assert.That((int)model.AdditionalData!["b"]!, Is.EqualTo(2));
        Assert.That(ReferenceEquals(model.AdditionalData["b"], second["b"]), Is.False, "values are cloned");
    }


    [Test] public void BaseRecord_IsAValueRecord_WithAdditionalData()
    {
        Item item = new(1) { AdditionalData = new JObjectNode { ["x"] = "y" } };

        Assert.That(item with { Value = 2 }, Is.Not.EqualTo(item));
        Assert.That(item.AdditionalData!.ContainsKey("x"), Is.True);
    }


    [Test] public void PropertyChangedEventArgs_AreCached()
    {
        PropertyChangedEventArgs first = "Name".AsPropertyChangedEventArgs();
        Assert.That("Name".AsPropertyChangedEventArgs(), Is.SameAs(first));
        Assert.That(first.PropertyName, Is.EqualTo("Name"));
    }


    [Test] public void ExpectedValueTypeException_NamesBothTypes()
    {
        ExpectedValueTypeException e = new(42, typeof(string), typeof(Guid));

        Assert.That(e.Message, Does.Contain(typeof(int).FullName).And.Contain(typeof(string).FullName).And.Contain(typeof(Guid).FullName));
    }
}