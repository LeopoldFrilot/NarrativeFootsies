using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePopup : MonoBehaviour
{
    [Header("Cutscene")] [SerializeField] private float secondsToFadeIn = 2;
    [SerializeField] private float secondsToFadeOut = 2;
    [SerializeField] private CutsceneUI UI;

    private CanvasGroup canvasGroup;
    private Coroutine fadeIn;
    private Coroutine fadeOut;
    private Coroutine cutsceneDelay;
    private int sceneIndex = -1;
    private NFGDialogueSO dialogue;

    public void Initialize(NFGDialogueSO dialogue)
    {
        this.dialogue = dialogue;
        sceneIndex = -1;
        canvasGroup = GetComponent<CanvasGroup>();
        UI.OnReadyToContinue += OnReadyToContinue;
    }

    private void OnReadyToContinue()
    {
        ContinueCutscene();
    }

    public void TriggerShowAnimation()
    {
        fadeIn = StartCoroutine(FadeIn());
    }

    public void ContinueCutscene()
    {
        if (cutsceneDelay != null)
        {
            return;
        }

        if (!UI.IsReadyToContinue())
        {
            UI.UpdateUI(dialogue.lines[sceneIndex]);
            return;
        }

        sceneIndex++;

        if (sceneIndex >= dialogue.lines.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        cutsceneDelay = StartCoroutine(DelayNextCutscene(dialogue.lines[sceneIndex].delayInSec));
    }

    private IEnumerator DelayNextCutscene(float amount)
    {
        yield return Help.GetWait(amount);
        cutsceneDelay = null;
        UI.UpdateUI(dialogue.lines[sceneIndex]);
        TriggerShowAnimation();
    }

    public void TriggerHideAnimation()
    {
        fadeOut = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;
        float time = 0;
        while (canvasGroup.alpha < 1)
        {
            yield return null;
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / secondsToFadeIn);
            time += Time.deltaTime;
        }

        fadeIn = null;
        ContinueCutscene();
    }

    private IEnumerator FadeOut()
    {
        canvasGroup.alpha = 1;
        float time = 0;
        while (canvasGroup.alpha > 0)
        {
            yield return null;
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / secondsToFadeOut);
            time += Time.deltaTime;
        }

        fadeOut = null;
        TriggerHideAnimation();
    }
}