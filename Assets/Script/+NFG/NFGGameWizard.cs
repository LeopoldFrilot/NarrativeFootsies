using Footsies;
using UnityEngine.SceneManagement;

public class NFGGameWizard : Singleton<NFGGameWizard>
{
    public NFGCampaignRunner campaignRunner;

    public void LoadCampaign()
    {
        campaignRunner.StartCampaign();
    }
}