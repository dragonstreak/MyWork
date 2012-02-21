Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Namespace BLL
    Public Class PMS_ProposalStageBLL
        Dim dalFactory As EnterpriseDalFactory
        Dim iEntity As IPMS_ProposalStage
        Public Sub New()
            dalFactory = New EnterpriseDalFactory()

            iEntity = dalFactory.GetProduct(Of IPMS_ProposalStage, PMS_ProposalStageDAO)()
        End Sub
        Public Function GetEntityById(ByVal id As Integer) As PMS_ProposalStage
            Return iEntity.GetEntityById(id)
        End Function
        Public Sub DeleteEntity(ByVal Id As Integer)
            iEntity.DeleteEntity(Id)
        End Sub
        Public Function GetEntityDataSet() As DataSet
            Return iEntity.GetEntityDataSet()
        End Function
        Public Function GetEntityList() As List(Of PMS_ProposalStage)
            Return iEntity.GetEntityList()
        End Function
        Public Function SaveEntity(ByVal entity As PMS_ProposalStage) As Integer
            Return iEntity.SaveEntity(entity)
        End Function
        Public Function GetStageByProposalId(ByVal proposalId As String) As List(Of PMS_ProposalStage)
            Return iEntity.GetStageByProposalId(proposalId)
        End Function
        Function GetStageComponentMethodologyList(ByVal jobNumber As String) As DataSet
            Return iEntity.GetStageComponentMethodologyList(jobNumber)
        End Function
        ''' <summary>
        ''' Add on 2012/2/8
        ''' this method is used to get stage component costing file list.
        ''' </summary>
        ''' <param name="jobNumber">Pass the job number</param>
        ''' <returns>Return the dataset of stage component costing file.</returns>
        ''' <remarks></remarks>
        Function GetStageComponentCostingFileList(ByVal jobNumber As String) As DataSet
            Return iEntity.GetStageComponentCostingFileList(jobNumber)
        End Function
    End Class
End Namespace

