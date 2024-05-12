using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetObject;

    public void Activate()
    {
        targetObject.SetActive(!targetObject.activeSelf);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
            Activate();
        }
    }
}
