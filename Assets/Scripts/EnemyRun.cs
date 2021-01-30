using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{

    public float speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Тебя догнали, петушара");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
