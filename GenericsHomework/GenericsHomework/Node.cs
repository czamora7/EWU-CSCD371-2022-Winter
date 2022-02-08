namespace GenericsHomework;
public class Node<T>
{

    public Node<T> _Next;
    public T? Data { get; private set; }
    public Node<T> Next { 
        get { return _Next; }
        private set { }
    }

    public Node(T t)
    {
        Data = t;
        Next = this;
    }

    public override String ToString()
    {
        return Data?.ToString();
    }

    public void Append(Node<T> nextNode)
    {
        this.Next = nextNode;
    }


}