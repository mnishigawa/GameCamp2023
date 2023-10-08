using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace staffroll
{
    public class StaffrollMain : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
            }
        }
    }
}