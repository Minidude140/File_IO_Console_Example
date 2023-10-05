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
        'ImportCustomerData()
        'ReadRecordsFromFile("junk.txt")
        ReadRecordsFromFile("../../cleanfile.txt")
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
    Sub ReadRecordsFromFile(fileName As String)
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String = ""
        Try
            FileOpen(fileNumber, fileName, OpenMode.Input)
            Do Until EOF(fileNumber)
                Input(fileNumber, currentRecord)
                Console.WriteLine(currentRecord)
            Loop
            FileClose(fileNumber)

        Catch notFound As System.IO.FileNotFoundException
            Console.WriteLine($"Sorry, the file {fileName} was not found")
        Catch ex As Exception
            fileNumber = FreeFile()
            FileOpen(fileNumber, "error.txt", OpenMode.Append)
            Write(fileNumber, ex.GetBaseException)
            FileClose(fileNumber)
        End Try
    End Sub
    'read all the records of email.txt
    Sub ImportCustomerData()
        Dim fileName As String = "../../email.txt"
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String = ""
        Dim recordCount As Integer = 0
        Dim customerData() As String
        Dim cleanFileName As String = "../../" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"
        Dim badRecordCount As Integer = 0

        FileOpen(fileNumber, fileName, OpenMode.Input)
        Do Until EOF(fileNumber)
            'Input(fileNumber, currentRecord) **used to retrieve each record instead of line**
            'sets currentRecord to the next line of data in email.txt
            currentRecord = LineInput(fileNumber)
            'assigns current record to current record with all " removed
            currentRecord = Replace(currentRecord, Chr(34), "", 1, -1)
            'assigns current record to current record with all $ removed
            currentRecord = Replace(currentRecord, "$", "", 1, -1)
            currentRecord = Replace(currentRecord, ChrW(&HA0), "", 1, -1)
            currentRecord = Replace(currentRecord, ChrW(&HC2), "", 1, -1)
            customerData = Split(currentRecord, ",")
            'TODO test array length before appending to see if data is valid
            If UBound(customerData) < 3 Then
                'bad data
                badRecordCount += 1
            Else
                'good data
                ReDim Preserve customerData(3)
                If InStr(customerData(3), ChrW(&HA0)) > 0 Or InStr(customerData(3), ChrW(&HA0)) > 0 Then
                    Console.WriteLine($"Customer {recordCount} may have bad data.  See: {customerData(3)}")
                End If
                ExportCustomerData(customerData, cleanFileName)
            End If
            'Console.WriteLine(currentRecord)
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
        WriteLine(fileNumber)
        FileClose(fileNumber)
    End Sub
End Module
