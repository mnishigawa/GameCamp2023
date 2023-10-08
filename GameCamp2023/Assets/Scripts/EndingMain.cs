using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ending
{
    public class EndingMain : MonoBehaviour
    {

        public enum EndingType
        {
            ZOUWIN = 0,
            UNIWIN
        }

        [SerializeField]
        GameObject[] EndingObject;   // ゾウエンディング用

        private EndingType endingType;    // エンディングの種類

        // Start is called before the first frame update
        void Start()
        {
            int nZouScore = game.GameMain.instance.GetScore(game.GameMain.PlayerIndex.ZOU);
            int nUniScore = game.GameMain.instance.GetScore(game.GameMain.PlayerIndex.UNI);

            if (nZouScore >= nUniScore)
            {
                endingType = EndingType.ZOUWIN;
            }
            else
            {
                endingType = EndingType.UNIWIN;
            }

            foreach (var obj in EndingObject)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            EndingObject[(int)endingType].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            if (Input.anyKeyDown)
            {
                switch (endingType)
                {
                    case EndingType.ZOUWIN: // エンドロールに遷移
                        SceneManager.LoadScene("StaffrollScene", LoadSceneMode.Single);
                        break;

                    case EndingType.UNIWIN:
                        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
                        break;
                }
            }
        }


    }
}
