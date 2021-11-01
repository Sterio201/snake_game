using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCollision : MonoBehaviour
{
    [SerializeField] SnakeScript snake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fruit")
        {
            if(other.gameObject.GetComponent<EatScript>().colorCapsule == snake.colorSnake)
            {
                Destroy(other.gameObject);

                GameObject partSnake = snake.fullBody[snake.fullBody.Count - 1];

                Vector3 positionNewSnake = new Vector3(partSnake.transform.position.x, partSnake.transform.position.y, partSnake.transform.position.z - 0.66f);

                GameObject newPartSnake = Instantiate(snake.bodyPrefab, positionNewSnake, Quaternion.identity);

                newPartSnake.transform.SetParent(snake.gameObject.transform.parent);

                SnakePart snakePart = newPartSnake.GetComponent<SnakePart>();
                snakePart.followObject = partSnake;
                snakePart.speed = snake.speed + 1.6f;

                if (snake.fullBody.Count >= 2)
                {
                    snakePart.speed += 1.5f;
                }

                newPartSnake.GetComponent<MeshRenderer>().material.color = snake.colorSnake;

                snake.fullBody.Add(newPartSnake);

                snake.score++;
                snake.score_text.text = snake.score.ToString();
            }
            else
            {
                if (snake.cristallization)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    other.GetComponent<EatScript>().EndGame();
                }
            }
        }
        if (other.gameObject.tag == "colorShift")
        {
            other.gameObject.GetComponent<ShiftColorScript>().ShiftColor(snake);
        }
        if(other.gameObject.tag == "trap")
        {
            if (snake.cristallization)
            {
                Destroy(other.gameObject);
            }
            else
            {
                other.gameObject.GetComponent<TrapScript>().EndGame();
            }
        }
        if (other.gameObject.tag == "cristall")
        {
            Destroy(other.gameObject);
            snake.cristalls++;

            snake.text_cristall.text = snake.cristalls.ToString();

            if(snake.cristalls == 3)
            {
                snake.cristalls = 0;
                snake.cristallization = true;

                snake.cameraSnake.GetComponent<CameraMove>().speedCamera *= 2;

                snake.text_cristall.text = "0";
            }
        }
        if (other.gameObject.tag == "finisch")
        {
            snake.panelEnd.SetActive(true);

            snake.panelEnd.transform.GetChild(0).gameObject.GetComponent<Text>().text = "вы выиграли";

            Time.timeScale = 0f;
        }
    }

    // При столкновении с границами
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "grenzeLeft")
        {
            snake.grenzeLeft = true;
        }
        if(collision.gameObject.tag == "grenzeRight")
        {
            snake.grenzeRight = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "grenzeLeft")
        {
            snake.grenzeLeft = false;
        }
        if(collision.gameObject.tag == "grenzeRight")
        {
            snake.grenzeRight = false;
        }
    }
}