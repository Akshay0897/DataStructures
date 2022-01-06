using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class BufferExtensions
    {
        public delegate void Printer<T>(T data);

        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print) 
        {
            foreach (var item in buffer) 
            {
                print(item);
            }
        }

        public static IEnumerable<TOutput> AsEnumurableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
                yield return result;
            }
        }
    }
}
