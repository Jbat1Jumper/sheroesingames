using System.Collections.Generic;
using UnityEngine;

public class Table {
    public HashSet<string> Columns = new HashSet<string>();
    public List<Dictionary<string, string>> Rows = new List<Dictionary<string, string>>();

    public static Table Load(string path) {
        try
        {
            var asset = Resources.Load<TextAsset>(path);

            return Table.ParseTSV(
                asset.text
                //Resources.Load<TextAsset>(path).text
            );
        }
        catch (System.Exception e) {
            Debug.LogError($"Failed to load table: {path}");
            throw e;
        }
    }

    static public Table ParseTSV(string tsvText)
    {
        var table = new Table();
        var columns = new List<string>();

        //split the data on split line character
        string[] lines = tsvText.Split("\n"[0]);

        var firstRow = lines[0].Split('\t');

        foreach (var column_name in firstRow) {
            columns.Add(column_name);
            table.Columns.Add(column_name);
        }

        // find the max number of columns
        for (int i = 1; i < lines.Length; i++)
        {
            var parsedRow = new Dictionary<string, string>();
            string[] row = lines[i].Split('\t');
            for (int j = 0; j < row.Length; j++) {
                parsedRow.Add(columns[j], row[j]);
            }

            table.Rows.Add(parsedRow);
        }

        return table;
    }

    public void MergeWith(Table other)
    {
        foreach (var c in other.Columns)
            Columns.Add(c);

        for (var i = 0; i < this.Rows.Count; i++)
        {
            if (other.Rows.Count < i)
                continue;

            foreach (var key in other.Rows[i].Keys)
                this.Rows[i][key] = other.Rows[i][key];
        }
    }
}
