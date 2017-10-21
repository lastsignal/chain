namespace Chain
{
    public interface ILink<in T> where T : ILinkParameter
    {
        void Execute(T parameter);

        bool ShouldStopPropagation();

        bool ShouldStopExecution();
    }
}
