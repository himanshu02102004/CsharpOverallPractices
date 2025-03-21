using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_Enumerator
{
    public class MyCollection<T> : IEnumerable<T>,IReadOnlyList<T>
    {

        List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);

        }

        public IEnumerator<T> GetEnumerator()
        {
           return new MyCollectionEnumerator<T>(this);
        } // generic


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();// non generic method
        

       




        public int Count { get { return _list.Count; } }


        public T this[int index] {  get { return _list[index]; } }




        class MyCollectionEnumerator<T> : IEnumerator<T>
        {
            public T Current { get; set; }

            int index = -1;



            MyCollection<T> _collection = new MyCollection<T>();


            object IEnumerator.Current => Current;




            public MyCollectionEnumerator(MyCollection<> _collection)
            {
                this._collection = _collection;
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (++index >= _collection.Count)
                {
                    return false;
                }
                Current = collection[index];
                return true;
            }



            public void Reset()
            {

            }
        }






    } }
