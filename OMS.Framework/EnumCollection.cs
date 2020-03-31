using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OMS.Framework
{
    public static class EnumCollection
    {
        public enum TicketSaleStatus
        {
            Due = 1,
            Partial,
            Paid
        }

        public enum ChaFormStatus
        {
            Draft = 0,
            Approved,
            Submited,
            Decline,
            ReSubmit
        }

        public enum PaymentStatus
        {
            Partial= 1,            
            Paid
        }

        public enum ChequeLeafStatus
        {
            UnUsed = 1,
            Issued,
            Honor,
            DisHonor,
            Cancel,
            Received
        }

        public enum UserStatus
        {
            Enable=1,
            Disable=0
        }

        public enum TransactionNature
        {
            Debit = 1,
            Credit
        }

        public enum AccountType
        {
            Transactable = 1,
            NonTransactable
        }

        public enum BankAccountType
        {
            Current_Account=1,
            Saving_Account
        }

        public enum StockStatus
        {
            HasStock = 1,
            StockOut,
            PartialStock,
        }

        //public enum ReferenceType
        //{
        //    Supplier = 1,
        //    Customer,
        //    Channel,
        //}

        public enum StockTransactionType
        {
            Purchase = 1,
            PurchaseReturn,
            Sale,
            SaleReturn,
            Damage
        }
        
        public enum EmployeeGrade
        {
            Grade1 = 1,
            Grade2,
            Grade3,
            Grade4,
            Grade5,
            Grade6,
            Grade7,
            Grade8,
            Grade9,
            Grade10,
            Grade11,
            Grade12,
            Grade13,
            Grade14,
            Grade15,
            Grade16,
            Grade17,
            Grade18,
            Grade19,
            Grade20
        }

        public enum AddressType
        {
            Present = 1,
            Permanent
        }

        public enum ListItemType
        {
            ChannelType = 1,
            ChannelParent,
            City,
            ChannelCode,
            ChannelName,
            OrderNo,
            SupplierName,
            ItemName,
            ItemCode,
            CustomerName,
            EmployeeName,
            DepartmentName,
            CategoryName,
            ClassName,
            AccountName,
            AccountCode,
            ReferenceType,
            TransactionMode,
            Supplier,
            Customer,
            AccountType,
            Bank,
            Select,
            ChequeLeafStatus,
            TransactionType,
            Country,
            AssetType,
            CompanyType,
            CompanyCategory,
            DocumentTypeList,
            BusinessTypeList,
            MesurementUnit,
            Currency,
            Invoice
        }
        public enum UserType
        {
            Admin=1,
            Accounts,
            Branch_User
        }

        public enum SystemModule
        {
            Contacts = 1,
            Financial_Management,
            Bank_Management,
            Admin_Management,
            Ticket_Sale,
            Inventory_Management,
            Order_Details,
            Item_Details
        }

        #region Transaction Enum

        public enum TransactionType
        {
            Payment=1,
            Receive=2,
            Voucher=3
        }

        public enum AmountType
        {
            In_Percentage = 1,
            In_Amount
        }

        public enum SupplierType
        {
            Supplier = 1,
            Airlines
        }

        public enum AirlinesType
        {
            IATA = 1,
            Non_IATA
        }

        public enum ReferenceType
        {
            Supplier = 1,
            Customer,
            Others
        }

        public enum TransactionMode
        {
            Cash = 1,
            Cheque = 2,
            Credit = 3,
            Card = 4
        }

        public enum TransactionStatus
        {
            NonPosted = 1,
            Posted
        }

        public enum VerificationStatus
        {
            Pending = 0,
            Processing,
            Approved_for_Committee_Meeting,
            Completed
        }
        public enum MembershipStatus
        {
            Pending = 0,
            Approved

        }
        public enum TypeOfSubmission
        {
            New = 1,
            Existing,
            AlreayApplied

        }

        public enum DocumentType
        {
            PayOrder = 1,
            Trade_license,
            TIN_Certificate,
            Partnership_Aggrement,
            Bank_Statment,
            VAT_Certificate

        }

    }

        #endregion

    #region Insentive Enum
   

    

    #endregion
    public class EnumHelper
    {
        public EnumHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Methods


        public static ListItemCollection EnumToList<T>()
        {
            ListItemCollection lists = new ListItemCollection();
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                string modifyItem = item.ToString();
                int value = (int)Enum.Parse(typeof(T), item);
                modifyItem = item.Replace("__", " + ");
                modifyItem = modifyItem.Replace('_', ' ');
                ListItem listItem = new ListItem(/*item.Replace('_', ' ')*/modifyItem, value.ToString());

                lists.Add(listItem);

            }
            return lists;
        }

        public static string EnumToString<T>(int value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }
        public static string EnumToString<T>(T value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }

        public static string EnumToString<T1>(long p)
        {
            throw new NotImplementedException();
        }

        #endregion 

    }
}
