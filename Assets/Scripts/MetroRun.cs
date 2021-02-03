using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MetroRun : MonoBehaviour
{
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
    void Start()
    {
        anim.speed = 2;
        runButton.onClick.AddListener(RunOnClick);
    }


    private void FixedUpdate()
    { if (speed > 0)
        {
            float speedround = (float)Math.Round(speed, 2);
            metersText.text = ("Meters" + Mathf.Round(transform.position.z));
            speedText.text = ("Speed" + speedround);
            speed -= 0.001f;
            anim.speed -= 0.001f;
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    
        if (speed == 0)
        {
            speed = 0;
            Debug.Log("Тебя поймали");
            transform.Translate(new Vector3(0, 0, 0));
            anim.Play("Entry");
        }
    }
}
