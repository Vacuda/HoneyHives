// GENERATED AUTOMATICALLY FROM 'Assets/Admin/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GameLevel"",
            ""id"": ""1a714881-2df5-4a7a-a6a9-4cc955916597"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""71147960-7c76-4611-8d7d-7d48cde01ded"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Button"",
                    ""id"": ""058d5d1a-94d8-416a-ab26-1e8dd9d59096"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePointer"",
                    ""type"": ""Value"",
                    ""id"": ""3212862f-2e12-4f9d-b298-9f1acb568d96"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85551f62-2319-4e1a-88ef-23cbf7e334e2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6751d9ad-a4b2-40e1-8543-0c01e2d169b1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51364316-db85-4a18-a9b4-8a94b0d55cec"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TitleLevel"",
            ""id"": ""099ae11f-6a43-4ee3-ad00-c8f29a3d5ba5"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""af5be0b4-c792-4908-bccb-b7c57c6a06cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""188aaaaa-b724-479c-908b-1620269d33d0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameLevel
        m_GameLevel = asset.FindActionMap("GameLevel", throwIfNotFound: true);
        m_GameLevel_Interact = m_GameLevel.FindAction("Interact", throwIfNotFound: true);
        m_GameLevel_Spin = m_GameLevel.FindAction("Spin", throwIfNotFound: true);
        m_GameLevel_MousePointer = m_GameLevel.FindAction("MousePointer", throwIfNotFound: true);
        // TitleLevel
        m_TitleLevel = asset.FindActionMap("TitleLevel", throwIfNotFound: true);
        m_TitleLevel_Interact = m_TitleLevel.FindAction("Interact", throwIfNotFound: true);
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

    // GameLevel
    private readonly InputActionMap m_GameLevel;
    private IGameLevelActions m_GameLevelActionsCallbackInterface;
    private readonly InputAction m_GameLevel_Interact;
    private readonly InputAction m_GameLevel_Spin;
    private readonly InputAction m_GameLevel_MousePointer;
    public struct GameLevelActions
    {
        private @PlayerControls m_Wrapper;
        public GameLevelActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_GameLevel_Interact;
        public InputAction @Spin => m_Wrapper.m_GameLevel_Spin;
        public InputAction @MousePointer => m_Wrapper.m_GameLevel_MousePointer;
        public InputActionMap Get() { return m_Wrapper.m_GameLevel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameLevelActions set) { return set.Get(); }
        public void SetCallbacks(IGameLevelActions instance)
        {
            if (m_Wrapper.m_GameLevelActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnInteract;
                @Spin.started -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnSpin;
                @MousePointer.started -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnMousePointer;
                @MousePointer.performed -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnMousePointer;
                @MousePointer.canceled -= m_Wrapper.m_GameLevelActionsCallbackInterface.OnMousePointer;
            }
            m_Wrapper.m_GameLevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
                @MousePointer.started += instance.OnMousePointer;
                @MousePointer.performed += instance.OnMousePointer;
                @MousePointer.canceled += instance.OnMousePointer;
            }
        }
    }
    public GameLevelActions @GameLevel => new GameLevelActions(this);

    // TitleLevel
    private readonly InputActionMap m_TitleLevel;
    private ITitleLevelActions m_TitleLevelActionsCallbackInterface;
    private readonly InputAction m_TitleLevel_Interact;
    public struct TitleLevelActions
    {
        private @PlayerControls m_Wrapper;
        public TitleLevelActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_TitleLevel_Interact;
        public InputActionMap Get() { return m_Wrapper.m_TitleLevel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TitleLevelActions set) { return set.Get(); }
        public void SetCallbacks(ITitleLevelActions instance)
        {
            if (m_Wrapper.m_TitleLevelActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_TitleLevelActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TitleLevelActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TitleLevelActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_TitleLevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public TitleLevelActions @TitleLevel => new TitleLevelActions(this);
    public interface IGameLevelActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
        void OnMousePointer(InputAction.CallbackContext context);
    }
    public interface ITitleLevelActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
