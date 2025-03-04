﻿using System;
using Loaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.TextControllers
{
    public class PressKeyToContinueText : MonoBehaviour
    {
        public Text text;
        
        [SerializeField] private KeyCode keyToPress;
        [SerializeField] private string nextSceneAddress;
        
        private ScenesLoader _scenesLoader;
        
        public static event Action OnClicked;

        [Inject]
        private void Construct(ScenesLoader scenesLoader)
        {
            _scenesLoader = scenesLoader;
        }

        private void Update()
        {
            EnableNextSceneLoading();
        }
        
        private void EnableNextSceneLoading()
        {
            if (Input.GetKeyDown(keyToPress))
            {
                OnClicked?.Invoke();
                StartCoroutine(_scenesLoader.LoadSceneCoroutine(nextSceneAddress));
            }
        }
    }
}