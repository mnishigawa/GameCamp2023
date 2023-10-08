using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleLogo : MonoBehaviour
{
    [SerializeField]
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 20.0f * Time.deltaTime);
    }
}
