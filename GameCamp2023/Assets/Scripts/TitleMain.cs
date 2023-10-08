using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace title
{
    public class TitleMain : MonoBehaviour
    {
        private TitleInput inputManager;

        [SerializeField]
        private AudioClip se;

        private AudioSource audioSource;

        private float time = 0.0f;
        private bool bEnter = false;

        // Start is called before the first frame update
        void Start()
        {
            // 入力マネージャ　インスタンス生成と初期化
            inputManager = new TitleInput();
            inputManager.Initialize();

            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            // 入力情報の更新
            inputManager.UpdateInputStatus();

            if (inputManager.GetInputStatus(0).RIGHT == true ||
                Input.anyKeyDown)
            {
                audioSource.PlayOneShot(se);
                bEnter = true;
            }

            if(bEnter == false)
            {
                return;
            }

            time += Time.deltaTime;
            if(time >= 1.0f)
            {
                SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
            }

        }
    }
}
