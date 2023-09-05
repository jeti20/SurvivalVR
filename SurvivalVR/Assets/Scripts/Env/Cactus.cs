using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public int damage;
    public float damageRate;

    public List<IDamagable> thingsToDamage = new List<IDamagable>();

    void Start()
    {
        StartCoroutine(DealDamage());
    }

    IEnumerator DealDamage()
    {
        // every "damageRate" seconds, damage all thingsToDamage
        while (true)
        {
            for (int i = 0; i < thingsToDamage.Count; i++)
            {
                thingsToDamage[i].TakePhysicalDamage(damage);
            }

            yield return new WaitForSeconds(damageRate);
        }
    }

    // called when an object collides with the cactus
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Kolizcja");
        // if it's an IDamagable, add it to the list
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            thingsToDamage.Add(collision.gameObject.GetComponent<IDamagable>());
            Debug.Log("KolizcjaZDamagable");
        }
        
    }

    // called when an object stops colliding with the cactus
    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        // if it's an IDamagable, remove it from the list
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            thingsToDamage.Remove(collision.gameObject.GetComponent<IDamagable>());
        }
    }
}
