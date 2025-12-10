using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
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

    protected override void OnUsedItem(Player player, UsableItem item)
    {
        base.OnUsedItem(player, item);
        
        player.SendHint(Main.Instance.Config.Scp500Aphera);
        player.Scale *= -1;
    }
    
}
