using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MetroRun : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Button runButton;
    public Text metersText;
    public Text speedText;

    public Animator anim;


   void RunOnClick()
    {
        speed = speed + 0.05f;
        anim.speed += 0.05f;
    }
    // Start is called before the first frame update
    void Start()
    {
        runButton.onClick.AddListener(RunOnClick);
    }

    // Update is called once per frame
    void Update()
    { if (speed < 20 ) {
           float speedround = (float)Math.Round(speed, 2);
            metersText.text = ("Meters" + Mathf.Round(transform.position.z));
            speedText.text = ("Speed" + speedround);
            speed = speed - 0.01f;
            anim.speed -= 0.01f;
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (speed == 0)
        {
            speed = 0;
            Debug.Log("Тебя поймали");
        }
    }
}
