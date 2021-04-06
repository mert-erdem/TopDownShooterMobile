using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    private GameObject weapon;


    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("weapon");    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="player")
        {
            weapon.GetComponent<WeaponScript>().MaxAmmo();
            
            Destroy(this.gameObject);
        }
    }
}
