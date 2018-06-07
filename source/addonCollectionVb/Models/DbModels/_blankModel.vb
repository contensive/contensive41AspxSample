﻿
Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.xxxxxCollectionNameSpaceGoesHerexxxxx.Models     '<------ set namespace
    Public Class xxxxxmodelNameGoesHerexxxxx        '<------ set set model Name and everywhere that matches this string
        Inherits baseModel
        Implements ICloneable
        '
        '====================================================================================================
        '-- const
        Public Const contentName As String = "xxxxxcontentNameGoesHerexxxxx"      '<------ set content name
        Public Const contentTableName As String = "xxxxxtableNameGoesHerexxxxx"   '<------ set to tablename for the primary content (used for cache names)
        Private Shadows Const contentDataSource As String = "default"             '<------ set to datasource if not default
        '
        '====================================================================================================
        ' -- instance properties
        'instancePropertiesGoHere
        ' sample instance property -- Public Property DataSourceID As Integer
        '
        '====================================================================================================
        Public Overloads Shared Function add(cp As CPBaseClass) As xxxxxmodelNameGoesHerexxxxx
            Return add(Of xxxxxmodelNameGoesHerexxxxx)(cp)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function create(cp As CPBaseClass, recordId As Integer) As xxxxxmodelNameGoesHerexxxxx
            Return create(Of xxxxxmodelNameGoesHerexxxxx)(cp, recordId)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function create(cp As CPBaseClass, recordGuid As String) As xxxxxmodelNameGoesHerexxxxx
            Return create(Of xxxxxmodelNameGoesHerexxxxx)(cp, recordGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function createByName(cp As CPBaseClass, recordName As String) As xxxxxmodelNameGoesHerexxxxx
            Return createByName(Of xxxxxmodelNameGoesHerexxxxx)(cp, recordName)
        End Function
        '
        '====================================================================================================
        Public Overloads Sub save(cp As CPBaseClass)
            MyBase.save(Of xxxxxmodelNameGoesHerexxxxx)(cp)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Sub delete(cp As CPBaseClass, recordId As Integer)
            delete(Of xxxxxmodelNameGoesHerexxxxx)(cp, recordId)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Sub delete(cp As CPBaseClass, ccGuid As String)
            delete(Of xxxxxmodelNameGoesHerexxxxx)(cp, ccGuid)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Function createList(cp As CPBaseClass, sqlCriteria As String, Optional sqlOrderBy As String = "id") As List(Of xxxxxmodelNameGoesHerexxxxx)
            Return createList(Of xxxxxmodelNameGoesHerexxxxx)(cp, sqlCriteria, sqlOrderBy)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordName(cp As CPBaseClass, recordId As Integer) As String
            Return baseModel.getRecordName(Of xxxxxmodelNameGoesHerexxxxx)(cp, recordId)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordName(cp As CPBaseClass, ccGuid As String) As String
            Return baseModel.getRecordName(Of xxxxxmodelNameGoesHerexxxxx)(cp, ccGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordId(cp As CPBaseClass, ccGuid As String) As Integer
            Return baseModel.getRecordId(Of xxxxxmodelNameGoesHerexxxxx)(cp, ccGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getCount(cp As CPBaseClass, sqlCriteria As String) As Integer
            Return baseModel.getCount(Of xxxxxmodelNameGoesHerexxxxx)(cp, sqlCriteria)
        End Function
        '
        '====================================================================================================
        Public Overloads Function getUploadPath(fieldName As String) As String
            Return MyBase.getUploadPath(Of xxxxxmodelNameGoesHerexxxxx)(fieldName)
        End Function
        '
        '====================================================================================================
        '
        Public Function Clone(cp As CPBaseClass) As xxxxxmodelNameGoesHerexxxxx
            Dim result As xxxxxmodelNameGoesHerexxxxx = DirectCast(Me.Clone(), xxxxxmodelNameGoesHerexxxxx)
            result.id = cp.Content.AddRecord(contentName)
            result.ccguid = cp.Utils.CreateGuid()
            result.save(cp)
            Return result
        End Function
        '
        '====================================================================================================
        '
        Public Function Clone() As Object Implements ICloneable.Clone
            Return Me.MemberwiseClone()
        End Function
        '
        '====================================================================================================
        ''' <summary>
        ''' Save a list of this model to the database, guid required, using the guid as a key for update/import, and ignoring the id.
        ''' </summary>
        ''' <param name="cp"></param>
        ''' <param name="modelList">A dictionary with guid as key, and this model as object</param>
        Public Shared Sub migrationImport(cp As CPBaseClass, modelList As Dictionary(Of String, xxxxxmodelNameGoesHerexxxxx))
            Dim ContentControlID As Integer = cp.Content.GetID(contentName)
            For Each kvp In modelList
                If (Not String.IsNullOrEmpty(kvp.Value.ccguid)) Then
                    kvp.Value.id = 0
                    Dim dbData As xxxxxmodelNameGoesHerexxxxx = create(cp, kvp.Value.ccguid)
                    If (dbData IsNot Nothing) Then
                        kvp.Value.id = dbData.id
                    Else
                        kvp.Value.DateAdded = Now
                        kvp.Value.CreatedBy = 0
                    End If
                    kvp.Value.ContentControlID = ContentControlID
                    kvp.Value.ModifiedDate = Now
                    kvp.Value.ModifiedBy = 0
                    kvp.Value.save(cp)
                End If
            Next
        End Sub


    End Class
End Namespace
