using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetroRun : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Button runButton;
    public Text metersText;
    public Text speedText;


   void RunOnClick()
    {
        speed = speed + 0.1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        runButton.onClick.AddListener(RunOnClick);
    }

    // Update is called once per frame
    void Update()
    { if (speed < 20 ) {
            metersText.text = ("Meters" + Mathf.Round(transform.position.z));
            speedText.text = ("Speed" + Mathf.Round(speed));
            speed = speed - 0.01f;
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (speed == 0)
        {
            speed = 0;
            Debug.Log("Тебя поймали");
        }
    }
}
