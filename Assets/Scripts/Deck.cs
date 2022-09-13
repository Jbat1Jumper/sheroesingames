using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = System.Random;

public class Deck : MonoBehaviour
{
    Stack<Situation> Situations = new Stack<Situation>();

    private bool isInitialize = false;
    public Situation GetNextSituation()
    {
        if (!isInitialize)
        {
            InitializeSituations();
            isInitialize = true;
        }
        if (Situations.Count > 0) {
            Debug.Log("Poppin Situation");
            return Situations.Pop();
        }

        Debug.Log("No more cards");
        return null;
    }

    private void InitializeSituations() {

        Translations.ChangeLanguage(Translations.CurrentLanguage); // Just to ensure they are loaded

        var situations = new List<Situation>();

        foreach (var row in Translations.GameData.Rows) {
            if (string.IsNullOrWhiteSpace(row["Sprite de Carta"]) || string.IsNullOrWhiteSpace(row["ID Situación"]) || row["Habilitada"].ToLower() != "si")
                continue;

            situations.Add(LoadSituation(row));
        }

        ShuffleSituations(situations);
    }

    private Situation LoadSituation(Dictionary<string, string> row) {
        return new Situation() {
            Id = row["ID Situación"],
            CardSprite = Resources.Load<Sprite>(row["Sprite de Carta"]),

            LeftResult = LoadOutcome("A", row),
            RightResult = LoadOutcome("B", row),
            SituationText = row["Texto Situación"],
        };
    }

    private static Regex OutcomeDescriptionRegex = new Regex(@"\[(?<text_between_brackets>.*)\](?<the_rest>.*)");

    private Outcome LoadOutcome(string outcomeId, Dictionary<string, string> row)
    {
        var parsedText = OutcomeDescriptionRegex.Match(row["Texto " + outcomeId]);

        return new Outcome() {
            Id = outcomeId,
            EnergyChange = int.Parse(row["Energia " + outcomeId]),
            MoodChange = int.Parse(row["Estado de ánimo " + outcomeId]),
            EmpowermentChange = int.Parse(row["Empoderamiento " + outcomeId]),
            ActionText = parsedText.Groups["text_between_brackets"].Value,
            OutcomeDescription = parsedText.Groups["the_rest"].Value,
        };
    }

    public void ShuffleSituations(List<Situation> wholeDeck)
    {
        Random r = new Random((int)Time.time);

        while (wholeDeck.Count > 0)
        {
            var aSituation = wholeDeck[r.Next(0, wholeDeck.Count)];     // grab a random card
            Situations.Push(aSituation);                              // push it on the stack
            wholeDeck.Remove(aSituation);                              // remove it from the original list
        }
    }
}
