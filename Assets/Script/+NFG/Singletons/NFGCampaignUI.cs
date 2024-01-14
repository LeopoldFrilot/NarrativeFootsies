using System.Collections.Generic;
using Footsies;
using TMPro;
using UnityEngine.UI;

public class NFGCampaignUI : Singleton<NFGCampaignUI>
{
    public TextMeshProUGUI mainText;
    public List<Button> buttons = new();

    public void Initialize(string mainText)
    {
        this.mainText.text = mainText;
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
}