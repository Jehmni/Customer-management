using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task_b
{
    internal class CustomerQueue
    {
        // Private properties of the class
        private string[] queue = new string[20];  // Array to store the queue elements
        private int count = 0;  // Number of elements in the queue
        private int head = 0;  // Index of the head element
        private int tail = -1;  // Index of the tail element (increment tail before enqueue)

        // Method to add an element to the queue
        public void Enqueue(string name)
        {
            // Check if the queue is full before adding an element
            if (count < queue.Length)
            {
                tail = (tail + 1) % queue.Length;  // Increment tail first and implement cyclic queue using modulus
                queue[tail] = name;  // Add the user-supplied value to the tail of the queue
                count++;  // Increment the count
            }
            else
            {
                throw new InvalidOperationException("Queue is full");  // Throw an error message if the queue is full
            }
        }

        // Method to remove an element from the queue
        public string Dequeue()
        {
            // Check if the queue has an element that can be removed
            if (count > 0)
            {
                string name = queue[head];  // Remove the element from the head of the queue and assign it to a variable
                head = (head + 1) % queue.Length;  // Increment head and enforce cyclic queue using modulus
                count--;  // Decrement the count
                return name;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");  // Throw an error message if the queue is empty
            }
        }

        // Get method for count to ensure it can be accessed publicly
        public int Count()
        {
            return count;
        }

        // Public get method for the queue
        public string[] GetQueue()
        {
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = queue[(head + i) % queue.Length];
            }
            return result;
        }
    }
}
