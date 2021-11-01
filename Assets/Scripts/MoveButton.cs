using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    [SerializeField] GameObject snake;
    [SerializeField] bool left;

    Rigidbody r;

    public bool isHeldDown = false;

    private void Start()
    {
        r = snake.GetComponent<Rigidbody>();
    }

    public void onPress()
    {
        isHeldDown = false;
    }

    public void onRelease()
    {
        isHeldDown = true;
    }

    private void Update()
    {
        if (isHeldDown)
        {
            if (!snake.GetComponent<SnakeScript>().cristallization)
            {
                if (left)
                {
                    if (snake.GetComponent<SnakeScript>().grenzeLeft)
                    {
                        Vector3 direction = Vector3.left;
                        direction *= 3f;

                        r.velocity = direction;
                    }
                    else
                    {
                        snake.transform.Translate(Vector3.left * Time.deltaTime * 3f);
                    }
                }
                else
                {
                    if (snake.GetComponent<SnakeScript>().grenzeRight)
                    {
                        Vector3 direction = Vector3.right;
                        direction *= 3f;

                        r.velocity = direction;
                    }
                    else
                    {
                        snake.transform.Translate(Vector3.right * Time.deltaTime * 3f);
                    }
                }
            }
        }
    }
}