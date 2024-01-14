using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct CutsceneLine
{
    public NFGCutsceneSpeakerSO speaker;
    [Multiline] public string line;
    public float delayInSec;
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NFG/Narrative/NewDialogue")]
public class NFGDialogueSO : ScriptableObject
{
    public List<CutsceneLine> lines = new();
}