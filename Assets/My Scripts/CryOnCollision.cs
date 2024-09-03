using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CryOnCollision : MonoBehaviour
{
    public AudioSource[] Colliders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ZombieBig")
        {
            Colliders[0].Play();
        }
        if (other.gameObject.tag == "Vehicle")
        {
            Colliders[1].Play();
        }
        if (other.gameObject.tag == "Zombie")
        {
            Colliders[2].Play();
        }
        if (other.gameObject.tag == "PowUp_HP" || other.gameObject.tag == "PowUp_Shield" || other.gameObject.tag == "PowUp_Teleporter")
        {
            Colliders[3].Play();
        }
    }
}
