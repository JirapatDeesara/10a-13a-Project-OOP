using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    { 
        Debug.Log("Hit");
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            GetItem item_ = GetComponent<GetItem>();

            if (item_ != null && player != null)
            {
                item_.ApplyItem(player);
                Destroy(gameObject);
            }
        }
    }
}
