using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryGoalHolder", menuName = "NFG/Narrative/StoryGoalHolder")]
public class NFGStoryGoalHolderSO : ScriptableObject
{
    public List<NFGStoryGoalSO> storyGoals = new();

    public NFGStoryGoalSO GetStoryGoal(StoryGoalID ID)
    {
        foreach (var storyGoal in storyGoals)
        {
            if (storyGoal.storyGoalID == ID)
            {
                return storyGoal;
            }
        }

        return null;
    }
}