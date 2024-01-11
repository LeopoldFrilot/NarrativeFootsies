using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NFGCampaignRunner : MonoBehaviour
{
    [SerializeField] private int campaignStartIndex = 3;
    [SerializeField] private NFGCampaignStructureSO campaignStructure;

    private string currentSceneID = "Campaign";
    private NFGScene currentScene = null;
    private NFGScene campaign = null;
    private NFGScene nullScene = null;

    public void StartCampaign()
    {
        SceneManager.LoadScene(campaignStartIndex);
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
}
