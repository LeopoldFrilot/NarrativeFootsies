using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tournament", menuName = "NFG/SceneContainers/Tournament")]
[Serializable]
public class NFGTournamentSO : NFGSceneSO
{
    public override NFGScene CreateScene()
    {
        return new NFGTournament();
    }
}

[Serializable]
public class NFGTournament : NFGScene
{
    
}