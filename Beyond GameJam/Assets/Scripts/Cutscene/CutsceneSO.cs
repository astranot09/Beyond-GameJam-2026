using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneSO", menuName = "Scriptable Objects/CutsceneSO")]
public class CutsceneSO : ScriptableObject
{
    public List<Sprite> cutsceneSprite = new List<Sprite>();
}
