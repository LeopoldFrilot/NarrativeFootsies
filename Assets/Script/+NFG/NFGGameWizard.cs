using Footsies;
using UnityEngine.SceneManagement;

public class NFGGameWizard : Singleton<NFGGameWizard>
{
    public int fightSceneIndex = 2;
    public NFGCampaignRunner campaignRunner;

    public void LoadCampaign()
    {
        campaignRunner.StartCampaign();
    }
}