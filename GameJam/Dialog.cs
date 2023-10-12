namespace GameJam
{
    internal class Dialog
    {
        public readonly string _lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Urna molestie at elementum eu facilisis sed. Elit at imperdiet dui accumsan sit amet nulla facilisi morbi. Mauris pharetra et ultrices neque ornare. Accumsan in nisl nisi scelerisque eu ultrices vitae. Habitant morbi tristique senectus et netus et malesuada fames ac. Dictumst quisque sagittis purus sit amet volutpat. Facilisis mauris sit amet massa vitae tortor condimentum lacinia quis. Ac auctor augue mauris augue neque gravida in fermentum et. Placerat orci nulla pellentesque dignissim enim sit amet. Tristique et egestas quis ipsum suspendisse. Fringilla ut morbi tincidunt augue interdum.";

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
