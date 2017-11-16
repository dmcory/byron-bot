Imports System.Net.Http
Imports System.Threading.Tasks
Imports Microsoft.AspNet.WebHooks

Public Class SlackWebHookHandler
    Inherits WebHookHandler

    Public Overrides Function ExecuteAsync(generator As String, context As WebHookHandlerContext) As Task
        Dim nvc As NameValueCollection
        If context.TryGetData(Of NameValueCollection)(nvc) Then
            Dim question As String = nvc("subcontext")
            Dim msg As String = String.Format($"The answer to {question} is always.")
            Dim reply As New SlackResponse(msg)
            context.Response = context.Request.CreateResponse(reply)
        End If
        Return Task.FromResult(True)
    End Function
End Class
