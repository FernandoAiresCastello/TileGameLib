using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public class MemoryFile
    {
        public const string NewLine = "\r\n";

        public string Path { set; get; }
        public int Length => Bytes.Count;
        public bool EndOfFile => ReadPtr >= Length;

        private List<byte> Bytes = new List<byte>();
        private int ReadPtr = 0;

        public MemoryFile()
        {
        }

        public MemoryFile(byte[] bytes)
        {
            if (bytes != null)
            {
                foreach (byte b in bytes)
                    WriteByte(b);
            }
        }

        public MemoryFile(string path)
        {
            LoadFromPhysicalFile(path);
        }

        public byte[] ToByteArray()
        {
            return Bytes.ToArray();
        }

        public void WriteByte(byte b)
        {
            Bytes.Add(b);
        }

        public void WriteChar(char c)
        {
            Bytes.Add((byte)c);
        }

        public void WriteString(string str)
        {
            foreach (char ch in str)
                WriteByte((byte)ch);
        }

        public void WriteLine(string str = "")
        {
            WriteString(str + "\n");
        }

        public void WriteStringNullTerminated(string str)
        {
            WriteString(str);
            WriteByte(0);
        }

        public void WriteShort(int value)
        {
            if (value < 0 || value > ushort.MaxValue)
                throw new TGLException($"Cannot write value {value} as ushort");

            foreach (byte b in BitConverter.GetBytes((ushort)value))
                WriteByte(b);
        }

        public void WriteInt(int value)
        {
            if (value < 0)
                throw new TGLException($"Cannot write value {value} as type uint");

            foreach (byte b in BitConverter.GetBytes((uint)value))
                WriteByte(b);
        }

        public byte ReadByte()
        {
            AssertValidPtr();
            return Bytes[ReadPtr++];
        }

        public char ReadChar()
        {
            return (char)ReadByte();
        }

        public string ReadStringNullTerminated()
        {
            StringBuilder str = new StringBuilder();
            byte b = byte.MaxValue;

            while (b != 0)
            {
                b = ReadByte();
                if (b != 0)
                    str.Append((char)b);
            }

            return str.ToString();
        }

        public string ReadAllText()
        {
            StringBuilder str = new StringBuilder();

            ReadPtr = 0;
            while (ReadPtr < Length)
                str.Append((char)Bytes[ReadPtr++]);

            ReadPtr = 0;
            return str.ToString();
        }

        public int ReadShort()
        {
            byte byte1 = ReadByte();
            byte byte2 = ReadByte();
            return BitConverter.ToUInt16(new byte[] { byte1, byte2 }, 0);
        }

        public int ReadInt()
        {
            byte byte1 = ReadByte();
            byte byte2 = ReadByte();
            byte byte3 = ReadByte();
            byte byte4 = ReadByte();
            return (int)BitConverter.ToUInt32(new byte[] { byte1, byte2, byte3, byte4 }, 0);
        }

        private void AssertValidPtr()
        {
            if (EndOfFile)
                throw new TGLException($"Cannot read past file length: index = {ReadPtr}, length = {Length}");
        }

        public void SaveToPhysicalFile(string path)
        {
            Path = path;
            System.IO.File.WriteAllBytes(path, Bytes.ToArray());
        }

        public void LoadFromPhysicalFile(string path)
        {
            Path = path;
            Bytes = System.IO.File.ReadAllBytes(path).ToList();
        }

        public void Seek(int filePointer)
        {
            if (filePointer >= 0 && filePointer < Length)
                ReadPtr = filePointer;
        }
    }
}
