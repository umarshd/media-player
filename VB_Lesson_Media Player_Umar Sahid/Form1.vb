Public Class Form1

    Dim total As Integer = 0
    Dim mp3file(10) As String

    Private Sub AddMedia()
        Dim curFile As String
        If (total > 9) Then
            MessageBox.Show("Jumlah file sudah maksimal")
            Exit Sub
        End If
        OpenFileDialog1.ShowDialog()
        curFile = OpenFileDialog1.SafeFileName

        ListBox1.Items.Add(curFile)
        total = total + 1
        mp3file(total) = OpenFileDialog1.FileName

    End Sub

    Private Sub PlayMedia()
        Dim i As Integer
        Dim newPlayList As WMPLib.IWMPPlaylist = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("soundsToPlay")

        For i = 1 To total
            newPlayList.appendItem(AxWindowsMediaPlayer1.newMedia(mp3file(i)))
        Next

        'play the list
        AxWindowsMediaPlayer1.Visible = True
        AxWindowsMediaPlayer1.currentPlaylist = newPlayList
        AxWindowsMediaPlayer1.stretchToFit = True
    End Sub

    Private Sub buttonAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonAddFile.Click
        AddMedia()
    End Sub

    Private Sub buttonPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPlay.Click
        PlayMedia()
    End Sub


End Class
