using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{

    void Start() {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            GetComponent<Image>().color = new Vector4(1f, 1f, 1f, GetComponent<Image>().color.a == 0.4f ? 0.0f : 0.4f);
        }
    }
    
}
