using Chain;

namespace UnitTests.SupportingItems
{
    public class L4 : ILink<Message>
    {
        public void Execute(Message message)
        {
            Results.Add($"L4: {message.Name}");
        }

        public bool ShouldStopPropagation()
        {
            return false;
        }

        public bool ShouldStopExecution()
        {
            return true;
        }
    }
}
