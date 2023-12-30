using System;
using UnityEngine;

[Serializable]
public abstract class NFGDialogueSceneSO : NFGSceneSO
{
}

[CreateAssetMenu(fileName = "StaticDialogueScene", menuName = "NFG/Scenes/StaticDialogueScene")]
[Serializable]
public class NFGStaticDialogueSceneSO : NFGDialogueSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGStaticDialogueScene();
    }
}

[Serializable]
public class NFGStaticDialogueScene : NFGScene
{
    
}