using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace game
{
    public class GameMain : MonoBehaviour
    {
        public static GameMain instance = null;

        public const int PlayerNum = 3;

        public enum PlayerIndex
        {
            ZOU = 0,
            WAKAME = 1,
            UNI = 2
        }

        public enum ObjectType
        {
            ZOU,
            WAKAME,
            UNI,
            WATER,
            MINIWAKAME,
            MINIUNI
        }

        private PlayerInput inputManager;

        private bool isGameActive = false;

        private float time;

        private bool isGameEnd = false;

        private bool isInFinishEvent = false;

        private bool isFinishEventEnd = false;

        private int wakameScore;

        private int uniScore;

        public Tilemap tilemap;

        public List<PlayerBase> playerList;

        public Image countDownImage;

        public List<Sprite> countDownSprite;

        public Image startImage;

        public Text timeText;

        public float TimeLimit = 30f;

        public int TileScore = 10;

        public Image WakameGauge;

        public Image UniGauge;

        public Image FinishImage;

        [SerializeField]
        private AudioClip bgm;

        [SerializeField]
        private AudioClip finish;

        [SerializeField]
        private AudioClip countdown;

        private AudioSource audioSource;


        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            DontDestroyOnLoad(this);

            // 入力マネージャ　インスタンス生成と初期化
            inputManager = new PlayerInput();
            inputManager.Initialize();

            // プレイヤーの初期化
            foreach(var player in playerList)
            {
                player.Initialize(tilemap);
            }

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(countdown);
            audioSource.clip = bgm;
            audioSource.Play();

            // カウントダウン開始
            isGameActive = false;
            countDownImage.gameObject.SetActive(false);
            startImage.gameObject.SetActive(false);
            StartCoroutine(StartCountDownCoroutine());
            time = TimeLimit;
            timeText.gameObject.SetActive(true);
            isGameEnd = false;
            wakameScore = 0;
            uniScore = 0;
            FinishImage.gameObject.SetActive(false);
            isInFinishEvent = false;
            isFinishEventEnd = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(isGameEnd)
            {
                if (isFinishEventEnd)
                {
                    // 終了処理
                    audioSource.Stop();
                    SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
                    isFinishEventEnd = false;
                    return;
                }

                if (isInFinishEvent == false)
                {
                    StartCoroutine(FinishEventCoroutine());
                    isInFinishEvent = true;
                    audioSource.PlayOneShot(finish);
                }
                return;
            }

            if(isGameActive)
            {
                // 制限時間更新
                time -= Time.deltaTime;
                if(time <= 0f)
                {
                    timeText.gameObject.SetActive(false);
                    isGameEnd = true;
                    return;
                }
                else
                {
                    int timer = (int)time;
                    timeText.text = timer.ToString();
                }

                // 入力情報の更新
                inputManager.UpdateInputStatus();

                // プレイヤー更新
                for(int i = 0; i < PlayerNum; i++)
                {
                    playerList[i].Move(inputManager.GetInputStatus((PlayerIndex)i), tilemap);
                    
                    if(playerList[i].ReplaceTile())
                    {
                        switch(i)
                        {
                            case (int)PlayerIndex.ZOU:
                            uniScore -= TileScore;
                            break;
                            case (int)PlayerIndex.WAKAME:
                            wakameScore += TileScore;
                            break;
                            case (int)PlayerIndex.UNI:
                            uniScore += TileScore;
                            //wakameScore -= TileScore;
                            break;
                        }
                    }
                }

                // スコアゲージ更新
                Vector2 wakameGaugeSize = WakameGauge.rectTransform.sizeDelta;
                wakameGaugeSize.x = wakameScore;
                WakameGauge.rectTransform.sizeDelta = wakameGaugeSize;
                Vector2 uniGaugeSize = UniGauge.rectTransform.sizeDelta;
                uniGaugeSize.x = uniScore;
                UniGauge.rectTransform.sizeDelta = uniGaugeSize;
            }
        }

        IEnumerator StartCountDownCoroutine()
        {
            countDownImage.sprite = countDownSprite[0];
            countDownImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);

            countDownImage.sprite = countDownSprite[1];
            yield return new WaitForSeconds(1.0f);

            countDownImage.sprite = countDownSprite[2];
            yield return new WaitForSeconds(1.0f);

            countDownImage.gameObject.SetActive(false);
            startImage.gameObject.SetActive(true);
            isGameActive = true;
            yield return new WaitForSeconds(1.0f);
            startImage.gameObject.SetActive(false);
            yield break;
        }

        IEnumerator FinishEventCoroutine()
        {
            FinishImage.gameObject.SetActive(true);

            yield return new WaitForSeconds(3.0f);

            FinishImage.gameObject.SetActive(false);

            isFinishEventEnd = true;
        }

        // スコア取得
        public int GetScore(PlayerIndex index)
        {
            switch(index)
            {
                case PlayerIndex.ZOU:
                case PlayerIndex.WAKAME:
                    return wakameScore;
                case PlayerIndex.UNI:
                    return uniScore;
                default:
                    return 0;
            }
        }

        // 指定位置のタイルを取得
        public static TileBase GetCurrentTile(Vector3 position, Tilemap tileMap)
        {
            Vector3Int cellPosition = tileMap.WorldToCell(position);

            var targetTile = tileMap.GetTile(cellPosition);

            return targetTile;
        }

        // 対象座標が壁かどうか判定する
        public static bool GetIsWall(Vector3 playerPosition, Tilemap tileMap)
        {
            Vector3Int cellPosition = tileMap.WorldToCell(playerPosition);

            var targetTile = tileMap.GetTile(cellPosition);
            
            if(targetTile.name == "Wall" || targetTile.name == "OuterWall")
            {
                return true;
            }
            return false;
        }

    }
}