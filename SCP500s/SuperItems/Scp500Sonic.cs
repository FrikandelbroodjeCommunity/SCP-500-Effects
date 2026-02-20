using CustomPlayerEffects;
using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Events.Arguments.PlayerEvents;

namespace SCP500s.SuperItems;

public class Scp500Sonic : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.sonic";
    public override string Name => "SCP500 Sonic";
    public override string Description => "Gives extreme speed.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.MicroHIDDesk
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Lcz173Entrance
            }
        }
    };

    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;
        ev.Player.EnableEffect<MovementBoost>(200, 5);
        ev.Player.SendHint(Main.Instance.Config.Scp500Sonic, 7);
    }
}