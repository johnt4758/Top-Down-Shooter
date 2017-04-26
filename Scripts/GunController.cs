using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{

    Gun equippedGun;
    //empty game object that is set in unity as the placeholder for the gun
    public Transform weaponHold;
    //assigned in unity, originally pulled from the prefab folder labled "Gun"
    public Gun startingGun;

    private void Start()
    {
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if(equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        //generating the starting gun at the weaponHold's position
        equippedGun = Instantiate(gunToEquip,weaponHold.position,weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;

    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
