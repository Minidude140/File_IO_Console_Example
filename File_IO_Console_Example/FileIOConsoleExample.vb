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
        'WriteToFile()
        'For i = 0 To 10
        '    'append 10 times
        '    AppendToFile()
        'Next
        'AppendRecordsToFile()
        ImportCustomerData()
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

    Sub AppendRecordsToFile()
        FileOpen(1, "Data.log", OpenMode.Append)
        Write(1, "This is a string")
        Write(1, 1234)
        Write(1, True)
        Write(1, DateTime.Now)
        FileClose(1)
    End Sub

    'read all the records in data.log and write to console
    Sub ReadRecordsFromFile()

    End Sub
    'read all the records of email.txt
    Sub ImportCustomerData()
        Dim fileName As String = "../../email.txt"
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String = ""
        Dim recordCount As Integer = 0
        Dim customerData() As String
        Dim cleanFileName As String = "../../" & DateTime.Now.ToString("yyyyMMddhhss") & ".txt"

        FileOpen(fileNumber, fileName, OpenMode.Input)
        Do Until EOF(fileNumber)
            'Input(fileNumber, currentRecord) **used to retrieve each record instead of line**
            'sets currentRecord to the next line of data in email.txt
            currentRecord = LineInput(fileNumber)
            'assigns current record to current record with all " removed
            currentRecord = Replace(currentRecord, Chr(34), "", 1, -1)
            'assigns current record to current record with all $ removed
            currentRecord = Replace(currentRecord, "$", "", 1, -1)
            customerData = Split(currentRecord, ",")
            'TODO test array length before appending to see if data is valid
            ExportCustomerData(customerData, cleanFileName)
            Console.WriteLine(currentRecord)
            recordCount += 1

        Loop

        FileClose(fileNumber)
        Console.WriteLine($"There are {recordCount} records in {fileName} file.")
    End Sub

    Sub ExportCustomerData(recordData() As String, fileName As String)
        Dim fileNumber As Integer = FreeFile()
        FileOpen(fileNumber, fileName, OpenMode.Append)
        For i = LBound(recordData) To UBound(recordData)
            Write(fileNumber, recordData(i))
        Next
        FileClose(fileNumber)
    End Sub
End Module
