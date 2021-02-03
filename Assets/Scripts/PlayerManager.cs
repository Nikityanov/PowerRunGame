using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public RoadGenerator rg;
    public Text coinsCounter;
    public int coinsCount = 0;
    public PlayerMovement pm;

    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsCount += 1;
            coinsCounter.text = coinsCount.ToString();
        }
        if (other.gameObject.tag == "obstacle")
        {
            rg.PauseLevel();
            coinsCounter.text = "You Die";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            pm.isGrounded = true;
        }
    }
}