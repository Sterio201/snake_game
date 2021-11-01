using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    [HideInInspector]
    public GameObject followObject;

    [HideInInspector]
    public float speed;

    // Update is called once per frame
    void Update()
    {
        followObject.transform.LookAt(followObject.transform);
        transform.position = Vector3.Lerp(transform.position, followObject.transform.position, Time.deltaTime * (speed - 0.2f));
    }
}