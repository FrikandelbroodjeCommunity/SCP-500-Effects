using CustomPlayerEffects;
using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;

namespace SCP500s.SuperItems;

public class Scp500Shadow : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.shadow";
    public override string Name => "SCP500 Shadow";
    public override string Description => "Lets you pass through doors unseen, like a true shadow.";
    public override ItemType VisualType => ItemType.SCP500;
    public override SpawnLocation SpawnLocation { get; }= new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp049Armory
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp330Table
            }
        }
    };


    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;

        ev.Player.SendHint(Main.Instance.Config.Scp500Shadow, 7);
        ev.Player.EnableEffect<Ghostly>(1, 7);
    }
}