using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Develop.Scripts.Common
{
    public class FadeCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _changeValue;

        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Image _loadingBar;


        private bool _isFadeStart;

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        public void FaderLoadString(string sceneName)
        {
            StartCoroutine(FadeOutString(sceneName));
        }

        public void FadeLoadInt(int sceneIndex)
        {
            StartCoroutine(FadeOutInt(sceneIndex));
        }

        private IEnumerator FadeIn()
        {
            _loadingScreen.SetActive(false);
            _isFadeStart = false;

            while (_canvasGroup.alpha > 0)
            {
                if (_isFadeStart)
                    yield break;

                _canvasGroup.alpha -= _changeValue;
                yield return new WaitForSeconds(_fadeDuration);
            }
        }

        private IEnumerator FadeOutString(string sceneName)
        {
            if (_isFadeStart)
                yield break;

            _isFadeStart = true;

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += _changeValue;
                yield return new WaitForSeconds(_fadeDuration);
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;
            _loadingScreen.SetActive(true);
            _loadingBar.fillAmount = 0;

            while (asyncOperation.isDone == false)
            {
                _loadingBar.fillAmount = asyncOperation.progress / 0.9f;

                if (asyncOperation.progress >= 0.9f)
                    asyncOperation.allowSceneActivation = true;

                yield return null;
            }

            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeOutInt(int sceneIndex)
        {
            if (_isFadeStart)
                yield break;

            _isFadeStart = true;

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += _changeValue;
                yield return new WaitForSeconds(_fadeDuration);
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;
            _loadingScreen.SetActive(true);
            _loadingBar.fillAmount = 0;

            while (asyncOperation.isDone == false)
            {
                _loadingBar.fillAmount = asyncOperation.progress / 0.9f;

                if (asyncOperation.progress >= 0.9f)
                    asyncOperation.allowSceneActivation = true;

                yield return null;
            }

            StartCoroutine(FadeIn());
        }
    }
}
