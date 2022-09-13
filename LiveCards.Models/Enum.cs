using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Models
{
    public enum SubscriptionStatus
    {
        New = 1,
        Active = 2,
        Inactive = 3,
        RegularDisconnection = 4,
        Canceled = 5,
    }


    public enum SettingsKeys
    {
        PrepaidForge_Email,
        PrepaidForge_Password,
        TalTelecom_PhoneNumber,
        TalTelecom_Year,
        TalTelecom_RefreshToken,
        TalTelecom_Jwt,
        AgentPercent,
        DealerPercent,
        CustomerPercent,
        Facebook,
        Instagram,
        Linkedin,
        Twitter
    }

    public enum TicketStatus
    {
        New = 1,
        InTreatment = 2,
        Completed = 3,
        NotTreatable = 4,
        InManagerialCare = 5
    }

    public enum TicketTopics
    {
        SIMReplacement = 5,
        ActivateNumber = 8,
        SwitchCompany = 9,
        Renew = 10,
        CloseSubscription = 12,
        UpdatePackage = 13,
        ActivateNewNumber = 14,
        ChangeStatus = 15,
        AddJawwalMinutes = 17,
    }

    public enum BillTypes
    {
        Initial = 0,
        Supplier = 1,
        LEAD = 2,
        Credit = 3,
    }


    public enum APICompanyIds
    {
        Cellcom = 3,
        We4g = 7,
        Hotmobile = 8,
        Golan = 2,
        Partner = 9
    }


    public enum SortingAttributes
    {
        CustomerName,
        PhoneNumber,
        PackageName,
        DistributorName,
        Status,
        LastUpdate,
    }

    public enum BillType
    {
        Subscription = 0,
        Dealer = 1
    }

    public enum InvoiceTypes
    {
        TaxInvoice = 1,
        TaxInvoiceReceipt = 2,
        CreditInvoice = 3,
        Receipt = 4
    }

    public enum PaymentTypes
    {
        CreditCard = 1,
        Cash = 2,
        Check = 3,
        BankTransfer = 4
    }

    public enum DocumentActions
    {
        Print,
        PDF,
        Email
    }

    public enum PriceType
    {
        Operator = 0,
        Dealer = 1,
        SubDealer = 2,
        Subscription = 3
    }


    public enum AllPermissions
    {
        Users_Index = 7,
        Users_NewUser = 8,
        Users_Permission = 9,
        Users_Search = 10,
        Tickets_Index = 13,
        Tickets_Details = 14,
        Tickets_ChangeStatus = 15,
        Tickets_ChangeStatusAll = 16,
        Tickets_AddNote = 17,
        Tickets_Delete = 18,
        Tickets_DeleteAll = 19,
        Tickets_ExportExcel = 20,
        Subscriptions_Index = 22,
        Subscriptions_New = 23,
        Subscriptions_Export = 24,
        Subscriptions_Search = 25,
        Subscriptions_CallService = 26,
        Subscriptions_FillPac = 27,
        Subscriptions_ChangeCustomer = 28,
        Subscriptions_FillNo = 30,
        Subscriptions_UploadFile = 3,
        Subscriptions_AddComment = 32,
        Subscriptions_Details = 33,
        Subscriptions_DeletePayment = 34,
        Subscriptions_ActivateNumber = 35,
        Subscriptions_PauseNumber = 36,
        Subscriptions_CloseNumber = 37,
        Subscriptions_ChangeSIM = 38,
        Subscriptions_ChangeStatus = 39,
        Subscriptions_ChangeStatusAll = 40,
        Subscriptions_ChangePackage = 41,
        Subscriptions_ChangePackageAll = 42,
        Subscriptions_ChangePriceAll = 43,
        Subscriptions_ChangeDealer = 44,
        Subscriptions_ChangeDealerAll = 45,
        Subscriptions_ChangeAutoRenewal = 46,
        Subscriptions_ChangeCutDate = 47,
        Subscriptions_Renew = 48,
        Subscriptions_RenewAll = 49,
        Subscriptions_RenewToDate = 136,
        Subscriptions_ExportSubscriptionReport = 50,
        Subscriptions_RemoveComment = 51,
        Subscriptions_Delete = 52,
        Subscriptions_DeleteRange = 53,
        Subscriptions_APIDetails = 54,
        Subscriptions_BlockSIM = 55,
        Subscriptions_BlockSIMAll = 57,
        Settings_EditSetting = 59,
        Payments_AddPayment = 61,
        Payments_Preview = 62,
        Payments_New = 63,
        Payments_index = 64,
        Payments_OpenPayments = 65,
        Payments_Document = 66,
        Payments_ExportPdf = 67,
        Payments_deleteInvoicePayments = 139,
        Packages_Index = 71,
        Packages_New = 72,
        Packages_Details = 73,
        Packages_Search = 75,
        Packages_Delete = 76,
        Packages_PackageCompanyList = 126,
        Packages_NewPackageCompany = 127,
        Numbers_uploadLines = 78,
        Numbers_RemoveNumbers = 80,
        Numbers_AffiliateDealer = 81,
        Numbers_ExportAllNumbers = 82,
        Numbers_Index = 84,
        Home_Index = 86,
        Home_DailyReport = 87,
        Home_ExportDealersReport = 88,
        Home_GetSubscriptions = 89,
        Home_Reset = 90,
        Home_Search = 91,
        Home_ResetMsg = 92,
        Home_ExportOpenCalls = 93,
        Dealer_Index = 95,
        Dealer_ChangeDealerPassword = 96,
        Dealer_New = 97,
        Dealer_payments = 98,
        Dealer_paymentUpdate = 99,
        Dealer_AddPaymentNote = 100,
        Dealer_PayDealerBill = 101,
        Dealer_Invoices = 102,
        Dealer_DeletePayment = 103,
        Dealer_DeletePaymentRange = 104,
        Dealer_CloseAccount = 105,
        Dealer_LoginDealerAsync = 106,
        Dealer_NewAdverties = 107,
        Dealer_DeleteAdverty = 108,
        Dealer_Delete = 109,
        Dealer_Details = 110,
        Dealer_PostDealerPackages = 111,
        Dealer_ChangeDealerPackagePrice = 112,
        Dealer_ExportPaymentReport = 114,
        Dealer_ExportInvoicePaymentReport = 115,
        Dealer_AllDealersCompanies = 129,
        Dealer_DealerCompanyDetails = 130,
        Dealer_NewDealerCompany = 131,
        Dealer_AddNumbers = 132,

        Dealer_Active = 133,
        Dealer_InActive = 134,
        Dealer_Subscription = 135,
        Companies_Index = 117,
        Companies_Add = 118,
        Companies_Edit = 119,
        Companies_Delete = 120,
        Companies_ImportExel = 121,
        Companies_IsActive = 128,
        APILogs_Index = 123,
        APILogs_Details = 124,
        APILogs_DeleteConfirmed = 125,

    }
}