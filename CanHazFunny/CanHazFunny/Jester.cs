namespace CanHazFunny;
public class Jester
{
    private Comedian _Comedian;
    private JokeService _JokeService;
    protected Comedian? Comedian 
    {
        get => _Comedian;
        set 
        { 
            if (value is null) throw new ArgumentNullException(nameof(value));
            _Comedian = value;
        } 
    }
    protected JokeService? JokeService
    {
        get => _JokeService;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            _JokeService = value;
        }
    }

    public void TellJoke(Comedian? comedian, JokeService? jokeService)
    {
        //set the dependencies as the parameters
        //retrieve the joke from the jokeservice
        //check to see if the joke is a chuck norris joke
        //if it is get another one
        //if not display the joke and exit
    }

}

