//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""ChopStick"",
            ""id"": ""e8be8f73-e10c-405a-aa20-1b88aed04ffe"",
            ""actions"": [
                {
                    ""name"": ""MouseInput"",
                    ""type"": ""Value"",
                    ""id"": ""47a7b341-b800-408a-99e1-d9f38cc51902"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""68cc7c22-88e4-4217-a130-30f51709956d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c76ba84-95a9-4c38-a9fb-3a9c2d33226e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e459c397-c4b4-4283-ba33-30d84fa47ec7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ChiliPepper"",
            ""id"": ""9868e165-4380-4fd8-9f93-3122c1a1fe5b"",
            ""actions"": [
                {
                    ""name"": ""KeyboardInput"",
                    ""type"": ""Value"",
                    ""id"": ""66f74098-807b-480a-8406-206c7a84801b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d39f6399-47b0-44c5-97a3-14643f2a6f5e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2c03aa1f-a613-4338-9590-8520c6193657"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""449d026e-5203-40b5-8e7c-87a9d7fe8914"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4743735b-6e8b-4753-9d8f-58adc74c846e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""33ad6d9d-874f-464f-a43f-7d4e8418efb1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ChopStick
        m_ChopStick = asset.FindActionMap("ChopStick", throwIfNotFound: true);
        m_ChopStick_MouseInput = m_ChopStick.FindAction("MouseInput", throwIfNotFound: true);
        m_ChopStick_Click = m_ChopStick.FindAction("Click", throwIfNotFound: true);
        // ChiliPepper
        m_ChiliPepper = asset.FindActionMap("ChiliPepper", throwIfNotFound: true);
        m_ChiliPepper_KeyboardInput = m_ChiliPepper.FindAction("KeyboardInput", throwIfNotFound: true);
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

    // ChopStick
    private readonly InputActionMap m_ChopStick;
    private IChopStickActions m_ChopStickActionsCallbackInterface;
    private readonly InputAction m_ChopStick_MouseInput;
    private readonly InputAction m_ChopStick_Click;
    public struct ChopStickActions
    {
        private @PlayerInput m_Wrapper;
        public ChopStickActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseInput => m_Wrapper.m_ChopStick_MouseInput;
        public InputAction @Click => m_Wrapper.m_ChopStick_Click;
        public InputActionMap Get() { return m_Wrapper.m_ChopStick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ChopStickActions set) { return set.Get(); }
        public void SetCallbacks(IChopStickActions instance)
        {
            if (m_Wrapper.m_ChopStickActionsCallbackInterface != null)
            {
                @MouseInput.started -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnMouseInput;
                @MouseInput.performed -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnMouseInput;
                @MouseInput.canceled -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnMouseInput;
                @Click.started -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_ChopStickActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_ChopStickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseInput.started += instance.OnMouseInput;
                @MouseInput.performed += instance.OnMouseInput;
                @MouseInput.canceled += instance.OnMouseInput;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public ChopStickActions @ChopStick => new ChopStickActions(this);

    // ChiliPepper
    private readonly InputActionMap m_ChiliPepper;
    private IChiliPepperActions m_ChiliPepperActionsCallbackInterface;
    private readonly InputAction m_ChiliPepper_KeyboardInput;
    public struct ChiliPepperActions
    {
        private @PlayerInput m_Wrapper;
        public ChiliPepperActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @KeyboardInput => m_Wrapper.m_ChiliPepper_KeyboardInput;
        public InputActionMap Get() { return m_Wrapper.m_ChiliPepper; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ChiliPepperActions set) { return set.Get(); }
        public void SetCallbacks(IChiliPepperActions instance)
        {
            if (m_Wrapper.m_ChiliPepperActionsCallbackInterface != null)
            {
                @KeyboardInput.started -= m_Wrapper.m_ChiliPepperActionsCallbackInterface.OnKeyboardInput;
                @KeyboardInput.performed -= m_Wrapper.m_ChiliPepperActionsCallbackInterface.OnKeyboardInput;
                @KeyboardInput.canceled -= m_Wrapper.m_ChiliPepperActionsCallbackInterface.OnKeyboardInput;
            }
            m_Wrapper.m_ChiliPepperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @KeyboardInput.started += instance.OnKeyboardInput;
                @KeyboardInput.performed += instance.OnKeyboardInput;
                @KeyboardInput.canceled += instance.OnKeyboardInput;
            }
        }
    }
    public ChiliPepperActions @ChiliPepper => new ChiliPepperActions(this);
    public interface IChopStickActions
    {
        void OnMouseInput(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IChiliPepperActions
    {
        void OnKeyboardInput(InputAction.CallbackContext context);
    }
}
