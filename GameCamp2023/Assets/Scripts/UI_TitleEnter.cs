using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleEnter : MonoBehaviour
{
    private int AlphaCnt = 0;
    private const int ADDTIME = 360;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AlphaCnt = (AlphaCnt + 1) % ADDTIME;
        // ì_ñ≈èàóù
        GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Sin(Mathf.PI * ((float)AlphaCnt / (float)ADDTIME)));
    }
}
