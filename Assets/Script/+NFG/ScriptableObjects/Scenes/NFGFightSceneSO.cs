using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FightScene", menuName = "NFG/Scenes/FightScene")]
[Serializable]
public class NFGFightSceneSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGFightScene();
    }
}

[Serializable]
public class NFGFightScene : NFGScene
{
    
}