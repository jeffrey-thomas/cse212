using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with items already in priority order ("A",3), ("B",2) , ("C",1) then dequeue until empty
    // Expected Result: A, B, C
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",3);
        priorityQueue.Enqueue("B",2);
        priorityQueue.Enqueue("C",1);

        String[] expected = ["A", "B", "C"];

        int i = 0;
        while(priorityQueue.Length > 0){
            String item = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i++],item);
        }
    }

    [TestMethod]
    // Scenario: Create a queue with items in reverse priority order ("A",1), ("B",2) , ("C",3) then dequeue until empty
    // Expected Result: C, B, A
    // Defect(s) Found: The check for highest priority never checked the last item in the queue
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",1);
        priorityQueue.Enqueue("B",2);
        priorityQueue.Enqueue("C",3);

        String[] expected = ["C", "B", "A"];

        int i = 0;
        while(priorityQueue.Length > 0){
            String item = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i++],item);
        }
    }

    [TestMethod]
    // Scenario: Create a queue with items with identical priority ("A",1), ("B",1) , ("C",1) then dequeue until empty
    // Expected Result: A, B, C
    // Defect(s) Found: Instead of returning the first item with highest priority it was returning the last
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",1);
        priorityQueue.Enqueue("B",1);
        priorityQueue.Enqueue("C",1);

        String[] expected = ["A", "B", "C"];

        int i = 0;
        while(priorityQueue.Length > 0){
            String item = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i++],item);
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue from and empty queue
    // Expected Result: InvalidOperationException("The queue is empty.")
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
       
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
    // Add more test cases as needed below.

}