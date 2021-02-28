using UnityEngine;

namespace Config
{
    [System.Serializable]
    public class PlayerConfig
    {
        public KeyCode abilityKey = KeyCode.Space;
    }
    
    [CreateAssetMenu(menuName = "GameConfig",fileName = "NewConfig")]
    public class GameConfig : ScriptableObject
    {
        public PlayerConfig playerConfig;
    }
}
