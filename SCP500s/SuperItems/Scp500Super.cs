using System.Collections.Generic;
using CustomPlayerEffects;
using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using MEC;
using PlayerStatsSystem;

namespace SCP500s.SuperItems;

public class Scp500Super : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.super";
    public override string Name => "Super SCP500";

    public override string Description =>
        "Eat this to move faster and walk silently, but you lose the use of your hands.";

    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.MicroHIDContainment
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.PCsStoriedDesk
            }
        }
    };

    internal static readonly HashSet<Player> SeveredHands = new();

    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
        PlayerEvents.Hurting += OnPlayerHurting;
    }

    protected override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();
        PlayerEvents.Hurting -= OnPlayerHurting;
    }

    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;

        ev.Player.SendHint(Main.Instance.Config.Scp500Super, 7);
        ev.Player.EnableEffect<Invisible>(1, 7f);
        ev.Player.EnableEffect<MovementBoost>(1, 50);
        ev.Player.EnableEffect<SilentWalk>(1, 7f);
        ev.Player.EnableEffect<SeveredHands>(1, 1f);
        SeveredHands.Add(ev.Player);

        Timing.CallDelayed(7f, () => SeveredHands.Remove(ev.Player));
    }

    private static void OnPlayerHurting(PlayerHurtingEventArgs ev)
    {
        if (SeveredHands.Contains(ev.Player) && ev.DamageHandler is UniversalDamageHandler universalHandler &&
            universalHandler.TranslationId == DeathTranslations.SeveredHands.Id)
        {
            ev.IsAllowed = false;
        }
    }
}