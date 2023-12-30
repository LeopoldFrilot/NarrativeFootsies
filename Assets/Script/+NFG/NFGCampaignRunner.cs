using UnityEngine;
using UnityEngine.SceneManagement;


public class NFGCampaignRunner : MonoBehaviour
{
    [SerializeField] private int campaignStartIndex;
    [SerializeField] private NFGCampaignStructureSO campaignStructure;

    [SerializeField][ReadOnly] private NFGCampaign campaign;

    public void StartCampaign()
    {
        SceneManager.LoadScene(campaignStartIndex);
        campaign = campaignStructure.CreateScene() as NFGCampaign;
    }
}
