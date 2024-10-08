//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Game/Scripts/Input/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""JetControls"",
            ""id"": ""a737afdc-b3f4-43d8-9886-53c2228cb8ac"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""7aa84a29-0003-454b-a4d5-59f364bc2ea7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ThrottleAxis"",
                    ""type"": ""Value"",
                    ""id"": ""b3ba650f-4fb3-4658-a7c1-9338c249eb1c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PitchAxis"",
                    ""type"": ""Value"",
                    ""id"": ""ebaf558d-5226-4986-a2d9-0b5e7620e04d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""YawAxis"",
                    ""type"": ""Value"",
                    ""id"": ""a7100ae4-9762-4a05-aa73-ca9f5751ee95"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RollAxis"",
                    ""type"": ""Value"",
                    ""id"": ""8c046d48-9418-45ab-addf-2dac4277c14c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""422f46cb-5d39-4f05-91d7-4390ddc43b37"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Yaw"",
                    ""id"": ""77784225-d717-47da-ae94-609ad968b81c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""70d5f332-cf96-4b32-b04d-422e35cef136"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b7e8e241-9e2b-49d3-86d7-94a353cc2e16"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Throttle"",
                    ""id"": ""c0e78c06-d69e-4305-a9af-8cbb757277c0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""08acbfe8-2059-4cf7-8cf8-1299cca354c1"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""264fb889-d4c5-4298-a691-d50bc4f34904"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Pitch"",
                    ""id"": ""6b1a21a6-e0cf-474b-a80a-9a2f116b1955"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PitchAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""30c920b5-42a8-4dd7-81a9-f0c6cda1211e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PitchAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""30b388e7-9064-446f-ad54-da71cbdaa36f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PitchAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Roll"",
                    ""id"": ""539dad95-e1e7-4c0b-b49d-46525c4c2d1e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""71494b86-b0bb-48a9-b9ec-b21f5807ee0c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""826459d2-6351-45a0-b358-db9dcd33cf92"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Weapons"",
            ""id"": ""59c38a1d-b5fb-42f7-843d-0975a9645d7f"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""43941da2-47e3-4449-be55-f053af4983ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df39917e-e62e-45e3-bcff-b83cca67cd91"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // JetControls
        m_JetControls = asset.FindActionMap("JetControls", throwIfNotFound: true);
        m_JetControls_Mouse = m_JetControls.FindAction("Mouse", throwIfNotFound: true);
        m_JetControls_ThrottleAxis = m_JetControls.FindAction("ThrottleAxis", throwIfNotFound: true);
        m_JetControls_PitchAxis = m_JetControls.FindAction("PitchAxis", throwIfNotFound: true);
        m_JetControls_YawAxis = m_JetControls.FindAction("YawAxis", throwIfNotFound: true);
        m_JetControls_RollAxis = m_JetControls.FindAction("RollAxis", throwIfNotFound: true);
        // Weapons
        m_Weapons = asset.FindActionMap("Weapons", throwIfNotFound: true);
        m_Weapons_Newaction = m_Weapons.FindAction("New action", throwIfNotFound: true);
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

    // JetControls
    private readonly InputActionMap m_JetControls;
    private List<IJetControlsActions> m_JetControlsActionsCallbackInterfaces = new List<IJetControlsActions>();
    private readonly InputAction m_JetControls_Mouse;
    private readonly InputAction m_JetControls_ThrottleAxis;
    private readonly InputAction m_JetControls_PitchAxis;
    private readonly InputAction m_JetControls_YawAxis;
    private readonly InputAction m_JetControls_RollAxis;
    public struct JetControlsActions
    {
        private @PlayerControls m_Wrapper;
        public JetControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_JetControls_Mouse;
        public InputAction @ThrottleAxis => m_Wrapper.m_JetControls_ThrottleAxis;
        public InputAction @PitchAxis => m_Wrapper.m_JetControls_PitchAxis;
        public InputAction @YawAxis => m_Wrapper.m_JetControls_YawAxis;
        public InputAction @RollAxis => m_Wrapper.m_JetControls_RollAxis;
        public InputActionMap Get() { return m_Wrapper.m_JetControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JetControlsActions set) { return set.Get(); }
        public void AddCallbacks(IJetControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_JetControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JetControlsActionsCallbackInterfaces.Add(instance);
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
            @ThrottleAxis.started += instance.OnThrottleAxis;
            @ThrottleAxis.performed += instance.OnThrottleAxis;
            @ThrottleAxis.canceled += instance.OnThrottleAxis;
            @PitchAxis.started += instance.OnPitchAxis;
            @PitchAxis.performed += instance.OnPitchAxis;
            @PitchAxis.canceled += instance.OnPitchAxis;
            @YawAxis.started += instance.OnYawAxis;
            @YawAxis.performed += instance.OnYawAxis;
            @YawAxis.canceled += instance.OnYawAxis;
            @RollAxis.started += instance.OnRollAxis;
            @RollAxis.performed += instance.OnRollAxis;
            @RollAxis.canceled += instance.OnRollAxis;
        }

        private void UnregisterCallbacks(IJetControlsActions instance)
        {
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
            @ThrottleAxis.started -= instance.OnThrottleAxis;
            @ThrottleAxis.performed -= instance.OnThrottleAxis;
            @ThrottleAxis.canceled -= instance.OnThrottleAxis;
            @PitchAxis.started -= instance.OnPitchAxis;
            @PitchAxis.performed -= instance.OnPitchAxis;
            @PitchAxis.canceled -= instance.OnPitchAxis;
            @YawAxis.started -= instance.OnYawAxis;
            @YawAxis.performed -= instance.OnYawAxis;
            @YawAxis.canceled -= instance.OnYawAxis;
            @RollAxis.started -= instance.OnRollAxis;
            @RollAxis.performed -= instance.OnRollAxis;
            @RollAxis.canceled -= instance.OnRollAxis;
        }

        public void RemoveCallbacks(IJetControlsActions instance)
        {
            if (m_Wrapper.m_JetControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJetControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_JetControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JetControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JetControlsActions @JetControls => new JetControlsActions(this);

    // Weapons
    private readonly InputActionMap m_Weapons;
    private List<IWeaponsActions> m_WeaponsActionsCallbackInterfaces = new List<IWeaponsActions>();
    private readonly InputAction m_Weapons_Newaction;
    public struct WeaponsActions
    {
        private @PlayerControls m_Wrapper;
        public WeaponsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Weapons_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Weapons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponsActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IWeaponsActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IWeaponsActions instance)
        {
            if (m_Wrapper.m_WeaponsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponsActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponsActions @Weapons => new WeaponsActions(this);
    public interface IJetControlsActions
    {
        void OnMouse(InputAction.CallbackContext context);
        void OnThrottleAxis(InputAction.CallbackContext context);
        void OnPitchAxis(InputAction.CallbackContext context);
        void OnYawAxis(InputAction.CallbackContext context);
        void OnRollAxis(InputAction.CallbackContext context);
    }
    public interface IWeaponsActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
