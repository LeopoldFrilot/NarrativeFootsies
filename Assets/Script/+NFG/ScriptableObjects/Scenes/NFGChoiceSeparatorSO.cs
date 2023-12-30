
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
    
}