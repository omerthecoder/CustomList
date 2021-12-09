using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    class genericListe<T> : IList<T>
    {
        public genericListe()
        {
            _data = new T[0];
        }
        private T[] _data;
        public T this[int index]
        {
            get
            {
                if (index >=_data.Length)
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
       
        public int Count 
        {
            get { return _data.Length; }
        }

        public bool IsReadOnly { get { return _data.IsReadOnly; } }

        public void Add(T item)
        {
            Array.Resize(ref _data,_data.Length + 1) ;
            _data[_data.Length - 1] = item;
        }

        public void Clear()
        {
            Array.Resize(ref _data, 0);

        }

        public bool Contains(T item)
        {
            EqualityComparer<T> ec = EqualityComparer<T>.Default;
            for (int i = 0; i < _data.Length; i++)
            {
                if (ec.Equals(_data[i], item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_data,0, array, arrayIndex,_data.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new dataEnumerator<T>(_data);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_data,item,0,_data.Length);
        }

        public void Insert(int index, T item)
        {
            if (index>=_data.Length)
            {
                return;
            }
            Array.Resize(ref _data, _data.Length + 1);
            T[] temp = new T[_data.Length];
            Array.Copy(_data, temp, _data.Length);
            for (int i = index; i < _data.Length-1; i++)
            {
                _data[i + 1] = temp[i];
            }
            _data[index] = item;
        }

        public bool Remove(T item)
        {
            T[] tempArray=null;
            int index = 0;
            bool result = false;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].Equals(item))
                {
                    _data[i] = default(T);
                    index = i;
                    tempArray = _data;
                    result = true;
                    break;
                }
            }
            if (tempArray==null)
            {
                throw new ArgumentNullException();
            }
            for (int i = index; i < tempArray.Length; i++)
            {
                if (i>=_data.Length-1)
                {
                    Array.Resize(ref tempArray, tempArray.Length - 1);
                    break;
                }
                if (tempArray[i].Equals(default(T)))
                {
                    tempArray[i] = _data[i + 1];
                    tempArray[i + 1] = default(T);
                    continue;
                }
            }
            _data = tempArray;
            return result;
        }

        public void RemoveAt(int index)
        {
            if (index>=_data.Length)
            {
                return;
            }
            if (index<_data.Length-1)
            {
                Array.Copy(_data, index + 1, _data, index, _data.Length-1 - index); 
            }
            Array.Resize(ref _data, _data.Length - 1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
    class dataEnumerator<T> : IEnumerator<T>
    {
        T[] temp;
        int index = -1;
        public dataEnumerator(T[] iterationArray)
        {
            temp = iterationArray;
        }
        public T Current {
            get {
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
            return index<temp.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
