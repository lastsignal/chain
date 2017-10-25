using Chain;

namespace UnitTests.SupportingItems
{
    public class L2 : ILink<Message>
    {
        public void Execute(Message message)
        {
            Results.Add($"L2: {message.Name}");
        }

        public bool ShouldStopPropagation()
        {
            return false;
        }
        public bool ShouldStopExecution()
        {
            return false;
        }
    }
}
