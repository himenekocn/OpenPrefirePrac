using CounterStrikeSharp.API.Core;

namespace OpenPrefirePrac;

public class PlayerStatus
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

    /**
     * -1 if player is not practicing
     */
    public int PracticeIndex = -1;
    
    public int Progress = 0;
    
    /**
     * 0: No healing
     * 1: Init hp 500 with no healing
     * 2: +25hp for each kill
     * 3: +100hp for each kill (default)
     * 4: +500hp for each kill
     */
    public int HealingMethod = 3;
    
    public readonly List<CCSPlayerController> Bots = new();
    public readonly Dictionary<string, int> LocalizedPracticeNames = new();
    public readonly Dictionary<string, int> LocalizedDifficultyNames = new();
    
    /**
     * 0: Random mode, randomly spawn some targets(the spawn ratio is specified in the practice profile)
     * 1: Full mode, all targets
     */
    public int TrainingMode = 0;
    
    public readonly Dictionary<string, int> LocalizedTrainingModeNames = new();
    public readonly List<int> EnabledTargets = new();
    public readonly List<int> Beams = new();

    public PlayerStatus(DefaultConfig defaultConfig)
    {
        HealingMethod = defaultConfig.Difficulty;
        TrainingMode = defaultConfig.TrainingMode;
    }

    public PlayerStatus()
    {
        // Default constructor
    }

    public Weapon PlayerWeapon = new();
}
