using Bluehorse.Core.Helper;

namespace Bluehorse.Game.Messages
{
    public sealed class MessageBus
    {
        public static readonly Message<string, float, object> SampleMessage01 = new Message<string, float, object>();
        public static readonly Message<string, float, object> SampleMessage02 = new Message<string, float, object>();
        public static readonly Message<string, float, object> SampleMessage03 = new Message<string, float, object>();
    }

    public class MessageArgs
    {
        public static readonly MessageArgs None = new MessageArgs();

        public override string ToString()
        {
            return "()";
        }
    }

    public sealed class PvpLeagueFinishedMessageArgs : MessageArgs
    {
        public PvpLeagueFinishedMessageArgs(string leagueId, int reward)
        {
            LeagueId = leagueId;
            Reward = reward;
        }

        public string LeagueId { get; }
        public int Reward { get; }
    }
    // MessageBus.PvpLeagueFinished.Send(new PvpLeagueFinishedMessageArgs(league.Id, league.Reward));

    public sealed class PlayerResourcesChangedMessageArgs : MessageArgs
    {
        public PlayerResourcesChangedMessageArgs(int fame, int gold, int strix, int flasks)
        {
            Fame = fame;
            Gold = gold;
            Strix = strix;
            Flasks = flasks;
        }

        public int Fame { get; }
        public int Gold { get; }
        public int Strix { get; }
        public int Flasks { get; }

        public override string ToString()
        {
            return $"{nameof(Fame)}: {Fame}, {nameof(Gold)}: {Gold}, {nameof(Strix)}: {Strix}, {nameof(Flasks)}: {Flasks}";
        }
    }
    // MessageBus.ResourcesChanged.Send(new PlayerResourcesChangedMessageArgs(fame, gold, strix, flasks));
}