using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CanvasGroup transitionCanvasGroup;
    [SerializeField] private float transitionDuration = 0.5f;
    public static void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SwitchWithTransition(int sceneIndex)
    {
        StartCoroutine(TransitionLerp(sceneIndex));
    }

    private IEnumerator TransitionLerp(int sceneIndex)
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < transitionDuration)
        {
            transitionCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transitionCanvasGroup.alpha = 1f;
        SwitchScene(sceneIndex);
    }
}
