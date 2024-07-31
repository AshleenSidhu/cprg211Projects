using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	[Serializable]
	public class Node<User>
	{
		public User Value { get; set; }

		// Public property 'Next' points to the next node in the list, initially null.
		public Node<User> Next { get; set; }

		// Constructor to initialize a new node with provided data; 'Next' is by default null.
		public Node(User value)
		{
			this.Value = value; // Set the data part of the node.
		}

		public override string ToString()
		{
			return Value.ToString();
		}

	}
}
