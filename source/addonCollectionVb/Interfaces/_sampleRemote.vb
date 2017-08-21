﻿
Option Explicit On
Option Strict On

Imports AddonCollectionVb.Controllers
Imports Contensive.BaseClasses
'
Namespace AddonCollectionVb
    '
    Public Class getProjectListNoDetailsClass
        Inherits AddonBaseClass
        '
        '=====================================================================================
        '
        Public Overrides Function Execute(ByVal cp As CPBaseClass) As Object
            Dim result As String = ""
            Dim sw As New Stopwatch : sw.Start()
            Try
                '
                ' -- initialize application. If authentication needed and not login page, pass true
                Using ae As New applicationController(cp, True)
                    '
                    ' -- optionally add a timer to report how long this section took
                    ae.packageProfileList.Add(New applicationController.packageProfileClass() With {.name = "applicationControllerConstructor", .time = sw.ElapsedMilliseconds})
                    If ae.packageErrorList.Count = 0 Then
                        '
                        ' -- create sample data
                        Dim personList As List(Of Models.personModel) = Models.personModel.createList(cp, "")
                        '
                        ' -- add sample data to a node
                        ae.packageNodeList.Add(New applicationController.packageNodeClass With {
                            .dataFor = "nameOfThisDataForRemoteToRecognize",
                            .data = personList
                        })
                    End If
                    '
                    ' -- optionally add a timer to report how long this section took
                    ae.packageProfileList.Add(New applicationController.packageProfileClass() With {.name = "getProjectListNoDetailsClass", .time = sw.ElapsedMilliseconds})
                    result = ae.getSerializedPackage()
                End Using
            Catch ex As Exception
                cp.Site.ErrorReport(ex)
            End Try
            Return result
        End Function
        '
        '
    End Class
    '
    '
End Namespace
