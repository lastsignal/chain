﻿using Chain;

namespace UnitTests.SupportingItems
{
    public class L1 : ILink<Message>
    {
        public void Execute(Message message)
        {
            Results.Add($"L1: {message.Name}");
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
