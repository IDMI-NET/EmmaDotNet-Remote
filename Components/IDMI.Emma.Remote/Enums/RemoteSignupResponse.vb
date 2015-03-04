
Namespace Enums
    '   NAME         : RemoteSignupResponse
    '   DATE CREATED : 08/01/11
    '   MOD HISTORY  : 
    ''' <summary>
    ''' Remote signup response codes.
    ''' </summary>
    ''' 
    <Obsolete("RemoteSignup API has been deprecated by MyEmma. See http://api.myemma.com/")>
    Public Enum RemoteSignupResponse
        AddedAMember = 1
        UpdatedAMember = 2
        MemberExists = 3
        DeletedTheMember = 4
        FailedToAuthenticate = -1
        FailedToAddMember = -2
        FailedToUpdateMember = -3
        FailedToDeleteMember = -5
        InvalidEmailAddress = -6
    End Enum
End Namespace