using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class NFGSceneSO : ScriptableObject
{
    public List<NFGSceneSO> sceneStructure = new();
    
    [Header("If repeating structure, use this instead")]
    public int maxRepeatingTimes = 0;
    public List<NFGSceneSO> scenesBeforeRepeatingStructure = new();
    public List<NFGSceneSO> repeatingStructure = new();
    public List<NFGSceneSO> scenesAfterRepeatingStructure = new();

    public virtual NFGScene CreateScene()
    {
        throw new NotImplementedException();
    }

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
[Serializable]
public class NFGCampaignStructureSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        var campaign = new NFGCampaign();
        campaign.Initialize(this, "Campaign", null);
        return campaign;
    }
}

[Serializable]
public abstract class NFGScene
{
    public NFGSceneSO dataRef = null;
    public string heirarchyID = "";
    public List<NFGScene> childScenes = new();
    public NFGScene parentScene = null;

    public virtual void Initialize(NFGSceneSO data, string hID, NFGScene parentScene)
    {
        dataRef = data;
        heirarchyID = hID;
        this.parentScene = parentScene;
        
        childScenes.Clear();
        for (int i = 0; i < data.sceneStructure.Count; i++)
        {
            var newScene = data.sceneStructure[i].CreateScene();
            newScene.Initialize(data.sceneStructure[i], $"{heirarchyID}.{i}", this);
            childScenes.Add(newScene);
        }
    }
}

[Serializable]
public class NFGCampaign : NFGScene
{
    
}