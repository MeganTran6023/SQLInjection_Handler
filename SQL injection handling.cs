// C# program to illustrate how  
// to write a file in C# 
using System; 
using System.IO; 
  
class Program { 
    static void Main(string[] args) 
    { 
        // Store the path of the textfile in your system 
        string file = @"C:\Users\journ\Downloads\Textfile.txt"; 
  
        // To overwrite SQL text to prepared statement 
        // string[] textLines1 = { "This is the first line",  
        //                        "This is the second line", 
        //                       "This is the third line" }; 
  
        // File.WriteAllLines(file, textLines1); 
  
        // replace with
        // // Prepare the SQL statement
// $stmt = $conn->prepare("SELECT * FROM users WHERE username = ? AND password   
//  = ?");

// // Bind parameters
// $stmt->bind_param("ss", $username, $password);

// // Execute   
//  the statement
// $stmt->execute();

 
        // To display current contents of the file 
        Console.WriteLine(File.ReadAllText(file)); 
  
        Console.ReadKey(); 
    } 
} 