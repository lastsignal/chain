using Chain;

namespace UnitTests.SupportingItems
{
    public class L4 : ILink<Message>
    {
        public void Execute(Message parameter)
        {
            Results.Add($"L4: {parameter.Name}");
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
