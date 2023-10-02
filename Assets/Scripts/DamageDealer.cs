using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage=10; //damage variable

    public int GetDamage() //to get damaged
    {
        return damage;
    }

    public void Hit() //to die
    {
        Destroy(gameObject);
    }
}
