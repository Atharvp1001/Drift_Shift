using UnityEngine;

public class CarMovement : MonoBehaviour
{

    private Vector3 MoveForce;

    [Header("Movement")]
    [SerializeField]private float MoveSpeed = 110f;
    [SerializeField]private float SteerAngle = 10f;

    [Header("Drag")]
    [SerializeField]private float Drag = 0.99f;
    [SerializeField]private float MaxSpeed = 100f;

    [Header("Traction")]
    [SerializeField]private float Traction = 2;

    // Update is called once per frame
    void Update()
    {   
        //Moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Steering
        float SteerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * SteerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        //Drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed); //Add a limiter to speed

        //Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
