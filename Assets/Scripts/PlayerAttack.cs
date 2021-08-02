using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject Magic;
    public Transform pos;
    public float shootSpeed;
    float curTime;

    MainMenu mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && mm.isGameStart)
            {
                Instantiate(Magic, pos.position, transform.rotation);
            }
            curTime = shootSpeed;
        }

        curTime -= Time.deltaTime;
    }
}
