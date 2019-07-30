using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessageSystem;

/// <summary>
///  This class exists to act as an in-scene container for any item, allowing for it to be interacted with
/// </summary>

public class ItemHarness : MonoBehaviour, IMessageSystem
{
    [SerializeField]
    private Item m_Item;

    // Passes whatever message has been received on to its controlling Item
    public void OnMessageReceive(MessageType _eMessageType, object _MessageBody)
    {
        
        m_Item.OnMessageReceive(_eMessageType, _MessageBody);
    }
}
