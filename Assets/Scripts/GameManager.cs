using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private TimeSpan bestTime;
    private bool racing = false;
    [SerializeField] private TMP_Text timerText, bestTimeText;
    public delegate void TimerEvent();



    [SerializeField]private string bestTimeKey = "bestTimeLVL1";
    
    
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
        int bestTimeInt = PlayerPrefs.GetInt(bestTimeKey, int.MaxValue);
        bestTime = new TimeSpan(bestTimeInt);
        bestTimeText.text = "BEST TIME" + bestTime.ToString("mm\\:ss");
    }
    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, 3);
    }
    void FinishRace()
    {
        racing = false;
        GameData.Instance.AddLevelTime((float)raceTime.TotalMilliseconds/1000f);
        if (raceTime < bestTime)
        {
            bestTimeText.text = "BEST TIME" + raceTime.ToString("mm\\:ss");
            PlayerPrefs.SetInt(bestTimeKey,(int)raceTime.Ticks);
            PlayerPrefs.Save();
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StartRace()
    {
        racing = true;
        raceStart = DateTime.Now;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (racing)
            raceTime = DateTime.Now - raceStart + penaltyTime;
        timerText.text = "TIME " + raceTime.ToString("mm\\:ss");
        

    }
}
