using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace tutorial
{
    public class TutorialMain : MonoBehaviour
    {
        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("MAPScene", LoadSceneMode.Single);
            }
        }
    }
}
