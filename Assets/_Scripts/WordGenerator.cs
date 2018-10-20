using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class WordGenerator {

    public static List<string> WordList = new List<string>();
    public static List<string> PhraseList = new List<string>();

    public static string[] data =
    {
        "coding your own games",
"cant wait to see what you make with this",
"null referance exception",
"off by one error",
"bits and bobs",
"what could possibly go wrong?",
"online learning",
"global game jam",
"github",
"visual studio",
"krita",
"adobe photoshop",
"bosca ceoil",
"substance painter",
"blender 3d",
"web gl",
"trello",
"game maker",
"evernote",
"discord",
"waka time",
"incompetech",
"kenny assets",
"open game art",
"vertex shader",
"fragment shader",
"vector3",
"vector2",
"rigidbody",
"oncollisionenter",
"ontriggerenter",
"unity pro",
"open source",
"made with unity",
"twitter",
"hashtags",
"indie game dev",
"asset store",
"free assets",
"paid assets",
"ludum dare",
"ad block",
"render pipeline",
"the theme always sucks",
"like and subscribe",
"getcomponent",
"findobjectoftype",
"happy accident",
"index out of range",
"special discount",
"refactor",
"comment",
"debug.log",
"fire of belief",
"beneath the skin",
"they have no choice!",
"packt publishing",
"rigidbody",
"raycasthit",
"shader",
"textmesh",
"debug",
"research",
"program",
"bootcamp",
"glossary",
"algorithm",
"apprenticeship",
"asynchronous",
"bootstrap",
"database",
"inheritance",
"framework",
"open-source",
"interface",
"synchronous",
"syntax",
"whiteboarding",
"blood sweat and tears"

};

    public static string GetRandomWord() {
        int index = Random.Range(0, WordList.Count);
        
        return WordList[index];
   }


    public static void PopulateWordList() {
        string line;
        //StreamReader file = new StreamReader("Assets/Resources/Random Phrases.txt");

        //while ((line = file.ReadLine()) != null) {
        //    string newWord = line;
        //    WordList.Add(newWord.ToLower());
        //}

        foreach (string word in data) {
            WordList.Add(word.ToLower());
        }
    }


}
