using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Season", menuName = "NFG/SceneContainers/Season")]
[Serializable]
public class NFGSeasonSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGSeason();
    }
}

[Serializable]
public class NFGSeason : NFGScene
{
    
}