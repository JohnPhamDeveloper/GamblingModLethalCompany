﻿using UnityEngine;
using UnityEngine.UI;

namespace GamblersMod.Patches
{
    public class PlayerGamblingUIManager : MonoBehaviour
    {
        // UI Utility
        GameObject gamblingMachineInteractionTextCanvasObject;
        Canvas gamblingMachineInteractionTextCanvas;
        GameObject gamblingMachineInteractionTextObject;
        GameObject gamblingMachineInteractionScrapInfoTextObject;
        Text gamblingMachineInteractionScrapInfoText;
        Text gamblingMachineInteractionText;

        string interactionName;
        string interactionText;

        public PlayerGamblingUIManager()
        {
            // Gambling Interaction GUI
            gamblingMachineInteractionTextCanvasObject = new GameObject();

            interactionName = "gamblingMachine";
            interactionText = "Press E to gamble";

            gamblingMachineInteractionTextCanvasObject.name = $"{interactionName}InteractionTextCanvasObject";
            gamblingMachineInteractionTextCanvasObject.AddComponent<Canvas>();
            gamblingMachineInteractionTextCanvasObject.SetActive(false);

            gamblingMachineInteractionTextCanvas = gamblingMachineInteractionTextCanvasObject.GetComponent<Canvas>();
            gamblingMachineInteractionTextCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            gamblingMachineInteractionTextCanvasObject.AddComponent<CanvasScaler>();
            gamblingMachineInteractionTextCanvasObject.AddComponent<GraphicRaycaster>();

            // Title
            gamblingMachineInteractionTextObject = new GameObject();
            gamblingMachineInteractionTextObject.name = $"{interactionName}InteractionTextObject";
            gamblingMachineInteractionTextObject.AddComponent<Text>();
            gamblingMachineInteractionTextObject.transform.localPosition = new Vector3((gamblingMachineInteractionTextCanvas.GetComponent<RectTransform>().rect.width / 2) - 20, (gamblingMachineInteractionTextCanvas.GetComponent<RectTransform>().rect.height / 2) - 50, 0);

            gamblingMachineInteractionText = gamblingMachineInteractionTextObject.GetComponent<Text>();
            gamblingMachineInteractionText.text = interactionText;
            gamblingMachineInteractionText.alignment = TextAnchor.MiddleCenter;
            gamblingMachineInteractionText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            gamblingMachineInteractionText.rectTransform.sizeDelta = new Vector2(300, 200);
            gamblingMachineInteractionText.fontSize = 26;

            gamblingMachineInteractionText.transform.parent = gamblingMachineInteractionTextCanvasObject.transform;

            // Subtitle
            gamblingMachineInteractionScrapInfoTextObject = new GameObject();
            gamblingMachineInteractionScrapInfoTextObject.name = $"{interactionName}InteractionScrapInfoTextObject";
            gamblingMachineInteractionScrapInfoTextObject.AddComponent<Text>();
            gamblingMachineInteractionScrapInfoTextObject.transform.localPosition = new Vector3((gamblingMachineInteractionTextCanvas.GetComponent<RectTransform>().rect.width / 2) - 20, (gamblingMachineInteractionTextCanvas.GetComponent<RectTransform>().rect.height / 2) - 100, 0);

            gamblingMachineInteractionScrapInfoText = gamblingMachineInteractionScrapInfoTextObject.GetComponent<Text>();
            gamblingMachineInteractionScrapInfoText.text = interactionText;
            gamblingMachineInteractionScrapInfoText.alignment = TextAnchor.MiddleCenter;
            gamblingMachineInteractionScrapInfoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            gamblingMachineInteractionScrapInfoText.rectTransform.sizeDelta = new Vector2(300, 200);
            gamblingMachineInteractionScrapInfoText.fontSize = 15;
            gamblingMachineInteractionScrapInfoText.color = Color.green;

            gamblingMachineInteractionScrapInfoText.transform.parent = gamblingMachineInteractionTextCanvasObject.transform;

            // Render interaction text on player canvas
            UnityEngine.Object.Instantiate(gamblingMachineInteractionTextCanvasObject);
        }

        public void SetInteractionText(string text)
        {
            gamblingMachineInteractionText.text = text;
        }

        public void SetInteractionSubText(string text)
        {
            gamblingMachineInteractionScrapInfoText.text = text;
        }

        public void ShowInteractionText()
        {
            gamblingMachineInteractionTextCanvasObject.SetActive(true);
        }

        public void HideInteractionText()
        {
            gamblingMachineInteractionTextCanvasObject.SetActive(false);
        }
    }
}
