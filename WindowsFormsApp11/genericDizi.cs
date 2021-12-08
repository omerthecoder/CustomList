using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    class genericDizi<T>
    {
        public genericDizi()
        {
            _data = new T[0];
        }
        private T[] _data;
        void Add(T deger)
        {
            Array.Resize(ref _data,_data.Length+1);
            _data[_data.Length - 1] = deger;
        }
        public T this[int index]
        {
            get
            {
                if (index>=_data.Length)
                {
                    throw new Exception("hata");
                }
                return _data[index];
            } set {
                if (index >= _data.Length)
                {
                    throw new Exception("hata");
                }_data[index] = value;
            } 
        }

    }
}
