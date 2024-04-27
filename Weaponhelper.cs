using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace OpenPrefirePrac;

public enum WeaponType
{
    Grenade = 0,
    Primary = 1,
    Secondary = 2,
}

public class Weapon
{
    public Weapon(string giveName, WeaponType type = WeaponType.Grenade)
    {
        Type = type;
        GiveName = giveName;
    }

    public WeaponType Type { get; set; }
    public string GiveName { get; set; }
}

public static class WeaponHelper
{
    internal static (Dictionary<string, Weapon> Weapons, Dictionary<string, Weapon> WeaponCheckers) LoadWeapons()
    {
        var weapons = new Dictionary<string, Weapon>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"AK-47",                              new("weapon_ak47",          WeaponType.Primary)},
                {"AWP",                                new("weapon_awp",          WeaponType.Primary)},
                {"M4A4",                               new("weapon_m4a1",          WeaponType.Primary)},
                {"M4A1-S",                             new("weapon_m4a1_silencer",          WeaponType.Primary)},
                {"AUG",                                new("weapon_aug",          WeaponType.Primary)},
                {"SSG 08",                             new("weapon_ssg08",          WeaponType.Primary)},
                {"Negev",                              new("weapon_negev",          WeaponType.Primary)},
                {"M249",                               new("weapon_m249",          WeaponType.Primary)},
                {"FAMAS",                              new("weapon_famas",          WeaponType.Primary)},
                {"Galil AR",                           new("weapon_galilar",          WeaponType.Primary)},
                {"MP5-SD",                             new("weapon_mp5sd",          WeaponType.Primary)},
                {"PP-Bizon",                           new("weapon_bizon",          WeaponType.Primary)},
                {"UMP-45",                             new("weapon_ump45",          WeaponType.Primary)},
                {"MP9",                                new("weapon_mp9",          WeaponType.Primary)},
                {"P90",                                new("weapon_p90",          WeaponType.Primary)},
                {"MP7",                                new("weapon_mp7",          WeaponType.Primary)},
                {"MAC-10",                             new("weapon_mac10",          WeaponType.Primary)},
                {"SG 553",                             new("weapon_sg556",          WeaponType.Primary)},
                {"G3SG1",                              new("weapon_g3sg1",          WeaponType.Primary)},
                {"SCAR-20",                            new("weapon_scar20" ,          WeaponType.Primary)},
                {"XM1014",                             new("weapon_xm1014",          WeaponType.Primary)},
                {"MAG-7",                              new("weapon_mag7",          WeaponType.Primary)},
                {"Sawed-Off",                          new("weapon_sawedoff",          WeaponType.Primary)},
                {"Nova",                               new("weapon_nova",          WeaponType.Primary)},

