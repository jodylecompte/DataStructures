namespace data_structures_test;

using data_structures;

public class LinkedListTest
{
    [SetUp]
    public void Setup()
    {
    }

    /*
     * ****************************************
     * Constructor Tests
     * ****************************************
     */
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

    /*
    * ****************************************
    * AddFirst() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Prepend_On_AddFirst()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddFirst(new Node<int>(10));
        list.AddFirst(new Node<int>(15));

        // Ensure First and Last are different references now
        Assert.That(list.Count, Is.EqualTo(3));
        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        // Assert that the chains next references are intact
        Assert.That(list.First.Value, Is.EqualTo(15));
        Assert.That(list.First.Next.Value, Is.EqualTo(10));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(5));

        // Assert that the chain's prev references are intact
        Assert.That(list.Last.Value, Is.EqualTo(5));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(10));
        Assert.That(list.Last.Prev.Prev.Value, Is.EqualTo(15));
    }

    [Test]
    public void Should_Create_Node_And_Prepend_On_AddFirst_Overload()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddFirst(16);
        list.AddFirst(32);

        Assert.That(list.First.Value, Is.EqualTo(32));
        Assert.That(list.First.Next.Value, Is.EqualTo(16));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(5));
    }


    [Test]
    public void Should_Throw_Exception_On_AddFirst_With_Null_Node()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.AddFirst(null);
        });
    }

    /*
    * ****************************************
    * Clear() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Clear_References_And_Length_On_Clear()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.Clear();

        Assert.That(list.First, Is.EqualTo(null));
        Assert.That(list.Last, Is.EqualTo(null));
        Assert.That(list.Count, Is.EqualTo(0));
    }

    /*
    * ****************************************
    * CopyTo() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Throw_Exception_On_Copy_With_Negative_Index()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        int[] newArray = new int[5];

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            list.CopyTo(newArray, -15);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_Copy_With_Null_Array()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.CopyTo(null, 1);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_Copy_With_Insufficient_Array_Size()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        int[] newArray = new int[1];

        list.AddFirst(10);
        list.AddFirst(15);
        list.AddFirst(20);

        Assert.Throws<ArgumentException>(() =>
        {
            list.CopyTo(newArray, 0);
        });
    }

    [Test]
    public void Should_Copy_List_To_Array_Given_Proper_Setup()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        int[] newArray = new int[10];

        list.AddFirst(10);
        list.AddFirst(15);
        list.AddFirst(20);

        list.CopyTo(newArray, 0);

        Assert.That(newArray[0], Is.EqualTo(20));
        Assert.That(newArray[1], Is.EqualTo(15));
        Assert.That(newArray[2], Is.EqualTo(10));
        Assert.That(newArray[3], Is.EqualTo(5));
    }

    [Test]
    public void Should_Copy_List_To_Array_At_Prescribed_Index()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        int[] newArray = new int[10];

        list.AddFirst(10);
        list.AddFirst(15);
        list.AddFirst(20);

        list.CopyTo(newArray, 4);

        Assert.That(newArray[4], Is.EqualTo(20));
        Assert.That(newArray[5], Is.EqualTo(15));
        Assert.That(newArray[6], Is.EqualTo(10));
        Assert.That(newArray[7], Is.EqualTo(5));
    }
}
