using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/Dialogues", order = 1)]
public class DialogScriptableObject : ScriptableObject
{
    public List<string> phrases = new List<string>();
}
