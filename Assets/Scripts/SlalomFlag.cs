using UnityEngine;

public class SlalomFlag : MonoBehaviour
{
    private enum Direction { Left, Right }

    [SerializeField] private Direction flagDirection;
    [SerializeField] private bool flagPassed = false;
    [SerializeField] private Material goodMat, badMat;

    public static GameManager.TimerEvent RacePenalty;
    public static GameManager.TimerEvent CorrectFlagPassed;
    
    void Update()
    {
        if (PlayerControl.playerPos != null && 
            PlayerControl.playerPos.position.z < transform.position.z && 
            !flagPassed)
        {
            flagPassed = true;

            Direction passingDirection = Direction.Right;

            if (PlayerControl.playerPos.position.x < transform.position.x)
            {
                passingDirection = Direction.Left;
            }

            MeshRenderer renderer = GetComponent<MeshRenderer>();

            if (passingDirection == flagDirection)
            {
                renderer.material = goodMat;
                CorrectFlagPassed?.Invoke();
            }
            else
            {
                renderer.material = badMat;
                RacePenalty?.Invoke();
            }

            Debug.Log("flag passed");
        }
    }
}