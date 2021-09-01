using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        bool[] _inputs = null;

        private void FixedUpdate()
        {
            SendInputToServer();
        }

        /// <summary>Sends player input to the server.</summary>
        private void SendInputToServer()
        {
            if (_inputs == null || _inputs.Length == 0)
            {
                _inputs = new bool[5];
            }

            _inputs[0] = Input.GetKey(KeyCode.W);
            _inputs[1] = Input.GetKey(KeyCode.S);
            _inputs[2] = Input.GetKey(KeyCode.A);
            _inputs[3] = Input.GetKey(KeyCode.D);
            _inputs[4] = Input.GetKey(KeyCode.Space);

            ClientSend.PlayerMovement(_inputs);
        }
    }
}