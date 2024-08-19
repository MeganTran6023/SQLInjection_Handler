using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Directory of the file
        string file = @"C:\XXX\XXXX\Downloads\Textfile.txt";

        // Read all lines of the file into an array
        string[] lines = File.ReadAllLines(file);

        // Find the index of the line containing the vulnerable SQL query
        int queryLineIndex = Array.FindIndex(lines, line => line.Contains("$sql = \"SELECT * FROM users WHERE username="));

        if (queryLineIndex != -1)
        {
            // Calculate the number of new lines to add
            int numberOfNewLines = 9;
            int totalLines = Math.Max(lines.Length, queryLineIndex + numberOfNewLines);

            // Create a new array to hold the updated lines
            string[] updatedLines = new string[totalLines];

            // Copy existing lines to the new array
            Array.Copy(lines, updatedLines, Math.Min(lines.Length, queryLineIndex));

            // Replace the vulnerable SQL query and add the secure prepared statement
            updatedLines[queryLineIndex] = "using (var cmd = new MySqlCommand(\"SELECT * FROM users WHERE username = @username AND password = @password\", conn))";
            updatedLines[queryLineIndex + 1] = "{";
            updatedLines[queryLineIndex + 2] = "    cmd.Parameters.AddWithValue(\"@username\", username);";
            updatedLines[queryLineIndex + 3] = "    cmd.Parameters.AddWithValue(\"@password\", password);";
            updatedLines[queryLineIndex + 4] = "    using (var reader = cmd.ExecuteReader())";
            updatedLines[queryLineIndex + 5] = "    {";
            updatedLines[queryLineIndex + 6] = "        // Handle the results here";
            updatedLines[queryLineIndex + 7] = "    }";
            updatedLines[queryLineIndex + 8] = "}";

            // Copy any remaining original lines after the replaced lines
            if (queryLineIndex + numberOfNewLines < lines.Length)
            {
                Array.Copy(lines, queryLineIndex + numberOfNewLines, updatedLines, queryLineIndex + numberOfNewLines, lines.Length - (queryLineIndex + numberOfNewLines));
            }

            // Write the modified lines back to the file
            File.WriteAllLines(file, updatedLines);

            // Display the current contents of the file
            Console.WriteLine("SQL query successfully replaced with a prepared statement.");
            Console.WriteLine(File.ReadAllText(file)); 
            Console.ReadKey(); 
        }
        else
        {
            // If the SQL query was not found
            Console.WriteLine("The SQL query was not found in the file.");
            Console.WriteLine(File.ReadAllText(file)); 
            Console.ReadKey(); 
        }
    }
}
