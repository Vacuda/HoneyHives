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
            ""name"": ""GameLevel_Outer"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameLevel_Outer
        m_GameLevel_Outer = asset.FindActionMap("GameLevel_Outer", throwIfNotFound: true);
        m_GameLevel_Outer_Interact = m_GameLevel_Outer.FindAction("Interact", throwIfNotFound: true);
        m_GameLevel_Outer_Spin = m_GameLevel_Outer.FindAction("Spin", throwIfNotFound: true);
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

    // GameLevel_Outer
    private readonly InputActionMap m_GameLevel_Outer;
    private IGameLevel_OuterActions m_GameLevel_OuterActionsCallbackInterface;
    private readonly InputAction m_GameLevel_Outer_Interact;
    private readonly InputAction m_GameLevel_Outer_Spin;
    public struct GameLevel_OuterActions
    {
        private @PlayerControls m_Wrapper;
        public GameLevel_OuterActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_GameLevel_Outer_Interact;
        public InputAction @Spin => m_Wrapper.m_GameLevel_Outer_Spin;
        public InputActionMap Get() { return m_Wrapper.m_GameLevel_Outer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameLevel_OuterActions set) { return set.Get(); }
        public void SetCallbacks(IGameLevel_OuterActions instance)
        {
            if (m_Wrapper.m_GameLevel_OuterActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnInteract;
                @Spin.started -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_GameLevel_OuterActionsCallbackInterface.OnSpin;
            }
            m_Wrapper.m_GameLevel_OuterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
            }
        }
    }
    public GameLevel_OuterActions @GameLevel_Outer => new GameLevel_OuterActions(this);
    public interface IGameLevel_OuterActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
    }
}
