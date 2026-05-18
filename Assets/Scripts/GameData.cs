using System;
using UnityEngine;

public class GameData : MonoBehaviour
{ 
   private static GameData instance;

   private void Awake()
   {
      instance = this;
   }
}
