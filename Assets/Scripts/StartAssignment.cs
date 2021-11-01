using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAssignment : MonoBehaviour
{
    [SerializeField] Color[] allColors;

    [SerializeField] TrapScript[] allTraps;

    [SerializeField] ShiftColorScript[] grenzeColors;

    [SerializeField] EatScript[] humans_color_one;
    [SerializeField] EatScript[] humans_color_two;
    [SerializeField] EatScript[] humans_color_three;
    [SerializeField] EatScript[] humans_color_fohre;
    [SerializeField] EatScript[] humans_color_five;
    [SerializeField] EatScript[] humans_color_six;

    [SerializeField] GameObject panelEnd;
    [SerializeField] Text score;

    [SerializeField] SnakeScript snake;

    private void Awake()
    {
        int j = 0;

        for(int i = 1; i<allColors.Length; i++)
        {
            grenzeColors[j].colorShift = allColors[i];
            j++;
        }

        for (int i = 0; i<allTraps.Length; i++)
        {
            allTraps[i].panelEnd = panelEnd;
        }

        ColorHumans(humans_color_one, allColors[0]);
        ColorHumans(humans_color_two, allColors[1]);
        ColorHumans(humans_color_three, allColors[2]);
        ColorHumans(humans_color_fohre, allColors[3]);
        ColorHumans(humans_color_five, allColors[4]);
        ColorHumans(humans_color_six, allColors[5]);

        snake.colorSnake = allColors[0];

        snake.score_text = score;
    }

    void ColorHumans(EatScript[] mass, Color color)
    {
        for(int i = 0; i<mass.Length; i++)
        {
            mass[i].colorCapsule = color;
            mass[i].panelEnd = panelEnd;
        }
    }
}