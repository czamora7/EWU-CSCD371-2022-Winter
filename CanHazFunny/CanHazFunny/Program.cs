namespace CanHazFunny;
class Program
{
    static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        Jester mrJ = new Jester();
        mrJ.TellJoke(new Comedian(), new JokeService());

    }
}

