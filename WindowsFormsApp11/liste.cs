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

        public object SyncRoot { get {return _data.SyncRoot; } }

        public bool IsSynchronized { get { return _data.IsSynchronized; } }

        public int Add(object value)
        {
            Array.Resize(ref _data, _data.Length + 1);
            _data[_data.Length - 1] = value;
            return 1;
        }

        public void Clear()
        {
            Array.Resize(ref _data, 0);
        }

        public bool Contains(object value)
        {
            EqualityComparer<object> ec = EqualityComparer<object>.Default;
            for (int i = 0; i < _data.Length; i++)
            {
                if (ec.Equals(_data[i], value)) return true;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(_data, 0, array, index, _data.Length);
        }

        public IEnumerator GetEnumerator()
        {
            return new dataEnumerator(_data);
        }

        public int IndexOf(object value)
        {
            return Array.IndexOf(_data, value, 0, _data.Length);
        }

        public void Insert(int index, object value)
        {
            if (index >= _data.Length)
            {
                return;
            }
            Array.Resize(ref _data, _data.Length + 1);
            object[] temp = new object[_data.Length];
            Array.Copy(_data, temp, _data.Length);
            for (int i = index; i < _data.Length - 1; i++)
            {
                _data[i + 1] = temp[i];
            }
            _data[index] = value;
        }

        public void Remove(object value)
        {
            object[] tempArray = null;
            int index = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].Equals(value))
                {
                    _data[i] = default(object);
                    index = i;
                    tempArray = _data;
                    break;
                }
            }
            if (tempArray == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = index; i < tempArray.Length; i++)
            {
                if (i >= _data.Length - 1)
                {
                    Array.Resize(ref tempArray, tempArray.Length - 1);
                    break;
                }
                if (tempArray[i].Equals(default(object)))
                {
                    tempArray[i] = _data[i + 1];
                    tempArray[i + 1] = default(object);
                    continue;
                }
            }
            _data = tempArray;
        }

        public void RemoveAt(int index)
        {
            if(index >= _data.Length)
            {
                return;
            }
            if (index < _data.Length - 1)
            {
                Array.Copy(_data, index + 1, _data, index, _data.Length - 1 - index);
            }
            Array.Resize(ref _data, _data.Length - 1);
        }
        class dataEnumerator: IEnumerator
        {
            object[] temp;
            int index = -1;
            public dataEnumerator(object[] iterationArray)
            {
                temp = iterationArray;
            }
            public object Current
            {
                get
                {
                    return temp[index];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                index++;
                return index < temp.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
