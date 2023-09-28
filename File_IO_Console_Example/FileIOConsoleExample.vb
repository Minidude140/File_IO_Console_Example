'Zachary Christensen
'RCET 2265
'Fall 2023
'File IO Console in Class Example
'https://github.com/Minidude140/File_IO_Console_Example.git


Option Explicit On
Option Strict On

Module FileIOConsoleExample

    Sub Main()
        'Write file once
        WriteToFile()
        For i = 0 To 10
            'append 10 times
            AppendToFile()
        Next
        Console.Read()

    End Sub

    Sub WriteToFile()
        'open a file called test.txt then write "Follow the White rabbit..."
        'input is into program, output is to file
        FileOpen(1, "test.txt", OpenMode.Output)
        PrintLine(1, "Hello, Neo")
        FileClose(1)
    End Sub
    Sub AppendToFile()
        'open a file called test.txt and append to the end of file
        FileOpen(1, "test.txt", OpenMode.Append)
        PrintLine(1, "Follow the white rabbit....")
        FileClose(1)
    End Sub
End Module
