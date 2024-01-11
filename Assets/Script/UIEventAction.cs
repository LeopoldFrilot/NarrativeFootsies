using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Footsies
{
    public class UIEventAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        public enum Action
        {
            LoadVsCPU,
            LoadVsPlayer,
            ExitGame,
            BGMToggle,
            SEToggle,
            LoadCampaign,
            ReturnToStart
        }

        public Action action;

        private void Awake()
        {
            if(action == Action.BGMToggle)
            {
                var toggle = gameObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    toggle.isOn = SoundManager.Instance.isBGMOn;
                }
            }
        }

        public void InvokeAction()
        {
            switch(action)
            {
                case Action.LoadVsCPU:
                    LoadVsCPU();
                    break;
                case Action.LoadVsPlayer:
                    LoadVsPlayer();
                    break;
                case Action.ExitGame:
                    ExitGame();
                    break;
                case Action.BGMToggle:
                    toggleBGM();
                    break;
                case Action.SEToggle:
                    break;
                case Action.LoadCampaign:
                    LoadCampaign();
                    break;
                case Action.ReturnToStart:
                    LoadStartScene();
                    break;
            }
        }

        private void LoadStartScene()
        {
            GameManager.Instance.LoadTitleScene();
        }

        private void LoadVsCPU()
        {
            GameManager.Instance.LoadVsCPUScene();
        }

        private void LoadVsPlayer()
        {
            GameManager.Instance.LoadVsPlayerScene();
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void LoadCampaign()
        {
            GameManager.Instance.LoadCampaign();
        }

        private void toggleBGM()
        {
            var isOn = SoundManager.Instance.toggleBGM();
            var toggle = gameObject.GetComponent<Toggle>();
            if(toggle != null)
            {
                toggle.isOn = isOn;
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }

}