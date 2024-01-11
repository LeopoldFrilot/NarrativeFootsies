using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceScene", menuName = "NFG/Scenes/ChoiceScene")]
[Serializable]
public class NFGChoiceSceneSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGChoiceScene();
    }
}

[Serializable]
public class NFGChoiceScene : NFGScene
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