using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace title
{
    public class TitleMain : MonoBehaviour
    {
        private TitleInput inputManager;

        // Start is called before the first frame update
        void Start()
        {
            // 入力マネージャ　インスタンス生成と初期化
            inputManager = new TitleInput();
            inputManager.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            // 入力情報の更新
            inputManager.UpdateInputStatus();

            if (inputManager.GetInputStatus(0).RIGHT == true ||
                Input.anyKeyDown)
            {
                SceneManager.LoadScene("MAPScene", LoadSceneMode.Single);
            }

        }
    }
}
