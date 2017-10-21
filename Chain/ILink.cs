namespace Chain
{
    public interface ILink<in T>
    {
        void Execute(T parameter);

        bool ShouldStopPropagation();

        bool ShouldStopExecution();
    }
}
