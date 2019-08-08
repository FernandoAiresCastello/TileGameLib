using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public class Stack
    {
        private readonly Stack<string> Values = new Stack<string>();

        public int Size => Values.Count;

        public Stack()
        {
        }

        public void Clear()
        {
            Values.Clear();
        }

        public void Push(string value)
        {
            Values.Push(value);
        }

        public string PopStr()
        {
            return Values.Pop();
        }

        public int PopInt()
        {
            int value = TopInt();
            Values.Pop();
            return value;
        }

        public int TopInt()
        {
            int number = 0;
            string value = Values.Peek().Trim();

            if (value.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
                number = Convert.ToInt32(value, 16);
            else if (value.StartsWith("0b", StringComparison.InvariantCultureIgnoreCase))
                number = Convert.ToInt32(value.Substring(2), 2);
            else
                int.TryParse(value, out number);

            return number;
        }

        public List<string> ToList()
        {
            List<string> list = new List<string>();

            foreach (string value in Values.AsEnumerable())
                list.Add(value);

            return list;
        }
    }
}
