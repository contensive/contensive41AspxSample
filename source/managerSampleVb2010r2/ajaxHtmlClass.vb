
Imports Contensive.BaseClasses

Namespace Contensive.addons.managerSample
    Public Class ajaxClass
        Inherits AddonBaseClass
        '
        ' Ajax Handler - Remote Method
        '   returns content of inner classes to the contains originally created around them
        '
        Public Overrides Function Execute(ByVal CP As CPBaseClass) As Object
            Dim returnHtml As String = ""
            '
            Try
                Dim adminAccountDetails As New managerSampleADetailsClass
                Dim accountList As New managerSampleAListClass
                Dim orgList As New managerSampleBClass
                Dim srcFormId As Integer = CP.Utils.EncodeInteger(CP.Doc.GetProperty(rnSrcFormId))
                Dim dstFormId As Integer = CP.Utils.EncodeInteger(CP.Doc.GetProperty(rnDstFormId))
                Dim rqs As String = CP.Doc.GetProperty("baseRqs")
                Dim rightNow As Date = getRightNow(CP)
                '
                ' process form
                '
                If (srcFormId <> 0) Then
                    Select Case srcFormId
                        Case formIdSampleAList
                            '
                            '
                            '
                            dstFormId = accountList.processForm(CP, srcFormId, rqs)
                        Case formIdSampleADetails
                            '
                            '
                            '
                            dstFormId = adminAccountDetails.processForm(CP, srcFormId, rqs, rightNow)
                        Case formIdSampleCList
                            '
                            '
                            '
                            dstFormId = orgList.processForm(CP, srcFormId, rqs)
                    End Select
                End If
                '
                ' get form
                '
                Select Case dstFormId
                    Case formIdSampleAList
                        '
                        '
                        '
                        returnHtml = accountList.getForm(CP, dstFormId, rqs)
                    Case formIdSampleCList
                        '
                        '
                        '
                        returnHtml = orgList.getForm(CP, dstFormId, rqs, rightNow)
                    Case formIdSampleADetails
                        '
                        '
                        '
                        returnHtml = adminAccountDetails.getForm(CP, dstFormId, rqs, rightNow)
                End Select
            Catch ex As Exception
                CP.Site.ErrorReport(ex, "error in aoManagerTemplate.adminClass.execute")
            End Try
            '
            ' assemble body
            '
            Return returnHtml
        End Function
    End Class
End Namespace
