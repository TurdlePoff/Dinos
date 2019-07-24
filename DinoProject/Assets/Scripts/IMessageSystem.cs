using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessageSystem
{
    public enum MessageType
    {
        eTapEvent,
        eDragEvent,
        eDropEvent
    }

    public interface IMessageSystem
    {
        void OnMessageReceive(MessageType _eMessage, object _MessagePayload);
    }


}


