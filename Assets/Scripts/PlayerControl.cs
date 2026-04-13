using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotationSpeed = 30f, moveSpeed = -10f;
private Rigidbody rb;
    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVector = move.ReadValue<Vector2>();
        float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180f);
        float speedMultiplier = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
        rb.AddForce(transform.forward * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
        transform.Rotate(0,moveVector.x * rotationSpeed * Time.fixedDeltaTime,0);
        //Debug.Log("move x: " + moveVector.x + ", y: " + moveVector.y);
    
        
        Debug.Log("slopeAngle" + slopeAngle);
        
        
    }
}
