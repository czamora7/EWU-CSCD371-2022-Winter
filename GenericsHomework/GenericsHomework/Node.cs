namespace GenericsHomework;
public class Node<T>
{

    public Node<T> _Next;
    public T? Data { get; private set; }
    public Node<T> Next { 
        get { return _Next; }
        private set { _Next = value; }
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

    public void Append(T data)
    {
        this.Next = new Node<T>(data);
    }

    public void Clear()
    {
        //walk through the list until the end(determined by
        //a self-referencing next or a next pointing to the original node)
        Node<T> check = this;
        Node<T> head = this;

        while(check.Next != check && check.Next != head)
        {
            check = check.Next;
        }

        //if the tail's next is a self reference..
        if (check.Next == check)
        {
            //set the head's next reference to itself
            head.Next = head;
        }
        //else the list is circular
        else
        {
            //set the tails next to self reference
            check.Next = check;
            //set the heads next to self reference
            head.Next = head;
        }
    }

    public bool Exists()
    {
        return false;
    }
}