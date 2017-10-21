using Chain;

namespace UnitTests.SupportingItems
{
    public class L3 : ILink<Message>
    {
        public void Execute(Message parameter)
        {
            Results.Add($"L3: {parameter.Name}");
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
