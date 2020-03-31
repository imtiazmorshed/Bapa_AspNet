using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OMS.DAL;
using OMS.Facade;
using System.Collections.Generic;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class rptVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Login.aspx?" + "&msgSessionOut=1");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["transactionMasterID"] != null)
                    {
                        using (TheFacade _facade = new TheFacade())
                        {
                            //Company Information
                            CompanyInfo com = new CompanyInfo();
                            com = _facade.CommonFacade.GetCompanyInfoAll().FirstOrDefault();
                            imgLogo.ImageUrl = com.LogoLocation;
                            lblCompany.Text = com.Name;
                            lblAddress.Text = com.Address;
                            lblEmail.Text = "E-mail: " + com.Email;
                            lblPhone.Text = "Phone: " + com.Phone;

                            //lblBranchName.Text = Session["BranchName"].ToString();
                            Acc_TransactionMaster acc_TransactionMaster = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(Convert.ToInt64(Request.QueryString["transactionMasterID"].ToString()));
                            lblParticulars.Text = acc_TransactionMaster.Particulars;
                            lblToFrom.Text = acc_TransactionMaster.ToFrom;
                            lblDate.Text = acc_TransactionMaster.TransactionDate.ToString("dd/MM/yyyy");
                            lblTransactionNo.Text = acc_TransactionMaster.JournalCode;
                            if (acc_TransactionMaster.TransactionTypeID == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                            {
                                lblTransactionType.Text = "Payment Voucher";
                            }
                            else if (acc_TransactionMaster.TransactionTypeID == Convert.ToInt32(EnumCollection.TransactionType.Receive))
                            {
                                lblTransactionType.Text = "Receipt Voucher";
                            }
                            else
                            {
                                lblTransactionType.Text = "Journal Voucher";
                            }
                            //lblTransactionType.Text = EnumHelper.EnumToString(acc_TransactionMaster.TransactionTypeID);
                            List<Acc_TransactionDetail> acc_TransactionDetailList = new List<Acc_TransactionDetail>();
                            if (Request.QueryString["status"] != null)
                            {
                                acc_TransactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(acc_TransactionMaster.IID, Convert.ToInt32(Request.QueryString["status"].ToString()));
                            }
                            else
                            {
                                acc_TransactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(acc_TransactionMaster.IID, Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted));
                            }
                            List<Acc_TransactionDetail> acc_TransactionDetailListForAmount = new List<Acc_TransactionDetail>();
                            acc_TransactionDetailListForAmount = acc_TransactionDetailList.Where(td => td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit)).ToList();
                            foreach (Acc_TransactionDetail TDetail in acc_TransactionDetailListForAmount)
                            {
                                amount += TDetail.Amount;
                            }
                            lblTotalAmount.Text = amount.ToString("0.00");

                            // Translation number to word
                            string inWord = TranslateNumber(amount);
                            lblTakaInWord.Text = inWord.Substring(0, 1).ToUpper() + inWord.Substring(1).ToLower() + " Only."; // add money unit such as taka or dollar here...

                            lvTransactionDetail.DataSource = acc_TransactionDetailList;
                            lvTransactionDetail.DataBind();
                        }
                    }
                    //string inWord = TranslateNumber(Convert.ToDecimal(1320.20));
                    //string inWord = TranslateNumber(Convert.ToDecimal(198779.00531)); 
                    //lblTakaInWord.Text = inWord.Substring(0,1).ToUpper()+inWord.Substring(1).ToLower();
                }
            }
        }

        #region Translation In Word
        private string NumberInWord(string numeric)
        {
            int number = Convert.ToInt32(numeric);
            string strvalue = "";
            switch (number)
            {
                case 1:
                    strvalue = "one "; 
                    break;

                case 2:
                    strvalue = "two ";
                    break;

                case 3:
                    strvalue = "three ";
                    break;

                case 4:
                    strvalue = "four ";
                    break;

                case 5:
                    strvalue = "five ";
                    break;

                case 6:
                    strvalue = "six ";
                    break;

                case 7:
                    strvalue = "seven ";
                    break;

                case 8:
                    strvalue = "eight ";
                    break;

                case 9:
                    strvalue = "nine ";
                    break;

                case 0:
                    strvalue = "";
                    break;

                default:
                    strvalue = "";
                    break;
            }

            return strvalue;
        }

        private string TranslateNumber(decimal amount)
        {
            string number = amount.ToString();
            string[] strNumber = number.Split('.');

            string outputValue = "";

            int length = strNumber[0].Length;

            string currentNumber="";
            string restNumber = "";
            string temp;
            if (length >= 8)
            {
                
                int cuttingX = 0;
                if (length == 10)
                {
                    currentNumber = strNumber[0].Substring(0, 3);
                    restNumber = strNumber[0].Substring(3, length - 3);
                }
                else if (length == 9)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                }
                else if(length==8)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                }
                outputValue = outputValue + PseudoTranslator(currentNumber, "crore ");

                temp = restNumber;
                currentNumber = restNumber.Substring(0, 2);
                restNumber = temp.Substring(2, 5);
                outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                temp = restNumber;
                currentNumber = restNumber.Substring(0, 2);
                restNumber = temp.Substring(2, 3);
                outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                outputValue = outputValue + PseudoTranslator(restNumber, "");
            }
            else if (length > 5 && length<8)
            {
                if (length == 7)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                    temp = restNumber;
                    currentNumber = restNumber.Substring(0, 2);
                    restNumber = temp.Substring(2, 3);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");

                }
                else if (length == 6)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                    temp = restNumber;
                    currentNumber = restNumber.Substring(0, 2);
                    restNumber = temp.Substring(2, 3);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
            }

            else if (length > 3 && length < 6)
            {
                if (length == 5)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
                else if (length == 4)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
            }
            else if(length<4)
            {
                outputValue = outputValue + PseudoTranslator(strNumber[0], "");
            }
            //outputValue = outputValue+PseudoTranslator(strNumber[0]);
            if (strNumber.Count() > 1)
            {
                outputValue = outputValue + TranslateAfterPoint(strNumber[1]);
            }
            return outputValue;
        }

        private string TranslateAfterPoint(string p)
        {
            string returnstr="";
            int number = Convert.ToInt32(p);
            if (number > 0)
            {
                returnstr = " point";
                for (int i = 0; i < p.Length ; i++)
                {
                    if (p[i] == '0')
                    {
                        returnstr = returnstr + " zero";
                    }
                    else
                    {
                        returnstr = returnstr +" "+ NumberInWord(p[i].ToString());
                    }
                }
            }

            return returnstr;
        }

        private string PseudoTranslator(string p,string postfix)
        {
            string number = "";

            string first = "";
            string rest = "";

            if (p.Length == 3)
            {
                number = number + NumberInWord(p.Substring(0, 1));//+ " hundred ";
                if (Convert.ToInt32(p.Substring(0, 1)) > 0)
                {
                    number = number + " hundred ";
                }
                number = number + TwoDecimmalTranslation(p.Substring(1, p.Length - 1));
            }
            else if (p.Length > 0)
            {
                number = number + TwoDecimmalTranslation(p);
            }
            if (Convert.ToInt32(p) > 0)
            {
                number = number + " " + postfix;
            }

            return number;//+" "+postfix;
        }

        private string TwoDecimmalTranslation(string p)
        {
            string t = "";
            int value = Convert.ToInt32(p);
            if (p.Length > 1)
            {
                if (value == 11)
                {
                    t = "eleven ";
                }
                if (value == 12)
                {
                    t = "twelve ";
                }
                if (value == 13)
                {
                    t = "thirteen ";
                }
                if (value == 14)
                {
                    t = "fourteen ";
                }
                if (value == 15)
                {
                    t = "fifteen ";
                }
                if (value > 15 && value < 20)
                {
                    t = NumberInWord(value.ToString().Substring(1, 1)).Trim() + "teen ";
                }
                if (value == 30)
                {
                    t = "thirty ";
                }
                if (value > 19 && value < 30)
                {
                    t = "twenty" + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 30 && value < 40)
                {
                    t = "thirty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 40 && value < 50)
                {
                    t = "forty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 50 && value < 60)
                {
                    t = "fifty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 60 && value < 70)
                {
                    t = "sixty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 70 && value < 80)
                {
                    t = "seventy " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 80 && value < 90)
                {
                    t = "eighty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 90 && value < 100)
                {
                    t = "ninety " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
            }
            else
            {
                t = NumberInWord(p);
            }
            return t;
        }

        #endregion

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnlPrint;
            //Session["header"] = this.Page.Title;
            Session["header"] = string.Empty;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=550px,width=750px,scrollbars=1');</script>");
        }
        decimal amount = 0;
        int slNo = 1;
        protected void lvTransactionDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;

            Acc_TransactionDetail acc_TransactionDetail = (Acc_TransactionDetail)((ListViewDataItem)(e.Item)).DataItem;

            Label lblSLNo = (Label)currentItem.FindControl("lblSLNo");
            Label lblAccountName = (Label)currentItem.FindControl("lblAccountName");
            Label lblParticular = (Label)currentItem.FindControl("lblParticular");
            Label lblBalance = (Label)currentItem.FindControl("lblBalance");
            Label lblDebit = (Label)currentItem.FindControl("lblDebit");
            Label lblCredit = (Label)currentItem.FindControl("lblCredit");

            lblSLNo.Text = slNo.ToString();
            slNo++;
            if (acc_TransactionDetail.Acc_ChartOfAccount != null)
            {
                lblAccountName.Text = acc_TransactionDetail.Acc_ChartOfAccount.Name + "[" + acc_TransactionDetail.Acc_ChartOfAccount.AccountNo + "]";
            }
            lblParticular.Text = acc_TransactionDetail.Particulars;
            if (acc_TransactionDetail.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            {
                lblDebit.Text = acc_TransactionDetail.Amount.ToString("0.00");
                lblCredit.Text = "--";
            }
            else
            {
                lblDebit.Text = "--";
                lblCredit.Text = acc_TransactionDetail.Amount.ToString("0.00");
            }
            //if (acc_TransactionDetail.DebitAmount == 0)
            //{
            //    lblDebit.Text = "--";
            //}
            //else
            //{
            //    lblDebit.Text = acc_TransactionDetail.DebitAmount.ToString();
            //}
            //if (acc_TransactionDetail.CreditAmount == 0)
            //{
            //    lblCredit.Text = "--";
            //}
            //else
            //{
            //    lblCredit.Text = acc_TransactionDetail.CreditAmount.ToString();
            //}
        }
    }
}
