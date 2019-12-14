using System.Collections.Generic;
using System.IO;

namespace CollectionGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            //THIS SCRIPT IS GENERATES A FILE FOR COLLECTION

            var destination = @"C:\Users\RR\Dropbox\css-advanced\logoto\docs\collections\_teams";
            var teams = @"C:\Users\RR\Dropbox\css-advanced\logoto\docs\_data\teamsToHTML.txt";
            var isExist = File.Exists(teams);

            var names = new HashSet<string>();

            var counter = 0;

            if (isExist)
            {
                var readedFile = File.ReadAllLines(teams);

                foreach (var teamName in readedFile)
                {
                    names.Add(teamName);
                }
            }

            var isEmpty = names.Count == 0;

            if (isEmpty == false)
            {
                foreach (var name in names)
                {
                    counter++;

                    var file = destination + "\\" + name + ".html";
                    var layout = "single-team";

                    var frontMatter = $"---\n" +
                                      $"index: {counter}\n" +
                                      $"layout: {layout}\n" +
                                      $"---";

                    File.WriteAllText(file, frontMatter);
                }
            }
        }
    }
}
