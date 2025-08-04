using Sirenix.OdinInspector;
using UnityEngine;

namespace Util {

    public class MonoSingleton<T> : SerializedMonoBehaviour	where T : Component
    {
        protected static T _instance;
        
        public static T Instance => _instance;

        protected virtual void Awake ()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (_instance != null)
            {
                return;
            }
            _instance = this as T;			
        }
    }
}