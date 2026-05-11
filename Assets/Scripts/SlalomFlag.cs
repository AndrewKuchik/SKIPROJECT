using UnityEngine;
using UnityEngine.PlayerLoop;

public class SlalomFlag : MonoBehaviour
{
    private enum Direction {Left, Right}

    [SerializeField] private Direction flagDirection;
    private bool flagPassed = false;
    [SerializeField] private Material goodMat, badMat;
    public static GameManager.TimerEvent RacePenalty;
    
    void Update()
    {
        if (PlayerControl.playerPos != null && 
            PlayerControl.playerPos.position.z < transform.position.z && 
            !flagPassed)
        {
            flagPassed = true;
            Direction passingDirection = Direction.Right;
            if (PlayerControl.playerPos.position.x < transform.position.x)
                passingDirection = Direction.Left;
            MeshRenderer rendered = GetComponent<MeshRenderer>();
            if (passingDirection == flagDirection)
            {
                rendered.material = goodMat;
            }

            else
            {
                rendered.material = badMat;
                RacePenalty.Invoke();
            }
                
            flagPassed = true;
            Debug.Log("flag passed");
        }
    }
}
