using System.Collections.Generic;
using FrikanUtils.CustomItems;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using UnityEngine;

namespace SCP500s.SuperItems;

public abstract class Scp500Base : CustomItem
{
    internal static readonly Dictionary<ushort, LightSourceToy> ActiveLights = new();

    private static readonly Color GlowColor = new Color32(0x31, 0x33, 0x00, 0x01);

    protected override void SubscribeEvents()
    {
        PlayerEvents.DroppedItem += AddGlow;
        PlayerEvents.PickedUpItem += RemoveGlow;

        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        PlayerEvents.DroppedItem -= AddGlow;
        PlayerEvents.PickedUpItem -= RemoveGlow;

        base.UnsubscribeEvents();
    }

    private void AddGlow(PlayerDroppedItemEventArgs ev)
    {
        if (!Check(ev.Pickup.Serial) || ev.Pickup.LastOwner == null) return;
        if (ev.Pickup.Base.transform == null) return;
        
        if (ActiveLights.TryGetValue(ev.Pickup.Serial, out var light))
        {
            light.Transform.parent = ev.Pickup.Base.transform;
        }
        else
        {
            light = LightSourceToy.Create(ev.Pickup.Base.transform);
        }

        light.Color = GlowColor;
        light.Intensity = 0.7f;
        light.Range = 0.5f;
        light.ShadowType = LightShadows.None;

        ActiveLights[ev.Pickup.Serial] = light;
    }

    private void RemoveGlow(PlayerPickedUpItemEventArgs ev)
    {
        if (!Check(ev.Item.Serial) || !ActiveLights.TryGetValue(ev.Item.Serial, out var light)) return;

        light.Destroy();
        ActiveLights.Remove(ev.Item.Serial);
    }
}