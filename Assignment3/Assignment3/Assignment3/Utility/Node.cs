using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	public class Node<User>
	{
		// Public property 'Data' holds the value of the node.
		public User Value { get; set; }

		// Public property 'Next' points to the next node in the list, initially null.
		public Node<User> Next { get; set; }

		// Constructor to initialize a new node with provided data; 'Next' is by default null.
		public Node(User value)
		{
			this.Value = value; // Set the data part of the node.
		}

	}
}
