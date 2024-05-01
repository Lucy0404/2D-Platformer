using UnityEngine;

namespace Assets.Scripts
{
    public class GroundChecker : MonoBehaviour
    {
        public bool IsGrounded => isGrounded;

        private bool isGrounded = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            isGrounded = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isGrounded = false;
        }
    }
}