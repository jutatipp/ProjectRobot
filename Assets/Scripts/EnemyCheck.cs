using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Enemy>())
        {
            // Destroy(transform.parent.gameObject);
            player.healthBar.Damage(0.002f);
        }
    }
}
