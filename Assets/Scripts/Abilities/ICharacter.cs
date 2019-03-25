using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICharacter
{
  int Type { get; }
  Sprite Sprite { get; }
  List<Material> Materials { get; }
}
