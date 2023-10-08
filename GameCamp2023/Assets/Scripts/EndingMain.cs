using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            foreach (var obj in EndingObject)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetEndingType(EndingType type)
        {
            endingType = type;
            EndingObject[(int)endingType].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }


    }
}
