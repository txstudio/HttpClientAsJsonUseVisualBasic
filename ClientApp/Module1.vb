Imports System.Net.Http
Imports DataContract
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

    '在舊版本的 Visual Studio 中 VB.NET 擴充方法需要手動輸入
    '   Intellisense 不會列出 PostAsJsonAsync, ReadAsAsync 方法但是編譯會過
    '   PostAsJsonAsync, ReadAsAsync 方法擴充於 System.Net.Http.Formatting 中

    '   在 Visual Studio 2017 會列出 VB.NET 的擴充方法

    Const BaseAddress As String = "http://localhost:57688/"
    Const RelativeUrl As String = "/api/login"


    Sub DisplayObj(Obj As Object)
        Dim _Json As String
        Dim _JsonFormat As String

        _Json = JsonConvert.SerializeObject(Obj)
        _JsonFormat = JObject.Parse(_Json).ToString()

        Console.WriteLine(_JsonFormat)
    End Sub

    Sub Main()

        Dim _Client As HttpClient
        Dim _Request As LoginRequest
        Dim _Response As LoginResponse

        _Client = New HttpClient()
        _Client.BaseAddress = New Uri(BaseAddress)

        _Request = New LoginRequest()
        _Request.Account = "user@txstudio.com"
        _Request.Password = "password"


        Console.WriteLine("Request Body")
        DisplayObj(_Request)
        Console.WriteLine()

        Dim _MessageResponse = _Client.PostAsJsonAsync(Of LoginRequest)(RelativeUrl, _Request).Result

        If _MessageResponse.IsSuccessStatusCode = True Then
            _Response = _MessageResponse.Content.ReadAsAsync(Of LoginResponse)().Result

            Console.WriteLine("Response Body")
            DisplayObj(_Response)
        End If

        Console.WriteLine()
        Console.WriteLine("press any key to exit")
        Console.ReadKey()

    End Sub

End Module
