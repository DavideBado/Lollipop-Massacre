using UnityEngine;

namespace Character
{

    [CreateAssetMenu(fileName = "New Character", menuName = "Character", order = 1)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField]
        internal int CharacterID;
        [SerializeField]
        internal GameObject CharacterView;
        [SerializeField]
        internal int Life;

    }
}
