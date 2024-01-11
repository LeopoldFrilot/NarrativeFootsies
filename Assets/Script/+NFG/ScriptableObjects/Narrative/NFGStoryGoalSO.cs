using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum StoryGoalID
{
    Count
}

[Serializable]
public struct SGPrerequisite
{
    public bool not;
    public StoryGoalID ID;

    public SGPrerequisite(StoryGoalID ID, bool not)
    {
        this.ID = ID;
        this.not = not;
    }
}

[CreateAssetMenu(fileName = "NewStoryGoal", menuName = "NFG/Narrative/NewStoryGoal")]
public class NFGStoryGoalSO : ScriptableObject
{
    public StoryGoalID storyGoalID;
    public string goalName = "PLACEHOLDER GOAL NAME";
    public string goalDescription = "PLACEHOLDER GOAL DESCRIPTION";
    public List<SGPrerequisite> prerequisites = new();
}