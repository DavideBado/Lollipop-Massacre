using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public interface ICharacter
    {
        List<Sprite> Sprites { set; }
        void Attack();
        void Ability();
        void Preview();
    }
}
