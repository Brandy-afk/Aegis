using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialAnimation : MonoBehaviour
{
  [SerializeField] List<GameObject> tutorialPanels;
  [SerializeField] CanvasGroup canvasGroup;
  [SerializeField] EnemySpawner enemySpawner;
  [SerializeField] float fadeInDuration = 1f;
  [SerializeField] float displayDuration = 2f;
  [SerializeField] float fadeOutDuration = 1f;

  private void Start()
  {
    StartCoroutine(ShowTutorialPanels());
  }

  IEnumerator ShowTutorialPanels()
  {
    foreach (GameObject panel in tutorialPanels)
    {
      panel.SetActive(true);


      float fadeInStartTime = Time.time;
      while (Time.time - fadeInStartTime <= fadeInDuration)
      {
        float alpha = Mathf.Lerp(0, 1, (Time.time - fadeInStartTime) / fadeInDuration);
        canvasGroup.alpha = alpha;
        yield return null;
      }
      canvasGroup.alpha = 1;


      yield return new WaitForSeconds(displayDuration);


      float fadeOutStartTime = Time.time;
      while (Time.time - fadeOutStartTime <= fadeOutDuration)
      {
        float alpha = Mathf.Lerp(1, 0, (Time.time - fadeOutStartTime) / fadeOutDuration);
        canvasGroup.alpha = alpha;
        yield return null;
      }
      canvasGroup.alpha = 0;

      panel.SetActive(false);
    }

    enemySpawner.StartSpawning();
  }
}