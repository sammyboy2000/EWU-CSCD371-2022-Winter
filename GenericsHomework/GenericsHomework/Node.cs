namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        private T Value { get; set; }
        public Node<T> Next { get;  private set; }

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
            if(temp.ToString() == index.ToString())
                return true;
            while(index.Next != this)
            {
                if (temp.ToString() == index.ToString())
                    return true;
                index = index.Next;
            }
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
    }
}