using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{

    public float moveSpeed = 7f;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        //used to get the players input on the X, Y and Z axis
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.move(moveVelocity);

        //Here we are getting the raycast of the mouse pointer from the main camera
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDis;

        if (groundPlane.Raycast(ray, out rayDis))
        {
            Vector3 point = ray.GetPoint(rayDis);
            Debug.DrawLine(ray.origin, point, Color.blue);
            controller.LookAt(point);
        }
        //Shooting a bullet wherever the player is looking
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
