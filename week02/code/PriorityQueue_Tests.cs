using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Priority queue adds the correct number of items in the correct order
    // Expected Result: "["Item 1 (Pri:{6})", "Item 2 (Pri:{1})", "Item 3 (Pri:{4})"]"
    // Defect(s) Found: None at this point
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 6);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 4);

        Assert.AreEqual("[Item 1 (Pri:6), Item 2 (Pri:1), Item 3 (Pri:4)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue should return the value of the item with the highest priority
    // Expected Result: "Item 2"
    // Defect(s) Found: None at this point
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 6);
        priorityQueue.Enqueue("Item 3", 4);

        Assert.AreEqual("Item 2", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: High priority items is in the front of the queue
    // Expected Result: "Item 1"
    // Defect(s) Found: None at this point
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 6);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 4);

        Assert.AreEqual("Item 1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: High priority items is in the back of the queue
    // Expected Result: "Item 3"
    // Defect(s) Found: Dequeue ignores the last item added
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 4);
        priorityQueue.Enqueue("Item 3", 6);

        Assert.AreEqual("Item 3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: All items are dequeued in the correct order
    // Expected Result: "Item 2", "Item 5", "Item 4", "Item 1", "Item 3"
    // Defect(s) Found: High priority item was not being dequeued
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 5);
        priorityQueue.Enqueue("Item 3", 1);
        priorityQueue.Enqueue("Item 4", 3);
        priorityQueue.Enqueue("Item 5", 4);

        Assert.AreEqual("Item 2", priorityQueue.Dequeue());
        Assert.AreEqual("Item 5", priorityQueue.Dequeue());
        Assert.AreEqual("Item 4", priorityQueue.Dequeue());
        Assert.AreEqual("Item 1", priorityQueue.Dequeue());
        Assert.AreEqual("Item 3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: When more than one high priority item has the same number, dequeue should return the item that was added first
    // Expected Result: "Item 2"
    // Defect(s) Found: It returned the last high priority item added, not the first
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 6);
        priorityQueue.Enqueue("Item 3", 6);
        priorityQueue.Enqueue("Item 4", 6);
        priorityQueue.Enqueue("Item 5", 4);

        Assert.AreEqual("Item 2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown when dequeue is called
    // Expected Result: "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_7()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "The queue is empty.");
        
    }
}