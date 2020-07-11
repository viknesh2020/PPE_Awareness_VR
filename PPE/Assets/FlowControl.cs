using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowControl : MonoBehaviour
{
    public GameObject[] appliedObjects;
    public GameObject[] objectsOnDesk;
    public GameObject[] labels;
    public GameObject personHands;
    public Material gloves;
    public GazePointer pointer;
    public TextMeshProUGUI instructionText;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in appliedObjects)
        {
            go.SetActive(false);
        }

        instructionText.SetText("Welcome ! Please follow the instructions shown here to proceed further.");
        StartCoroutine(InstructPerson());
    }

    IEnumerator InstructPerson()
    {
        yield return new WaitForSeconds(10);
        instructionText.SetText("Objective is to instruct the person to wear Personal Protective Equipments before entering the work place.");
        yield return new WaitForSeconds(8);
        instructionText.SetText("PPEs are placed infront of you on the table.");
        yield return new WaitForSeconds(10);
        instructionText.SetText("On gazing at each of the object, you can make them wear by the person.");
        yield return new WaitForSeconds(10);
        StartCoroutine(ApplyMask());
    }

    IEnumerator ApplyMask()
    {
        objectsOnDesk[0].tag = "wearable";
        instructionText.SetText("As a first step, gaze at the N95 mask placed on the table");
        yield return new WaitUntil(() => pointer.gazeComplete);
        appliedObjects[0].SetActive(true);
        objectsOnDesk[0].SetActive(false);
        labels[0].SetActive(false);
        objectsOnDesk[0].tag = "Player";
        pointer.gazeComplete = false;
        instructionText.SetText("Great! you have successfully instructed the person to wear mask and he is wearing it.");
        yield return new WaitForSeconds(10);
        StartCoroutine(ApplyGloves());
    }

    IEnumerator ApplyGloves()
    {
        objectsOnDesk[1].tag = "wearable";
        instructionText.SetText("Now gaze at the gloves on the table to make the person to wear that gloves.");
        yield return new WaitUntil(() => pointer.gazeComplete);
        personHands.GetComponent<SkinnedMeshRenderer>().material = gloves;
        objectsOnDesk[1].SetActive(false);
        labels[1].SetActive(false);
        objectsOnDesk[1].tag = "Player";
        pointer.gazeComplete = false;
        instructionText.SetText("Good Job! you have successfully instructed the person to wear gloves.");
        yield return new WaitForSeconds(10);
        StartCoroutine(ApplyShield());
    }

    IEnumerator ApplyShield()
    {
        objectsOnDesk[2].tag = "wearable";
        instructionText.SetText("Now, to protect further from spreading diseases, ask the person to wear the face shield");
        yield return new WaitUntil(() => pointer.gazeComplete);
        appliedObjects[1].SetActive(true);
        objectsOnDesk[2].SetActive(false);
        labels[2].SetActive(false);
        objectsOnDesk[2].tag = "Player";
        pointer.gazeComplete = false;
        instructionText.SetText("Nice!. The person is now protected from the spreading diseases.");
        yield return new WaitForSeconds(10);
        StartCoroutine(ApplyHelmet());
    }

    IEnumerator ApplyHelmet()
    {
        objectsOnDesk[3].tag = "wearable";
        instructionText.SetText("Final instruction before he enter into the workplace. Instruct him to wear the safety helmet.");
        yield return new WaitUntil(() => pointer.gazeComplete);
        appliedObjects[2].SetActive(true);
        objectsOnDesk[3].SetActive(false);
        labels[3].SetActive(false);
        objectsOnDesk[3].tag = "Player";
        pointer.gazeComplete = false;
        instructionText.SetText("Well done!. He is completely equiped with safety equipments. He can enter the workplace now.");
    }
}
