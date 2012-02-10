<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewDesign.aspx.vb" Inherits="PMS_ViewDesign" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IllumineraERPConnectionString %>" 
        SelectCommand="SELECT a.Id, a.JobNumber, a.JobName, a.JobIndex, a.BusinessUnitId, a.ClientId, a.Proposalrating, a.SectorId, a.ProductCategoryId, a.StudyTypeId, a.Probability, a.Description, a.KeyWords, a.UploadFilePath, a.CreateDate, a.Status, a.StatusNote, a.StatusDate, b.Id AS Expr1, b.StageNumber, b.StageName, b.Description AS Expr2, b.CreatedBy, b.CreatedDate, b.UpdatedBy, b.UpdatedDate, b.Jobnumber AS Expr3, c.id AS Expr4, c.StageId, c.ComponentName, c.KeyWords AS Expr5, c.SampleDesign, c.SampleSize, c.MethdologyType, c.Methodology, c.UpdatedDate AS Expr6, c.UpdatedBy AS Expr7, c.CreatedDate AS Expr8, c.CreatedBy AS Expr9, c.Jobnumber AS Expr10 FROM t_PMS_ProposalInfo AS a INNER JOIN t_PMS_ProposalStage AS b ON a.JobNumber = b.Jobnumber LEFT OUTER JOIN t_PMS_Component AS c ON b.Id = c.StageId">
    </asp:SqlDataSource>
    </form>
</body>
</html>
