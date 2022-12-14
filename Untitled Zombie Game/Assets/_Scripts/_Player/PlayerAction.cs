//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/_Scripts/_Player/PlayerAction.inputactions
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
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""1dca9412-a824-470d-b31f-750755e07f59"",
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
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10113913-2ab5-4612-9a54-caf7c1aa63b1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Playeractions"",
            ""id"": ""8294e36f-ce8a-4f12-b001-c6b3c8560e9f"",
            ""actions"": [
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""6f21f65f-355b-4117-92ed-e8cc90c7e266"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""51ee2d10-67bd-4cca-99af-3cb1b2ea8e9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReloadScene"",
                    ""type"": ""Button"",
                    ""id"": ""8c8fcb32-1b52-4b7b-99d4-2a27e3bed3be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Damage"",
                    ""type"": ""Button"",
                    ""id"": ""88dae6f4-cbfb-490d-81f5-88e17108df9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80c19f56-7ce6-459e-8e70-edb444f2e4a7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""281b06d5-051b-404d-ad6e-9b30a3bebdb7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6baf7e1c-c899-4b96-910e-e2df695707e1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReloadScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c696650e-60e2-4411-8810-0b424151025f"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Damage"",
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
        m_PlayerShoot_Reload = m_PlayerShoot.FindAction("Reload", throwIfNotFound: true);
        // Playeractions
        m_Playeractions = asset.FindActionMap("Playeractions", throwIfNotFound: true);
        m_Playeractions_Pick = m_Playeractions.FindAction("Pick", throwIfNotFound: true);
        m_Playeractions_Drop = m_Playeractions.FindAction("Drop", throwIfNotFound: true);
        m_Playeractions_ReloadScene = m_Playeractions.FindAction("ReloadScene", throwIfNotFound: true);
        m_Playeractions_Damage = m_Playeractions.FindAction("Damage", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerShoot_Reload;
    public struct PlayerShootActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerShootActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_PlayerShoot_Shoot;
        public InputAction @Reload => m_Wrapper.m_PlayerShoot_Reload;
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
                @Reload.started -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerShootActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_PlayerShootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public PlayerShootActions @PlayerShoot => new PlayerShootActions(this);

    // Playeractions
    private readonly InputActionMap m_Playeractions;
    private IPlayeractionsActions m_PlayeractionsActionsCallbackInterface;
    private readonly InputAction m_Playeractions_Pick;
    private readonly InputAction m_Playeractions_Drop;
    private readonly InputAction m_Playeractions_ReloadScene;
    private readonly InputAction m_Playeractions_Damage;
    public struct PlayeractionsActions
    {
        private @PlayerAction m_Wrapper;
        public PlayeractionsActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pick => m_Wrapper.m_Playeractions_Pick;
        public InputAction @Drop => m_Wrapper.m_Playeractions_Drop;
        public InputAction @ReloadScene => m_Wrapper.m_Playeractions_ReloadScene;
        public InputAction @Damage => m_Wrapper.m_Playeractions_Damage;
        public InputActionMap Get() { return m_Wrapper.m_Playeractions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayeractionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayeractionsActions instance)
        {
            if (m_Wrapper.m_PlayeractionsActionsCallbackInterface != null)
            {
                @Pick.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnPick;
                @Pick.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnPick;
                @Pick.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnPick;
                @Drop.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDrop;
                @ReloadScene.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnReloadScene;
                @ReloadScene.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnReloadScene;
                @ReloadScene.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnReloadScene;
                @Damage.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDamage;
                @Damage.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDamage;
                @Damage.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnDamage;
            }
            m_Wrapper.m_PlayeractionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pick.started += instance.OnPick;
                @Pick.performed += instance.OnPick;
                @Pick.canceled += instance.OnPick;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @ReloadScene.started += instance.OnReloadScene;
                @ReloadScene.performed += instance.OnReloadScene;
                @ReloadScene.canceled += instance.OnReloadScene;
                @Damage.started += instance.OnDamage;
                @Damage.performed += instance.OnDamage;
                @Damage.canceled += instance.OnDamage;
            }
        }
    }
    public PlayeractionsActions @Playeractions => new PlayeractionsActions(this);
    public interface IPlayerShootActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
    public interface IPlayeractionsActions
    {
        void OnPick(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnReloadScene(InputAction.CallbackContext context);
        void OnDamage(InputAction.CallbackContext context);
    }
}
