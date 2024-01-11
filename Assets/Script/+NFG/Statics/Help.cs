using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public static class Help
{
    public static float MinutesToSeconds(float minutes)
    {
        return minutes * 60f;
    }

    public static float SecondsToMinutes(float seconds)
    {
        return seconds / 60f;
    }

    public static float SecondsToHours(float seconds)
    {
        return SecondsToMinutes(seconds) / 60f;
    }

    public static float GetDifferenceBetweenTimesInSeconds(DateTime a, DateTime b)
    {
        TimeSpan result = a.Subtract(b);
        return (float)result.TotalSeconds;
    }

    public static float GetDifferenceBetweenTimesInMinutes(DateTime a, DateTime b)
    {
        return SecondsToMinutes(GetDifferenceBetweenTimesInSeconds(a, b));
    }

    private static Camera _camera;

    public static Camera MainCamera
    {
        get
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }

            return _camera;
        }
    }

    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new();

    public static WaitForSeconds GetWait(float time)
    {
        if (WaitDictionary.TryGetValue(time, out var wait))
        {
            return wait;
        }

        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    }

    // Used to get world object to follow UI object position
    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, MainCamera, out var result);
        return result;
    }

    public static Vector2 GetScreenpointOfWorldObject(Transform transform)
    {
        return RectTransformUtility.WorldToScreenPoint(MainCamera, transform.position);
    }

    public static Vector2 GetScreenCenter()
    {
        return new Vector2(Screen.width * .5f, Screen.height * .5f);
    }

    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t)
        {
            Object.Destroy(child.gameObject);
        }
    }

    public static int GetGameplaySceneNumber()
    {
        return 8;
    }

    public static T RandomElementInArray<T>(List<T> array)
    {
        return array[Random.Range(0, array.Count - 1)];
    }
}