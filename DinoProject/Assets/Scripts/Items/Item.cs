using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MessageSystem;

public class Item : ScriptableObject, IMessageSystem
{
    [Header("Visual Properties")]
    public Sprite m_2DSprite;
    public Mesh m_3DModel;
    public string m_strDescription;

    //public virtual 

    public virtual void OnMessageReceive(MessageType _eMessageType, object _MessageBody)
    {

    }

    protected virtual void OnDrop(object _MessageBody) { }

    protected virtual void OnDrag(object _MessageBody) { }

    protected virtual void OnTap(object _MessageBody) { }
}
