using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace OpenPrefirePrac;

public partial class OpenPrefirePrac
{
    public enum WeaponType
    {
        Primary = 0,
        Secondary = 1,
    }

    public class Weapon
    {
        public Weapon(string giveName, WeaponType type = WeaponType.Primary)
        {
            Type = type;
            GiveName = giveName;
        }

        public WeaponType Type { get; set; }
        public string GiveName { get; set; }
    }

    private static class WeaponHelper
    {
        internal static (Dictionary<string, Weapon> Weapons, Dictionary<string, Weapon> WeaponCheckers) LoadWeapons()
        {
            var weapons = new Dictionary<string, Weapon>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"AK-47",                              new("weapon_ak47")},
                {"AWP",                                new("weapon_awp")},
                {"Desert Eagle",                       new("weapon_deagle")},
                {"M4A4",                               new("weapon_m4a1")},
                {"M4A1-S",                             new("weapon_m4a1_silencer")},
                {"SG 553",                             new("weapon_sg553")},
                {"AUG",                                new("weapon_aug")},
                {"SSG 08",                             new("weapon_ssg08")},
                {"Negev",                              new("weapon_negev")},
                {"M249",                               new("weapon_m249")},
                {"FAMAS",                              new("weapon_famas")},
                {"Galil AR",                           new("weapon_galilar")},
                {"MP5-SD",                             new("weapon_mp5sd")},
                {"PP-Bizon",                           new("weapon_bizon")},
                {"UMP-45",                             new("weapon_ump45")},
                {"MP9",                                new("weapon_mp9")},
                {"P90",                                new("weapon_p90")},
                {"MP7",                                new("weapon_mp7")},
                {"MAC-10",                             new("weapon_mac10")},
                {"sg556",                              new("weapon_sg556")},
                {"G3SG1",                              new("weapon_g3sg1")},
                {"SCAR-20",                            new("weapon_scar20" )},
                {"XM1014",                             new("weapon_xm1014")},
                {"MAG-7",                              new("weapon_mag7")},
                {"Sawed-Off",                          new("weapon_sawedoff")},
                {"Nova",                               new("weapon_nova")},
            };

            var weaponCheckers = new Dictionary<string, Weapon>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"weapon_ak47",                        new("weapon_ak47")},
                {"weapon_awp",                         new("weapon_awp")},
                {"weapon_deagle",                      new("weapon_deagle")},
                {"weapon_m4a1",                        new("weapon_m4a1")},
                {"weapon_m4a1_silencer",               new("weapon_m4a1_silencer")},
                {"weapon_sg553",                       new("weapon_sg553")},
                {"weapon_aug",                         new("weapon_aug")},
                {"weapon_ssg08",                       new("weapon_ssg08")},
                {"weapon_negev",                       new("weapon_negev")},
                {"weapon_bizon",                       new("weapon_bizon")},
                {"weapon_m249",                        new("weapon_m249")},
                {"weapon_famas",                       new("weapon_famas")},
                {"weapon_galilar",                     new("weapon_galilar")},
                {"weapon_mp5sd",                       new("weapon_mp5sd")},
                {"weapon_ump45",                       new("weapon_ump45")},
                {"weapon_mp9",                         new("weapon_mp9")},
                {"weapon_p90",                         new("weapon_p90")},
                {"weapon_mp7",                         new("weapon_mp7")},
                {"weapon_mac10",                       new("weapon_mac10")},
                {"weapon_sg556",                       new("weapon_sg556")},
                {"weapon_g3sg1",                       new("weapon_g3sg1")},
                {"weapon_scar20",                      new("weapon_scar20" )},
                {"weapon_xm1014",                      new("weapon_xm1014")},
                {"weapon_mag7",                        new("weapon_mag7")},
                {"weapon_sawedoff",                    new("weapon_sawedoff")},
                {"weapon_nova",                        new("weapon_nova")},
            };
            return (weapons, weaponCheckers);
        }
    }

    private static class MenuHelper
    {
        private static Dictionary<string, Weapon> _weapons;
        private static Dictionary<string, Weapon> _weaponCheckers;

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
                _playerWeapon[player] = selectedWeapon;
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
}