                {"Desert Eagle",                       new("weapon_deagle",         WeaponType.Secondary)},
                {"Glock-18",                           new("weapon_glock",          WeaponType.Secondary)},
                {"P2000",                              new("weapon_hkp2000",        WeaponType.Secondary)},
                {"USP-S",                              new("weapon_usp_silencer",   WeaponType.Secondary)},
                {"Tec-9",                              new("weapon_tec9",           WeaponType.Secondary)},
                {"P250",                               new("weapon_p250",           WeaponType.Secondary)},
                {"CZ75-Auto",                          new("weapon_cz75a",          WeaponType.Secondary)},
                {"Dual Berettas",                      new("weapon_elite",          WeaponType.Secondary)},
                {"Five-SeveN",                         new("weapon_fiveseven",      WeaponType.Secondary)},
                {"R8 Revolver",                        new("weapon_revolver",       WeaponType.Secondary)},
            };

        var weaponCheckers = new Dictionary<string, Weapon>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"weapon_ak47",                        new("weapon_ak47",          WeaponType.Primary)},
                {"weapon_awp",                         new("weapon_awp",          WeaponType.Primary)},
                {"weapon_m4a1",                        new("weapon_m4a1",          WeaponType.Primary)},
                {"weapon_m4a1_silencer",               new("weapon_m4a1_silencer",          WeaponType.Primary)},
                {"weapon_aug",                         new("weapon_aug",          WeaponType.Primary)},
                {"weapon_ssg08",                       new("weapon_ssg08",          WeaponType.Primary)},
                {"weapon_negev",                       new("weapon_negev",          WeaponType.Primary)},
                {"weapon_bizon",                       new("weapon_bizon",          WeaponType.Primary)},
                {"weapon_m249",                        new("weapon_m249",          WeaponType.Primary)},
                {"weapon_famas",                       new("weapon_famas",          WeaponType.Primary)},
                {"weapon_galilar",                     new("weapon_galilar",          WeaponType.Primary)},
                {"weapon_mp5sd",                       new("weapon_mp5sd",          WeaponType.Primary)},
                {"weapon_ump45",                       new("weapon_ump45",          WeaponType.Primary)},
                {"weapon_mp9",                         new("weapon_mp9",          WeaponType.Primary)},
                {"weapon_p90",                         new("weapon_p90",          WeaponType.Primary)},
                {"weapon_mp7",                         new("weapon_mp7",          WeaponType.Primary)},
                {"weapon_mac10",                       new("weapon_mac10",          WeaponType.Primary)},
                {"weapon_sg556",                       new("weapon_sg556",          WeaponType.Primary)},
                {"weapon_g3sg1",                       new("weapon_g3sg1",          WeaponType.Primary)},
                {"weapon_scar20",                      new("weapon_scar20" ,          WeaponType.Primary)},
                {"weapon_xm1014",                      new("weapon_xm1014",          WeaponType.Primary)},
                {"weapon_mag7",                        new("weapon_mag7",          WeaponType.Primary)},
                {"weapon_sawedoff",                    new("weapon_sawedoff",          WeaponType.Primary)},
                {"weapon_nova",                        new("weapon_nova",          WeaponType.Primary)},

                {"weapon_deagle",                      new("weapon_deagle",         WeaponType.Secondary)},
                {"weapon_glock",                       new("weapon_glock",          WeaponType.Secondary)},
                {"weapon_hkp2000",                     new("weapon_hkp2000",        WeaponType.Secondary)},
                {"weapon_usp_silencer",                new("weapon_usp_silencer",   WeaponType.Secondary)},
                {"weapon_tec9",                        new("weapon_tec9",           WeaponType.Secondary)},
                {"weapon_p250",                        new("weapon_p250",           WeaponType.Secondary)},
                {"weapon_cz75a",                       new("weapon_cz75a",          WeaponType.Secondary)},
                {"weapon_fiveseven",                   new("weapon_fiveseven",      WeaponType.Secondary)},
                {"weapon_elite",                       new("weapon_elite",          WeaponType.Secondary)},
                {"weapon_revolver",                    new("weapon_revolver",       WeaponType.Secondary)},
            };
        return (weapons, weaponCheckers);
    }
}

public static class MenuHelper
{
    private static Dictionary<string, Weapon> _weapons;
    private static Dictionary<string, Weapon> _weaponCheckers;

    private static void GiveSelectedItem(CCSPlayerController player, ChatMenuOption option)
    {
        if (player == null
            || player.IsValid == false
            || player.IsBot == true
            || player?.PlayerPawn?.Value?.WeaponServices?.MyWeapons == null)
        {
            return;
        }
        if (_weapons.TryGetValue(option.Text, out var selectedWeapon))
        {
            RemoveCurrentWeapon(player, selectedWeapon);
            player.GiveNamedItem(selectedWeapon.GiveName);
            if(selectedWeapon.Type == WeaponType.Primary)
            {
                OpenPrefirePrac._playerWeapon[player] = selectedWeapon;
            }
            if(selectedWeapon.Type == WeaponType.Secondary)
            {
                OpenPrefirePrac._playerPWeapon[player] = selectedWeapon;
            }
            MenuManager.CloseActiveMenu(player);
        }
    }

    static MenuHelper()
    {
        var res = WeaponHelper.LoadWeapons();
        _weapons = res.Weapons;
        _weaponCheckers = res.WeaponCheckers;
    }

    internal static void GetGuns(ChatMenu gunMenu, WeaponType? type = null)
    {
        Dictionary<string, Weapon> weapons = _weapons;
        if (type != null)
        {
            weapons = _weapons.Where(x => x.Value.Type == type.Value)
                              .ToDictionary(x => x.Key, y => y.Value);
        }
        foreach (var item in weapons)
        {
            gunMenu.AddMenuOption(item.Key, GiveSelectedItem);
        }
    }

    private static void RemoveCurrentWeapon(CCSPlayerController? player, Weapon selectedWeapon)
    {
        foreach (var weapon in player!.PlayerPawn.Value!.WeaponServices!.MyWeapons)
        {
            if (weapon.Value != null &&
                string.IsNullOrWhiteSpace(weapon.Value.DesignerName) == false &&
                weapon.Value.DesignerName != "[null]" &&
                _weaponCheckers.TryGetValue(weapon.Value.DesignerName, out var currentWeapon))
            {
                if (currentWeapon.Type == selectedWeapon.Type)
                {
                    weapon.Value.Remove();
                }
            }
        }
    }
}
