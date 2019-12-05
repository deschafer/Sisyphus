using System;
using UnityEngine;
using UnityEngine.UI;

public class Link : MonoBehaviour {

    private TimeOut to;

    void Start() {
        to = GameObject.FindObjectOfType<TimeOut>();
    }

    void Update() {
        GetComponent<Text>().text = Math.Round(to.timerActive, 1) + "";
    }
}
