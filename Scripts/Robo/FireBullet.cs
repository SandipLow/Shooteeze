using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour
{
    public GameObject Target;
    public GameObject Bullet;
    public float rotationDamping;

    // public GameObject damageEffect;
    // Color damageColor;

    void Start()
    {
        // damageColor = damageEffect.GetComponent<Image>().color;
    }

    void FixedUpdate()
    {
        look();
        shoot();
    }

    void look()
    {
        Quaternion rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Bullet.transform.position, Bullet.transform.forward, out hit, 60f))
        {
            // Debug.Log(hit.transform.name);
            if (hit.transform.name == "Player")
            {
                Bullet.GetComponent<ParticleSystem>().Play();
                hit.transform.GetComponent<PlayerHealth>().TakeDamage(1);
                // damageColor.a += 0.0005f;
                // damageEffect.GetComponent<Image>().color = damageColor;
            }
            
        }
    }

}
