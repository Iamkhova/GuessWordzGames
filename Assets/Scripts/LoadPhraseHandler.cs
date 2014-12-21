using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class LoadPhraseHandler : MonoBehaviour {

	public string fileName;
	public int maxPhraseCount;

	public PhraseHandler.PhraseXML[] phraseXML = new PhraseHandler.PhraseXML[1000];

	private string path;


	// Use this for initialization
	void Start () {
		loadPhrases ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadPhrases()
	{
		path = getPath ();

		XmlReader reader = XmlReader.Create (path);
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load (reader);

		XmlNodeList Data = xmlDoc.GetElementsByTagName ("ThePhraseData");
		for (int i = 0; i < Data.Count; i++) 
		{
			// getting the phrases
			XmlNode DataChilds = Data.Item (i);

			// getting all data stored inside phrase object

			XmlNodeList allPhraseObjects = DataChilds.ChildNodes;
			maxPhraseCount = Data.Count;

			for (int j = 0; j < allPhraseObjects.Count; j++)
			{
				XmlNode phraseObjects_Title = allPhraseObjects.Item(0);
				XmlNode phraseObjects_Text = allPhraseObjects.Item(1);
				XmlNode phraseObjects_Hint = allPhraseObjects.Item(2);


				phraseXML[i] = new PhraseHandler.PhraseXML();
				phraseXML[i].phraseTitle = phraseObjects_Title.InnerText;
				phraseXML[i].phraseText = phraseObjects_Text.InnerText;
				phraseXML[i].phraseHint = phraseObjects_Hint.InnerText;

			}
		}

		reader.Close ();

	}

	public PhraseHandler.PhraseXML getNewPhrase()
	{
		loadPhrases (); // Reload the Phrases.. just in case

		PhraseHandler.PhraseXML _thePhrase = new PhraseHandler.PhraseXML ();
		int ranNumber = Random.Range (0, maxPhraseCount);

		Debug.Log ("Max Phrase Count: " + maxPhraseCount);
		Debug.Log ("Random Phrase Number: " + ranNumber);

		_thePhrase.phraseTitle = phraseXML [ranNumber].phraseTitle;
		_thePhrase.phraseText = phraseXML [ranNumber].phraseText;
		_thePhrase.phraseHint = phraseXML [ranNumber].phraseHint;

		return _thePhrase;

	}

	private string getPath() 
	{
		#if UNITY_EDITOR
			Debug.Log ("Device show as UNITY_EDITOR");
			return Application.dataPath + "/Resources/" + fileName;
		#endif
	
		#if UNITY_ANDROID
			return Application.persistentDataPath + "/" + fileName;
		#endif

		#if UNITY_IPHONE
			return Application.persistentDataPath + "/" + fileName;
		#endif


		#if UNITY_STANDALONE_WIN
			return Application.datapath + "/" + fileName;
		#endif

	}
}
