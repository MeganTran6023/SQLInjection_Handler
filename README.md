# SQLInjection_Handler

## Description
This simple C# project was made to practice fundamental coding syntax in the language.

The project reads through a text file with a specific file path. If it identifies a certin string that indicates a SQL inject, it replaces it with a prepared statement.

This is applicable to be used in cybersecurity settings where users may experience files with malware from attackers, so such dangers must be dealt with before any effect takes place.

## Getting Started
**Prerequisites:**

* VSCode IDE
* C# Dev Kit

**Installation:** 

1) Install C# Dev kit via VSCode  by searching C# Dev Kit in Extensions panel.

**Usage:**

1) To clone this repository, type into git bash:

```
git clone https://github.com/MeganTran6023/SQLInjection_Handler

```

2) Change the path to your path inside main method:

```
        // Directory of the file
        string file = @"C:\XXX\XXXX\Downloads\Textfile.txt";

```

3) Run program by pressing play button on top right of VSCode.

## References
* [GeekForGeeks File Reader and Writer](https://www.geeksforgeeks.org/how-to-read-and-write-a-text-file-in-c-sharp/)
