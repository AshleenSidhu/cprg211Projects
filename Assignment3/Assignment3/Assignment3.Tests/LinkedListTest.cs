using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3;
using Assignment3.Utility;
using NUnit.Framework;

namespace Assignment3.Tests
{
	[TestFixture]
	public class LinkedListTest
	{
		private ILinkedListADT users;
		private SLL userSLL; //Used in ReversedLinkedListTest method

		[SetUp]
		public void Setup()
		{
			this.users = new SLL();
			users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
			users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
			users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
			users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

		}

		/// <summary>
		/// Test for the AddFirst method of the linked list.
		/// It verifies that the AddFirst method correctly adds a new User object to the beginning of the list.
		/// </summary>
		[Test]
		public void TestAddFirst()
		{
			// add a new user to the beginning.
			users.AddFirst(new User(0, "Kevin Kim", "jiyeon.heo@gmail.com", "123456"));
			// get the name of the first user in the list
			string expected = users.GetValue(0).Name;
			// check that the name of the first user matches the expected name
			Assert.AreEqual("Kevin Kim", expected);

		}

		/// <summary>
		/// Test for the AddLast method of the linked list.
		/// It verifies that the AddLast method correctly adds a new User object to the end of the list.
		/// </summary>
		[Test]
		public void TestAddLast()
		{
		}

		/// <summary>
		/// Test for the Add method.
		/// It verifies that the Add method correctly add a new User object to the specified index in the list.
		/// </summary>
		[Test]
		public void TestAdd()
		{
			// add a new user to the index 2
			users.Add(new User(10, "Sandra Kelly", "sandra1@sait.com", "98700400"), 2);
			string expected = users.GetValue(2).Name;
			// check that the name of the user object at index 2 matches the expected name
			Assert.That(expected, Is.EqualTo("Sandra Kelly"));
		}

		/// <summary>
		/// Test for the removeFirst method
		/// </summary>
		[Test]
		public void TestRemoveFirst()
		{
			// remove the first user
			users.RemoveFirst();
			// get the name of the first(index 0) user object in the list
			string expected = users.GetValue(0).Name;
			// check that the name of the first user object matches the expected name
			Assert.That(expected, Is.EqualTo("Joe Schmoe"));
		}

		/// <summary>
		/// Test for the removeLast method
		/// </summary>
		[Test]
		public void TestRemoveLast()
		{
		}

		/// <summary>
		/// Test for the remove method
		/// </summary>
		[Test]
		public void TestRemove()
		{
		}

		/// <summary>
		/// Test for the Getvalue method
		/// </summary>
		[Test]
		public void TestGetValue()
		{
		}

		[Test]
		public void IsEmptyTest()
		{
			Assert.IsFalse(users.IsEmpty());
		}

		[Test]
		public void ReplaceTest()
		{
		}

		/// <summary>
		/// Test for the reverse method
		/// </summary>
		[Test]
		public void ReverseLinkedListTest()
		{
			//Arrange and Act
			SLL userSLL = new SLL();
			userSLL.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
			userSLL.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
			userSLL.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
			userSLL.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

			SLL reversedList = userSLL.Reverse();
			Node<User> reversedHead = reversedList.Head;

			int expected1 = 4;
			int expected2 = 3;
			int expected3 = 2;
			int expected4 = 1;

			int outputted1 = reversedHead.Value.Id;
			int outputted2 = reversedHead.Next.Value.Id;
			int outputted3 = reversedHead.Next.Next.Value.Id;
			int outputted4 = reversedHead.Next.Next.Next.Value.Id;

			//Assert
			Assert.That(outputted1, Is.EqualTo(expected1));
			Assert.That(outputted2, Is.EqualTo(expected2));
			Assert.That(outputted3, Is.EqualTo(expected3));
			Assert.That(outputted4, Is.EqualTo(expected4));
		}


	}
}
