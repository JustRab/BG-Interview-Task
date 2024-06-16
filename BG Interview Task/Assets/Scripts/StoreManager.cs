using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public GameObject shopPanel;

    public Collider2D playerCollider;

    public bool isInSafeZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            Debug.Log("Player has entered the shop zone");
            isInSafeZone = true;
        }
    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            Debug.Log("Player has exited the shop zone");
            shopPanel.SetActive(false);
        }
    }
}
