namespace data_structures_test;

using data_structures;

public class NodeTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_Create_A_Node()
    {
        Node<int> node = new Node<int>(5);

        Assert.That(node.Value, Is.EqualTo(5));
    }

    [Test]
    public void Should_Support_Generic_Types()
    {
        Node<String> node = new Node<String>("Jody");

        Assert.That(node.Value, Is.EqualTo("Jody"));
    }

    [Test]
    public void Should_Have_Null_Next_And_Prev_References()
    {
        Node<String> node = new Node<String>("Jody");

        Assert.That(node.Next, Is.EqualTo(null));
        Assert.That(node.Prev, Is.EqualTo(null));
    }
}
