using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace CollectionsTests
{
    public class CollectionTests
    {
        [Test]
        public void TestCollectionEmptyConstructor()
        {
            var nums = new Collection<int>();
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }
        [Test]
        public void Test_Collection_ConstructorSingleItem() 
        {
            var nums = new Collection<int>(5);
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems() 
        {
            var nums = new Collection<int>(5, 10, 15);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }
        [Test]
        public void Test_Collection_Add() 
        {
            var nums = new Collection<int>();
            nums.Add(5);
            nums.Add(10);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 10]"));
            
        }
        [Test]
        public void Test_Collection_AddWithGrow() 
        {
            var nums = new Collection<int>(5, 10, 15);
            nums.Add(20);
            nums.Add(25);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15, 20, 25]"));

        }
        [Test]
        public void Test_Collection_AddRange() {

            var nums = new Collection<int>();
            var newNums = Enumerable.Range(0, 5).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));

        }
        [Test]
        public void Test_Collection_GetByIndex() { 
            var nums = new Collection<int> (5, 10, 15);
            var num = nums[1];
            Assert.That(num, Is.EqualTo(10));
        }
        [Test]
        public void Test_Collection_GetByInvalidIndex() {
            var nums = new Collection<int>(5, 10, 15);
            var num = nums[3];
            Assert.That(num, Is.EqualTo(nums));
        }
        
        [Test]
        public void Test_Collection_AddRangeWithGrow() {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var NewNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(NewNums);

            string expectedNums = "[" + string.Join(", ", NewNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }
        [Test]
        public void Test_Collection_InsertAtStart() { 
            var nums = new Collection<int>(5, 10, 15);
            nums.InsertAt(0, 10);

            Assert.That(nums.Count, Is.EqualTo(4));
            Assert.That(nums.ToString, Is.EqualTo("[10, 5, 10, 15]"));
        }
        [Test]
        public void Test_Collection_InsertAtEnd() {
            var nums = new Collection<int>(5, 10, 15);
            nums.InsertAt(3, 10);

            Assert.That(nums.Count, Is.EqualTo(4));
            Assert.That(nums.ToString, Is.EqualTo("[5, 10, 15, 10]"));
        }
 
        [Test]
        public void Test_Collection_RemoveAtStart() {
            var nums = new Collection<int>(5, 10, 15);
            nums.RemoveAt(0);

            Assert.That(nums.Count, Is.EqualTo(2));
            Assert.That(nums.ToString, Is.EqualTo("[10, 15]"));
        }
        [Test]
        public void Test_Collection_RemoveAtEnd() {
            var nums = new Collection<int>(5, 10, 15);
            nums.RemoveAt(2);

            Assert.That(nums.Count, Is.EqualTo(2));
            Assert.That(nums.ToString, Is.EqualTo("[5, 10]"));
        }
       
        [Test]
        public void Test_Collection_RemoveAll() {
            var nums = new Collection<int>(5, 10, 15);
            nums.RemoveAt(0);
            nums.RemoveAt(0);
            nums.RemoveAt(0);

            Assert.That(nums.Count, Is.EqualTo(0));
            Assert.That(nums.ToString, Is.EqualTo("[]"));
        }
            
        [Test]
        [Timeout(5000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 10000;
            var nums = new Collection<int>();

            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

        [TestCase("Peter", 0, "Peter")]
        [TestCase("Peter, Maria, George", 0, "Peter")]
        [TestCase("Peter, Maria, George", 1, "Maria")]
        [TestCase("Peter, Maria, George", 2, "George")]
        public void alabala(
            string data, int index, string expectedValue)
        {
            // Arrange
            var nums = new Collection<string>(data.Split(", "));

            // Act

            var actual = nums[index];

            // Assert
            Assert.AreEqual(expectedValue, actual);
        }

    }
}