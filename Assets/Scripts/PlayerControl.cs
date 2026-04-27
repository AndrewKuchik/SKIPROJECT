using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotationSpeed = 30f, moveSpeed = -10f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayers;
private Rigidbody rb;
    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
        
    }

    //private void OnDrawGizmos()
   // {
    //    Gizmos.color = Color.red;
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded= Physics.Linecast(transform.position, 
            transform.position - transform.up*2, groundLayers);
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position,transform.position - transform.up);
        if(isGrounded)
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
}
