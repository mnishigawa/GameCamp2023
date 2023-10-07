using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// ˆÚ“®•ûŒü
        /// </summary>
        public enum BulletAngle
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }
        private BulletAngle bulletAngle;    // ˆÚ“®•ûŒü

        private float MoveSpeed = 1f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 MoveAxis = new Vector3();
            MoveAxis = Vector3.zero;

            MoveAxis.x += Mathf.Sin(Mathf.PI * (int)bulletAngle) * MoveSpeed * Time.deltaTime;
            MoveAxis.y += Mathf.Cos(Mathf.PI * (int)bulletAngle) * MoveSpeed;

            transform.Translate(MoveAxis.x, MoveAxis.y, 0.0f, Space.Self);
        }
    }
}
