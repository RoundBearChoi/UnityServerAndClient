﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class NetworkManager : MonoBehaviour
    {
        [SerializeField]
        ClientData[] clients = null;

        public static NetworkManager instance;

        public GameObject playerPrefab;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.Log("Instance already exists, destroying object!");
                Destroy(this);
            }
        }

        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;

            Server.Start(26950);

            clients = Server.clients;
        }

        private void OnApplicationQuit()
        {
            Server.Stop();
        }

        public Player InstantiatePlayer()
        {
            return Instantiate(playerPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity).GetComponent<Player>();
        }
    }
}