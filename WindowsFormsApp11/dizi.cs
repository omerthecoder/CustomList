using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    class dizi
    {

        public dizi()
        {
            _data = new object[0];
        }
        private object[] _data;
        public void Add(object obj)
        {
            Array.Resize(ref _data, _data.Length + 1);
            _data[_data.Length - 1] = obj;
        }
        public object this[int index]
        {
            get
            {
                if (index >= _data.Length) throw new Exception("out of range");
                return _data[index];
            }
            set
            {
                if (index >= _data.Length) throw new Exception("out of range");
                _data[index] = value;
            }
        }
    }
}
