using System.Collections.Generic;
using UnityEngine;
namespace Memorias.Framework.ObjectPool 
{
    public class ObjectPool<T> where T : class
    {
        private Queue<T> _fila = new();
        public void SetPool(T pool)
        {
            _fila.Enqueue(pool);
        }
        public T GetPool()
        {
            return _fila.Dequeue();
        }
    }
}
