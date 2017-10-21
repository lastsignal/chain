using System;

namespace Chain
{
    public interface IChain<T>
    {
        void AddLink<TLink>() where TLink : ILink<T>, new();
        void ExecuteAll(T message);

        void SetClosingAction(Action<T> endLinkAction);
    }
}
