using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public class ParameterStack
    {
        private readonly Stack<string> Values = new Stack<string>();

        public int Size => Values.Count;
        public bool IsEmpty => Size == 0;

        public ParameterStack()
        {
        }

        public void Clear()
        {
            Values.Clear();
        }

        public void Push(object value)
        {
            Values.Push(value.ToString());
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

        public string TopStr()
        {
            return Values.Peek();
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

        public void DiscardTop()
        {
            Values.Pop();
        }

        public void DuplicateTop()
        {
            Values.Push(Values.Peek());
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
