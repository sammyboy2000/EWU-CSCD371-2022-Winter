namespace GenericsHomework
{
    public class Node
    {
        public object? Value { get; set; }
        private Node Next { get;  set; }
        public Node GetNext() { return Next; }
        public Node(object? value)
        {
            Value = value;
            Next = this;
        }
        public override string ToString()
        {
            if (Value == null)  
                return "null";
            Type type = Value.GetType();
            if(type == typeof(string) || type == typeof(char))
            {
                return (string)Value;
            }
            if(type == typeof(bool))
            {
                bool b = (bool)Value;
                if (b)
                    return "true";
                else
                    return "false";
            }
            if(type == typeof(int))
            {
                return $"{(int)Value}";
            }
            if(type == typeof(Int64))
            {
                return $"{(Int64)Value}";
            }
            if(type == typeof(float) || type == typeof(Double))
            {
                return $"{(Double)Value}";
            }
            return "Type unknown";
        }
        public void Append(object? value)
        {
            if (Exists(value))
                throw new ArgumentException("Value already exists in list.");
            Node index = this;
            while (Next != index)
            {
                index = index.Next;
            }
            index.Next = new Node(value);
            index = index.Next;
            index.Next = this;
        }
        public bool Exists(object? Value)
        {
            Node temp = new(Value);
            Node index = this;
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
            //Does not work when simple setting this to this.Next
            //GC is smart enough to clean up a circling list, but not to clean up 
            //a list that has a reference to a variable that is still in scope.
            if (this == this.Next)
               return;
           Node index = this;
           while (index.Next != this)
               index = index.Next;
           index.Next = index.Next.Next;
            this.Next = this;
        }
    }
}