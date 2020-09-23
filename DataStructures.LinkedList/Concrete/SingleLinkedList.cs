﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.LinkedList.Abstractions;

namespace DataStructures.LinkedList.Concrete
{
    public class SingleLinkedList<T> : ILinkedList<T>
    {
        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }
        public ILinkedListNode<T> First { get; private set; }
        public ILinkedListNode<T> Last => null;


        public ILinkedListNode<T> AddFirst(T entity)
        {
            var node = new LinkedListNode<T>(entity) {Next = First};
            First = node;
            Count++;
            return node;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Linked list is empty.");

            var first = First;
            First = First.Next;
            first.Next = null;
            Count--;
        }

        public ILinkedListNode<T> AddLast(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T entity)
        {
            var current = First;

            while (current != null)
            {
                if (current.Value.Equals(entity))
                    return true;
                if (current.Next == null)
                    break;
                current = current.Next;
            }

            return false;
        }

        public ILinkedListNode<T> Find(T entity)
        {
            var current = First;

            while (current != null)
            {
                if (current.Value.Equals(entity))
                    return current;
                if (current.Next == null)
                    break;
                current = current.Next;
            }

            return null;
        }
        
        // very not optimal solution for space and complexity
        // there are 2x list in memory and O(n^2) time complexity
        public void Reverse()
        {
            var queue = new Queue<ILinkedListNode<T>>();
            var current = First;
            
            while (true)
            {
                queue.Enqueue(current);
                if (current.Next == null)
                    break;
                current = current.Next;
            }
            
            Clear();

            while (queue.Any()) 
                AddFirst(queue.Dequeue().Value);
        }

        public void Clear()
        {
            while (Count > 0) RemoveFirst();
        }
    }
}