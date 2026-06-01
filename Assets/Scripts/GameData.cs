using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
   public List<float> bestTimes = new List<float>();

   private static GameData instance;

   [SerializeField] private string leaderboardKey = "leaderboard";
   [SerializeField] private string bestTimeKey = "bestTimeLVL1";
   [SerializeField] private int maxLeaderboardEntries = 5;

   private void Awake()
   {
      if (instance != null && instance != this)
      {
         Destroy(gameObject);
         return;
      }

      instance = this;
      DontDestroyOnLoad(gameObject);

      LoadLeaderboard();
   }

   private void LoadLeaderboard()
   {
      bestTimes.Clear();

      for (int i = 0; i < maxLeaderboardEntries; i++)
      {
         string key = leaderboardKey + i;

         if (PlayerPrefs.HasKey(key))
         {
            float time = PlayerPrefs.GetFloat(key);
            bestTimes.Add(time);
         }
      }

      bestTimes.Sort();
   }

   private void SaveLeaderboard()
   {
      bestTimes.Sort();

      while (bestTimes.Count > maxLeaderboardEntries)
      {
         bestTimes.RemoveAt(bestTimes.Count - 1);
      }

      for (int i = 0; i < maxLeaderboardEntries; i++)
      {
         PlayerPrefs.DeleteKey(leaderboardKey + i);
      }

      for (int i = 0; i < bestTimes.Count; i++)
      {
         PlayerPrefs.SetFloat(leaderboardKey + i, bestTimes[i]);
      }

      PlayerPrefs.Save();
   }

   public void AddLevelTime(float time)
   {
      bestTimes.Add(time);
      bestTimes.Sort();

      while (bestTimes.Count > maxLeaderboardEntries)
      {
         bestTimes.RemoveAt(bestTimes.Count - 1);
      }

      SaveLeaderboard();
   }

   [ContextMenu("Reset Leaderboard And Best Time")]
   public void ResetLeaderboardAndBestTime()
   {
      bestTimes.Clear();

      for (int i = 0; i < maxLeaderboardEntries; i++)
      {
         PlayerPrefs.DeleteKey(leaderboardKey + i);
      }

      PlayerPrefs.DeleteKey(bestTimeKey);
      PlayerPrefs.Save();

      Debug.Log("Leaderboard and best time were reset.");
   }

   public static GameData Instance
   {
      get { return instance; }
   }
}