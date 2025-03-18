using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_Enumerator
{
    public class MyCollection<T> : IEnumerable<T>
    {

        List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);

        }


        public IEnumerator<T> GetEnumerator() => GetEnumerator();



        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }





    class MyCollectionEnumerator<T> : IEnumerator<T>
    {
        public T Current => Current;

        MyCollection<T> _collection = new MyCollection<T>;

        object IEnumerator.Current => Current;
        
        public MyCollectionEnumerator(MyCollection<T> _collection)
        {
            this._collection = _collection;
        }


        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
           
        }
    }




}
