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

        // Start is called before the first frame update
        void Start()
        {
            foreach (var text in EndingText)
            {
                text.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //int type = game.GameMain.エンディング列挙;
            int type = 0;
            time += Time.deltaTime;
            EndingText[type].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, time));
        }
    }
}
