using System.Collections.Generic;
namespace Memorias.Framework.ObjectPool 
{
    public class ObjectPool<T> where T : class
    {
        #region Singleton
        private static ObjectPool<T> _instance;
        public static ObjectPool<T> Instance {  get { return _instance; } }
        #endregion
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
