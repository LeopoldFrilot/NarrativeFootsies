using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        return new NFGCampaign();
    }
}

[Serializable]
public abstract class NFGScene
{
    public NFGSceneSO dataRef = null;
    public string heirarchyID = "";
    public List<NFGScene> childScenes = new();
    public NFGScene parentScene = null;

    public Action OnSceneEnd;
    
    protected float internalClock = 0;
    protected float debugMaxTime = .5f;
    
    public void TriggerSceneEnd()
    {
        OnEndSceneInternal();
    }

    public virtual void Initialize(NFGSceneSO data, string hID, ref NFGScene parentScene)
    {
        dataRef = data;
        heirarchyID = hID;
        this.parentScene = parentScene;
        childScenes.Clear();
        internalClock = 0;
    }

    public virtual void Tick()
    {
        internalClock += Time.deltaTime;
    }

    protected virtual void OnEndSceneInternal()
    {
        OnSceneEnd?.Invoke();
    }
}

[Serializable]
public class NFGCampaign : NFGScene
{
    public override void Initialize(NFGSceneSO data, string hID, ref NFGScene parentScene)
    {
        base.Initialize(data, hID, ref parentScene);
        NFGCampaignUI.Instance.Initialize("Welcome to the campaign!\nPress Continue to begin your journey");
        NFGCampaignUI.Instance.buttons[0].gameObject.SetActive(true);
        NFGCampaignUI.Instance.buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
        NFGCampaignUI.Instance.buttons[0].onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        TriggerSceneEnd();
    }

    protected override void OnEndSceneInternal()
    {
        NFGCampaignUI.Instance.buttons[0].onClick.RemoveListener(OnClick);
        base.OnEndSceneInternal();
    }
}