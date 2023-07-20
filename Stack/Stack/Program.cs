using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
	class Node
	{
		public int Data;
		public Node Next;

		public Node(int data)
		{
			this.Data = data;
			this.Next = null;
		}
	}

	class Stack : IEnumerable
	{
		public Node top;
		public int size;
		public int capacity;

		public IEnumerable<int> GetIteratedStack()
		{
			Node temp = top;
			while (temp != null)
			{
				yield return temp.Data;
				temp = temp.Next;
			}
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public Stack(int capacity)
		{
			this.capacity = capacity;
			this.top = null;
			this.size = 0;
		}

		public bool IsFull()
		{
			return size == capacity;
		}


		public void PushElement(int data)
		{
			if (IsFull())
			{
				throw new System.Exception("Stack is Full!!");
			}
			Node newNode = new Node(data)
			{
				Next = top
			};
			top = newNode;
			size++;
		}

		public bool IsEmpty()
		{
			return size == 0;
		}

		public int PopElement()
		{

			if (IsEmpty())
			{
				throw new System.Exception("Stack is Empty!");
			}
			Node removedNode = top;
			top = top.Next;
			size--;
			return removedNode.Data;
		}

		public int GetPeek()
		{
			if (IsEmpty())
			{
				throw new System.Exception("Stack is empty!!");
			}
			return top.Data;
		}

		public bool Contains(int val)
		{
			Node temp = top;
			while (temp != null)
			{
				if (temp.Data == val)
				{
					return true;
				}
				temp = temp.Next;
			}
			return false;
		}

		public int GetMid()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty!!\n");
			}

			Node fast = top;
			Node slow = top;
			while (fast != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;
			}
			return slow.Data;
		}

		public void SortStack()
		{

			if (IsEmpty())
			{
				Console.WriteLine("Stack is Empty!!\n");
			}

			Stack tempStack = new Stack(capacity);

			while (!IsEmpty())
			{
				int temp = PopElement();
				while (!tempStack.IsEmpty() && temp < tempStack.GetPeek())
				{
					PushElement(tempStack.PopElement());
				}
				tempStack.PushElement(temp);
			}

			while (!tempStack.IsEmpty())
			{
				PushElement(tempStack.PopElement());
			}

		}


		public void PrintStack()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is Empty!!\n");
				return;
			}
			Node curr = top;
			while (curr != null)
			{
				Console.Write(curr.Data + " ");
				curr = curr.Next;
			}
			Console.WriteLine();
		}


		public void ReverseStack()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty!!\n");
			}
			Node prev = null, next = null;
			Node curr = top;
			while (curr != null)
			{
				next = curr.Next;
				curr.Next = prev;
				prev = curr;
				curr = next;
			}
			top = prev;
		}

	}


	class Program
	{
		private static void Main(string[] args)
		{
			Stack stack = new Stack(50);
			Console.WriteLine("-------------- STACK IMPLEMENTATION -----------------\n");
			while (true)
			{
				int choice;
				Console.WriteLine("1: Push element on top");
				Console.WriteLine("2: Pop element from top");
				Console.WriteLine("3: Peek element");
				Console.WriteLine("4: Check existence of particular element in stack");
				Console.WriteLine("5: Size of stack");
				Console.WriteLine("6: Center element in stack");
				Console.WriteLine("7: Sort the stack");
				Console.WriteLine("8: Reverse the stack");
				Console.WriteLine("9: Iterator on stack");
				Console.WriteLine("10: Print the stack");
				Console.WriteLine("0: Exit\n\n");

				Console.Write("Enter your choice: ");

				// will check whether the choice is in the range.
				if (int.TryParse(Console.ReadLine(), out choice) && (choice <= 10 && choice >= 0))
				{
					switch (choice)
					{

						case 0:
							Console.WriteLine("Terminating!!");
							return;

						case 1:
							Console.Write("Enter element value to push: ");
							int value = int.Parse(Console.ReadLine());
							stack.PushElement(value);
							Console.WriteLine($"Value {value} pushed successfully..\n");
							break;

						case 2:
							int poppedElement = stack.PopElement();
							Console.WriteLine($"Value {poppedElement} popped successfully..\n");
							break;

						case 3:
							int peekElement = stack.GetPeek();
							Console.WriteLine($"Peek element is {peekElement}..\n");
							break;

						case 4:
							Console.Write("Which element do you want to check? ");
							int inputVal = int.Parse(Console.ReadLine());
							if (stack.Contains(inputVal))
							{
								Console.WriteLine($"{inputVal} is present in the stack..");
							}
							else
							{
								Console.WriteLine($"{inputVal} is not present in the stack..");
							}
							Console.WriteLine();
							break;

						case 5:
							Console.WriteLine("Size of stack is: " + stack.size + '\n');
							break;

						case 6:
							int mid = stack.GetMid();
							Console.WriteLine("Middle element of stack is " + mid);
							break;

						case 7:
							stack.SortStack();
							Console.WriteLine("Sorted the stack successfully!!\n");
							break;

						case 8:
							stack.ReverseStack();
							Console.WriteLine("Reversed the stack successfully!!\n");
							break;

						case 9:
							IEnumerable<int> iteratedStack = stack.GetIteratedStack();
							Console.WriteLine("Iterated Stack is: ");
							foreach (int item in iteratedStack)
							{
								Console.WriteLine(item + " ");
							}
							Console.WriteLine();
							break;

						case 10:
							stack.PrintStack();
							break;

						default:
							Console.WriteLine("Invalid choice!!");
							break;
					}

				}
				else
				{
					Console.WriteLine("Enter a valid choice!!");
					continue;
				}




			}

		}
	}
}