namespace GameJam
{
    internal class Dialog
    {
        public Dictionary<string, string[]> NPCDict;
        public Dictionary<string, string> ResponseDict;

        public Dialog()
        { NPCDict = new(); ResponseDict = new(); }

        public string[] GetResponses(string dialog)
        { return NPCDict[dialog]; }

        public string GetResponseDialog(string response = "")
        { return ResponseDict[response]; }
    }
}
