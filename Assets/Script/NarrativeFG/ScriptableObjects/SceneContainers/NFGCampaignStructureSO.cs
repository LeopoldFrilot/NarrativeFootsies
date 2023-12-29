using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class NFGScene : ScriptableObject
{
    public List<NFGScene> sceneStructure = new();
    
    [Header("If repeating structure, use this instead")]
    public int maxRepeatingTimes = 0;
    public List<NFGScene> scenesBeforeRepeatingStructure = new();
    public List<NFGScene> repeatingStructure = new();
    public List<NFGScene> scenesAfterRepeatingStructure = new();

    private void OnValidate()
    {
        if (maxRepeatingTimes > 0)
        {
            sceneStructure.Clear();
            sceneStructure = NFGHelp.AppendArray(sceneStructure, scenesBeforeRepeatingStructure);
        
            for (int i = 0; i < maxRepeatingTimes; i++)
            {
                sceneStructure = NFGHelp.AppendArray(sceneStructure, repeatingStructure);
            }
        
            sceneStructure = NFGHelp.AppendArray(sceneStructure, scenesAfterRepeatingStructure);
        }
    }
}

[CreateAssetMenu]
public class NFGCampaignStructureSO : NFGScene
{
    
}