using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NFGCampaignRunner : MonoBehaviour
{
    [SerializeField] private int campaignStartIndex = 3;
    [SerializeField] private NFGCampaignStructureSO campaignStructure;
    [SerializeField] private List<NFGDialogueSO> allLines;

    private string currentSceneID = "Campaign";
    private NFGScene currentScene = null;
    private NFGScene campaign = null;
    private NFGYear currentYear = null;
    private NFGSeason currentSeason = null;
    private NFGGauntlet currentGauntlet = null;
    private NFGTournament currentTournament = null;
    private NFGScene nullScene = null;
    private int dialogueIndex = 0;

    public IEnumerator StartCampaign()
    {
        SceneManager.LoadScene(campaignStartIndex);
        yield return Help.GetWait(.5f);
        campaign = campaignStructure.CreateScene();
        if (campaign != null)
        {
            campaign.Initialize(campaignStructure, currentSceneID, ref nullScene); 
        }

        ChangeScenes(ref campaign);
    }

    private void Update()
    {
        if (currentScene == null)
        {
            return;
        }
        
        currentScene.Tick();
    }

    private void ChangeScenes(ref NFGScene newScene)
    {
        if (currentScene != null)
        {
            currentScene.OnSceneEnd -= OnSceneEnd;
        }

        if (newScene is NFGYear year)
        {
            currentYear = year;
        }
        else if (newScene is NFGSeason season)
        {
            currentSeason = season;
        }
        else if (newScene is NFGGauntlet gauntlet)
        {
            currentGauntlet = gauntlet;
        }
        else if (newScene is NFGTournament tournament)
        {
            currentTournament = tournament;
        }

        currentScene = newScene;
        currentScene.OnSceneEnd += OnSceneEnd;
    }

    private void OnSceneEnd()
    {
        if (currentScene.childScenes.Count < currentScene.dataRef.sceneStructure.Count)
        {
            NFGSceneSO nextSceneData = currentScene.dataRef.sceneStructure[currentScene.childScenes.Count];
            NFGScene nextScene = nextSceneData.CreateScene();
            currentSceneID += $".{currentScene.childScenes.Count}";
            nextScene.Initialize(nextSceneData, currentSceneID, ref currentScene);
            currentScene.childScenes.Add(nextScene);
            ChangeScenes(ref nextScene);
            return;
        }

        if (currentScene.parentScene != null)
        {
            currentSceneID = currentScene.parentScene.heirarchyID;
            ChangeScenes(ref currentScene.parentScene);
            OnSceneEnd();
            return;
        }

        currentScene = null;
    }

    public NFGDialogueSO PickNextScene()
    {
        if (dialogueIndex >= allLines.Count)
        {
            return null;
        }

        NFGDialogueSO line = allLines[dialogueIndex];
        dialogueIndex++;
        return line;
    }
}
