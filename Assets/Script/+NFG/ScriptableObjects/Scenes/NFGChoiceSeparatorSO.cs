
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceSeparator", menuName = "NFG/Scenes/ChoiceSeparator")]
[Serializable]
public class NFGChoiceSeparatorSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGChoiceSeparator();
    }
}

[Serializable]
public class NFGChoiceSeparator : NFGScene
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