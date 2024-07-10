using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using TMPro;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        public TMP_FontAsset tempFont;

       void Start()
        {
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            Character Robin = CharacterManager.instance.CreateCharacter("Robin");
            Character Juliette = CharacterManager.instance.CreateCharacter("Juliette");
            Character Adam = CharacterManager.instance.CreateCharacter("Adam");

            List<string> lines = new List<string>()
            {
                "Robin \"Hi!\"",
                "This is a line.",
                "And andother.",
                "And a last one."
            };
            yield return Robin.Say(lines);

            Robin.SetNameColor(Color.blue);
            Robin.SetDialogueColor(Color.green);
            Robin.SetNameFont(tempFont);
            Robin.SetDialogueFont(tempFont);

            yield return Robin.Say(lines);

            Robin.ResetConfigurationData();

            yield return Robin.Say(lines);

            lines = new List<string>()
            {
                "I am Juliette",
                "More lines {c} Here."
            };
            yield return Juliette.Say(lines);

            lines = new List<string>()
            {
                "I am Adam",
                "More lines {c} Here."
            };
            yield return Adam.Say(lines);

            Debug.Log("Finished");
        }    
    }
}
