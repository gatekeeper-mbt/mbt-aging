Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS.FileSystem
Module mSQL_Funtion
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    Public Function SQL_Reader(ByVal SQL_str As String) As SqlDataReader
        Conn.Open()
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        Reader.Close()
        Conn.Close()
        Return Reader
    End Function
    Public Sub SQL_Write(ByVal SQL_str As String)
        Conn.Open()
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        SQL_Cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub
End Module
