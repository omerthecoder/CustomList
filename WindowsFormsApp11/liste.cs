using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    class liste : IList
    {
        public object[] _data;
        public liste()
        {
            _data = new object[0];
        }
        public object this[int index] {
            get
            {
                if (index >= _data.Length)
                {
                    throw new Exception("Target out of range");
                }
                return _data[index];
            }
            set
            {
                if (index >= _data.Length)
                {
                    throw new Exception("Target out of range");
                }
                _data[index] = value;
            }
        }

        public bool IsReadOnly {
            get { return _data.IsReadOnly; }
        }

        public bool IsFixedSize { get { return _data.IsFixedSize; } }

        public int Count { get { return _data.Length; } }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
