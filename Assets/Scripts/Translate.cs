using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public static Translate Instance { get; private set; }

    Dictionary<string, string> PortugueseDictionary = new Dictionary<string, string>();
    Dictionary<string, string> GermanDictionary = new Dictionary<string, string>();
    Dictionary<string, string> SpanishDictionary = new Dictionary<string, string>();
    Dictionary<string, string> FrenchDictionary = new Dictionary<string, string>();

    enum Language
    {
        Portuguese,
        German,
        Spanish,
        French,
        COUNT
    };

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PortugueseDictionary["3 Rules: 1) Do / 2) Not / 3) Die"] = "3 Regras: 1) Tente / 2) Não / 3) Morrer";
        PortugueseDictionary["Unstable"] = "Instável";
        PortugueseDictionary["Summoning / Replication / Strength in numbers / It follows you"] = "Convocação / Replicação / Força em números / Isso segue você";
        PortugueseDictionary["Making connections / On and Off"] = "Fazendo conexões / Ligado e Desligado";
        PortugueseDictionary["Decay"] = "Decair";
        PortugueseDictionary["Delivery"] = "Entrega";
        PortugueseDictionary["One tool, many uses"] = "Uma ferramenta, muitos usos";
        PortugueseDictionary["Delay the inevitable"] = "Atrase o inevitável";
        PortugueseDictionary["Keep your distance"] = "Mantenha distância";
        PortugueseDictionary["The environment changes you"] = "O ambiente muda você";
        PortugueseDictionary["Leave something behind"] = "Deixe algo para trás";
        PortugueseDictionary["Everything changes at night"] = "Tudo muda a noite";
        
        GermanDictionary["3 Rules: 1) Do / 2) Not / 3) Die"] = "3 Regeln: 1) Lass / 2) Nicht / 3) Sterben";
        GermanDictionary["Unstable"] = "Instabil";
        GermanDictionary["Summoning / Replication / Strength in numbers / It follows you"] = "Beschwörung / Replikation / Stärke in Zahlen / Es folgt dir";
        GermanDictionary["Making connections / On and Off"] = "Verbindungen herstellen / Ein und Aus";
        GermanDictionary["Decay"] = "Verfall";
        GermanDictionary["Delivery"] = "Lieferung";
        GermanDictionary["One tool, many uses"] = "Ein Werkzeug, viele Anwendungen";
        GermanDictionary["Delay the inevitable"] = "Verzögere das Unvermeidliche";
        GermanDictionary["Keep your distance"] = "Halten Sie Abstand";
        GermanDictionary["The environment changes you"] = "Die Umgebung verändert dich";
        GermanDictionary["Leave something behind"] = "Lass etwas zurück";
        GermanDictionary["Everything changes at night"] = "Nachts ändert sich alles";

        SpanishDictionary["3 Rules: 1) Do / 2) Not / 3) Die"] = "3 reglas: 1) Hacer / 2) No / 3) Morir";
        SpanishDictionary["Unstable"] = "Inestable";
        SpanishDictionary["Summoning / Replication / Strength in numbers / It follows you"] = "Invocación / Replicación / Fuerza en números / Te sigue";
        SpanishDictionary["Making connections / On and Off"] = "Hacer conexiones / Encendido y apagado";
        SpanishDictionary["Decay"] = "Decaer";
        SpanishDictionary["Delivery"] = "Entrega";
        SpanishDictionary["One tool, many uses"] = "Una herramienta, muchos usos";
        SpanishDictionary["Delay the inevitable"] = "Retrasa lo inevitable";
        SpanishDictionary["Keep your distance"] = "Mantén tu distancia";
        SpanishDictionary["The environment changes you"] = "El entorno te cambia";
        SpanishDictionary["Leave something behind"] = "Deja algo atrás";
        SpanishDictionary["Everything changes at night"] = "Todo cambia de noche";

        FrenchDictionary["3 Rules: 1) Do / 2) Not / 3) Die"] = "3 règles: 1) Ne / 2) meurs / 3) pas";
        FrenchDictionary["Unstable"] = "Instable";
        FrenchDictionary["Summoning / Replication / Strength in numbers / It follows you"] = "Invocation / Réplication / La force du nombre / Il vous suit";
        FrenchDictionary["Making connections / On and Off"] = "Connexions / Marche et Arrêt";
        FrenchDictionary["Decay"] = "Carie";
        FrenchDictionary["Delivery"] = "Livraison";
        FrenchDictionary["One tool, many uses"] = "Un outil, plusieurs utilisations";
        FrenchDictionary["Delay the inevitable"] = "Retarder l'inévitable";
        FrenchDictionary["Keep your distance"] = "Garde tes distances";
        FrenchDictionary["The environment changes you"] = "L'environnement vous change";
        FrenchDictionary["Leave something behind"] = "Laisser quelque chose derrière";
        FrenchDictionary["Everything changes at night"] = "Tout change la nuit";
    }

    public string Go(string value)
    {
        switch ((Language) Core.Instance.Language)
        {
            case Language.Portuguese:
                return PortugueseDictionary[value];
            case Language.German:
                return GermanDictionary[value];
            case Language.Spanish:
                return SpanishDictionary[value];
            case Language.French:
                return FrenchDictionary[value];
        }
        return value;
    }

    public void ChangeLanguage()
    {
        Core.Instance.Language = Random.Range(0, (int) Language.COUNT);
    }


}
