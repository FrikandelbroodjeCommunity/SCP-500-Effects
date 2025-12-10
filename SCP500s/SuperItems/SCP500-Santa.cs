using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Features.Wrappers;
using MEC;

namespace SCP500s.SuperItems;

public class Scp500Santa : SCP500Base
{
    public override string Id => "gamendegamer.scp-500.santa";
    public override string Name => "SCP500 Santa";
    public override string Description => "A pill of luck, gives a random item, good or bad.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.IntercomCrate
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.LczPCsDesk
            }
        }
    };

    protected override void OnUsedItem(Player player, UsableItem item)
    {
        base.OnUsedItem(player, item);

        player.SendHint(Main.Instance.Config.Scp500Santa, 7);

        Timing.CallDelayed(.1f, () =>
        {
            var random = Main.Instance.Config.Items.RandomItem();
            var newItem = player.AddItem(random);
            player.CurrentItem = newItem;
        });
    }
}