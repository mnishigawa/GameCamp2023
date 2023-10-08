using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleLogo : MonoBehaviour
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
        transform.localScale =  new Vector3(0.5f, 0.5f, 0.5f) + Vector3.one * Mathf.Sin(Mathf.PI * ((float)AlphaCnt / (float)ADDTIME)) * 0.1f;
    }
}
