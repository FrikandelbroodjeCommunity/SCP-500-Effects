using CustomPlayerEffects;
using FrikanUtils.CustomItems;
using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Features.Wrappers;

namespace SCP500s.SuperItems;

public class Scp500Ops : CustomItem
{
    public override string Id => "gamendegamer.scp-500.tracker";
    public override string Name => "SCP500 Tracker";
    public override string Description => "Lets you see all players through walls, like SCP-1344.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Lcz173Desk
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Gr18Containment
            }
        }
    };

    protected override void OnUsedItem(Player player, UsableItem item)
    {
        base.OnUsedItem(player, item);

        player.EnableEffect<Scp1344>(1, 15f);
        player.SendHint(Main.Instance.Config.Scp500Ops, 7);
    }
}