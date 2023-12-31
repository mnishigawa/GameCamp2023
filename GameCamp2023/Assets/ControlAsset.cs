//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/ControlAsset.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlAsset: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlAsset"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""6592fa6e-7488-4b0e-9118-4a14d92289f0"",
            ""actions"": [
                {
                    ""name"": ""P1UP"",
                    ""type"": ""Button"",
                    ""id"": ""0c5d38cc-6b78-411f-ade5-fa171b0ecf40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P1LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""3badf991-5eed-4a5a-bd11-d6b1f3587bf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P1RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""08d73261-1fe7-43f1-b3a6-06a7fd5d0c7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P1DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""f50441c0-880d-431d-8ed8-9d239c90e7b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P1Fire"",
                    ""type"": ""Button"",
                    ""id"": ""de8a7b57-84e1-42e5-b231-1c40c42fc0a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2UP"",
                    ""type"": ""Button"",
                    ""id"": ""99c5d7eb-2132-4cfa-bca7-1c9aebb5a2a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""80eef4f9-55e8-438d-be63-7b485bc37ab8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""451906a3-9aee-48f3-8588-05248b5d7070"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""1d73790f-8398-45c5-b12e-d65b470a8179"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P3UP"",
                    ""type"": ""Button"",
                    ""id"": ""0e1d7584-12d8-41fe-99ab-9b1b6f2acb1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P3LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""832db6df-bb55-4d88-ade3-ded2306fce15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P3RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""37e03e50-f464-4072-a969-fec873660881"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P3DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""168ed07e-665e-4a28-845b-36e0cef13555"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3360f09-b287-4e95-9565-627798428ac7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c662eb1-fb03-4e20-bbb2-2a9a7a5686d6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b4f8f4-59a1-44e7-b0a4-3f20eb3bb2f7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""997bf442-d2ed-426b-b69a-70804d884345"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41b6c2ad-88e3-43a1-8060-23b9cb939015"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e0369a7-0c20-434d-91b1-7b5c20d337ef"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67b0651f-c0d3-4b2d-8524-1bc842f11f2d"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec0076f2-dff9-4218-ad07-608756d61d89"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""968205f2-cbc2-4131-a521-ae1866e3d6eb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b94cd409-f17e-4def-80c2-61a49e3832a4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb2fb237-82ef-409b-947f-c0bf34e26a4a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c442a114-09a5-4aa8-9f4c-e1a88528f989"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bea8a75-b63b-422d-9f25-40728a387d46"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""228b50d9-4ae3-4cfa-a203-cb407077747b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50e0b233-b3d3-4766-94ed-5060e47a4b5c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a624501e-5a71-41c9-a9ad-96e4478b75d2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P3RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e9aca76-0e85-42e2-a0c3-166153a1dc59"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5283257b-2da7-42ad-8f66-8938b6a3d5c8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMap
        m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
        m_ActionMap_P1UP = m_ActionMap.FindAction("P1UP", throwIfNotFound: true);
        m_ActionMap_P1LEFT = m_ActionMap.FindAction("P1LEFT", throwIfNotFound: true);
        m_ActionMap_P1RIGHT = m_ActionMap.FindAction("P1RIGHT", throwIfNotFound: true);
        m_ActionMap_P1DOWN = m_ActionMap.FindAction("P1DOWN", throwIfNotFound: true);
        m_ActionMap_P1Fire = m_ActionMap.FindAction("P1Fire", throwIfNotFound: true);
        m_ActionMap_P2UP = m_ActionMap.FindAction("P2UP", throwIfNotFound: true);
        m_ActionMap_P2LEFT = m_ActionMap.FindAction("P2LEFT", throwIfNotFound: true);
        m_ActionMap_P2RIGHT = m_ActionMap.FindAction("P2RIGHT", throwIfNotFound: true);
        m_ActionMap_P2DOWN = m_ActionMap.FindAction("P2DOWN", throwIfNotFound: true);
        m_ActionMap_P3UP = m_ActionMap.FindAction("P3UP", throwIfNotFound: true);
        m_ActionMap_P3LEFT = m_ActionMap.FindAction("P3LEFT", throwIfNotFound: true);
        m_ActionMap_P3RIGHT = m_ActionMap.FindAction("P3RIGHT", throwIfNotFound: true);
        m_ActionMap_P3DOWN = m_ActionMap.FindAction("P3DOWN", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ActionMap
    private readonly InputActionMap m_ActionMap;
    private List<IActionMapActions> m_ActionMapActionsCallbackInterfaces = new List<IActionMapActions>();
    private readonly InputAction m_ActionMap_P1UP;
    private readonly InputAction m_ActionMap_P1LEFT;
    private readonly InputAction m_ActionMap_P1RIGHT;
    private readonly InputAction m_ActionMap_P1DOWN;
    private readonly InputAction m_ActionMap_P1Fire;
    private readonly InputAction m_ActionMap_P2UP;
    private readonly InputAction m_ActionMap_P2LEFT;
    private readonly InputAction m_ActionMap_P2RIGHT;
    private readonly InputAction m_ActionMap_P2DOWN;
    private readonly InputAction m_ActionMap_P3UP;
    private readonly InputAction m_ActionMap_P3LEFT;
    private readonly InputAction m_ActionMap_P3RIGHT;
    private readonly InputAction m_ActionMap_P3DOWN;
    public struct ActionMapActions
    {
        private @ControlAsset m_Wrapper;
        public ActionMapActions(@ControlAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @P1UP => m_Wrapper.m_ActionMap_P1UP;
        public InputAction @P1LEFT => m_Wrapper.m_ActionMap_P1LEFT;
        public InputAction @P1RIGHT => m_Wrapper.m_ActionMap_P1RIGHT;
        public InputAction @P1DOWN => m_Wrapper.m_ActionMap_P1DOWN;
        public InputAction @P1Fire => m_Wrapper.m_ActionMap_P1Fire;
        public InputAction @P2UP => m_Wrapper.m_ActionMap_P2UP;
        public InputAction @P2LEFT => m_Wrapper.m_ActionMap_P2LEFT;
        public InputAction @P2RIGHT => m_Wrapper.m_ActionMap_P2RIGHT;
        public InputAction @P2DOWN => m_Wrapper.m_ActionMap_P2DOWN;
        public InputAction @P3UP => m_Wrapper.m_ActionMap_P3UP;
        public InputAction @P3LEFT => m_Wrapper.m_ActionMap_P3LEFT;
        public InputAction @P3RIGHT => m_Wrapper.m_ActionMap_P3RIGHT;
        public InputAction @P3DOWN => m_Wrapper.m_ActionMap_P3DOWN;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_ActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionMapActionsCallbackInterfaces.Add(instance);
            @P1UP.started += instance.OnP1UP;
            @P1UP.performed += instance.OnP1UP;
            @P1UP.canceled += instance.OnP1UP;
            @P1LEFT.started += instance.OnP1LEFT;
            @P1LEFT.performed += instance.OnP1LEFT;
            @P1LEFT.canceled += instance.OnP1LEFT;
            @P1RIGHT.started += instance.OnP1RIGHT;
            @P1RIGHT.performed += instance.OnP1RIGHT;
            @P1RIGHT.canceled += instance.OnP1RIGHT;
            @P1DOWN.started += instance.OnP1DOWN;
            @P1DOWN.performed += instance.OnP1DOWN;
            @P1DOWN.canceled += instance.OnP1DOWN;
            @P1Fire.started += instance.OnP1Fire;
            @P1Fire.performed += instance.OnP1Fire;
            @P1Fire.canceled += instance.OnP1Fire;
            @P2UP.started += instance.OnP2UP;
            @P2UP.performed += instance.OnP2UP;
            @P2UP.canceled += instance.OnP2UP;
            @P2LEFT.started += instance.OnP2LEFT;
            @P2LEFT.performed += instance.OnP2LEFT;
            @P2LEFT.canceled += instance.OnP2LEFT;
            @P2RIGHT.started += instance.OnP2RIGHT;
            @P2RIGHT.performed += instance.OnP2RIGHT;
            @P2RIGHT.canceled += instance.OnP2RIGHT;
            @P2DOWN.started += instance.OnP2DOWN;
            @P2DOWN.performed += instance.OnP2DOWN;
            @P2DOWN.canceled += instance.OnP2DOWN;
            @P3UP.started += instance.OnP3UP;
            @P3UP.performed += instance.OnP3UP;
            @P3UP.canceled += instance.OnP3UP;
            @P3LEFT.started += instance.OnP3LEFT;
            @P3LEFT.performed += instance.OnP3LEFT;
            @P3LEFT.canceled += instance.OnP3LEFT;
            @P3RIGHT.started += instance.OnP3RIGHT;
            @P3RIGHT.performed += instance.OnP3RIGHT;
            @P3RIGHT.canceled += instance.OnP3RIGHT;
            @P3DOWN.started += instance.OnP3DOWN;
            @P3DOWN.performed += instance.OnP3DOWN;
            @P3DOWN.canceled += instance.OnP3DOWN;
        }

        private void UnregisterCallbacks(IActionMapActions instance)
        {
            @P1UP.started -= instance.OnP1UP;
            @P1UP.performed -= instance.OnP1UP;
            @P1UP.canceled -= instance.OnP1UP;
            @P1LEFT.started -= instance.OnP1LEFT;
            @P1LEFT.performed -= instance.OnP1LEFT;
            @P1LEFT.canceled -= instance.OnP1LEFT;
            @P1RIGHT.started -= instance.OnP1RIGHT;
            @P1RIGHT.performed -= instance.OnP1RIGHT;
            @P1RIGHT.canceled -= instance.OnP1RIGHT;
            @P1DOWN.started -= instance.OnP1DOWN;
            @P1DOWN.performed -= instance.OnP1DOWN;
            @P1DOWN.canceled -= instance.OnP1DOWN;
            @P1Fire.started -= instance.OnP1Fire;
            @P1Fire.performed -= instance.OnP1Fire;
            @P1Fire.canceled -= instance.OnP1Fire;
            @P2UP.started -= instance.OnP2UP;
            @P2UP.performed -= instance.OnP2UP;
            @P2UP.canceled -= instance.OnP2UP;
            @P2LEFT.started -= instance.OnP2LEFT;
            @P2LEFT.performed -= instance.OnP2LEFT;
            @P2LEFT.canceled -= instance.OnP2LEFT;
            @P2RIGHT.started -= instance.OnP2RIGHT;
            @P2RIGHT.performed -= instance.OnP2RIGHT;
            @P2RIGHT.canceled -= instance.OnP2RIGHT;
            @P2DOWN.started -= instance.OnP2DOWN;
            @P2DOWN.performed -= instance.OnP2DOWN;
            @P2DOWN.canceled -= instance.OnP2DOWN;
            @P3UP.started -= instance.OnP3UP;
            @P3UP.performed -= instance.OnP3UP;
            @P3UP.canceled -= instance.OnP3UP;
            @P3LEFT.started -= instance.OnP3LEFT;
            @P3LEFT.performed -= instance.OnP3LEFT;
            @P3LEFT.canceled -= instance.OnP3LEFT;
            @P3RIGHT.started -= instance.OnP3RIGHT;
            @P3RIGHT.performed -= instance.OnP3RIGHT;
            @P3RIGHT.canceled -= instance.OnP3RIGHT;
            @P3DOWN.started -= instance.OnP3DOWN;
            @P3DOWN.performed -= instance.OnP3DOWN;
            @P3DOWN.canceled -= instance.OnP3DOWN;
        }

        public void RemoveCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_ActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionMapActions @ActionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnP1UP(InputAction.CallbackContext context);
        void OnP1LEFT(InputAction.CallbackContext context);
        void OnP1RIGHT(InputAction.CallbackContext context);
        void OnP1DOWN(InputAction.CallbackContext context);
        void OnP1Fire(InputAction.CallbackContext context);
        void OnP2UP(InputAction.CallbackContext context);
        void OnP2LEFT(InputAction.CallbackContext context);
        void OnP2RIGHT(InputAction.CallbackContext context);
        void OnP2DOWN(InputAction.CallbackContext context);
        void OnP3UP(InputAction.CallbackContext context);
        void OnP3LEFT(InputAction.CallbackContext context);
        void OnP3RIGHT(InputAction.CallbackContext context);
        void OnP3DOWN(InputAction.CallbackContext context);
    }
}
