namespace data_structures_test;

using data_structures;

public class LinkedListTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_Initialize_Without_Node_On_Blank_Input()
    {
        LinkedList<int> list = new LinkedList<int>();

        Assert.That(list.First, Is.EqualTo(null));
        Assert.That(list.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_Initialize_First_Node_With_Value()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Assert.That(list.First, Is.Not.EqualTo(null));
        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.Count, Is.EqualTo(1));
    }

    [Test]
    public void Should_Have_Matching_Reference_for_First_And_Tail_On_Init()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Assert.That(list.First, Is.Not.EqualTo(null));
        Assert.That(list.First.Value, Is.EqualTo(5));

        Assert.That(list.Last, Is.Not.EqualTo(null));
        Assert.That(list.Last.Value, Is.EqualTo(5));

        Assert.That(list.Count, Is.EqualTo(1));
    }

    [Test]
    public void Should_Clear_References_And_Length_On_Clear()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.Clear();

        Assert.That(list.First, Is.EqualTo(null));
        Assert.That(list.Last, Is.EqualTo(null));
        Assert.That(list.Count, Is.EqualTo(0));
    }
}
