using Chain;

namespace UnitTests.SupportingItems
{
    public class L2 : ILink<Message>
    {
        public void Execute(Message parameter)
        {
            Results.Add($"L2: {parameter.Name}");
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
