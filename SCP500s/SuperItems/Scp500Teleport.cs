using System.Linq;
using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using FrikanUtils.Utilities;
using LabApi.Features.Wrappers;
using MapGeneration;
using UnityEngine;

namespace SCP500s.SuperItems;

public class Scp500Teleport : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.teleport";
    public override string Name => "SCP500-Xerneas";
    public override string Description => "if you eat this pill you can teleport to a rendom place in the Facility";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.HczCheckpointDesk
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.HczCheckpointHcz
            }
        }
    };

    protected override void OnUsedItem(Player player, UsableItem item)
    {
        base.OnUsedItem(player, item);

        player.SendHint(Main.Instance.Config.Scp500Teleport);
        player.Position = Room.List.Where(x => x.Shape == RoomShape.Straight).GetRandomElement().Position + Vector3.up;
    }
}