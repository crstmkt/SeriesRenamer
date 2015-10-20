Imports System.IO

Module Module1

    Sub Main()

        Dim SeriesName As String
        Dim SeasonNumber As String
        Dim SeasonArray As Array
        Dim EpisodeNumber As String
        Dim EpisodeArray As Array

        Dim Files = My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory)
        Dim SeriesForlders = My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.CurrentDirectory)
        Dim SeasonFolders
        Dim SplittedString As Array
        Dim NewFilename As String
        Dim EpiosodeTitleCounter As Integer


        For Each Folder In SeriesForlders
            SeasonFolders = My.Computer.FileSystem.GetDirectories(Folder)
            For Each SFolder In SeasonFolders
                Files = My.Computer.FileSystem.GetFiles(SFolder)
                For Each File In Files
                    NewFilename = ""
                    If File.EndsWith(".avi") Or File.EndsWith(".mkv") Or File.EndsWith(".mov") Then
                        Console.WriteLine(File)

                        SplittedString = File.Split("\")

                        SeriesName = SplittedString(SplittedString.Length - 3)
                        NewFilename += SeriesName

                        NewFilename += " - "

                        SeasonNumber = SplittedString(SplittedString.Length - 2)
                        SeasonArray = SeasonNumber.Split(" ")
                        NewFilename += "S"
                        NewFilename += SeasonArray(SeasonArray.Length - 1)

                        EpisodeNumber = SplittedString(SplittedString.Length - 1)
                        EpisodeArray = EpisodeNumber.Split(" ")
                        NewFilename += "E"
                        NewFilename += EpisodeArray(0)
                        NewFilename += " -"

                        EpiosodeTitleCounter = EpisodeArray.Length

                        For EpiosodeTitleCounter = 1 To EpisodeArray.Length - 1
                            NewFilename += String.Concat(" ", EpisodeArray(EpiosodeTitleCounter))
                        Next

                        Console.WriteLine(NewFilename)

                        My.Computer.FileSystem.RenameFile(File, NewFilename)
                    End If

                Next
            Next
        Next

        Console.ReadLine()

    End Sub

End Module
