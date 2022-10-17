//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/_Scripts/PlayerAction.inputactions
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

public partial class @PlayerAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""PlayerShoot"",
            ""id"": ""a17735df-5f8a-4585-9fd1-63dd4d89b57a"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""26513e88-1d4f-416a-98f2-4db5db25e2cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6cbc9a1-cf40-446b-8808-e045fefa3fbb"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerShoot
        m_PlayerShoot = asset.FindActionMap("PlayerShoot", throwIfNotFound: true);
        m_PlayerShoot_Shoot = m_PlayerShoot.FindAction("Shoot", throwIfNotFound: true);
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

    // PlayerShoot
    private readonly InputActionMap m_PlayerShoot;
    private IPlayerShootActions m_PlayerShootActionsCallbackInterface;
    private readonly InputAction m_PlayerShoot_Shoot;
    public struct PlayerShootActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerShootActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_PlayerShoot_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_PlayerShoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerShootActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerShootActions instance)
        {
            if (m_Wrapper.m_PlayerShootActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_PlayerShootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public PlayerShootActions @PlayerShoot => new PlayerShootActions(this);
    public interface IPlayerShootActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
