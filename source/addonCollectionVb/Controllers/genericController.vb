﻿

Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses
Imports Contensive.Addon.AddonCollectionVb.Models
Imports Contensive.Addon.AddonCollectionVb.Views
Imports Contensive.Addon.AddonCollectionVb.Controllers

Namespace Contensive.Addon.AddonCollectionVb.Controllers
	Public NotInheritable Class genericController
		Private Sub New()
		End Sub
		'
		'====================================================================================================
		''' <summary>
		''' if date is invalid, set to minValue
		''' </summary>
		''' <param name="srcDate"></param>
		''' <returns></returns>
		Public Shared Function encodeMinDate(srcDate As DateTime) As DateTime
			Dim returnDate As DateTime = srcDate
			If srcDate < New DateTime(1900, 1, 1) Then
				returnDate = DateTime.MinValue
			End If
			Return returnDate
		End Function
		'
		'====================================================================================================
		''' <summary>
		''' if valid date, return the short date, else return blank string 
		''' </summary>
		''' <param name="srcDate"></param>
		''' <returns></returns>
		Public Shared Function getShortDateString(srcDate As DateTime) As String
			Dim returnString As String = ""
			Dim workingDate As DateTime = encodeMinDate(srcDate)
			If Not isDateEmpty(srcDate) Then
				returnString = workingDate.ToShortDateString()
			End If
			Return returnString
		End Function
		'
		'====================================================================================================
		Public Shared Function isDateEmpty(srcDate As DateTime) As Boolean
			Return (srcDate < New DateTime(1900, 1, 1))
		End Function
		'
		'====================================================================================================
		Public Shared Function getSortOrderFromInteger(id As Integer) As String
			Return id.ToString().PadLeft(7, "0"C)
		End Function
		'
		'====================================================================================================
		Public Shared Function getDateForHtmlInput(source As DateTime) As String
			If isDateEmpty(source) Then
				Return ""
			Else
				Return source.Year + "-" + source.Month.ToString().PadLeft(2, "0"C) + "-" + source.Day.ToString().PadLeft(2, "0"C)
			End If
		End Function
	End Class
End Namespace

