using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found: The last item in the queue was not checked when searching for the highest priority item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items where two have the same highest priority.
    // Expected Result: The first item added with the highest priority should be removed first.
    // Defect(s) Found: When multiple items had the same highest priority, the later item was removed instead of the first item added
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Second", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Add two items, dequeue the highest priority item, then dequeue again.
    // Expected Result: The first dequeue returns "High" and the second returns "Low".
    // Defect(s) Found: Dequeue returned an item without removing it from the queue.
    public void TestPriorityQueue_RemovesItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}