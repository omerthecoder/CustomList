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

        public bool IsReadOnly { get { return ((ICollection<T>)_data).IsReadOnly; } }

        public void Add(T item)
        {
            (_data as List<T>).Add(item);
        }

        public void Clear()
        {
            (_data as List<T>).Clear();

        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
