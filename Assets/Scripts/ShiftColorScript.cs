using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftColorScript : MonoBehaviour
{
    public Color colorShift;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = colorShift;
    }

    public void ShiftColor(SnakeScript snake)
    {
        snake.colorSnake = colorShift;

        for(int i = 0; i<snake.fullBody.Count; i++)
        {
            snake.fullBody[i].GetComponent<MeshRenderer>().material.color = colorShift;
        }
    }
}