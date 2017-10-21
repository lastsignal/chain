using System;
using System.Collections.Generic;

namespace Chain
{
    public class EmptyChain<T> : IChain<T>
    {
        private readonly List<ILink<T>> _chain;
        private Action<T> _endLinkAction;

        public EmptyChain()
        {
            _chain = new List<ILink<T>>();
        }

        public void AddLink<TLink>() where TLink : ILink<T>, new()
        {
            var link = new TLink();
            _chain.Add(link);
        }

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
    }
}
