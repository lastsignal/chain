using System;

namespace Chain
{
    public interface IChain<T> where T : ILinkParameter
    {
        void AddLink<TClass>() where TClass : ILink<T>, new();
        void ExecuteAll(T message);

        void SetClosingAction(Action<T> endLinkAction);
    }
}
