using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using FrikanUtils.Utilities;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using Random = System.Random;

namespace SCP500s.SuperItems;

public class Scp500Lucky : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.lucky";
    public override string Name => "SCP500 Lucky";
    public override string Description => "Gives you a random status effect.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp079Intermediate
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp106Outside
            }
        }
    };

    private static readonly Random Random = new();

    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;

        ev.Player.SendHint(Main.Instance.Config.Scp500Lucky);
        ev.Player.Health = 105;

        ev.Player.EnableRandomEffect(Random.Next(0, 2) == 0
            ? EffectUtilities.EffectClassificationFlag.Negative
            : EffectUtilities.EffectClassificationFlag.Positive);
    }
}