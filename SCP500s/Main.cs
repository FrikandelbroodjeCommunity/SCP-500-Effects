using System;
using FrikanUtils.CustomItems;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using SCP500s.SuperItems;


namespace SCP500s
{
    public class Main : Plugin<Config>
    {
        public override string Name => "SCP500s";
        public override string Description => "Adds custom effects to SCP-500";
        public override string Author => "VividZap - Lumi";
        public override Version Version { get; } = new(4, 0, 0);
        public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);

        public static Main Instance { get; set; }

        private static readonly Scp500Aphera Aphera = new();
        private static readonly Scp500DrinkMe DrinkMe = new();
        private static readonly Scp500Lucky Lucky = new();
        private static readonly Scp500Ops Ops = new();
        private static readonly Scp500Santa Santa = new();
        private static readonly Scp500Shadow Shadow = new();
        private static readonly Scp500Sonic Sonic = new();
        private static readonly Scp500Super Super = new();
        private static readonly Scp500Swap Swap = new();
        private static readonly Scp500Teleport Teleport = new();

        public override void Enable()
        {
            Instance = this;

            CustomItemHandler.RegisterCustomItem(Aphera);
            CustomItemHandler.RegisterCustomItem(DrinkMe);
            CustomItemHandler.RegisterCustomItem(Lucky);
            CustomItemHandler.RegisterCustomItem(Ops);
            CustomItemHandler.RegisterCustomItem(Santa);
            CustomItemHandler.RegisterCustomItem(Shadow);
            CustomItemHandler.RegisterCustomItem(Sonic);
            CustomItemHandler.RegisterCustomItem(Super);
            CustomItemHandler.RegisterCustomItem(Swap);
            CustomItemHandler.RegisterCustomItem(Teleport);

            ServerEvents.WaitingForPlayers += OnWaitingForPlayers;
        }

        public override void Disable()
        {
            CustomItemHandler.UnregisterCustomItem(Aphera);
            CustomItemHandler.UnregisterCustomItem(DrinkMe);
            CustomItemHandler.UnregisterCustomItem(Lucky);
            CustomItemHandler.UnregisterCustomItem(Ops);
            CustomItemHandler.UnregisterCustomItem(Santa);
            CustomItemHandler.UnregisterCustomItem(Shadow);
            CustomItemHandler.UnregisterCustomItem(Sonic);
            CustomItemHandler.UnregisterCustomItem(Super);
            CustomItemHandler.UnregisterCustomItem(Swap);
            CustomItemHandler.UnregisterCustomItem(Teleport);

            ServerEvents.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private static void OnWaitingForPlayers()
        {
            Scp500Base.ActiveLights.Clear();
            Scp500Super.SeveredHands.Clear();
        }
    }
}