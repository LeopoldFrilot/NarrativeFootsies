using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneUI : MonoBehaviour
{
    [SerializeField] private Image speakerImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Animator animator;
    [SerializeField] private List<Image> tintables;
    [SerializeField] private List<TextMeshProUGUI> fontTintables;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float secondsToFadeIn = 1.0f;
    [SerializeField] private float secondsToFadeOut = .3f;
    
    private static readonly int ArrowBounce = Animator.StringToHash("arrow_bounce");
    
    private Coroutine fadeIn;
    private Coroutine fadeOut;
    private Coroutine cutsceneDelay;
    private bool visible;

    public Action OnReadyToContinue;

    private void TriggerReadyToContinue()
    {
        OnReadyToContinue?.Invoke();
    }

    public void UpdateUI(CutsceneLine line)
    {
        if (fadeIn != null)
        {
            StopCoroutine(fadeIn);
            InitLine(line);
            return;
        }

        if (!visible)
        {
            fadeIn = StartCoroutine(FadeIn(line));
            return;
        }

        if (fadeOut == null)
        {
            fadeOut = StartCoroutine(FadeOut());
        }
    }

    private void InitLine(CutsceneLine line)
    {
        canvasGroup.alpha = 1;
        animator.SetBool(ArrowBounce, true);
        speakerImage.sprite = line.speaker.speakerIcon;
        dialogueText.text = line.line;
        speakerName.text = line.speaker.speakerName;
        foreach (var tintable in tintables)
        {
            tintable.color = line.speaker.speakerThemeColor;
        }

        foreach (var tintable in fontTintables)
        {
            tintable.color = line.speaker.fontThemeColor;
        }
    }
    
    private IEnumerator FadeIn(CutsceneLine line)
    {
        visible = false;
        InitLine(line);
        canvasGroup.alpha = 0;
        float time = 0;
        while (canvasGroup.alpha < 1)
        {
            yield return null;
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / secondsToFadeIn);
            time += Time.deltaTime;
        }
        
        visible = true;
        fadeIn = null;
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
        visible = false;
        TriggerReadyToContinue();
    }

    public bool IsReadyToContinue()
    {
        return !visible;
    }
}