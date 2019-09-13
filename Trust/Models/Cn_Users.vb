'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Namespace Trust

    Partial Public Class Cn_Users
        Public Property User_ID As Integer
        Public Property NIK As String
        Public Property User_Name As String
        Public Property Full_Name As String
        Public Property Password As String
        Public Property Directorat_ID As Nullable(Of Integer)
        Public Property GM_ID As Nullable(Of Integer)
        Public Property Division_ID As Nullable(Of Integer)
        Public Property Department_ID As Nullable(Of Integer)
        Public Property Title_ID As Nullable(Of Integer)
        Public Property Role_ID As Nullable(Of Integer)
        Public Property Pic As String
        Public Property Paraf As Byte()
        Public Property Sign As Byte()
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Cn_Approvals As ICollection(Of Cn_Approvals) = New HashSet(Of Cn_Approvals)
        Public Overridable Property Cn_Approvals1 As ICollection(Of Cn_Approvals) = New HashSet(Of Cn_Approvals)
        Public Overridable Property Cn_ApprovalUserDetails As ICollection(Of Cn_ApprovalUserDetails) = New HashSet(Of Cn_ApprovalUserDetails)
        Public Overridable Property Cn_ApprovalUserDetails1 As ICollection(Of Cn_ApprovalUserDetails) = New HashSet(Of Cn_ApprovalUserDetails)
        Public Overridable Property Cn_ApprovalUsers As ICollection(Of Cn_ApprovalUsers) = New HashSet(Of Cn_ApprovalUsers)
        Public Overridable Property Cn_ApprovalUsers1 As ICollection(Of Cn_ApprovalUsers) = New HashSet(Of Cn_ApprovalUsers)
        Public Overridable Property Cn_ApprovalUsers2 As ICollection(Of Cn_ApprovalUsers) = New HashSet(Of Cn_ApprovalUsers)
        Public Overridable Property Cn_Departments As Cn_Departments
        Public Overridable Property Cn_Directorats As ICollection(Of Cn_Directorats) = New HashSet(Of Cn_Directorats)
        Public Overridable Property Cn_Directorats1 As ICollection(Of Cn_Directorats) = New HashSet(Of Cn_Directorats)
        Public Overridable Property Cn_Directorats2 As Cn_Directorats
        Public Overridable Property Cn_Directorats3 As Cn_Directorats
        Public Overridable Property Cn_Divisions As ICollection(Of Cn_Divisions) = New HashSet(Of Cn_Divisions)
        Public Overridable Property Cn_Divisions1 As ICollection(Of Cn_Divisions) = New HashSet(Of Cn_Divisions)
        Public Overridable Property Cn_Divisions2 As Cn_Divisions
        Public Overridable Property Cn_Divisions3 As Cn_Divisions
        Public Overridable Property Cn_GMs As ICollection(Of Cn_GMs) = New HashSet(Of Cn_GMs)
        Public Overridable Property Cn_GMs1 As ICollection(Of Cn_GMs) = New HashSet(Of Cn_GMs)
        Public Overridable Property Cn_GMs2 As Cn_GMs
        Public Overridable Property Cn_GMs3 As Cn_GMs
        Public Overridable Property Cn_Modules As ICollection(Of Cn_Modules) = New HashSet(Of Cn_Modules)
        Public Overridable Property Cn_Modules1 As ICollection(Of Cn_Modules) = New HashSet(Of Cn_Modules)
        Public Overridable Property Cn_NoSerieSetup As ICollection(Of Cn_NoSerieSetup) = New HashSet(Of Cn_NoSerieSetup)
        Public Overridable Property Cn_NoSerieSetup1 As ICollection(Of Cn_NoSerieSetup) = New HashSet(Of Cn_NoSerieSetup)
        Public Overridable Property Cn_RoleAuthorizations As ICollection(Of Cn_RoleAuthorizations) = New HashSet(Of Cn_RoleAuthorizations)
        Public Overridable Property Cn_RoleAuthorizations1 As ICollection(Of Cn_RoleAuthorizations) = New HashSet(Of Cn_RoleAuthorizations)
        Public Overridable Property Cn_Roles As ICollection(Of Cn_Roles) = New HashSet(Of Cn_Roles)
        Public Overridable Property Cn_Roles1 As ICollection(Of Cn_Roles) = New HashSet(Of Cn_Roles)
        Public Overridable Property Cn_Roles2 As Cn_Roles
        Public Overridable Property Cn_Titles As ICollection(Of Cn_Titles) = New HashSet(Of Cn_Titles)
        Public Overridable Property Cn_Titles1 As ICollection(Of Cn_Titles) = New HashSet(Of Cn_Titles)
        Public Overridable Property Cn_Titles2 As Cn_Titles
        Public Overridable Property Cn_Titles3 As Cn_Titles
        Public Overridable Property Cn_Units As ICollection(Of Cn_Units) = New HashSet(Of Cn_Units)
        Public Overridable Property Cn_Units1 As ICollection(Of Cn_Units) = New HashSet(Of Cn_Units)
        Public Overridable Property Ms_Citys As ICollection(Of Ms_Citys) = New HashSet(Of Ms_Citys)
        Public Overridable Property Ms_Citys1 As ICollection(Of Ms_Citys) = New HashSet(Of Ms_Citys)
        Public Overridable Property Ms_Contract_Signers As ICollection(Of Ms_Contract_Signers) = New HashSet(Of Ms_Contract_Signers)
        Public Overridable Property Ms_Contract_Signers1 As ICollection(Of Ms_Contract_Signers) = New HashSet(Of Ms_Contract_Signers)
        Public Overridable Property Ms_CostOfFunds As ICollection(Of Ms_CostOfFunds) = New HashSet(Of Ms_CostOfFunds)
        Public Overridable Property Ms_CostOfFunds1 As ICollection(Of Ms_CostOfFunds) = New HashSet(Of Ms_CostOfFunds)
        Public Overridable Property Ms_Customer_Identitass As ICollection(Of Ms_Customer_Identitass) = New HashSet(Of Ms_Customer_Identitass)
        Public Overridable Property Ms_Customer_BusinessLicenses As ICollection(Of Ms_Customer_BusinessLicenses) = New HashSet(Of Ms_Customer_BusinessLicenses)
        Public Overridable Property Ms_Customer_KYC_Shareholders As ICollection(Of Ms_Customer_KYC_Shareholders) = New HashSet(Of Ms_Customer_KYC_Shareholders)
        Public Overridable Property Ms_Customer_KYCs As ICollection(Of Ms_Customer_KYCs) = New HashSet(Of Ms_Customer_KYCs)
        Public Overridable Property Ms_Customer_KYC_Directors As ICollection(Of Ms_Customer_KYC_Directors) = New HashSet(Of Ms_Customer_KYC_Directors)
        Public Overridable Property Ms_Customer_KYC_Commissioners As ICollection(Of Ms_Customer_KYC_Commissioners) = New HashSet(Of Ms_Customer_KYC_Commissioners)
        Public Overridable Property Ms_Customer_KYC_AuthorizedSigners As ICollection(Of Ms_Customer_KYC_AuthorizedSigners) = New HashSet(Of Ms_Customer_KYC_AuthorizedSigners)
        Public Overridable Property Ms_Customer_CompanyGroups As ICollection(Of Ms_Customer_CompanyGroups) = New HashSet(Of Ms_Customer_CompanyGroups)
        Public Overridable Property Ms_Customer_KYC_LineBussinesss As ICollection(Of Ms_Customer_KYC_LineBussinesss) = New HashSet(Of Ms_Customer_KYC_LineBussinesss)
        Public Overridable Property Ms_Customer_Identitass1 As ICollection(Of Ms_Customer_Identitass) = New HashSet(Of Ms_Customer_Identitass)
        Public Overridable Property Ms_Customer_BusinessLicenses1 As ICollection(Of Ms_Customer_BusinessLicenses) = New HashSet(Of Ms_Customer_BusinessLicenses)
        Public Overridable Property Ms_Customer_KYC_Shareholders1 As ICollection(Of Ms_Customer_KYC_Shareholders) = New HashSet(Of Ms_Customer_KYC_Shareholders)
        Public Overridable Property Ms_Customer_KYCs1 As ICollection(Of Ms_Customer_KYCs) = New HashSet(Of Ms_Customer_KYCs)
        Public Overridable Property Ms_Customer_KYC_Directors1 As ICollection(Of Ms_Customer_KYC_Directors) = New HashSet(Of Ms_Customer_KYC_Directors)
        Public Overridable Property Ms_Customer_KYC_Commissioners1 As ICollection(Of Ms_Customer_KYC_Commissioners) = New HashSet(Of Ms_Customer_KYC_Commissioners)
        Public Overridable Property Ms_Customer_KYC_AuthorizedSigners1 As ICollection(Of Ms_Customer_KYC_AuthorizedSigners) = New HashSet(Of Ms_Customer_KYC_AuthorizedSigners)
        Public Overridable Property Ms_Customer_CompanyGroups1 As ICollection(Of Ms_Customer_CompanyGroups) = New HashSet(Of Ms_Customer_CompanyGroups)
        Public Overridable Property Ms_Customer_KYC_LineBussinesss1 As ICollection(Of Ms_Customer_KYC_LineBussinesss) = New HashSet(Of Ms_Customer_KYC_LineBussinesss)
        Public Overridable Property Ms_Customer_KYCs2 As ICollection(Of Ms_Customer_KYCs) = New HashSet(Of Ms_Customer_KYCs)
        Public Overridable Property Ms_FixedCosts As ICollection(Of Ms_FixedCosts) = New HashSet(Of Ms_FixedCosts)
        Public Overridable Property Ms_FixedCosts1 As ICollection(Of Ms_FixedCosts) = New HashSet(Of Ms_FixedCosts)
        Public Overridable Property Ms_ProjRatingMatrixs As ICollection(Of Ms_ProjRatingMatrixs) = New HashSet(Of Ms_ProjRatingMatrixs)
        Public Overridable Property Ms_ProjRatingMatrixs1 As ICollection(Of Ms_ProjRatingMatrixs) = New HashSet(Of Ms_ProjRatingMatrixs)
        Public Overridable Property Ms_ProspectCategorys As ICollection(Of Ms_ProspectCategorys) = New HashSet(Of Ms_ProspectCategorys)
        Public Overridable Property Ms_ProspectCategorys1 As ICollection(Of Ms_ProspectCategorys) = New HashSet(Of Ms_ProspectCategorys)
        Public Overridable Property Ms_RiskGradings As ICollection(Of Ms_RiskGradings) = New HashSet(Of Ms_RiskGradings)
        Public Overridable Property Ms_RiskGradings1 As ICollection(Of Ms_RiskGradings) = New HashSet(Of Ms_RiskGradings)
        Public Overridable Property Ms_Vehicles As ICollection(Of Ms_Vehicles) = New HashSet(Of Ms_Vehicles)
        Public Overridable Property Ms_Vehicle_Brands As ICollection(Of Ms_Vehicle_Brands) = New HashSet(Of Ms_Vehicle_Brands)
        Public Overridable Property Ms_Vehicles1 As ICollection(Of Ms_Vehicles) = New HashSet(Of Ms_Vehicles)
        Public Overridable Property Ms_Vehicle_Brands1 As ICollection(Of Ms_Vehicle_Brands) = New HashSet(Of Ms_Vehicle_Brands)
        Public Overridable Property Tr_ApplicationCashFlows As ICollection(Of Tr_ApplicationCashFlows) = New HashSet(Of Tr_ApplicationCashFlows)
        Public Overridable Property Tr_ApplicationCashFlows1 As ICollection(Of Tr_ApplicationCashFlows) = New HashSet(Of Tr_ApplicationCashFlows)
        Public Overridable Property Tr_Approvals As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals1 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals2 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals3 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals4 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals5 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals6 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals7 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_Approvals8 As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
        Public Overridable Property Tr_CalculateCashFlows As ICollection(Of Tr_CalculateCashFlows) = New HashSet(Of Tr_CalculateCashFlows)
        Public Overridable Property Tr_CalculateCashFlows1 As ICollection(Of Tr_CalculateCashFlows) = New HashSet(Of Tr_CalculateCashFlows)
        Public Overridable Property Tr_ContractReceipts As ICollection(Of Tr_ContractReceipts) = New HashSet(Of Tr_ContractReceipts)
        Public Overridable Property Tr_ContractDrafts As ICollection(Of Tr_ContractDrafts) = New HashSet(Of Tr_ContractDrafts)
        Public Overridable Property Tr_ContractSends As ICollection(Of Tr_ContractSends) = New HashSet(Of Tr_ContractSends)
        Public Overridable Property Tr_ContractDetails As ICollection(Of Tr_ContractDetails) = New HashSet(Of Tr_ContractDetails)
        Public Overridable Property Tr_ContractDetailHistorys As ICollection(Of Tr_ContractDetailHistorys) = New HashSet(Of Tr_ContractDetailHistorys)
        Public Overridable Property Tr_ContractDetailHistorys1 As ICollection(Of Tr_ContractDetailHistorys) = New HashSet(Of Tr_ContractDetailHistorys)
        Public Overridable Property Tr_ContractReceipts1 As ICollection(Of Tr_ContractReceipts) = New HashSet(Of Tr_ContractReceipts)
        Public Overridable Property Tr_ContractDrafts1 As ICollection(Of Tr_ContractDrafts) = New HashSet(Of Tr_ContractDrafts)
        Public Overridable Property Tr_ContractSends1 As ICollection(Of Tr_ContractSends) = New HashSet(Of Tr_ContractSends)
        Public Overridable Property Tr_ContractDetails1 As ICollection(Of Tr_ContractDetails) = New HashSet(Of Tr_ContractDetails)
        Public Overridable Property Tr_Deliverys As ICollection(Of Tr_Deliverys) = New HashSet(Of Tr_Deliverys)
        Public Overridable Property Tr_Deliverys1 As ICollection(Of Tr_Deliverys) = New HashSet(Of Tr_Deliverys)
        Public Overridable Property Tr_Invoices As ICollection(Of Tr_Invoices) = New HashSet(Of Tr_Invoices)
        Public Overridable Property Tr_InvoiceDetails As ICollection(Of Tr_InvoiceDetails) = New HashSet(Of Tr_InvoiceDetails)
        Public Overridable Property Tr_Invoices1 As ICollection(Of Tr_Invoices) = New HashSet(Of Tr_Invoices)
        Public Overridable Property Tr_InvoiceDetails1 As ICollection(Of Tr_InvoiceDetails) = New HashSet(Of Tr_InvoiceDetails)
        Public Overridable Property Tr_Invoices2 As ICollection(Of Tr_Invoices) = New HashSet(Of Tr_Invoices)
        Public Overridable Property Tr_Invoices3 As ICollection(Of Tr_Invoices) = New HashSet(Of Tr_Invoices)
        Public Overridable Property Tr_ProspectCustHistorys As ICollection(Of Tr_ProspectCustHistorys) = New HashSet(Of Tr_ProspectCustHistorys)
        Public Overridable Property Tr_ProspectCustHistorys1 As ICollection(Of Tr_ProspectCustHistorys) = New HashSet(Of Tr_ProspectCustHistorys)
        Public Overridable Property Tr_ProspectCustHistorys2 As ICollection(Of Tr_ProspectCustHistorys) = New HashSet(Of Tr_ProspectCustHistorys)
        Public Overridable Property Tr_QuotationDetails As ICollection(Of Tr_QuotationDetails) = New HashSet(Of Tr_QuotationDetails)
        Public Overridable Property Tr_QuotationDetails1 As ICollection(Of Tr_QuotationDetails) = New HashSet(Of Tr_QuotationDetails)
        Public Overridable Property Tr_TemporaryCars As ICollection(Of Tr_TemporaryCars) = New HashSet(Of Tr_TemporaryCars)
        Public Overridable Property Tr_TemporaryCars1 As ICollection(Of Tr_TemporaryCars) = New HashSet(Of Tr_TemporaryCars)
        Public Overridable Property Tr_TotalLossOnlys As ICollection(Of Tr_TotalLossOnlys) = New HashSet(Of Tr_TotalLossOnlys)
        Public Overridable Property Tr_TotalLossOnlys1 As ICollection(Of Tr_TotalLossOnlys) = New HashSet(Of Tr_TotalLossOnlys)
        Public Overridable Property Ms_Vehicle_Models As ICollection(Of Ms_Vehicle_Models) = New HashSet(Of Ms_Vehicle_Models)
        Public Overridable Property Ms_Vehicle_Models1 As ICollection(Of Ms_Vehicle_Models) = New HashSet(Of Ms_Vehicle_Models)
        Public Overridable Property Tr_Calculates As ICollection(Of Tr_Calculates) = New HashSet(Of Tr_Calculates)
        Public Overridable Property Tr_Calculates1 As ICollection(Of Tr_Calculates) = New HashSet(Of Tr_Calculates)
        Public Overridable Property Tr_Calculates2 As ICollection(Of Tr_Calculates) = New HashSet(Of Tr_Calculates)
        Public Overridable Property Ms_Dealers As ICollection(Of Ms_Dealers) = New HashSet(Of Ms_Dealers)
        Public Overridable Property Ms_Dealers1 As ICollection(Of Ms_Dealers) = New HashSet(Of Ms_Dealers)
        Public Overridable Property Tr_ApplicationPODetails As ICollection(Of Tr_ApplicationPODetails) = New HashSet(Of Tr_ApplicationPODetails)
        Public Overridable Property Tr_ApplicationPODetails1 As ICollection(Of Tr_ApplicationPODetails) = New HashSet(Of Tr_ApplicationPODetails)
        Public Overridable Property Tr_ApprovalPOs As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs1 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs2 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs3 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs4 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs5 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs6 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs7 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Tr_ApprovalPOs8 As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
        Public Overridable Property Ms_Invoice_Categorys As ICollection(Of Ms_Invoice_Categorys) = New HashSet(Of Ms_Invoice_Categorys)
        Public Overridable Property Ms_Invoice_Categorys1 As ICollection(Of Ms_Invoice_Categorys) = New HashSet(Of Ms_Invoice_Categorys)
        Public Overridable Property Cn_Levels As ICollection(Of Cn_Levels) = New HashSet(Of Cn_Levels)
        Public Overridable Property Cn_Levels1 As ICollection(Of Cn_Levels) = New HashSet(Of Cn_Levels)
        Public Overridable Property Tr_ApplicationPOs As ICollection(Of Tr_ApplicationPOs) = New HashSet(Of Tr_ApplicationPOs)
        Public Overridable Property Tr_ApplicationPOs1 As ICollection(Of Tr_ApplicationPOs) = New HashSet(Of Tr_ApplicationPOs)
        Public Overridable Property Tr_ApprovalApps As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps1 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps2 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps3 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps4 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps5 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps6 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps7 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps8 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps9 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps10 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_ApprovalApps11 As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
        Public Overridable Property Ms_Customers As ICollection(Of Ms_Customers) = New HashSet(Of Ms_Customers)
        Public Overridable Property Ms_Customers1 As ICollection(Of Ms_Customers) = New HashSet(Of Ms_Customers)
        Public Overridable Property Tr_ProspectCusts As ICollection(Of Tr_ProspectCusts) = New HashSet(Of Tr_ProspectCusts)
        Public Overridable Property Tr_ProspectCusts1 As ICollection(Of Tr_ProspectCusts) = New HashSet(Of Tr_ProspectCusts)
        Public Overridable Property Tr_ApplicationHeaders As ICollection(Of Tr_ApplicationHeaders) = New HashSet(Of Tr_ApplicationHeaders)
        Public Overridable Property Tr_ApplicationHeaders1 As ICollection(Of Tr_ApplicationHeaders) = New HashSet(Of Tr_ApplicationHeaders)
        Public Overridable Property Tr_Applications As ICollection(Of Tr_Applications) = New HashSet(Of Tr_Applications)
        Public Overridable Property Tr_Quotations As ICollection(Of Tr_Quotations) = New HashSet(Of Tr_Quotations)
        Public Overridable Property Tr_Quotations1 As ICollection(Of Tr_Quotations) = New HashSet(Of Tr_Quotations)
        Public Overridable Property Tr_Quotations2 As ICollection(Of Tr_Quotations) = New HashSet(Of Tr_Quotations)
        Public Overridable Property Tr_SetDeliveries As ICollection(Of Tr_SetDeliveries) = New HashSet(Of Tr_SetDeliveries)
        Public Overridable Property Tr_SetDeliveryDetails As ICollection(Of Tr_SetDeliveryDetails) = New HashSet(Of Tr_SetDeliveryDetails)
        Public Overridable Property Tr_SetDeliveries1 As ICollection(Of Tr_SetDeliveries) = New HashSet(Of Tr_SetDeliveries)
        Public Overridable Property Tr_SetDeliveryDetails1 As ICollection(Of Tr_SetDeliveryDetails) = New HashSet(Of Tr_SetDeliveryDetails)
        Public Overridable Property Tr_Contracts As ICollection(Of Tr_Contracts) = New HashSet(Of Tr_Contracts)
        Public Overridable Property Tr_Contracts1 As ICollection(Of Tr_Contracts) = New HashSet(Of Tr_Contracts)
    
    End Class

End Namespace
