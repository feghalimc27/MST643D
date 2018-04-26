using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class DialogueParser : MonoBehaviour {

    struct DialogueLine
    {
        public string name;
        public string content;
        public string position;
        public string[] options;

        public DialogueLine(string Name, string Content, string Position)
        {
            name = Name;
            content = Content;
            position = Position;
            options = new string[0];
        }
    }

    List<DialogueLine> lines;

    void Start()
    {
        string file = "Assets/All Scenes/8. Seeing Books/Dialogue";
        string sceneNum = EditorSceneManager.GetActiveScene().name;
        sceneNum = Regex.Replace(sceneNum, "[^0-9]", "");
        file += sceneNum;
        file += ".txt.";

        lines = new List<DialogueLine>();

        //LoadDialogue(file);
    }

}
