using UnityEngine;

using Esuriru.Utility;

namespace Esuriru.Stats
{
    [CreateAssetMenu(menuName = "Scriptable Object/Stat Type",
        fileName = "Stat Type")]
    public sealed class StatType : ScriptableObject
    {
        #region Serialized
        /// <summary>
        /// Enabled when name of stat type differs from Scriptable Object name
        /// </summary>
        [Header("Data")]
        [SerializeField]
        [Tooltip("Enable this when you want to have a name that differs from " +
            "the scriptable object")]
        private bool _enableCustomName;

        [ShowIf("_enableCustomName", true, disableType:
            ShowIfAttribute.Type.ReadOnly)]
        [SerializeField]
        private string _name;

        #endregion

        #region Public

        /// <summary>
        /// Name of the stat type, e.g Health
        /// </summary>
        public string Name
        {
            get
            {
                // In the event that the name is not filled in at runtime,
                // through one of Unity's message methods, initialize
                // the name before returning  
                if (string.IsNullOrWhiteSpace(_name))
                {
                    InitName(false);
                }
                return _name;
            }
            private set => _name = value;
        }

        #endregion

        #region Private

        /// <summary>
        /// Initializes the name field
        /// </summary>
        /// <param name="checkEmpty">Preliminary check</param>
        private void InitName(bool checkEmpty = true)
        {
            if (!checkEmpty || string.IsNullOrWhiteSpace(_name))
            {
                _name = name;
            }
        }

        /// <summary>
        /// Editor only unity message to fill in `Name` property
        /// </summary>
        private void OnValidate()
        {
            Init();
        }

        /// <summary>
        /// Editor and runtime unity message to fill in `Name` property
        /// </summary>
        private void OnEnable()
        {
            Init();
        }

        /// <summary>
        /// Editor and runtime unity message to fill in `Name` property
        /// </summary>
        private void Awake()
        {
            Init();
        }

        /// <summary>
        /// Initialization function
        /// </summary>
        private void Init()
        {
            // When custom name is enabled, we want to keep checking whether
            // the name is empty or not
            // When it is not enabled, we do not have to check because it
            // will be forced to initialize with the name
            // of the Scriptable Object
            InitName(_enableCustomName);
        }

        #endregion
    }
}