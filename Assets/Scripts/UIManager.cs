using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup overlay;

    [SerializeField] private float fadeSpeed = 0.5f;

    [SerializeField] private GameObject gameOverMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverMenu.SetActive(false);
        overlay.gameObject.SetActive(true);
        StartCoroutine(FadeOutOverlay());
        
    }

    private void OnEnable()
    {
        FinishGate.FinishRace += FinishRaceUI;
    }

    private void FinishRaceUI()
    {
        gameOverMenu.SetActive(true);
    }
    private IEnumerator FadeInOverlay()
    {
        while (overlay.alpha < 1.0f)
        {
            overlay.alpha += Time.deltaTime * fadeSpeed;
                yield return null;
        }
    }
    private IEnumerator FadeOutOverlay()
    {
        while (overlay.alpha > 0.0f)
        {
            overlay.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    public void Retry()
    {
        
    }

    private IEnumerator RetryCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
    }

    public void Quit()
    {
        
    }

    public void NextLevel()
    {
        
    }
    void Update()
    {
        
    }
}
