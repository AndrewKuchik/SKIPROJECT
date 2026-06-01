using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup overlay;
    [SerializeField] private float fadeSpeed = 0.5f;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private int nextLevelIndex;

    [SerializeField] private TMP_Text leaderboardText;
    
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

    private void OnDisable()
    {
        FinishGate.FinishRace -= FinishRaceUI;
    }

    private void FinishRaceUI()
    {
        gameOverMenu.SetActive(true);
        ShowLeaderboard();
    }

    private void ShowLeaderboard()
    {
        leaderboardText.text = "LEADERBOARD\n";

        if (GameData.Instance == null)
        {
            leaderboardText.text += "No data found";
            return;
        }

        int shownResults = 0;

        for (int i = 0; i < GameData.Instance.bestTimes.Count && shownResults < 5; i++)
        {
            float time = GameData.Instance.bestTimes[i];

            if (time >= 999.99f)
                continue;

            shownResults++;

            leaderboardText.text += shownResults + ". " + FormatTime(time) + "\n";
        }

        if (shownResults == 0)
        {
            leaderboardText.text += "No results yet";
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
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
        StartCoroutine(RetryCoroutine());
    }

    private IEnumerator RetryCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        Application.Quit();
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(nextLevelIndex);
    }
}