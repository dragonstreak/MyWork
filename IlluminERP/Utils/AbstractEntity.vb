Public Enum EntityStatus
    UnChange = 0
    Changed = 1
    Added = 2
End Enum
<System.SerializableAttribute()> _
Public Class AbstractEntity
    Public abstractEntityStatus As EntityStatus = EntityStatus.UnChange
End Class
