using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyHeadCheck>())
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
