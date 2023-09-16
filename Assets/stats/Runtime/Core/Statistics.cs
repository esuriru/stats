using UnityEngine;

namespace Esuriru.Stats
{
    [CreateAssetMenu(menuName = "Scriptable Object/Statistics",
        fileName = "Statistics")]
    public class Statistics : ScriptableObject
    {
        [SerializeField]
        private bool _isShared; 

          
    }
}