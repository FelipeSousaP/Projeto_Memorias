using System.Collections.Generic;
using UnityEngine;

public class objectPool<T> where T: class // estou dizendo para ele receber CLASSE e não valores
{
    Queue<T> Pool = new Queue<T>();

    public void SetPool(T pool)
    {
        if (!Pool.Contains(pool)) // caso não contenha o valor vindo, ele será adiquirindo na fila
        {
            Pool.Enqueue(pool); // adicionando um tipo generico na fila
        }
    }

    public T TryGetPool() // Usar Uma condicional
    {
        return Pool.Count > 0 ? Pool.Dequeue() : default(T);
        /* if (Pool.Count > 0)
         {
             return Pool.Dequeue(); // o paramentro recebe um objeto que sai da fila
         }
         return default(T);*/
        // nova coisa que descobri: Se T for uma classe, ele retorna null. Se T for um número, ele retorna 0.
    }
}
