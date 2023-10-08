using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ending
{
    public class UI_EndingText : MonoBehaviour
    {
        [SerializeField]
        GameObject[] EndingText;   // エンディングテキスト

        private float time;
        private ending.EndingMain.EndingType type;

        // Start is called before the first frame update
        void Start()
        {
            int nZouScore = game.GameMain.instance.GetScore(game.GameMain.PlayerIndex.ZOU);
            int nUniScore = game.GameMain.instance.GetScore(game.GameMain.PlayerIndex.UNI);

            if (nZouScore >= nUniScore)
            {
                type = ending.EndingMain.EndingType.ZOUWIN;
            }
            else
            {
                type = ending.EndingMain.EndingType.UNIWIN;
            }

            foreach (var text in EndingText)
            {
                text.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            EndingText[(int)type].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, time));
        }
    }
}
