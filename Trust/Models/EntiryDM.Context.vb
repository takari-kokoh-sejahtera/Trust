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
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Namespace Trust

    Partial Public Class TrustEntities
        Inherits DbContext
    
        Public Sub New()
            MyBase.New("name=TrustEntities")
        End Sub
    
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            Throw New UnintentionalCodeFirstException()
        End Sub
    
        Public Overridable Property V_CalculateMax() As DbSet(Of V_CalculateMax)
        Public Overridable Property V_Quotations() As DbSet(Of V_Quotations)
        Public Overridable Property V_ApplicationHD() As DbSet(Of V_ApplicationHD)
        Public Overridable Property Cn_Departments() As DbSet(Of Cn_Departments)
        Public Overridable Property Cn_Directorats() As DbSet(Of Cn_Directorats)
        Public Overridable Property Cn_Divisions() As DbSet(Of Cn_Divisions)
        Public Overridable Property Cn_GMs() As DbSet(Of Cn_GMs)
        Public Overridable Property Cn_NoSerieSetup() As DbSet(Of Cn_NoSerieSetup)
        Public Overridable Property Cn_RoleAuthorizations() As DbSet(Of Cn_RoleAuthorizations)
        Public Overridable Property Cn_Roles() As DbSet(Of Cn_Roles)
        Public Overridable Property Cn_Titles() As DbSet(Of Cn_Titles)
        Public Overridable Property Cn_Units() As DbSet(Of Cn_Units)
        Public Overridable Property Ms_Customer_CompanyGroups() As DbSet(Of Ms_Customer_CompanyGroups)
        Public Overridable Property Ms_Vehicle_Brands() As DbSet(Of Ms_Vehicle_Brands)
        Public Overridable Property Ms_ProjRatingMatrixs() As DbSet(Of Ms_ProjRatingMatrixs)
        Public Overridable Property Tr_QuotationDetails() As DbSet(Of Tr_QuotationDetails)
        Public Overridable Property V_ProspectHD() As DbSet(Of V_ProspectHD)
        Public Overridable Property Tr_Deliverys() As DbSet(Of Tr_Deliverys)
        Public Overridable Property V_QuotationHD() As DbSet(Of V_QuotationHD)
        Public Overridable Property Tr_Invoices() As DbSet(Of Tr_Invoices)
        Public Overridable Property Tr_ContractReceipts() As DbSet(Of Tr_ContractReceipts)
        Public Overridable Property Tr_ContractDetailHistorys() As DbSet(Of Tr_ContractDetailHistorys)
        Public Overridable Property Tr_TemporaryCars() As DbSet(Of Tr_TemporaryCars)
        Public Overridable Property Cn_Modules() As DbSet(Of Cn_Modules)
        Public Overridable Property Tr_ContractDetails() As DbSet(Of Tr_ContractDetails)
        Public Overridable Property Tr_InvoiceDetails() As DbSet(Of Tr_InvoiceDetails)
        Public Overridable Property Tr_TotalLossOnlys() As DbSet(Of Tr_TotalLossOnlys)
        Public Overridable Property Ms_RiskGradings() As DbSet(Of Ms_RiskGradings)
        Public Overridable Property Ms_CostOfFunds() As DbSet(Of Ms_CostOfFunds)
        Public Overridable Property Ms_FixedCosts() As DbSet(Of Ms_FixedCosts)
        Public Overridable Property Tr_CalculateCashFlows() As DbSet(Of Tr_CalculateCashFlows)
        Public Overridable Property Tr_ApplicationCashFlows() As DbSet(Of Tr_ApplicationCashFlows)
        Public Overridable Property Ms_ProspectCategorys() As DbSet(Of Ms_ProspectCategorys)
        Public Overridable Property Tr_ProspectCustHistorys() As DbSet(Of Tr_ProspectCustHistorys)
        Public Overridable Property Ms_Customer_BusinessLicenses() As DbSet(Of Ms_Customer_BusinessLicenses)
        Public Overridable Property Ms_Customer_Identitass() As DbSet(Of Ms_Customer_Identitass)
        Public Overridable Property Ms_FundingCosts() As DbSet(Of Ms_FundingCosts)
        Public Overridable Property Ms_Contract_Signers() As DbSet(Of Ms_Contract_Signers)
        Public Overridable Property Ms_Citys() As DbSet(Of Ms_Citys)
        Public Overridable Property Ms_Vehicles() As DbSet(Of Ms_Vehicles)
        Public Overridable Property Ms_Customer_KYC_AuthorizedSigners() As DbSet(Of Ms_Customer_KYC_AuthorizedSigners)
        Public Overridable Property Ms_Customer_KYC_Commissioners() As DbSet(Of Ms_Customer_KYC_Commissioners)
        Public Overridable Property Ms_Customer_KYC_Directors() As DbSet(Of Ms_Customer_KYC_Directors)
        Public Overridable Property Ms_Customer_KYC_Shareholders() As DbSet(Of Ms_Customer_KYC_Shareholders)
        Public Overridable Property Ms_Customer_KYC_LineBussinesss() As DbSet(Of Ms_Customer_KYC_LineBussinesss)
        Public Overridable Property Ms_Customer_KYCs() As DbSet(Of Ms_Customer_KYCs)
        Public Overridable Property Tr_ProspectCustDetails() As DbSet(Of Tr_ProspectCustDetails)
        Public Overridable Property Cn_Approvals() As DbSet(Of Cn_Approvals)
        Public Overridable Property Cn_ApprovalUserDetails() As DbSet(Of Cn_ApprovalUserDetails)
        Public Overridable Property Cn_ApprovalUsers() As DbSet(Of Cn_ApprovalUsers)
        Public Overridable Property Tr_ContractSends() As DbSet(Of Tr_ContractSends)
        Public Overridable Property Tr_ContractDrafts() As DbSet(Of Tr_ContractDrafts)
        Public Overridable Property Tr_Contracts() As DbSet(Of Tr_Contracts)
        Public Overridable Property Tr_Approvals() As DbSet(Of Tr_Approvals)
        Public Overridable Property Cn_Users() As DbSet(Of Cn_Users)
        Public Overridable Property Ms_Vehicle_Models() As DbSet(Of Ms_Vehicle_Models)
        Public Overridable Property Tr_Applications() As DbSet(Of Tr_Applications)
        Public Overridable Property Tr_Calculates() As DbSet(Of Tr_Calculates)
        Public Overridable Property Ms_Dealers() As DbSet(Of Ms_Dealers)
        Public Overridable Property Tr_ApplicationPODetails() As DbSet(Of Tr_ApplicationPODetails)
        Public Overridable Property V_ApplicationPO() As DbSet(Of V_ApplicationPO)
        Public Overridable Property Tr_ApprovalPOs() As DbSet(Of Tr_ApprovalPOs)
        Public Overridable Property V_ProspectCusts() As DbSet(Of V_ProspectCusts)
        Public Overridable Property Tr_ProspectCusts() As DbSet(Of Tr_ProspectCusts)
        Public Overridable Property Ms_Invoice_Categorys() As DbSet(Of Ms_Invoice_Categorys)
        Public Overridable Property Cn_Levels() As DbSet(Of Cn_Levels)
        Public Overridable Property Tr_ApplicationHeaders() As DbSet(Of Tr_ApplicationHeaders)
        Public Overridable Property Tr_ApplicationPOs() As DbSet(Of Tr_ApplicationPOs)
        Public Overridable Property V_ProspectCustDetails() As DbSet(Of V_ProspectCustDetails)
        Public Overridable Property Tr_ApprovalApps() As DbSet(Of Tr_ApprovalApps)
        Public Overridable Property Tr_Quotations() As DbSet(Of Tr_Quotations)
        Public Overridable Property Ms_Customers() As DbSet(Of Ms_Customers)
        Public Overridable Property V_Approval() As DbSet(Of V_Approval)
    
        Public Overridable Function sp_CalcucationCharFromUser(fA As Nullable(Of Integer), user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_CalcucationCharFromUser_Result)
            Dim fAParameter As ObjectParameter = If(fA.HasValue, New ObjectParameter("FA", fA), New ObjectParameter("FA", GetType(Integer)))
    
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_CalcucationCharFromUser_Result)("sp_CalcucationCharFromUser", fAParameter, user_IDParameter)
        End Function
    
        Public Overridable Function sp_DashboardMarketing(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_DashboardMarketing_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_DashboardMarketing_Result)("sp_DashboardMarketing", user_IDParameter)
        End Function
    
        Public Overridable Function sp_FillOTRList(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_FillOTRList_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_FillOTRList_Result)("sp_FillOTRList", user_IDParameter)
        End Function
    
        Public Overridable Function sp_GetCustomerFromUser(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_GetCustomerFromUser_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetCustomerFromUser_Result)("sp_GetCustomerFromUser", user_IDParameter)
        End Function
    
        Public Overridable Function sp_GetProspectFromUser(fA As Nullable(Of Integer), user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_GetProspectFromUser_Result)
            Dim fAParameter As ObjectParameter = If(fA.HasValue, New ObjectParameter("FA", fA), New ObjectParameter("FA", GetType(Integer)))
    
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetProspectFromUser_Result)("sp_GetProspectFromUser", fAParameter, user_IDParameter)
        End Function
    
        Public Overridable Function sp_LevelGroupGetEditDetail(levelGroup_ID As Nullable(Of Integer)) As ObjectResult(Of sp_LevelGroupGetEditDetail_Result)
            Dim levelGroup_IDParameter As ObjectParameter = If(levelGroup_ID.HasValue, New ObjectParameter("LevelGroup_ID", levelGroup_ID), New ObjectParameter("LevelGroup_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_LevelGroupGetEditDetail_Result)("sp_LevelGroupGetEditDetail", levelGroup_IDParameter)
        End Function
    
        Public Overridable Function sp_ModuleUser(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ModuleUser_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ModuleUser_Result)("sp_ModuleUser", user_IDParameter)
        End Function
    
        Public Overridable Function sp_POFromCustomerList(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_POFromCustomerList_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_POFromCustomerList_Result)("sp_POFromCustomerList", user_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationDetail(applicationHeader_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationDetail_Result)
            Dim applicationHeader_IDParameter As ObjectParameter = If(applicationHeader_ID.HasValue, New ObjectParameter("ApplicationHeader_ID", applicationHeader_ID), New ObjectParameter("ApplicationHeader_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationDetail_Result)("sp_PrintApplicationDetail", applicationHeader_IDParameter)
        End Function
    
        Public Overridable Function sp_ProspectCharFromUser(fA As Nullable(Of Integer), user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ProspectCharFromUser_Result)
            Dim fAParameter As ObjectParameter = If(fA.HasValue, New ObjectParameter("FA", fA), New ObjectParameter("FA", GetType(Integer)))
    
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ProspectCharFromUser_Result)("sp_ProspectCharFromUser", fAParameter, user_IDParameter)
        End Function
    
        Public Overridable Function sp_ProspectCustHistoryCharFromUser(fA As Nullable(Of Integer), user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ProspectCustHistoryCharFromUser_Result)
            Dim fAParameter As ObjectParameter = If(fA.HasValue, New ObjectParameter("FA", fA), New ObjectParameter("FA", GetType(Integer)))
    
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ProspectCustHistoryCharFromUser_Result)("sp_ProspectCustHistoryCharFromUser", fAParameter, user_IDParameter)
        End Function
    
        Public Overridable Function sp_QuotationCharFromUser(fA As Nullable(Of Integer), user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_QuotationCharFromUser_Result)
            Dim fAParameter As ObjectParameter = If(fA.HasValue, New ObjectParameter("FA", fA), New ObjectParameter("FA", GetType(Integer)))
    
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_QuotationCharFromUser_Result)("sp_QuotationCharFromUser", fAParameter, user_IDParameter)
        End Function
    
        Public Overridable Function sp_RoleGetEditDetail(role_ID As Nullable(Of Integer)) As ObjectResult(Of sp_RoleGetEditDetail_Result)
            Dim role_IDParameter As ObjectParameter = If(role_ID.HasValue, New ObjectParameter("Role_ID", role_ID), New ObjectParameter("Role_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_RoleGetEditDetail_Result)("sp_RoleGetEditDetail", role_IDParameter)
        End Function
    
        Public Overridable Function sp_ContractPrint(contract_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ContractPrint_Result)
            Dim contract_IDParameter As ObjectParameter = If(contract_ID.HasValue, New ObjectParameter("Contract_ID", contract_ID), New ObjectParameter("Contract_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ContractPrint_Result)("sp_ContractPrint", contract_IDParameter)
        End Function
    
        Public Overridable Function sp_ApproveGetCal(approval_ID As Nullable(Of Integer)) As ObjectResult(Of Nullable(Of Integer))
            Dim approval_IDParameter As ObjectParameter = If(approval_ID.HasValue, New ObjectParameter("Approval_ID", approval_ID), New ObjectParameter("Approval_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("sp_ApproveGetCal", approval_IDParameter)
        End Function
    
        Public Overridable Function sp_InvoiceListPerDay([date] As Nullable(Of Date)) As ObjectResult(Of sp_InvoiceListPerDay_Result)
            Dim dateParameter As ObjectParameter = If([date].HasValue, New ObjectParameter("Date", [date]), New ObjectParameter("Date", GetType(Date)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_InvoiceListPerDay_Result)("sp_InvoiceListPerDay", dateParameter)
        End Function
    
        Public Overridable Function sp_InvoicePrint(invoice_ID As Nullable(Of Integer), createdBy As Nullable(Of Integer)) As ObjectResult(Of sp_InvoicePrint_Result)
            Dim invoice_IDParameter As ObjectParameter = If(invoice_ID.HasValue, New ObjectParameter("Invoice_ID", invoice_ID), New ObjectParameter("Invoice_ID", GetType(Integer)))
    
            Dim createdByParameter As ObjectParameter = If(createdBy.HasValue, New ObjectParameter("CreatedBy", createdBy), New ObjectParameter("CreatedBy", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_InvoicePrint_Result)("sp_InvoicePrint", invoice_IDParameter, createdByParameter)
        End Function
    
        Public Overridable Function sp_ContractDetailPrint(contract_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ContractDetailPrint_Result)
            Dim contract_IDParameter As ObjectParameter = If(contract_ID.HasValue, New ObjectParameter("Contract_ID", contract_ID), New ObjectParameter("Contract_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ContractDetailPrint_Result)("sp_ContractDetailPrint", contract_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplication(application_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplication_Result)
            Dim application_IDParameter As ObjectParameter = If(application_ID.HasValue, New ObjectParameter("Application_ID", application_ID), New ObjectParameter("Application_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplication_Result)("sp_PrintApplication", application_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationCashFlow(application_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationCashFlow_Result)
            Dim application_IDParameter As ObjectParameter = If(application_ID.HasValue, New ObjectParameter("Application_ID", application_ID), New ObjectParameter("Application_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationCashFlow_Result)("sp_PrintApplicationCashFlow", application_IDParameter)
        End Function
    
        Public Overridable Function sp_GetParameterCostTest(city_ID As Nullable(Of Integer), model_ID As Nullable(Of Integer), transaction_Type As String) As ObjectResult(Of sp_GetParameterCostTest_Result)
            Dim city_IDParameter As ObjectParameter = If(city_ID.HasValue, New ObjectParameter("City_ID", city_ID), New ObjectParameter("City_ID", GetType(Integer)))
    
            Dim model_IDParameter As ObjectParameter = If(model_ID.HasValue, New ObjectParameter("Model_ID", model_ID), New ObjectParameter("Model_ID", GetType(Integer)))
    
            Dim transaction_TypeParameter As ObjectParameter = If(transaction_Type IsNot Nothing, New ObjectParameter("Transaction_Type", transaction_Type), New ObjectParameter("Transaction_Type", GetType(String)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetParameterCostTest_Result)("sp_GetParameterCostTest", city_IDParameter, model_IDParameter, transaction_TypeParameter)
        End Function
    
        Public Overridable Function sp_GetParameterCost(city_ID As Nullable(Of Integer), type As String, transaction_Type As String) As ObjectResult(Of sp_GetParameterCost_Result)
            Dim city_IDParameter As ObjectParameter = If(city_ID.HasValue, New ObjectParameter("City_ID", city_ID), New ObjectParameter("City_ID", GetType(Integer)))
    
            Dim typeParameter As ObjectParameter = If(type IsNot Nothing, New ObjectParameter("Type", type), New ObjectParameter("Type", GetType(String)))
    
            Dim transaction_TypeParameter As ObjectParameter = If(transaction_Type IsNot Nothing, New ObjectParameter("Transaction_Type", transaction_Type), New ObjectParameter("Transaction_Type", GetType(String)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetParameterCost_Result)("sp_GetParameterCost", city_IDParameter, typeParameter, transaction_TypeParameter)
        End Function
    
        Public Overridable Function sp_KYCIM(kYC_ID As Nullable(Of Integer)) As ObjectResult(Of sp_KYCIM_Result)
            Dim kYC_IDParameter As ObjectParameter = If(kYC_ID.HasValue, New ObjectParameter("KYC_ID", kYC_ID), New ObjectParameter("KYC_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_KYCIM_Result)("sp_KYCIM", kYC_IDParameter)
        End Function
    
        Public Overridable Function sp_KYCIMCommissioner(kYC_ID As Nullable(Of Integer)) As ObjectResult(Of String)
            Dim kYC_IDParameter As ObjectParameter = If(kYC_ID.HasValue, New ObjectParameter("KYC_ID", kYC_ID), New ObjectParameter("KYC_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("sp_KYCIMCommissioner", kYC_IDParameter)
        End Function
    
        Public Overridable Function sp_KYCIMDirector(kYC_ID As Nullable(Of Integer)) As ObjectResult(Of String)
            Dim kYC_IDParameter As ObjectParameter = If(kYC_ID.HasValue, New ObjectParameter("KYC_ID", kYC_ID), New ObjectParameter("KYC_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("sp_KYCIMDirector", kYC_IDParameter)
        End Function
    
        Public Overridable Function sp_KYCIMShareholder(kYC_ID As Nullable(Of Integer)) As ObjectResult(Of sp_KYCIMShareholder_Result)
            Dim kYC_IDParameter As ObjectParameter = If(kYC_ID.HasValue, New ObjectParameter("KYC_ID", kYC_ID), New ObjectParameter("KYC_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_KYCIMShareholder_Result)("sp_KYCIMShareholder", kYC_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintContractReceipt(contract_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintContractReceipt_Result)
            Dim contract_IDParameter As ObjectParameter = If(contract_ID.HasValue, New ObjectParameter("Contract_ID", contract_ID), New ObjectParameter("Contract_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintContractReceipt_Result)("sp_PrintContractReceipt", contract_IDParameter)
        End Function
    
        Public Overridable Function sp_ContractGetDetail(contract_ID As Nullable(Of Integer)) As ObjectResult(Of sp_ContractGetDetail_Result)
            Dim contract_IDParameter As ObjectParameter = If(contract_ID.HasValue, New ObjectParameter("Contract_ID", contract_ID), New ObjectParameter("Contract_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_ContractGetDetail_Result)("sp_ContractGetDetail", contract_IDParameter)
        End Function
    
        Public Overridable Function sp_QuotationList(user_ID As Nullable(Of Integer)) As ObjectResult(Of sp_QuotationList_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_QuotationList_Result)("sp_QuotationList", user_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationCOP(applicationHeader_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationCOP_Result)
            Dim applicationHeader_IDParameter As ObjectParameter = If(applicationHeader_ID.HasValue, New ObjectParameter("ApplicationHeader_ID", applicationHeader_ID), New ObjectParameter("ApplicationHeader_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationCOP_Result)("sp_PrintApplicationCOP", applicationHeader_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintQuotation(id As Nullable(Of Integer)) As ObjectResult(Of sp_PrintQuotation_Result)
            Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("id", id), New ObjectParameter("id", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintQuotation_Result)("sp_PrintQuotation", idParameter)
        End Function
    
        Public Overridable Function sp_PrintCalculateCashFlow(calculate_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintCalculateCashFlow_Result)
            Dim calculate_IDParameter As ObjectParameter = If(calculate_ID.HasValue, New ObjectParameter("Calculate_ID", calculate_ID), New ObjectParameter("Calculate_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintCalculateCashFlow_Result)("sp_PrintCalculateCashFlow", calculate_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintCalculation(calculate_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintCalculation_Result)
            Dim calculate_IDParameter As ObjectParameter = If(calculate_ID.HasValue, New ObjectParameter("Calculate_ID", calculate_ID), New ObjectParameter("Calculate_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintCalculation_Result)("sp_PrintCalculation", calculate_IDParameter)
        End Function
    
        Public Overridable Function sp_SaveCashFlow(isCalculate As Nullable(Of Boolean), calculate_ID As Nullable(Of Integer), user As Nullable(Of Integer), expedition_Status As String, payMonth As Nullable(Of Integer), cost_Price As Nullable(Of Decimal), dP As Nullable(Of Decimal), replacement As Nullable(Of Decimal), maintenance As Nullable(Of Decimal), sTNK As Nullable(Of Decimal), overhead As Nullable(Of Decimal), insurance As Nullable(Of Decimal), price_Month As Nullable(Of Decimal), rV As Nullable(Of Decimal), lama As Nullable(Of Decimal), expedition_Cost As Nullable(Of Decimal), type As String, payment As String, term_Of_Payment As Nullable(Of Integer), modification As Nullable(Of Decimal), gPS_Cost As Nullable(Of Decimal), gPS_CostPerMonth As Nullable(Of Decimal), agent_Fee As Nullable(Of Decimal), agent_FeePerMonth As Nullable(Of Decimal), other As Nullable(Of Decimal), keur As Nullable(Of Decimal), funding_Rate As Nullable(Of Decimal)) As ObjectResult(Of sp_SaveCashFlow_Result)
            Dim isCalculateParameter As ObjectParameter = If(isCalculate.HasValue, New ObjectParameter("IsCalculate", isCalculate), New ObjectParameter("IsCalculate", GetType(Boolean)))
    
            Dim calculate_IDParameter As ObjectParameter = If(calculate_ID.HasValue, New ObjectParameter("Calculate_ID", calculate_ID), New ObjectParameter("Calculate_ID", GetType(Integer)))
    
            Dim userParameter As ObjectParameter = If(user.HasValue, New ObjectParameter("user", user), New ObjectParameter("user", GetType(Integer)))
    
            Dim expedition_StatusParameter As ObjectParameter = If(expedition_Status IsNot Nothing, New ObjectParameter("Expedition_Status", expedition_Status), New ObjectParameter("Expedition_Status", GetType(String)))
    
            Dim payMonthParameter As ObjectParameter = If(payMonth.HasValue, New ObjectParameter("PayMonth", payMonth), New ObjectParameter("PayMonth", GetType(Integer)))
    
            Dim cost_PriceParameter As ObjectParameter = If(cost_Price.HasValue, New ObjectParameter("Cost_Price", cost_Price), New ObjectParameter("Cost_Price", GetType(Decimal)))
    
            Dim dPParameter As ObjectParameter = If(dP.HasValue, New ObjectParameter("DP", dP), New ObjectParameter("DP", GetType(Decimal)))
    
            Dim replacementParameter As ObjectParameter = If(replacement.HasValue, New ObjectParameter("Replacement", replacement), New ObjectParameter("Replacement", GetType(Decimal)))
    
            Dim maintenanceParameter As ObjectParameter = If(maintenance.HasValue, New ObjectParameter("Maintenance", maintenance), New ObjectParameter("Maintenance", GetType(Decimal)))
    
            Dim sTNKParameter As ObjectParameter = If(sTNK.HasValue, New ObjectParameter("STNK", sTNK), New ObjectParameter("STNK", GetType(Decimal)))
    
            Dim overheadParameter As ObjectParameter = If(overhead.HasValue, New ObjectParameter("Overhead", overhead), New ObjectParameter("Overhead", GetType(Decimal)))
    
            Dim insuranceParameter As ObjectParameter = If(insurance.HasValue, New ObjectParameter("Insurance", insurance), New ObjectParameter("Insurance", GetType(Decimal)))
    
            Dim price_MonthParameter As ObjectParameter = If(price_Month.HasValue, New ObjectParameter("Price_Month", price_Month), New ObjectParameter("Price_Month", GetType(Decimal)))
    
            Dim rVParameter As ObjectParameter = If(rV.HasValue, New ObjectParameter("RV", rV), New ObjectParameter("RV", GetType(Decimal)))
    
            Dim lamaParameter As ObjectParameter = If(lama.HasValue, New ObjectParameter("lama", lama), New ObjectParameter("lama", GetType(Decimal)))
    
            Dim expedition_CostParameter As ObjectParameter = If(expedition_Cost.HasValue, New ObjectParameter("Expedition_Cost", expedition_Cost), New ObjectParameter("Expedition_Cost", GetType(Decimal)))
    
            Dim typeParameter As ObjectParameter = If(type IsNot Nothing, New ObjectParameter("type", type), New ObjectParameter("type", GetType(String)))
    
            Dim paymentParameter As ObjectParameter = If(payment IsNot Nothing, New ObjectParameter("Payment", payment), New ObjectParameter("Payment", GetType(String)))
    
            Dim term_Of_PaymentParameter As ObjectParameter = If(term_Of_Payment.HasValue, New ObjectParameter("Term_Of_Payment", term_Of_Payment), New ObjectParameter("Term_Of_Payment", GetType(Integer)))
    
            Dim modificationParameter As ObjectParameter = If(modification.HasValue, New ObjectParameter("Modification", modification), New ObjectParameter("Modification", GetType(Decimal)))
    
            Dim gPS_CostParameter As ObjectParameter = If(gPS_Cost.HasValue, New ObjectParameter("GPS_Cost", gPS_Cost), New ObjectParameter("GPS_Cost", GetType(Decimal)))
    
            Dim gPS_CostPerMonthParameter As ObjectParameter = If(gPS_CostPerMonth.HasValue, New ObjectParameter("GPS_CostPerMonth", gPS_CostPerMonth), New ObjectParameter("GPS_CostPerMonth", GetType(Decimal)))
    
            Dim agent_FeeParameter As ObjectParameter = If(agent_Fee.HasValue, New ObjectParameter("Agent_Fee", agent_Fee), New ObjectParameter("Agent_Fee", GetType(Decimal)))
    
            Dim agent_FeePerMonthParameter As ObjectParameter = If(agent_FeePerMonth.HasValue, New ObjectParameter("Agent_FeePerMonth", agent_FeePerMonth), New ObjectParameter("Agent_FeePerMonth", GetType(Decimal)))
    
            Dim otherParameter As ObjectParameter = If(other.HasValue, New ObjectParameter("Other", other), New ObjectParameter("Other", GetType(Decimal)))
    
            Dim keurParameter As ObjectParameter = If(keur.HasValue, New ObjectParameter("Keur", keur), New ObjectParameter("Keur", GetType(Decimal)))
    
            Dim funding_RateParameter As ObjectParameter = If(funding_Rate.HasValue, New ObjectParameter("Funding_Rate", funding_Rate), New ObjectParameter("Funding_Rate", GetType(Decimal)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_SaveCashFlow_Result)("sp_SaveCashFlow", isCalculateParameter, calculate_IDParameter, userParameter, expedition_StatusParameter, payMonthParameter, cost_PriceParameter, dPParameter, replacementParameter, maintenanceParameter, sTNKParameter, overheadParameter, insuranceParameter, price_MonthParameter, rVParameter, lamaParameter, expedition_CostParameter, typeParameter, paymentParameter, term_Of_PaymentParameter, modificationParameter, gPS_CostParameter, gPS_CostPerMonthParameter, agent_FeeParameter, agent_FeePerMonthParameter, otherParameter, keurParameter, funding_RateParameter)
        End Function
    
        Public Overridable Function GetCountApprove(user_ID As Nullable(Of Integer)) As ObjectResult(Of GetCountApprove_Result)
            Dim user_IDParameter As ObjectParameter = If(user_ID.HasValue, New ObjectParameter("User_ID", user_ID), New ObjectParameter("User_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of GetCountApprove_Result)("GetCountApprove", user_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationPO(prospectCustomer_ID As Nullable(Of Integer), dealer_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationPO_Result)
            Dim prospectCustomer_IDParameter As ObjectParameter = If(prospectCustomer_ID.HasValue, New ObjectParameter("ProspectCustomer_ID", prospectCustomer_ID), New ObjectParameter("ProspectCustomer_ID", GetType(Integer)))
    
            Dim dealer_IDParameter As ObjectParameter = If(dealer_ID.HasValue, New ObjectParameter("Dealer_ID", dealer_ID), New ObjectParameter("Dealer_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationPO_Result)("sp_PrintApplicationPO", prospectCustomer_IDParameter, dealer_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationPODealer(prospectCustomer_ID As Nullable(Of Integer), dealer_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationPODealer_Result)
            Dim prospectCustomer_IDParameter As ObjectParameter = If(prospectCustomer_ID.HasValue, New ObjectParameter("ProspectCustomer_ID", prospectCustomer_ID), New ObjectParameter("ProspectCustomer_ID", GetType(Integer)))
    
            Dim dealer_IDParameter As ObjectParameter = If(dealer_ID.HasValue, New ObjectParameter("Dealer_ID", dealer_ID), New ObjectParameter("Dealer_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationPODealer_Result)("sp_PrintApplicationPODealer", prospectCustomer_IDParameter, dealer_IDParameter)
        End Function
    
        Public Overridable Function sp_PrintApplicationDetailNew(applicationHeader_ID As Nullable(Of Integer)) As ObjectResult(Of sp_PrintApplicationDetailNew_Result)
            Dim applicationHeader_IDParameter As ObjectParameter = If(applicationHeader_ID.HasValue, New ObjectParameter("ApplicationHeader_ID", applicationHeader_ID), New ObjectParameter("ApplicationHeader_ID", GetType(Integer)))
    
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_PrintApplicationDetailNew_Result)("sp_PrintApplicationDetailNew", applicationHeader_IDParameter)
        End Function
    
    End Class

End Namespace
