using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound;

       public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(this.gameObject);
            GameManager.instance.AddCoinScore(coinValue);
            AudioManager.instance.PlaySound(coinSound);
        }
    }
}
