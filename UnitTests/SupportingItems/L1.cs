using Chain;

namespace UnitTests.SupportingItems
{
    public class L1 : ILink<Message>
    {
        public void Execute(Message parameter)
        {
            Results.Add($"L1: {parameter.Name}");
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
