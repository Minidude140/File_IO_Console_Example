'Zachary Christensen
'RCET 2265
'Fall 2023
'File IO Console in Class Example
'https://github.com/Minidude140/File_IO_Console_Example.git


Option Explicit On
Option Strict On

Module FileIOConsoleExample

    Sub Main()
        WriteToFile()
        Console.Read()

    End Sub

    Sub WriteToFile()
        'open a file called test.txt then write "Follow the White rabbit..."
        'input is into program, output is to file
        FileOpen(1, "test.txt", OpenMode.Output)
        PrintLine(1, "Follow the white rabbit...")
        FileClose(1)

    End Sub
End Module
