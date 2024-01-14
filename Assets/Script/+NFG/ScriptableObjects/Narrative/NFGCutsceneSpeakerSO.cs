using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCutsceneSpeaker", menuName = "NFG/Narrative/NewCutsceneSpeaker")]
public class NFGCutsceneSpeakerSO : ScriptableObject
{
    public string speakerName;
    public Color speakerThemeColor;
    public Color fontThemeColor;
    public Sprite speakerIcon;
}