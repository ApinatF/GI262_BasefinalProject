using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSyntax : MonoBehaviour
{
    
    void Start()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        int n = stack.Pop();
        
        Debug.Log(n);

        while (stack.Count > 0)
        {
            n = stack.Pop();
        
            Debug.Log(n);
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);

        n = queue.Dequeue();
        
        Debug.Log(n);
        
        while (queue.Count > 0)
        {
            n = queue.Dequeue();
        
            Debug.Log(n);
        }
    }
    
    


}
