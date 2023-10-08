using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace teamlogo
{
    public class LogoMain : MonoBehaviour
    {
        private float time;

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Sin(Mathf.PI * (time * 0.25f)));

            if(time >= 4f)
            {
                SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
            }
        }
    }
}
