namespace UnitTests.SupportingItems
{
    public class L5 : ILinkMarker
    {
        public void Execute(Message message)
        {
            Results.Add($"L5: {message.Name}");
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
