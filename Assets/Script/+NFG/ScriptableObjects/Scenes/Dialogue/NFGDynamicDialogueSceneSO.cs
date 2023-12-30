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
    
}