
public class GameConfig {

    static bool jugando = true;
	
    public static bool IsPlaying()
    {
        return jugando;
    }

    public static void Play()
    {
        jugando = true;
    }

    public static void Stop()
    {
        jugando = false;
    }
}
