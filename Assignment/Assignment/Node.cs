using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    //Class copied from Assignment 4.
    public class Node<T> where T : notnull
    {
        private T Value { get; set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }
        public override string? ToString()
        {
            return Value.ToString();
        }
        public void Append(T value)
        {
            if (Exists(value))
                throw new ArgumentException("Value already exists in list.");
            Node<T> index = this;
            while (Next != index)
            {
                index = index.Next;
            }
            index.Next = new Node<T>(value);
            index = index.Next;
            index.Next = this;
        }
        public bool Exists(T Value)
        {
            Node<T> temp = new(Value);
            Node<T> index = this;
            if (temp.ToString() == index.ToString())
                return true;
            do
            {
                if (temp.ToString() == index.ToString())
                    return true;
                index = index.Next;
            } while (index != this);
            return false;
        }
        public void Clear()
        {
            //Does work when simply setting this to this.Next
            //GC is smart enough to clean up a circling list that has no references
            //debug builds will hang onto that memory for longer though.
            if (this == this.Next)
                return;
            Node<T> index = this;
            while (index.Next != this)
                index = index.Next;
            index.Next = index.Next.Next;
            this.Next = this;
        }

        //New work begins here...
        public IEnumerable<T> WholeList
        {
            get
            {
                Node<T> index = this;
                do
                {
                    yield return index.Value;
                    index = index.Next;

                } while (index != this);
            }
        }
        public IEnumerable<T> ChildItems(int maximum)
        {
            IEnumerable<T> temp = this.WholeList;
            for (int i = 0; i < maximum; i++)
            {
                yield return temp.ElementAt(i);
            }
        }
    }
}


