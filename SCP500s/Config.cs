using System.Collections.Generic;
using System.ComponentModel;

namespace SCP500s;

public class Config
{
    public string Scp500Aphera { get; set; } = "<color=#87457A>[Where is my head?]</color>";
    public string Scp500Lucky { get; set; } = "<color=#87457A>[Was luck on your side?]</color>";
    public string Scp500Swap { get; set; } = "<color=#87457A>[The worst betrayal]</color>";

    public string Scp500Teleport { get; set; } =
        "<color=#87457A>[You teleported to a random room in the facility]</color>";

    public string Scp500Rakun { get; set; } = "<color=#87457A>[Wow good kid]</color>";

    public string Scp500Ops { get; set; } =
        "<color=#8E7CC3>[Now you can see all players and enemies in this game]</color>";

    public string Scp500Santa { get; set; } = "<color=#87457A>[You have received a random item]</color>";
    public string Scp500Super { get; set; } = "<color=#ca9a19>[You're a superhero now]</color>";
    public string Scp500Shadow { get; set; } = "<color=#ec3a8b>[You can now pass through doors]</color>";
    public string Scp500Sonic { get; set; } = "<color=#198C19>[SUPER SONIC]</color>";


    [Description("List of possible items that can be used for Santa")]
    public List<ItemType> Items { get; set; } = new()
    {
        ItemType.ArmorHeavy,
        ItemType.ArmorLight,
        ItemType.GunAK,
        ItemType.GunE11SR,
        ItemType.Adrenaline,
        ItemType.KeycardO5,
        ItemType.Radio
    };
}