using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Vector3 velocity;
    Rigidbody myRigidBody;

	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody>();
	}
    public void move(Vector3 _velocity)
    {
        velocity = _velocity;                
    }

    void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 lookHight = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(lookHight);

    }
}
