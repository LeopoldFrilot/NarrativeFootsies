using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Gauntlet", menuName = "NFG/SceneContainers/Gauntlet")]
[Serializable]
public class NFGGauntletSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGGauntlet();
    }
}

[Serializable]
public class NFGGauntlet : NFGScene
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