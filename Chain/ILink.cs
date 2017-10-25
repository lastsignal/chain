namespace Chain
{
    public interface ILink<in T>
    {
        void Execute(T message);

        bool ShouldStopPropagation();

        bool ShouldStopExecution();
    }
}
