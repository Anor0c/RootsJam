// GENERATED AUTOMATICALLY FROM 'Assets/Leonard/InputMaps/RacineControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @RacineControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @RacineControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RacineControl"",
    ""maps"": [
        {
            ""name"": ""RacineGameplay"",
            ""id"": ""23901a0b-e35b-4f9d-bc92-309c669ba207"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8d53dbfa-57e8-4682-a13c-0cadd58010c4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bdb6257a-7eac-45eb-9379-206a64b65c36"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SpawnChoice"",
            ""id"": ""57666dd3-28f3-414b-8f4b-6c3e97e1d377"",
            ""actions"": [
                {
                    ""name"": ""SelectSpawnRight"",
                    ""type"": ""Button"",
                    ""id"": ""0848f82d-3e05-44c7-948c-38f84cbffb0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectSpawnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""7c5a8c84-d02c-41cc-9524-39ff7a3f70e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f2ac279-f4fd-4edf-8a60-f309b5fbbbce"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSpawnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aefd384-9a6c-4037-a869-de9da48e7050"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSpawnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f159a708-1f1e-43a2-aedf-5aa7da497cc4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSpawnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""945f18dc-3a3a-445e-a502-dade2867999a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSpawnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RacineGameplay
        m_RacineGameplay = asset.FindActionMap("RacineGameplay", throwIfNotFound: true);
        m_RacineGameplay_Move = m_RacineGameplay.FindAction("Move", throwIfNotFound: true);
        // SpawnChoice
        m_SpawnChoice = asset.FindActionMap("SpawnChoice", throwIfNotFound: true);
        m_SpawnChoice_SelectSpawnRight = m_SpawnChoice.FindAction("SelectSpawnRight", throwIfNotFound: true);
        m_SpawnChoice_SelectSpawnLeft = m_SpawnChoice.FindAction("SelectSpawnLeft", throwIfNotFound: true);
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

    // RacineGameplay
    private readonly InputActionMap m_RacineGameplay;
    private IRacineGameplayActions m_RacineGameplayActionsCallbackInterface;
    private readonly InputAction m_RacineGameplay_Move;
    public struct RacineGameplayActions
    {
        private @RacineControl m_Wrapper;
        public RacineGameplayActions(@RacineControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_RacineGameplay_Move;
        public InputActionMap Get() { return m_Wrapper.m_RacineGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RacineGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IRacineGameplayActions instance)
        {
            if (m_Wrapper.m_RacineGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_RacineGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_RacineGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_RacineGameplayActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_RacineGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public RacineGameplayActions @RacineGameplay => new RacineGameplayActions(this);

    // SpawnChoice
    private readonly InputActionMap m_SpawnChoice;
    private ISpawnChoiceActions m_SpawnChoiceActionsCallbackInterface;
    private readonly InputAction m_SpawnChoice_SelectSpawnRight;
    private readonly InputAction m_SpawnChoice_SelectSpawnLeft;
    public struct SpawnChoiceActions
    {
        private @RacineControl m_Wrapper;
        public SpawnChoiceActions(@RacineControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectSpawnRight => m_Wrapper.m_SpawnChoice_SelectSpawnRight;
        public InputAction @SelectSpawnLeft => m_Wrapper.m_SpawnChoice_SelectSpawnLeft;
        public InputActionMap Get() { return m_Wrapper.m_SpawnChoice; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpawnChoiceActions set) { return set.Get(); }
        public void SetCallbacks(ISpawnChoiceActions instance)
        {
            if (m_Wrapper.m_SpawnChoiceActionsCallbackInterface != null)
            {
                @SelectSpawnRight.started -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnRight;
                @SelectSpawnRight.performed -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnRight;
                @SelectSpawnRight.canceled -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnRight;
                @SelectSpawnLeft.started -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnLeft;
                @SelectSpawnLeft.performed -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnLeft;
                @SelectSpawnLeft.canceled -= m_Wrapper.m_SpawnChoiceActionsCallbackInterface.OnSelectSpawnLeft;
            }
            m_Wrapper.m_SpawnChoiceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectSpawnRight.started += instance.OnSelectSpawnRight;
                @SelectSpawnRight.performed += instance.OnSelectSpawnRight;
                @SelectSpawnRight.canceled += instance.OnSelectSpawnRight;
                @SelectSpawnLeft.started += instance.OnSelectSpawnLeft;
                @SelectSpawnLeft.performed += instance.OnSelectSpawnLeft;
                @SelectSpawnLeft.canceled += instance.OnSelectSpawnLeft;
            }
        }
    }
    public SpawnChoiceActions @SpawnChoice => new SpawnChoiceActions(this);
    public interface IRacineGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ISpawnChoiceActions
    {
        void OnSelectSpawnRight(InputAction.CallbackContext context);
        void OnSelectSpawnLeft(InputAction.CallbackContext context);
    }
}
