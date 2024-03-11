//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/99. ETC/Setting/Input/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""52f4bc63-a482-41e6-b60d-d37a45d069ef"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""07e28f3d-16a2-4e45-a4e6-e644bd310a54"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""d67c2640-6b6a-47be-938b-6920499259f1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cf4605df-c4f6-43ed-877b-a2894af07fc0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3efd9a77-54ae-4a29-9a20-4febc72c6c75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Collect"",
                    ""type"": ""Button"",
                    ""id"": ""70cdef10-d561-43ba-968a-562975dc5d16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""eb5bef7f-7501-4139-8830-1bc7f69fa159"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""bd18a8a7-2509-4e56-9019-ed33c2bb4312"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""032397b5-70b7-42cc-8e65-3820394f40c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""76cd7dc6-c0d1-42c3-8b89-53c14454a4cb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""46a37dab-6f7b-46f6-9d9b-a54fad2d9a06"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard&mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ba668cc9-be3a-4d18-ac0e-8914b2cd6f4e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard&mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8a824fa2-4252-477d-9b76-1eb432e45d9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard&mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c13b0837-f7ad-422a-a86f-3c732497d0ab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard&mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dfddb0c3-698e-42ab-8c31-fdbb6d342d11"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1157c0d8-3bc3-4c63-9aaa-f8fc87b2e734"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fea652c-d836-4d4a-b42e-747d3b359059"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""277fcc5c-45ad-4d47-a8a5-01d014e3e44a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d1a3fb2-1bc2-4605-bbaa-e1abc732d0ce"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ba4d953-63a5-47b4-8399-13e6b598a957"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14f7b672-efff-400b-8855-8843b020def8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MiniGame"",
            ""id"": ""dea00e81-aae5-4ef8-a0c1-05f201497227"",
            ""actions"": [
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""4cf45c21-be9e-4679-8909-c9ed4334275f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""4a51c533-f2a2-4dce-a109-b3231f036a2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""c7f33070-028f-4d25-a761-690aa1bec95b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61267d66-ac4c-4e52-8766-4f06c0462096"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ba3b945-2660-4d18-860a-cdd32b3519be"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8c8bb6a-803a-4fb4-9bb5-dddb406dc32c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ship"",
            ""id"": ""fb620dea-32fe-4add-b414-8133c36f7323"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ae95a57d-2ae5-48c4-8988-ccf8ac52df2c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""0e0d53b1-4801-4680-8275-7d63ef9147b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""cfabaeca-608d-4d06-9aed-22d3a1f7e890"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1e98e062-ea7f-4942-acd8-a192033015a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a6fdb524-8b44-4d9a-8c7c-8bb713d3ab8a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""37724033-3f66-47a0-b714-b5688036d90d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5bbd8ade-fcef-428f-be19-d5c64a23a82e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e1f5f762-98dc-482c-86bf-0eefbd01f9ef"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""a5ab87ea-cc23-4c59-9ed8-43af8be7ec34"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""a03c0225-0016-4628-ac1b-7de33568861a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""76f1a4a3-ab95-4db6-a924-2fdea722c980"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard&mouse"",
            ""bindingGroup"": ""keyboard&mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Play
        m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
        m_Play_Move = m_Play.FindAction("Move", throwIfNotFound: true);
        m_Play_MouseDelta = m_Play.FindAction("MouseDelta", throwIfNotFound: true);
        m_Play_MouseWheel = m_Play.FindAction("MouseWheel", throwIfNotFound: true);
        m_Play_Jump = m_Play.FindAction("Jump", throwIfNotFound: true);
        m_Play_Collect = m_Play.FindAction("Collect", throwIfNotFound: true);
        m_Play_Interact = m_Play.FindAction("Interact", throwIfNotFound: true);
        m_Play_Fire = m_Play.FindAction("Fire", throwIfNotFound: true);
        m_Play_Run = m_Play.FindAction("Run", throwIfNotFound: true);
        // MiniGame
        m_MiniGame = asset.FindActionMap("MiniGame", throwIfNotFound: true);
        m_MiniGame_Space = m_MiniGame.FindAction("Space", throwIfNotFound: true);
        m_MiniGame_A = m_MiniGame.FindAction("A", throwIfNotFound: true);
        m_MiniGame_D = m_MiniGame.FindAction("D", throwIfNotFound: true);
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Move = m_Ship.FindAction("Move", throwIfNotFound: true);
        m_Ship_F = m_Ship.FindAction("F", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Escape = m_UI.FindAction("Escape", throwIfNotFound: true);
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

    // Play
    private readonly InputActionMap m_Play;
    private List<IPlayActions> m_PlayActionsCallbackInterfaces = new List<IPlayActions>();
    private readonly InputAction m_Play_Move;
    private readonly InputAction m_Play_MouseDelta;
    private readonly InputAction m_Play_MouseWheel;
    private readonly InputAction m_Play_Jump;
    private readonly InputAction m_Play_Collect;
    private readonly InputAction m_Play_Interact;
    private readonly InputAction m_Play_Fire;
    private readonly InputAction m_Play_Run;
    public struct PlayActions
    {
        private @Controls m_Wrapper;
        public PlayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Play_Move;
        public InputAction @MouseDelta => m_Wrapper.m_Play_MouseDelta;
        public InputAction @MouseWheel => m_Wrapper.m_Play_MouseWheel;
        public InputAction @Jump => m_Wrapper.m_Play_Jump;
        public InputAction @Collect => m_Wrapper.m_Play_Collect;
        public InputAction @Interact => m_Wrapper.m_Play_Interact;
        public InputAction @Fire => m_Wrapper.m_Play_Fire;
        public InputAction @Run => m_Wrapper.m_Play_Run;
        public InputActionMap Get() { return m_Wrapper.m_Play; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
        public void AddCallbacks(IPlayActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @MouseDelta.started += instance.OnMouseDelta;
            @MouseDelta.performed += instance.OnMouseDelta;
            @MouseDelta.canceled += instance.OnMouseDelta;
            @MouseWheel.started += instance.OnMouseWheel;
            @MouseWheel.performed += instance.OnMouseWheel;
            @MouseWheel.canceled += instance.OnMouseWheel;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Collect.started += instance.OnCollect;
            @Collect.performed += instance.OnCollect;
            @Collect.canceled += instance.OnCollect;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
        }

        private void UnregisterCallbacks(IPlayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @MouseDelta.started -= instance.OnMouseDelta;
            @MouseDelta.performed -= instance.OnMouseDelta;
            @MouseDelta.canceled -= instance.OnMouseDelta;
            @MouseWheel.started -= instance.OnMouseWheel;
            @MouseWheel.performed -= instance.OnMouseWheel;
            @MouseWheel.canceled -= instance.OnMouseWheel;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Collect.started -= instance.OnCollect;
            @Collect.performed -= instance.OnCollect;
            @Collect.canceled -= instance.OnCollect;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
        }

        public void RemoveCallbacks(IPlayActions instance)
        {
            if (m_Wrapper.m_PlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayActions @Play => new PlayActions(this);

    // MiniGame
    private readonly InputActionMap m_MiniGame;
    private List<IMiniGameActions> m_MiniGameActionsCallbackInterfaces = new List<IMiniGameActions>();
    private readonly InputAction m_MiniGame_Space;
    private readonly InputAction m_MiniGame_A;
    private readonly InputAction m_MiniGame_D;
    public struct MiniGameActions
    {
        private @Controls m_Wrapper;
        public MiniGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Space => m_Wrapper.m_MiniGame_Space;
        public InputAction @A => m_Wrapper.m_MiniGame_A;
        public InputAction @D => m_Wrapper.m_MiniGame_D;
        public InputActionMap Get() { return m_Wrapper.m_MiniGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiniGameActions set) { return set.Get(); }
        public void AddCallbacks(IMiniGameActions instance)
        {
            if (instance == null || m_Wrapper.m_MiniGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MiniGameActionsCallbackInterfaces.Add(instance);
            @Space.started += instance.OnSpace;
            @Space.performed += instance.OnSpace;
            @Space.canceled += instance.OnSpace;
            @A.started += instance.OnA;
            @A.performed += instance.OnA;
            @A.canceled += instance.OnA;
            @D.started += instance.OnD;
            @D.performed += instance.OnD;
            @D.canceled += instance.OnD;
        }

        private void UnregisterCallbacks(IMiniGameActions instance)
        {
            @Space.started -= instance.OnSpace;
            @Space.performed -= instance.OnSpace;
            @Space.canceled -= instance.OnSpace;
            @A.started -= instance.OnA;
            @A.performed -= instance.OnA;
            @A.canceled -= instance.OnA;
            @D.started -= instance.OnD;
            @D.performed -= instance.OnD;
            @D.canceled -= instance.OnD;
        }

        public void RemoveCallbacks(IMiniGameActions instance)
        {
            if (m_Wrapper.m_MiniGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMiniGameActions instance)
        {
            foreach (var item in m_Wrapper.m_MiniGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MiniGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MiniGameActions @MiniGame => new MiniGameActions(this);

    // Ship
    private readonly InputActionMap m_Ship;
    private List<IShipActions> m_ShipActionsCallbackInterfaces = new List<IShipActions>();
    private readonly InputAction m_Ship_Move;
    private readonly InputAction m_Ship_F;
    public struct ShipActions
    {
        private @Controls m_Wrapper;
        public ShipActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Ship_Move;
        public InputAction @F => m_Wrapper.m_Ship_F;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void AddCallbacks(IShipActions instance)
        {
            if (instance == null || m_Wrapper.m_ShipActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShipActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @F.started += instance.OnF;
            @F.performed += instance.OnF;
            @F.canceled += instance.OnF;
        }

        private void UnregisterCallbacks(IShipActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @F.started -= instance.OnF;
            @F.performed -= instance.OnF;
            @F.canceled -= instance.OnF;
        }

        public void RemoveCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShipActions instance)
        {
            foreach (var item in m_Wrapper.m_ShipActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShipActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShipActions @Ship => new ShipActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Escape;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_UI_Escape;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_keyboardmouseSchemeIndex = -1;
    public InputControlScheme keyboardmouseScheme
    {
        get
        {
            if (m_keyboardmouseSchemeIndex == -1) m_keyboardmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard&mouse");
            return asset.controlSchemes[m_keyboardmouseSchemeIndex];
        }
    }
    public interface IPlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMouseWheel(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCollect(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface IMiniGameActions
    {
        void OnSpace(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
    }
    public interface IShipActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}
