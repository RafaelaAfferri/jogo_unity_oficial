using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    private int currentStep = 0;
    private bool stepCompleted = false;

    private void Start()
    {
        tutorialText.text = "Use WASD para se movimentar.";
        Debug.Log("Tutorial iniciado. Texto: " + tutorialText.text);

    }

    void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
                    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    stepCompleted = true;
                }
                break;

            case 1:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    stepCompleted = true;
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    stepCompleted = true;
                }
                break;
        }

        if (stepCompleted)
        {
            AdvanceStep();
        }
    }

    void AdvanceStep()
    {
        stepCompleted = false;
        currentStep++;

        switch (currentStep)
        {
            case 1:
                tutorialText.text = "Use E para interagir com os puzzles.";
                break;
            case 2:
                tutorialText.text = "Use TAB para abrir o menu de pause";
                break;
            case 3:
                tutorialText.text = "Boa sorte!";
                StartCoroutine(HideTutorial(2f)); // Esconde depois de 2 segundos
                break;
        }
    }

    IEnumerator HideTutorial(float delay)
    {
        yield return new WaitForSeconds(delay);
        tutorialText.gameObject.SetActive(false);
    }
}
