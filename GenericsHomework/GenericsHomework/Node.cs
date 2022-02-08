namespace GenericsHomework;
public class Node<T>
{
    public T? Data { get; private set; }
    public Node<T> Next { get; private set; }

    public Node(T t)
    {
        Data = t;
    }

    public override String ToString()
    {
        return Data?.ToString();
    }






}