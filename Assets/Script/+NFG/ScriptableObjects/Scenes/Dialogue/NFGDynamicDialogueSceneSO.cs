using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DynamicDialogueScene", menuName = "NFG/Scenes/DynamicDialogueScene")]
[Serializable]
public class NFGDynamicDialogueSceneSO : NFGDialogueSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGDynamicDialogueScene();
    }
}

[Serializable]
public class NFGDynamicDialogueScene : NFGScene
{
    public override void Tick()
    {
        base.Tick();
        Debug.Log(heirarchyID);
        if (internalClock >= debugMaxTime)
        {
            OnSceneEnd?.Invoke();
        }
    }
}