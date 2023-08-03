Imports System.Text
Imports System.Security.Cryptography
Public Class Seguridad

    Public Shared Function GenerarSHA(ByVal sCadena As String) As String

        Dim ueCodigo As New Text.UnicodeEncoding()

        Dim ByteSourceText() As Byte = ueCodigo.GetBytes(sCadena)

        Dim SHA As New SHA1CryptoServiceProvider

        Dim ByteHash() As Byte = SHA.ComputeHash(ueCodigo.GetBytes(sCadena))

        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Shared Function Encripta(ByVal Pass As String, user As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Clave = user
        Pass2 = ""
        For i = 1 To Len(Pass)
            CAR = Mid(Pass, i, 1)
            Codigo = Mid(Clave, ((i - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Right("0" & Hex(Asc(Codigo) Xor Asc(CAR)), 2)
        Next i
        Encripta = Pass2
    End Function

    Public Shared Function DesEncripta(ByVal Pass As String, user As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Dim j As Integer

        Clave = user
        Pass2 = ""
        j = 1
        For i = 1 To Len(Pass) Step 2
            CAR = Mid(Pass, i, 2)
            Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))
            j = j + 1
        Next i
        DesEncripta = Pass2
    End Function

End Class

