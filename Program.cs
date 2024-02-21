using DiffMatchPatch;

namespace DemoDiffMatchPatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo1();
            Demo2();
        }
        private static void Demo1()
        {
            string oldJson = File.ReadAllText("./DemoJson/example.json");
            string newJson = oldJson.Replace("minim", "minmaxum");
            // Compare file content with Google's Diff Match and Patch
            diff_match_patch dmp = new diff_match_patch();
            List<Diff> diffs = dmp.diff_main(oldJson, newJson);

            dmp.diff_cleanupSemantic(diffs); // Combines small changes on the same line into one change.
            string html = dmp.diff_prettyHtml(diffs); // Generates a pretty HTML report of the diff.
            File.WriteAllText("demo1.html", html);
        }
        private static void Demo2()
        {
            string oldJson = File.ReadAllText("./DemoJson/example.json");
            string newJson = oldJson.Replace("minim", "minmaxum");
            // Compare file content with Google's Diff Match and Patch
            diff_match_patch dmp = new diff_match_patch();
            List<Diff> diffs = dmp.diff_main(oldJson, newJson);

            dmp.diff_cleanupSemantic(diffs); // Combines small changes on the same line into one change.
            diffs = dmp.diff_ShortenEqualTextLines(diffs, 5); // Shortens the strings Equal lines to compress the hmtl report
            string html = dmp.diff_prettyHtml(diffs); // Generates a pretty HTML report of the diff.
            File.WriteAllText("demo2.html", html);
        }
    }
}
