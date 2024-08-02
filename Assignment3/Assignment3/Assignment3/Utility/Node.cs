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

		public Node<User> Next { get; set; }

		public Node(User value)
		{
			this.Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
