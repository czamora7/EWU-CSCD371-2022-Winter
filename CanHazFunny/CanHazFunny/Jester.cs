namespace CanHazFunny;
public class Jester
{
    private Comedian? _Comedian;
    private JokeService? _JokeService;
    protected Comedian Comedian 
    {
        get => _Comedian!;
        set 
        { 
            if (value is null) throw new ArgumentNullException(nameof(value));
            _Comedian = value;
        } 
    }
    protected JokeService JokeService
    {
        get => _JokeService!;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            _JokeService = value;
        }
    }

    public void TellJoke(Comedian comedian, JokeService jokeService)
    {
        //set the dependencies as the parameters
        Comedian = comedian;
        JokeService = jokeService;
        
        //retrieve the joke from the jokeservice
        string joke = this.JokeService.GetJoke();
        
        //check to see if the joke is a chuck norris joke, if it is get another one
#pragma warning disable CA1307 //this warning asked to specify the string comparison type, which 
                                //required specific enums be set in place not necessarily relevant
                                //in this string comparison
        while(joke.Contains("Chuck Norris"))
#pragma warning restore CA1307 
        {
            joke = this.JokeService.GetJoke();
        }

        //if not display the joke and exit
        this.Comedian.DisplayJoke(joke);
    }

}

