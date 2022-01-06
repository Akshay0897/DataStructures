using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty();
        void Write(T item);
        IEnumerable<TOutput> asEnumurable<TOutput>();
        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        public Queue<T> _queue = new Queue<T> ();

        public IEnumerable<TOutput> asEnumurable<TOutput>()
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in _queue)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue) 
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        public T Read()
        {
            return _queue.Dequeue();
        }

        public void Write(T item)
        {
            _queue.Enqueue(item);
        }
    }
}
