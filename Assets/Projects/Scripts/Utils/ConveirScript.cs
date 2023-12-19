using UnityEngine;

namespace Utils
{
    public class ConveirScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public float speed;
    
        private Rigidbody _rigidBody;
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 pos = _rigidBody.position;
            _rigidBody.position += Vector3.left * (speed * Time.fixedDeltaTime);
            _rigidBody.MovePosition(pos);
        }
    }
}
