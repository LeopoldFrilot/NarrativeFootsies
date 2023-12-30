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
    
}