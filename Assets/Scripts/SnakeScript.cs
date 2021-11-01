using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeScript : MonoBehaviour
{
    public GameObject cameraSnake;

    [HideInInspector]
    public bool grenzeLeft;

    [HideInInspector]
    public bool grenzeRight;

    public Text text_cristall;
    public GameObject panelEnd;

    [HideInInspector]
    public List<GameObject> fullBody;

    [HideInInspector]
    public Text score_text;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int cristalls;
    [HideInInspector]
    public bool cristallization;
    [HideInInspector]
    float time;

    public GameObject bodyPrefab;

    public float speed;

    public Color colorSnake;

    private void Start()
    {
        fullBody.Add(gameObject);
        gameObject.GetComponent<MeshRenderer>().material.color = colorSnake;

        score = 0;
        score_text.text = "0";

        cristalls = 0;
        text_cristall.text = "0";
        cristallization = false;

        time = 0f;

        cameraSnake.GetComponent<CameraMove>().speedCamera = speed;

        grenzeLeft = false;
        grenzeRight = false;
    }

    private void Update()
    {
        if (!cristallization)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed);
        }
        else
        {
            if(time < 3f)
            {
                time += Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed  * 2);
            }
            else
            {
                time = 0;
                cristallization = false;

                cameraSnake.GetComponent<CameraMove>().speedCamera = speed;
            }
        }
    }
}
