using System;

namespace Chain
{
    public class PlainChain<T> : IChain<T>
    {
        private readonly ILink<T>[] _chain;

        private Action<T> _endLinkAction;

        public void ExecuteAll(T message)
        {
            foreach (var link in _chain)
            {
                link.Execute(message);

                if (link.ShouldStopExecution())
                    return;

                if (link.ShouldStopPropagation())
                    break;
            }

            _endLinkAction?.Invoke(message);
        }

        public void SetClosingAction(Action<T> endLinkAction)
        {
            _endLinkAction = endLinkAction;
        }

        public PlainChain(ILink<T>[] chain)
        {
            _chain = chain;
        }
    }
}
