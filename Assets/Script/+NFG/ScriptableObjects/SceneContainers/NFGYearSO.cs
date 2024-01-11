using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Year", menuName = "NFG/SceneContainers/Year")]
[Serializable]
public class NFGYearSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGYear();
    }
}

[Serializable]
public class NFGYear : NFGScene
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