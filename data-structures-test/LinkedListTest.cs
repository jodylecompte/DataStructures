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
    * AddAfter() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Add_New_Node_With_Value_On_AddAfter_For_Fresh_List()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddAfter(list.First, 10);

        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.Last.Value, Is.EqualTo(10));

        Assert.That(list.First.Next.Value, Is.EqualTo(10));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(5));
    }

    [Test]
    public void Should_Add_New_Node_After_Target_Node_On_AddAfter()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> targetNode = new Node<int>(20);
        Node<int> newNode = new Node<int>(75);

        list.AddLast(25);
        list.AddLast(targetNode);
        list.AddLast(45);
        list.AddAfter(targetNode, newNode);
        list.AddLast(35);

        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        // Ensure forward references are intact
        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.First.Next.Value, Is.EqualTo(25));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(20));
        Assert.That(list.First.Next.Next.Next.Value, Is.EqualTo(75));
        Assert.That(list.First.Next.Next.Next.Next.Value, Is.EqualTo(45));
        Assert.That(list.First.Next.Next.Next.Next.Next.Value, Is.EqualTo(35));

        // Ensure backward references are intact
        Assert.That(list.Last.Value, Is.EqualTo(35));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(45));
        Assert.That(list.Last.Prev.Prev.Value, Is.EqualTo(75));
        Assert.That(list.Last.Prev.Prev.Prev.Value, Is.EqualTo(20));
        Assert.That(list.Last.Prev.Prev.Prev.Prev.Value, Is.EqualTo(25));
        Assert.That(list.Last.Prev.Prev.Prev.Prev.Prev.Value, Is.EqualTo(5));
    }

    [Test]
    public void Should_Throw_Exception_On_AddAfter_When_Node_Is_Null()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        Node<int> newNode = new Node<int>(10);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.AddAfter(null, newNode);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_AddAfter_When_NewNode_Is_Null()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        Node<int> targetNode = new Node<int>(10);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.AddAfter(targetNode, null);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_AddAfter_When_Node_Is_Not_In_List()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> targetNode = new Node<int>(10);
        Node<int> newNode = new Node<int>(15);

        Assert.Throws<InvalidOperationException>(() =>
        {
            list.AddAfter(targetNode, newNode);
        });
    }

    /*
    * ****************************************
    * AddBefore() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Add_New_Node_Before_Target_Node_On_AddBefore()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> targetNode = new Node<int>(20);
        Node<int> newNode = new Node<int>(75);

        list.AddLast(25);
        list.AddLast(targetNode);
        list.AddLast(45);
        list.AddBefore(targetNode, newNode);
        list.AddLast(35);

        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        // Ensure forward references are intact
        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.First.Next.Value, Is.EqualTo(25));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(75));
        Assert.That(list.First.Next.Next.Next.Value, Is.EqualTo(20));
        Assert.That(list.First.Next.Next.Next.Next.Value, Is.EqualTo(45));
        Assert.That(list.First.Next.Next.Next.Next.Next.Value, Is.EqualTo(35));

        // Ensure backward references are intact
        Assert.That(list.Last.Value, Is.EqualTo(35));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(45));
        Assert.That(list.Last.Prev.Prev.Value, Is.EqualTo(20));
        Assert.That(list.Last.Prev.Prev.Prev.Value, Is.EqualTo(75));
        Assert.That(list.Last.Prev.Prev.Prev.Prev.Value, Is.EqualTo(25));
        Assert.That(list.Last.Prev.Prev.Prev.Prev.Prev.Value, Is.EqualTo(5));
    }

    [Test]
    public void Should_Add_New_Node_At_Head_On_AddBefore_For_Fresh_List()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddBefore(list.First, 10);

        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        Assert.That(list.First.Value, Is.EqualTo(10));
        Assert.That(list.Last.Value, Is.EqualTo(5));

        Assert.That(list.First.Next.Value, Is.EqualTo(5));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(10));
    }

    [Test]
    public void Should_Throw_Exception_On_AddBefore_When_Node_Is_Null()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        Node<int> newNode = new Node<int>(10);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.AddBefore(null, newNode);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_AddBefore_When_NewNode_Is_Null()
    {
        LinkedList<int> list = new LinkedList<int>(5);
        Node<int> targetNode = new Node<int>(10);

        Assert.Throws<ArgumentNullException>(() =>
        {
            list.AddBefore(targetNode, null);
        });
    }

    [Test]
    public void Should_Throw_Exception_On_AddBefore_When_Node_Is_Not_In_List()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> targetNode = new Node<int>(10);
        Node<int> newNode = new Node<int>(15);

        Assert.Throws<InvalidOperationException>(() =>
        {
            list.AddBefore(targetNode, newNode);
        });
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
    * AddLast() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Append_On_AddLast()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddLast(new Node<int>(10));
        list.AddLast(new Node<int>(15));

        // Ensure First and Last are different references now
        Assert.That(list.Count, Is.EqualTo(3));
        Assert.That(list.First, Is.Not.EqualTo(list.Last));

        //// Assert that the chains next references are intact
        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.First.Next.Value, Is.EqualTo(10));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(15));

        //// Assert that the chain's prev references are intact
        Assert.That(list.Last.Value, Is.EqualTo(15));
        Assert.That(list.Last.Prev.Value, Is.EqualTo(10));
        Assert.That(list.Last.Prev.Prev.Value, Is.EqualTo(5));
    }

    [Test]
    public void Should_Create_Node_And_Append_On_AddLast_Overload()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddLast(16);
        list.AddLast(32);

        Assert.That(list.First.Value, Is.EqualTo(5));
        Assert.That(list.First.Next.Value, Is.EqualTo(16));
        Assert.That(list.First.Next.Next.Value, Is.EqualTo(32));
    }


    [Test]
    public void Should_Throw_Exception_On_AddLast_With_Null_Node()
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
    * Contains() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Return_Valid_Bool_On_Contains_Value()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        list.AddFirst(10);
        list.AddFirst(15);
        list.AddFirst(20);

        Assert.That(list.Contains(10), Is.EqualTo(true));
        Assert.That(list.Contains(20), Is.EqualTo(true));

        Assert.That(list.Contains(100), Is.EqualTo(false));
        Assert.That(list.Contains(1000), Is.EqualTo(false));
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

    /*
    * ****************************************
    * Find() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Return_First_Result_On_Valid()
    {
        LinkedList<int> list = new LinkedList<int>();

        Node<int> nodeOne = new Node<int>(5);
        Node<int> nodeTwo = new Node<int>(5);

        list.AddLast(nodeOne);
        list.AddLast(nodeTwo);

        Node<int> found = list.Find(5);

        Assert.That(found, Is.EqualTo(nodeOne));
        Assert.That(found, Is.Not.EqualTo(nodeTwo));
        Assert.That(found.Value, Is.EqualTo(5));
    }

    public void Should_Return_Null_On_Invalid_Find()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> found = list.Find(51);

        Assert.That(found, Is.EqualTo(null));
    }

    /*
    * ****************************************
    * FindLast() Method Tests
    * ****************************************
    */
    [Test]
    public void Should_Return_Last_Result_On_Valid_FindLast()
    {
        LinkedList<int> list = new LinkedList<int>();

        Node<int> nodeOne = new Node<int>(5);
        Node<int> nodeTwo = new Node<int>(5);

        list.AddLast(nodeOne);
        list.AddLast(nodeTwo);

        Node<int> found = list.FindLast(5);

        Assert.That(found, Is.EqualTo(nodeTwo));
        Assert.That(found, Is.Not.EqualTo(nodeOne));
        Assert.That(found.Value, Is.EqualTo(5));
    }

    public void Should_Return_Null_On_Invalid_FindLast()
    {
        LinkedList<int> list = new LinkedList<int>(5);

        Node<int> found = list.FindLast(51);

        Assert.That(found, Is.EqualTo(null));
    }
}
