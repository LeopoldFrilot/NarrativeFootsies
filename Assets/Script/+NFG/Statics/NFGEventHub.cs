using System;
using UnityEngine;

public static class NFGEventHub
{
    public static event Action OnFightFinished;

    public static void TriggerFightFinished()
    {
        OnFightFinished?.Invoke();
    }
}