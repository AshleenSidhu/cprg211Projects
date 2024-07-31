using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;

namespace Assignment3.Utility
{
	public class SLL : ILinkedListADT
	{
		public int Size { get; private set; }
		public Node<User> Head { get; private set; }
		public Node<User> Tail { get; private set; }
		public SLL()
		{
			Size = 0;
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Prepends (adds to beginning) value to the list.
		/// </summary>
		/// <param name="value">Value to store inside element.</param>
		public void AddFirst(User value)
		{
			Node<User> newNode = new Node<User>(value); // Create a new node.
			if (Head == null) // If the list is empty, head and tail point to the new node.
			{
				Head = newNode;
				Tail = newNode;
			}
			else // If the list is not empty, link new node to the existing head and update head.
			{
				newNode.Next = Head;
				Head = newNode;
			}
			Size++; // Increase the count of nodes.
		}

		/// <summary>
		/// Adds to the end of the list.
		/// </summary>
		/// <param name="value">Value to append.</param>
		public void AddLast(User value)
		{
			Node<User> newNode = new Node<User>(value); // Create a new node.
			if (Head == null) // If the list is empty, head and tail point to the new node.
			{
				Head = newNode;
			}
			else // If the list is not empty, link current tail to new node and update tail.
			{
				Tail.Next = newNode;
			}
			Tail = newNode;
			Size++; // Increase the count of nodes.
		}

		/// <summary>
		/// Removes first element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveFirst()
		{
			if (Head != null) // If the list is not empty, update head to the next node.
			{
				Head = Head.Next;
				if (Head == null) // If the list became empty, also update tail to null.
				{
					Tail = null;
				}
				Size--; // Decrease the count of nodes.
			}
			else
			{
				throw new CannotRemoveException("List is empty"); // Throw an exception if the list is empty.
			}
		}

		/// <summary>
		/// Removes last element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveLast()
		{
			if (Head == null) // Check if the list is empty.
			{
				throw new CannotRemoveException("List is empty"); // Throw an exception if the list is empty.
			}
			if (Head.Next == null) // Check if there is only one node in the list.
			{
				Head = null; // Make the list empty.
				Tail = null;
			}
			else
			{
				Node<User> current = Head;
				while (current.Next.Next != null) // Traverse until the second-last node.
				{
					current = current.Next;
				}
				current.Next = null; // Remove the last node by setting the second-last node's next to null.
				Tail = current; // Update the Tail to the new last node.
			}
			Size--; // Decrease count of nodes.
		}

		/// <summary>
		/// Removes element at index from list, reducing the size.
		/// </summary>
		/// <param name="index">Index of element to remove.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Remove(int index)
		{
			int countSizeReturn = Size;
			if (index < 0 || index >= countSizeReturn -1) // Check if the position is out of bounds.
			{
				throw new IndexOutOfRangeException("Index is negative or larger than size -1 of list"); // Throw an exception if the index is out of bounds.
			}
			if (index == 0) // If position is 0, remove the first node.
			{
				RemoveFirst();
				return;
			}
			if (index == Size - 1) // If position is the last index, remove the last node.
			{
				RemoveLast();
				return;
			}
			// Find the node just before the one to be deleted.
			Node<User> current = Head;
			for (int i = 0; i < index - 1; i++)
			{
				current = current.Next;
			}
			// Update the next pointer to skip over the deleted node.
			current.Next = current.Next.Next;
			Size--; // Decrease count of nodes.
		}

		/// <summary>
		/// Adds a new element at a specific position.
		/// </summary>
		/// <param name="value">Value that element is to contain.</param>
		/// <param name="index">Index to add new element at.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
		public void Add(User value, int index)
		{
			int countSizeReturn = Size;
			if (index < 0 || index > countSizeReturn -1) // Check if the position is out of bounds.
			{
				throw new IndexOutOfRangeException("Index is negative or larger than size -1 of list"); // Throw an exception if the index is out of bounds.
			}
			if (index == 0) // If position is 0, add the node to the beginning.
			{
				AddFirst(value);
				return;
			}
			if (index == Size) // If position is the last index, add the node to the end.
			{
				AddLast(value);
				return;
			}
			// Find the node just before the position to insert the new node.
			Node<User> current = Head;
			for (int i = 0; i < index - 1; i++)
			{
				current = current.Next;
			}
			// Create a new node and link it to the next node.
			Node<User> newNode = new Node<User>(value);
			newNode.Next = current.Next;
			current.Next = newNode;
			Size++; // Increase count of nodes.
		}

		/// <summary>
		/// Replaces the value  at index.
		/// </summary>
		/// <param name="value">Value to replace.</param>
		/// <param name="index">Index of element to replace.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Replace(User value, int index)
		{
			int countSizeReturn = Size;
			if (index < 0 || index >= countSizeReturn -1) // Check if the position is out of bounds.
			{
				throw new IndexOutOfRangeException("Index is negative or larger than size -1 of list"); // Throw an exception if the index is out of bounds.
			}
			// Find the node at the position and update the data.
			Node<User> current = Head;
			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
			current.Value = value;
		}

		/// <summary>
		/// Gets the first index of element containing value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>First of index of node with matching value or -1 if not found.</returns>
		public int IndexOf(User value)
		{
			// Traverse the list and find the first node with the data.
			Node<User> current = Head;
			int index = 0;
			while (current != null)
			{
				if (current.Value.Equals(value))
				{
					return index;
				}
				current = current.Next;
				index++;
			}
			return -1;
		}


		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>Value of node at index</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public User GetValue(int index)
		{
			int countSizeReturn = Size;
			//gets the value of the node at the specified index
			if (index < 0 || index >= countSizeReturn -1) // Check if the position is out of bounds.
			{
				throw new IndexOutOfRangeException("Index is negative or larger than size -1 of list"); // Throw an exception if the index is out of bounds.
			}
			// Find the node at the position and return the data.
			Node<User> current = Head;
			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
			// return the data of the node at the specified index
			return current.Value;

		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public void Clear()
		{
			Head = null; // Remove reference to the head, making the list empty.
			Tail = null; // Remove reference to the tail since the list is now empty.
			Size = 0; // Reset the count to 0 as there are no nodes in the list.
			Console.WriteLine("The list has been cleared.");
		}

		/// <summary>
		/// Go through nodes and check if one has value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>True if element exists with value.</returns>
		public bool Contains(User value)
		{
			Node<User> current = Head;
			while (current != null)
			{
				if (current.Value.Equals(value))
				{
					return true; // Found the value.
				}
				current = current.Next;
			}
			return false; // Value not found.
		}

		/// <summary>
		/// Gets the number of elements in the list.
		/// </summary>
		/// <returns>Size of list (0 meaning empty)</returns>
		public int Count()
		{
			return Size;
		}

		/// <summary>
		/// Checks if the list is empty.
		/// </summary>
		/// <returns>True if it is empty.</returns>
		public bool IsEmpty()
		{
			// If the head is null, the list is empty.
			if (Head == null)
			{
				return true;
			}
			return false;
		}
	}
}
