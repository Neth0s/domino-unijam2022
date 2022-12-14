//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d4aa3b91-82c5-4859-a875-d76483bc2eeb"",
            ""actions"": [
                {
                    ""name"": ""PlaceColor1"",
                    ""type"": ""Button"",
                    ""id"": ""a6e85bb3-7975-40e1-82aa-f49522a43d76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlaceColor2"",
                    ""type"": ""Button"",
                    ""id"": ""e99ae2c3-b41c-46a8-a4ab-a8b23785219c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlaceColor3"",
                    ""type"": ""Button"",
                    ""id"": ""3248f96e-dd10-4b79-bd0c-3dd4d7f7ed1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlaceColor4"",
                    ""type"": ""Button"",
                    ""id"": ""f9d5de1e-302c-45e2-bcbd-4bb783e10547"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LongDomino"",
                    ""type"": ""Button"",
                    ""id"": ""9b0d1665-dcde-45de-88ae-6b78367e97ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3338267a-360f-4c3e-a77b-3e433ee73c21"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceColor1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5f91c22-39ed-4a16-8c8d-234b575f41e1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceColor2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""746eb044-2a7a-44eb-9908-92c9acc0bd94"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceColor3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8680dcb-ce99-4c84-9f38-4f02368f0d13"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceColor4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""028dca19-53ac-4298-bdc7-75979bccc9d5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongDomino"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""4cea35c1-6c9d-47d7-b3e3-591c1eeb209f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3ac97779-7a33-4f9f-9fe7-deadcae3b2b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""23d0227e-3bea-418c-95db-b6f270b52c8d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PlaceColor1 = m_Player.FindAction("PlaceColor1", throwIfNotFound: true);
        m_Player_PlaceColor2 = m_Player.FindAction("PlaceColor2", throwIfNotFound: true);
        m_Player_PlaceColor3 = m_Player.FindAction("PlaceColor3", throwIfNotFound: true);
        m_Player_PlaceColor4 = m_Player.FindAction("PlaceColor4", throwIfNotFound: true);
        m_Player_LongDomino = m_Player.FindAction("LongDomino", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Pause = m_Menu.FindAction("Pause", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PlaceColor1;
    private readonly InputAction m_Player_PlaceColor2;
    private readonly InputAction m_Player_PlaceColor3;
    private readonly InputAction m_Player_PlaceColor4;
    private readonly InputAction m_Player_LongDomino;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceColor1 => m_Wrapper.m_Player_PlaceColor1;
        public InputAction @PlaceColor2 => m_Wrapper.m_Player_PlaceColor2;
        public InputAction @PlaceColor3 => m_Wrapper.m_Player_PlaceColor3;
        public InputAction @PlaceColor4 => m_Wrapper.m_Player_PlaceColor4;
        public InputAction @LongDomino => m_Wrapper.m_Player_LongDomino;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PlaceColor1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor1;
                @PlaceColor1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor1;
                @PlaceColor1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor1;
                @PlaceColor2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor2;
                @PlaceColor2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor2;
                @PlaceColor2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor2;
                @PlaceColor3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor3;
                @PlaceColor3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor3;
                @PlaceColor3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor3;
                @PlaceColor4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor4;
                @PlaceColor4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor4;
                @PlaceColor4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceColor4;
                @LongDomino.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLongDomino;
                @LongDomino.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLongDomino;
                @LongDomino.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLongDomino;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceColor1.started += instance.OnPlaceColor1;
                @PlaceColor1.performed += instance.OnPlaceColor1;
                @PlaceColor1.canceled += instance.OnPlaceColor1;
                @PlaceColor2.started += instance.OnPlaceColor2;
                @PlaceColor2.performed += instance.OnPlaceColor2;
                @PlaceColor2.canceled += instance.OnPlaceColor2;
                @PlaceColor3.started += instance.OnPlaceColor3;
                @PlaceColor3.performed += instance.OnPlaceColor3;
                @PlaceColor3.canceled += instance.OnPlaceColor3;
                @PlaceColor4.started += instance.OnPlaceColor4;
                @PlaceColor4.performed += instance.OnPlaceColor4;
                @PlaceColor4.canceled += instance.OnPlaceColor4;
                @LongDomino.started += instance.OnLongDomino;
                @LongDomino.performed += instance.OnLongDomino;
                @LongDomino.canceled += instance.OnLongDomino;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Pause;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Menu_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IPlayerActions
    {
        void OnPlaceColor1(InputAction.CallbackContext context);
        void OnPlaceColor2(InputAction.CallbackContext context);
        void OnPlaceColor3(InputAction.CallbackContext context);
        void OnPlaceColor4(InputAction.CallbackContext context);
        void OnLongDomino(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
