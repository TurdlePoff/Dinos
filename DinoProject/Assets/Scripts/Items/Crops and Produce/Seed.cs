using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessageSystem;

[CreateAssetMenu(fileName ="CropSeed", menuName ="New Crop Seed", order = 51)]
public class Seed : Item
{
    [Header("Seed Properties")]
    public float m_fGrowthTime;
    public int m_uiCost;
    public float m_fBaseValue;

    // Handles messages accordingly
    public override void OnMessageReceive(MessageType _eMessageType, object _MessageBody) {
        switch (_eMessageType) {

            case MessageType.eDragEvent: {
                // Drag
                break;
            }

            case MessageType.eDropEvent: {
                // Drop
                break;
            }

            case MessageType.eTapEvent: {
                // First touch
                break;
            }

            default:break;
        }
    }

    protected override void OnDrag(object _MessageBody) {
        base.OnDrag(_MessageBody);
    }

    protected override void OnDrop(object _MessageBody) {
        base.OnDrop(_MessageBody);
    }

    protected override void OnTap(object _MessageBody) {
        base.OnTap(_MessageBody);
    }
}
