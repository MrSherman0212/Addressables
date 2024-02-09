using UnityEngine;

namespace Project.Utility
{
    public class UndestroyableObj : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
