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

        private static readonly Scp500Ops Ops = new();
        private static readonly Scp500Rakun Rakun = new();
        private static readonly Scp500Santa Santa = new();
        private static readonly Scp500Shadow Shadow = new();
        private static readonly Scp500Sonic Sonic = new();
        private static readonly Scp500Super Super = new();

        public override void Enable()
        {
            Instance = this;

            CustomItemHandler.RegisterCustomItem(Ops);
            CustomItemHandler.RegisterCustomItem(Rakun);
            CustomItemHandler.RegisterCustomItem(Santa);
            CustomItemHandler.RegisterCustomItem(Shadow);
            CustomItemHandler.RegisterCustomItem(Sonic);
            CustomItemHandler.RegisterCustomItem(Super);

            ServerEvents.WaitingForPlayers += OnWaitingForPlayers;
        }

        public override void Disable()
        {
            CustomItemHandler.UnregisterCustomItem(Ops);
            CustomItemHandler.UnregisterCustomItem(Rakun);
            CustomItemHandler.UnregisterCustomItem(Santa);
            CustomItemHandler.UnregisterCustomItem(Shadow);
            CustomItemHandler.UnregisterCustomItem(Sonic);
            CustomItemHandler.UnregisterCustomItem(Super);

            ServerEvents.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private static void OnWaitingForPlayers()
        {
            SCP500Base.ActiveLights.Clear();
            Scp500Super.SeveredHands.Clear();
        }
    }
}