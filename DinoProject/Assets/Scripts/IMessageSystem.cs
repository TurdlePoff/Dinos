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

    // Message payload classes go here
    public class TouchMessagePayload {
        public GameObject m_Source;
        public GameObject m_ItemHarness;
    }

}


