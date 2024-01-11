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