using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Controllers
{
    public class BaseGamerController : MonoBehaviour
    {
        protected GameManager manager;
        
        public void Init(GameManager manager)
        {
            this.manager = manager;
        }
    }
}
