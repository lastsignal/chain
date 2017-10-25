namespace UnitTests.SupportingItems
{
    public class L6 : ILinkMarker
    {
        public void Execute(Message message)
        {
            Results.Add($"L6: {message.Name}");
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
