using FrikanUtils.Spawnpoints;
using FrikanUtils.Spawnpoints.LootSpawn;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace SCP500s.SuperItems;

public class Scp500Swap : Scp500Base
{
    public override string Id => "gamendegamer.scp-500.swap";
    public override string Name => "SCP500 Swap";
    public override string Description => "Take this pill to instantly betray your teammates.";
    public override ItemType VisualType => ItemType.SCP500;

    public override SpawnLocation SpawnLocation { get; } = new()
    {
        Points = new ISpawnPoint[]
        {
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.Scp939Desk
            },
            new LootSpawnPoint
            {
                Chance = 100,
                Point = LootPoint.PCsSmallDesk
            }
        }
    };

    protected override void OnUsedItem(PlayerUsedItemEventArgs ev)
    {
        base.OnUsedItem(ev);
        if (!Check(ev.UsableItem.Serial)) return;

        var newRole = ev.Player.Role switch
        {
            RoleTypeId.ClassD => RoleTypeId.Scientist,
            RoleTypeId.Scientist => RoleTypeId.ClassD,
            RoleTypeId.FacilityGuard => RoleTypeId.ClassD,
            RoleTypeId.ChaosConscript => RoleTypeId.NtfSpecialist,
            RoleTypeId.NtfSpecialist => RoleTypeId.ChaosConscript,
            RoleTypeId.ChaosRifleman => RoleTypeId.NtfPrivate,
            RoleTypeId.NtfPrivate => RoleTypeId.ChaosRifleman,
            RoleTypeId.ChaosMarauder => RoleTypeId.NtfSergeant,
            RoleTypeId.NtfSergeant => RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor => RoleTypeId.NtfCaptain,
            RoleTypeId.NtfCaptain => RoleTypeId.ChaosRepressor,
            _ => RoleTypeId.ClassD
        };

        ev.Player.SetRole(newRole, flags: RoleSpawnFlags.None);
        ev.Player.SendHint(Main.Instance.Config.Scp500Swap);
    }
}