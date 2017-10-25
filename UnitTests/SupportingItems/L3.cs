using Chain;

namespace UnitTests.SupportingItems
{
    public class L3 : ILink<Message>
    {
        public void Execute(Message message)
        {
            Results.Add($"L3: {message.Name}");
        }

        public bool ShouldStopPropagation()
        {
            return true;
        }

        public bool ShouldStopExecution()
        {
            return false;
        }
    }
}
