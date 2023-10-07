using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace game
{
    public class PlayerInput : ControlAsset.IActionMapActions
    {
        public struct InputStatus
        {
            public bool UP;
            public bool LEFT;
            public bool RIGHT;
            public bool DOWN;
            public bool FIRE;

            public InputStatus(bool up, bool left, bool right, bool down, bool fire)
            {
                UP = up;
                LEFT = left;
                RIGHT = right;
                DOWN = down;
                FIRE = fire;
            }
        }

        public enum InputType
        {
            P1UP = 0,
            P1LEFT,
            P1RIGHT,
            P1DOWN,
            P1FIRE,
            P2UP,
            P2LEFT,
            P2RIGHT,
            P2DOWN,
            P2FIRE,
            P3UP,
            P3LEFT,
            P3RIGHT,
            P3DOWN,
            P3FIRE,
            MAX
        }

        public List<InputStatus> PlayerInputStatusList;

        private bool[] InputStatusList;
        private ControlAsset controlAsset;

        public InputStatus GetInputStatus(game.GameMain.PlayerIndex playerIndex)
        {
            return PlayerInputStatusList[(int)playerIndex];
        }

        public void Initialize()
        {
            // InputSystemの初期化
            controlAsset = new ControlAsset();
            controlAsset.ActionMap.SetCallbacks(this);
            controlAsset.Enable();

            PlayerInputStatusList = new List<InputStatus>();

            InputStatusList = new bool[(int)InputType.MAX];

            // 入力情報の中身を全てfalseにしておく
            for(int i = 0; i > (int)InputType.MAX; i++)
            {
                InputStatusList[i] = false;
            }
            Debug.Log("inputManager Initialized");
        }

        public void UpdateInputStatus()
        {
            if(InputStatusList == null)
            {
                Debug.Log("InputStatusList is null");
                return;
            }

            // P1
            InputStatus p1inputStatus = new InputStatus(
                InputStatusList[(int)InputType.P1UP],
                InputStatusList[(int)InputType.P1LEFT],
                InputStatusList[(int)InputType.P1RIGHT],
                InputStatusList[(int)InputType.P1DOWN],
                InputStatusList[(int)InputType.P1FIRE]
            );

            // P2
            InputStatus p2inputStatus = new InputStatus(
                InputStatusList[(int)InputType.P2UP],
                InputStatusList[(int)InputType.P2LEFT],
                InputStatusList[(int)InputType.P2RIGHT],
                InputStatusList[(int)InputType.P2DOWN],
                InputStatusList[(int)InputType.P2FIRE]
            );

            // P3
            InputStatus p3inputStatus = new InputStatus(
                InputStatusList[(int)InputType.P3UP],
                InputStatusList[(int)InputType.P3LEFT],
                InputStatusList[(int)InputType.P3RIGHT],
                InputStatusList[(int)InputType.P3DOWN],
                InputStatusList[(int)InputType.P3FIRE]
            );

            // 更新
            PlayerInputStatusList.Clear();
            PlayerInputStatusList.Add(p1inputStatus);
            PlayerInputStatusList.Add(p2inputStatus);
            PlayerInputStatusList.Add(p3inputStatus);
        }

        void ControlAsset.IActionMapActions.OnP1UP(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P1UP] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P1UP] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP1LEFT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P1LEFT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P1LEFT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP1RIGHT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P1RIGHT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P1RIGHT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP1DOWN(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P1DOWN] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P1DOWN] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP1Fire(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P1FIRE] = true;
            }
            else
            {
                InputStatusList[(int)InputType.P1FIRE] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP2UP(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P2UP] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P2UP] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP2LEFT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P2LEFT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P2LEFT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP2RIGHT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P2RIGHT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P2RIGHT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP2DOWN(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P2DOWN] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P2DOWN] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP3UP(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P3UP] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P3UP] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP3LEFT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P3LEFT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P3LEFT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP3RIGHT(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P3RIGHT] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P3RIGHT] = false;
            }
        }
        void ControlAsset.IActionMapActions.OnP3DOWN(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                InputStatusList[(int)InputType.P3DOWN] = true;
            }
            if(context.canceled)
            {
                InputStatusList[(int)InputType.P3DOWN] = false;
            }
        }
    }
}