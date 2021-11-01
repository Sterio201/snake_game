using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject panelEnd;

    [HideInInspector]
    public Color colorCapsule;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = colorCapsule;
    }

    public void EndGame()
    {
        panelEnd.SetActive(true);

        panelEnd.transform.GetChild(0).gameObject.GetComponent<Text>().text = "вы проиграли";

        Time.timeScale = 0f;
    }
}