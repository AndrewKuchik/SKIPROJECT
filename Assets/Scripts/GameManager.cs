using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float raceStartTime;
    private float raceTime = 0f;
    private float penaltyTime = 0f;
    private float bestTime = float.MaxValue;

    private bool racing = false;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text bestTimeText;

    [SerializeField] private string bestTimeKey = "bestTimeLVL1_final";

    [Header("Performance")]
    [SerializeField] private float uiUpdateInterval = 0.1f;

    private float nextUiUpdateTime = 0f;

    public delegate void TimerEvent();

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void OnEnable()
    {
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
        SlalomFlag.RacePenalty += AddRacePenalty;
    }

    private void OnDisable()
    {
        StartGate.StartRace -= StartRace;
        FinishGate.FinishRace -= FinishRace;
        SlalomFlag.RacePenalty -= AddRacePenalty;
    }

    private void Start()
    {
        raceTime = 0f;
        penaltyTime = 0f;

        timerText.text = "TIME " + FormatTime(raceTime);

        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            bestTime = PlayerPrefs.GetFloat(bestTimeKey);
            bestTimeText.text = "BEST TIME " + FormatTime(bestTime);
        }
        else
        {
            bestTime = float.MaxValue;
            bestTimeText.text = "BEST TIME --:--.-";
        }
    }

    private void StartRace()
    {
        racing = true;
        raceStartTime = Time.time;
        raceTime = 0f;
        penaltyTime = 0f;
        nextUiUpdateTime = 0f;
    }

    private void AddRacePenalty()
    {
        if (racing)
        {
            penaltyTime += 3f;
        }
    }

    private void FinishRace()
    {
        if (!racing)
            return;

        racing = false;

        if (GameData.Instance != null)
        {
            GameData.Instance.AddLevelTime(raceTime);
        }

        if (raceTime < bestTime)
        {
            bestTime = raceTime;
            bestTimeText.text = "BEST TIME " + FormatTime(bestTime);

            PlayerPrefs.SetFloat(bestTimeKey, bestTime);
            PlayerPrefs.Save();
        }

        timerText.text = "TIME " + FormatTime(raceTime);
    }

    private void Update()
    {
        if (racing)
        {
            raceTime = Time.time - raceStartTime + penaltyTime;
        }

        if (Time.time >= nextUiUpdateTime)
        {
            timerText.text = "TIME " + FormatTime(raceTime);
            nextUiUpdateTime = Time.time + uiUpdateInterval;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int tenths = Mathf.FloorToInt((time * 10f) % 10f);

        return $"{minutes:00}:{seconds:00}.{tenths}";
    }
}