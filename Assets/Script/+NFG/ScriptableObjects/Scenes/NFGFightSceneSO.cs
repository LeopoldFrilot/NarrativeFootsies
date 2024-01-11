using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public override void Initialize(NFGSceneSO data, string hID, ref NFGScene parentScene)
    {
        base.Initialize(data, hID, ref parentScene);
        StartFight();
    }

    private void StartFight()
    {
        NFGEventHub.OnFightFinished += OnFightFinished;
        SceneManager.LoadScene(NFGHelp.GW.fightSceneIndex, LoadSceneMode.Additive);
    }

    public override void Tick()
    {
        base.Tick();
    }

    private void OnFightFinished()
    {
        SceneManager.UnloadSceneAsync(NFGHelp.GW.fightSceneIndex);
        NFGEventHub.OnFightFinished -= OnFightFinished;
        OnSceneEnd?.Invoke();
    }
}