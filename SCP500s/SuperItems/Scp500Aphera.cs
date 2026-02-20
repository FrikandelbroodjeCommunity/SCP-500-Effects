using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;

namespace SCP500s.SuperItems;

public class Scp500Aphera : Scp500Base
{
    public override string Id { get;  } = "gamendegamer.scp-500.aphera";
    public override string Name { get;  } =  "SCP500 Aphera";
    public override string Description { get;  } = "Will put your head in the ground.";
    public override ItemType VisualType { get; }=  ItemType.SCP500;
    public override SpawnLocation SpawnLocation { get; }= new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp049ArmoyWorkstation
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp106Inside
            }
        }
    };

    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;

        ev.Player.SendHint(Main.Instance.Config.Scp500Aphera);
        ev.Player.Scale *= -1;
    }
    
}
