Imports DataAccess.BLL
Imports DataAccess.Model

Partial Class PMS_StageEdit
    Inherits OperatePageBase
    Private stageBLL As New PMS_ProposalStageBLL

    ''' <summary>
    ''' This method is used to set form 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url

        If OperateType = "Modify" Then
            labelStatus.Text = "Save Stage"
            Dim id As String = Page.Request.QueryString("stageId")
            Dim stageEntity = stageBLL.GetEntityById(Convert.ToInt32(id))

            'set the form.
            Me.tbStageName.Text = stageEntity.StageName
            Me.tbDescription.Text = stageEntity.Description
            Me.tbStageNumber.Text = stageEntity.StageNumber
            ViewState("CurrentStage") = stageEntity
        Else
            Dim maxStageNumber As String = Page.Request.QueryString("maxStageNumber")
            Me.tbStageNumber.Text = CStr(CInt(maxStageNumber) + 1)
        End If

    End Sub
    
    Private Function CheckData() As Boolean

        If tbStageNumber.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Stage number should not be empty！');")
            Response.Write("</script>")
            Return False
        End If

       
        Return True
    End Function



    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'check data
        If Not CheckData() Then
            Return
        End If
        Try
            Dim operatedResult As Boolean
            Dim stageEntity As PMS_ProposalStage
            'Get Jobnumber from url

            'Get the information from user input

            If OperateType = "New" Then
                stageEntity = New PMS_ProposalStage
                stageEntity.StageName = tbStageName.Text.Trim
                stageEntity.Description = Me.tbDescription.Text.Trim
                stageEntity.StageNumber = CInt(tbStageNumber.Text.Trim)
                stageEntity.Jobnumber = Page.Request.QueryString("jobNumber")
                stageEntity.CreatedBy = CurrentLoginUser.ID ' CType(Session("LoginUserInfo"), User_UserInfo).ID
                stageEntity.CreatedDate = DateTime.Now
                stageEntity.Id = -1
                'operatedResult = (stageBLL.SaveEntity(stageEntity) > 0)
            End If
            If OperateType = "Modify" Then

                stageEntity = CType(ViewState("CurrentStage"), PMS_ProposalStage)
                stageEntity.StageName = tbStageName.Text.Trim
                stageEntity.Description = Me.tbDescription.Text.Trim
                stageEntity.StageNumber = CInt(tbStageNumber.Text.Trim)
                stageEntity.UpdatedBy = CurrentLoginUser.ID ' CType(Session("LoginUserInfo"), User_UserInfo).ID
                stageEntity.UpdatedDate = DateTime.Now
                'operatedResult = (stageBLL.SaveEntity(stageEntity) > 0)
            End If

            operatedResult = (stageBLL.SaveEntity(stageEntity) > 0)
            'if operate success, then should return,else should remind user that operate failed.
            If operatedResult Then
                'remind
                Response.Write("<script language=javascript>")
                Response.Write("alert('success!');window.returnValue='success';window.close();")
                Response.Write("</script>")
                'close current page
            Else
                'remind
                Response.Write("<script language=javascript>")
                Response.Write("alert('failed!');window.returnValue='failed';window.close();")
                Response.Write("</script>")
                'close current page
            End If
        Catch ex As Exception
            Dim st As String = ex.Message
            Throw ex
        End Try
    End Sub
End Class
