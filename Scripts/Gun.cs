using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    //Set in unity inspector originally named BulletSpawner 
    public Transform muzzle;
    //Set in unity inspector from the prefabs originally named Bullet
    public Bullets bullet;
    /// <summary>
    /// the lower two numbers are used to set the miliseconds between gun shots (msBetweenShots)
    /// and how fast the bullets will move (muzzleVelocity)
    /// </summary>
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;

    float nextShotTime;

    public void Shoot()
    { 
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullets newBullets = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullets ;
            newBullets.SetSpeed(muzzleVelocity);
        }
    }
}
