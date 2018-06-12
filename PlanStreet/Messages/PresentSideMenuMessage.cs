using System;
using GalaSoft.MvvmLight.Messaging;

namespace PlanStreet.Messages
{
	public class PresentSideMenuMessage : MessageBase
    {
        public PresentSideMenuMessage(bool isPresent)
        {
            IsPresent = isPresent;
        }

        public bool IsPresent { get; private set; }
    }
}
