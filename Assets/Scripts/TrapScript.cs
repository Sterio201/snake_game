using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject panelEnd;

    public void EndGame()
    {
        panelEnd.SetActive(true);

        panelEnd.transform.GetChild(0).gameObject.GetComponent<Text>().text = "вы проиграли";

        Time.timeScale = 0f;
    }
}
