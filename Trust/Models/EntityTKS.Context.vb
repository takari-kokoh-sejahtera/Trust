﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class TKSEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=TKSEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property manufacturers() As DbSet(Of manufacturer)
    Public Overridable Property owners() As DbSet(Of owner)
    Public Overridable Property vehicle_test() As DbSet(Of vehicle_test)
    Public Overridable Property vehicles() As DbSet(Of vehicle)

End Class
