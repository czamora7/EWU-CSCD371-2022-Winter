namespace CanHazFunny;
public class Jester
{
    private Comedian? _Comedian;
    private JokeService? _JokeService;
    private string? _Joke;
    public Comedian? Comedian 
    {
        get => _Comedian!;
        set 
        { 
            if (value is null) throw new ArgumentNullException(nameof(value));
            _Comedian = value;
        } 
    }
    public JokeService? JokeService
    {
        get => _JokeService!;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            _JokeService = value;
        }
    }

    public string?Joke
    {
        get => _Joke!;
        private set 
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            _Joke = value; 
        }
    }

    public Jester()
    {
        Joke = "Chuck Norris";
    }

    public string TellJoke(Comedian comedian, JokeService jokeService)
    {
        //set the dependencies as the parameters
        Comedian = comedian;
        JokeService = jokeService;
        
        //retrieve the joke from the jokeservice
        Joke = this.JokeService.GetJoke();
        
        //check to see if the joke is a chuck norris joke, if it is get another one
#pragma warning disable CA1307 //this warning asked to specify the string comparison type, which 
                                //required specific enums be set in place not necessarily relevant
                                //in this string comparison
        while(Joke.Contains("Chuck Norris"))
#pragma warning restore CA1307 
        {
            Joke = this.JokeService.GetJoke();
        }

        //if not display the joke and exit
        this.Comedian.DisplayJoke(Joke);
        return Joke;
    }

}

