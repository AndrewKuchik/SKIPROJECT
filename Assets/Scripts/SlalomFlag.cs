using UnityEngine;
using UnityEngine.PlayerLoop;

public class SlalomFlag : MonoBehaviour
{
    private enum Direction {Left, Right}

    [SerializeField] private Direction flagDirection;
    private bool flagPassed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.playerPos != null && PlayerControl.playerPos.position.z < transform.position.z && !flagPassed)
        {
            flagPassed = true;
            Debug.Log("flag passed");
        }
    }
}
