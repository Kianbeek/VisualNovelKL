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

        private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);

       void Start()
        {
            //Character Mane = CharacterManager.instance.CreateCharacter("Mane");
            //Character Reo = CharacterManager.instance.CreateCharacter("Reo");
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            /*            Character Kian = CharacterManager.instance.CreateCharacter("Kian");
                        Character Jasha = CharacterManager.instance.CreateCharacter("Jasha");
                        Character Damian = CharacterManager.instance.CreateCharacter("Damian");

                        List<string> lines = new List<string>()
                        {
                            "\"Hi!\"",
                            "This is a line.",
                            "And andother.",
                            "And a last one."
                        };
                        yield return Kian.Say(lines);

                        Kian.SetNameColor(Color.blue);
                        Kian.SetDialogueColor(Color.green);
                        Kian.SetNameFont(tempFont);
                        Kian.SetDialogueFont(tempFont);

                        yield return Kian.Say(lines);

                        Kian.ResetConfigurationData();

                        yield return Kian.Say(lines);

                        lines = new List<string>()
                        {
                            "I am Jasha",
                            "More lines {c} Here."
                        };
                        yield return Jasha.Say(lines);

                        lines = new List<string>()
                        {
                            "I am Damian",
                            "More lines {c} Here."
                        };
                        yield return Damian.Say(lines);

                        Debug.Log("Finished");*/
            /*   yield return new WaitForSeconds(1f);

               Character Mane = CharacterManager.instance.CreateCharacter("Mane");

               yield return new WaitForSeconds(1f);

               yield return Mane.Hide();

               yield return new WaitForSeconds(1f);

               yield return Mane.Show();

               yield return Mane.Say("Hello!");*/
            /*Character Mane = CreateCharacter("Mane");
            Character Mane2 = CreateCharacter("Mane2 as Mane");

            Mane.Show();
            Mane2.Show();

            yield return null;*/

/*            Character_Sprite Mane = CreateCharacter("Mane") as Character_Sprite;
            

            Mane.Show();

            Sprite faceSprite = Mane.GetSprite("Anger");

            Mane.SetSprite(faceSprite);
  
            //faceSprite = Mane.GetSprite("Happy");

            yield return new WaitForSeconds(2f);

            faceSprite = Mane.GetSprite("Happy");

            Mane.SetSprite(faceSprite);*/

            Character_Sprite Mane = CreateCharacter("Mane") as Character_Sprite;

            yield return new WaitForSeconds(1);

            Mane.Show();

            Sprite face = Mane.GetSprite("Happy");
            Mane.TransitionSprite(face);
            yield return Mane.TransitionSprite(face);

            Debug.Log($"Visible = {Mane.isVisible}");

            yield return new WaitForSeconds(1);

            Mane.TransitionSprite(Mane.GetSprite("Anger"));



            yield return null;
        }    
    }
}
