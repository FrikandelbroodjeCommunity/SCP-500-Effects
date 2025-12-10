using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Features.Wrappers;

namespace SCP500s.SuperItems;

public class Scp500DrinkMe : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.shrink";
    public override string Name => "SCP500 'Drink me'";
    public override string Description => "Shrinks your body after consuming it.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.WCs
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp914Shelve
            }
        }
    };

    protected override void OnUsedItem(Player player, UsableItem item)
    {
        base.OnUsedItem(player, item);

        player.Scale *= 0.5f;
        player.SendHint(Main.Instance.Config.Scp500Rakun, 7);
    }
}