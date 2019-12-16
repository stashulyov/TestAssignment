namespace Signals
{
    public class GameStartedSignal
    {
        public readonly bool AreBuffsEnabled;

        public GameStartedSignal(bool areBuffsEnabled)
        {
            AreBuffsEnabled = areBuffsEnabled;
        }
    }
}