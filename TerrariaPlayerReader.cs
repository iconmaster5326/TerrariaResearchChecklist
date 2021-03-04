using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using HtmlAgilityPack;
using Kaitai;
using System.Linq;

class Item
{
    public int id;
    public string name;
    public string internalName;
    public int needed;
    public string url;

    public Item(int id, string name, string internalName, int needed, string url)
    {
        this.id = id;
        this.name = name;
        this.internalName = internalName;
        this.needed = needed;
        this.url = url;
    }
}

class TerrariaPlayerReader
{
    static int[] BLACKLISTED_IDS = new int[] {
        226, // lesser restoration potion: removed in 1.4, but wiki (falsely) claims it's researchable
        766, // bone block: researchable, but obtainable only in 1.3 and earlier
    };
    static byte[] ENCRYPTION_KEY = new UnicodeEncoding().GetBytes("h3y_gUyZ");

    static void Main(string[] args)
    {
        var items = allItems();
        var save = readPlayerFile(args[0]);
        var internalNamesResearched = new Dictionary<string, int>();
        foreach (var research in save.ResearchesCompleted)
        {
            internalNamesResearched[research.Item.Contents] = research.Count;
        }

        int i = 0;
        foreach (var itemNotFullyResearched in items.Values.Where(item => !internalNamesResearched.ContainsKey(item.internalName) || internalNamesResearched[item.internalName] < item.needed))
        {
            Console.WriteLine(itemNotFullyResearched.name + ": " + itemNotFullyResearched.url);
            i++;
        }
        Console.WriteLine(i + "/" + items.Count + " (" + ((((double)i) / items.Count * 100)) + "%) items not yet researched.");
    }

    static TerrariaPlayer readPlayerFile(string path)
    {
        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Padding = PaddingMode.None;
        byte[] buffer = new byte[new FileInfo(path).Length];
        var n = new CryptoStream(new FileStream(path, FileMode.Open), rijndaelManaged.CreateDecryptor(ENCRYPTION_KEY, ENCRYPTION_KEY), CryptoStreamMode.Read).Read(buffer, 0, buffer.Length);
        return new TerrariaPlayer(new KaitaiStream(new MemoryStream(buffer, 0, n)));
    }

    static Dictionary<string, Item> allItems()
    {
        var result = new Dictionary<string, Item>();
        HtmlWeb web = new HtmlWeb();
        bool first;

        var idToInternalNames = new Dictionary<int, string>();
        var htmlItems = web.Load("https://terraria.gamepedia.com/Item_IDs").DocumentNode.SelectSingleNode("//*[contains(@class, 'terraria') and contains(@class, 'sortable')]/tbody");
        first = true;
        foreach (var row in htmlItems.ChildNodes)
        {
            if (first)
            {
                first = false;
                continue;
            }

            int id = int.Parse(row.ChildNodes[1].InnerText);
            if (BLACKLISTED_IDS.Contains(id)) {
                continue;
            }

            string internalName = row.ChildNodes[5].InnerText.Trim();
            idToInternalNames[id] = internalName;
        }

        var htmlResearch = web.Load("https://terraria.gamepedia.com/Journey_Mode/Research_list").DocumentNode.SelectSingleNode("//*[contains(@class, 'terraria')]/tbody");
        first = true;
        foreach (var row in htmlResearch.ChildNodes)
        {
            if (first)
            {
                first = false;
                continue;
            }

            int needed;

            try
            {
                needed = int.Parse(row.ChildNodes[5].InnerText);
            }
            catch (FormatException)
            {
                continue;
            }

            int id = int.Parse(row.ChildNodes[1].InnerText);
            string name = row.ChildNodes[3].InnerText.Trim();
            string url = "https://terraria.gamepedia.com" + row.ChildNodes[3].ChildNodes[0].GetAttributeValue("href", "");

            if (!idToInternalNames.ContainsKey(id))
            {
                continue;
            }

            result[idToInternalNames[id]] = new Item(id, name, idToInternalNames[id], needed, url);
        }
        return result;
    }
}
