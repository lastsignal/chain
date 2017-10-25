namespace Chain
{
    public interface IChain<T>
    {
        void ExecuteAll(T message);
    }
}
