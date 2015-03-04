# EmmaDotNet-Remote

A .NET wrapper providing legacy support for the deprecated MyEmma Remote Signup API.

## Summary

This library provides basic functionality to maintain existing forms, code, etc. that are dependant on the deprecated MyEmma Remote Signup API. Utility methods and helper classes can be found in the IDMI.Core library.

## Basic Usage

A RemoteSignup object requires a User Name, Password, Account ID, and Group ID. In the example below, these values are stored in the Web.config and accessed through a helper class.

```vb
Dim myRemoteSignupRequest As New IDMI.Emma.Remote.Business.RemoteSignup()
Dim myResponseCode As Integer = 0

With myRemoteSignupRequest
	Dim myConfig As New IDMI.Core.Business.ConfigObject()
	
	.Uri = myConfig("MyEmma_Uri")
	.UserName = myConfig("MyEmma_UserName")
	.Password = myConfig("MyEmma_Password")
	.AccountId = myConfig("MyEmma_AccountId")
	.GroupId = myConfig("MyEmma_GroupId")

	.MemberEmail = "test@example.org"
	.MemberFirstName = "John"
	.MemberLastName = "Doe"

	myRemoteSignupRequest.Send()
End With
```