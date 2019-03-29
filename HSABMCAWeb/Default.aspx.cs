using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;

namespace HSABMCAWeb
{
    public partial class _Default : Page
    {
        dsWebTableAdapters.PagesTableAdapter tadPages = new dsWebTableAdapters.PagesTableAdapter();
        dsWeb.PagesDataTable tblPages = new dsWeb.PagesDataTable();

        dsWebTableAdapters.HeadersTableAdapter tadHeaders = new dsWebTableAdapters.HeadersTableAdapter();
        dsWeb.HeadersDataTable tblHeaders = new dsWeb.HeadersDataTable();

        dsWebTableAdapters.PageDetailsTableAdapter tadPageDetails = new dsWebTableAdapters.PageDetailsTableAdapter();
        dsWeb.PageDetailsDataTable tblPageDetails = new dsWeb.PageDetailsDataTable();
        string page_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request["__EVENTTARGET"].Equals("btnHeaderClick"))
                {
                    page_id = Request["__EVENTARGUMENT"];
                    if (!page_id.Equals(""))
                    {
                        Find_Page(page_id: page_id);
                    }
                }
                return;
            }
            if (Request.QueryString["PageID"] != null)
            {
                string page_id = Request.QueryString["PageID"].ToString().ToLower();
                Find_Page(page_id: page_id);
                return;
            }
            Load_Home();
        }

        //protected void btn01_Info_Click(object sender, EventArgs e)
        //{
        //    string tooltip = pnl02_Page.ToolTip;
        //    LinkButton lbtn = (LinkButton)sender;
        //    Find_Page(page_id: lbtn.ToolTip);
        //    img99_Back.Visible = true;
        //    img99_Back.ToolTip = tooltip;

        //}

        protected void img02_Yes_Click(object sender, ImageClickEventArgs e)
        {
            Find_Page(page_id: img02_Yes.ToolTip);
        }

        protected void img02_No_Click(object sender, ImageClickEventArgs e)
        {
            Find_Page(page_id: img02_No.ToolTip);
        }
        protected void lnk02_Yes_Click(object sender, EventArgs e)
        {
            Find_Page(page_id: img02_Yes.ToolTip);
        }

        protected void lnk02_No_Click(object sender, EventArgs e)
        {
            Find_Page(page_id: img02_No.ToolTip);
        }

        protected void Find_Page(string page_id)
        {
            if (page_id.ToLower().Equals("home"))
            {
                Load_Home();
                return;
            }
            pnl02_Page.ToolTip = page_id;
            tadPages.Fill(tblPages, Page_ID: page_id);
            foreach (dsWeb.PagesRow prow in tblPages)
            {
                Load_Page(prow: prow);
                return;
            }
            pnl99_Footer.Visible = false;
            img99_Next.Visible = false;
            img99_Back.Visible = false;
            img99_Next.Visible = false;
            pnl02_Page.Visible = true;
            pnl02A_Prompt.Visible = false;
            lbl02_Prompt.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")+page_id + " page not found - please report to support ";
        }

        protected void Load_Page(dsWeb.PagesRow prow)
        {
            tadHeaders.FillByID(tblHeaders, Header_ID: prow.HeaderType);
            foreach (dsWeb.HeadersRow hrow in tblHeaders)
            {
                Load_HeaderRow(hrow: hrow);
            }
            pnl99_Footer.Visible = true;
            pnl02_Page.Visible = true;
            pnl02A_Prompt.Visible = true;
            lbl02_Prompt.Text = prow.DisplayHTML;
            if (prow.IsYesPage_IDNull() || prow.YesPage_ID.Equals(""))
            {
                tr02_Yes.Visible = false;
                img02_Yes.ToolTip = "Home";
            }
            else
            {
                tr02_Yes.Visible = true;
                img02_Yes.ToolTip = prow.YesPage_ID;
            }
            if (prow.IsNoPage_IDNull() || prow.NoPage_ID.Equals(""))
            {
                tr02_No.Visible = false;
                img02_No.ToolTip = "Home";
            }
            else
            {
                tr02_No.Visible = true;
                img02_No.ToolTip = prow.NoPage_ID;
            }
            lnk02_Yes.ToolTip = img02_Yes.ToolTip;
            lnk02_No.ToolTip = img02_No.ToolTip; pnl02A_Prompt.Visible = tr02_Yes.Visible || tr02_No.Visible;
            if (prow.IsBackPage_IDNull() || prow.BackPage_ID.Equals(""))
            {
                img99_Back.Visible = false;
                img99_Back.ToolTip = "Home";
            }
            else
            {
                img99_Back.Visible = true;
                img99_Back.ToolTip = prow.BackPage_ID;
            }
            if (prow.IsNextPage_IDNull() || prow.NextPage_ID.Equals(""))
            {
                img99_Next.Visible = false;
                img99_Next.ToolTip = "Home";
            }
            else
            {
                img99_Next.Visible = true;
                img99_Next.ToolTip = prow.NextPage_ID;
            }
        }

        #region pnl99_Footer

        protected void img99_Home_Click(object sender, ImageClickEventArgs e)
        {
            Load_Home();
        }

        protected void Load_Home()
        {
            tadHeaders.Fill(tblHeaders);
            tbl01_Header2.Rows.Clear();
           
            foreach (dsWeb.HeadersRow hrow in tblHeaders)
            {
                Load_HeaderRow(hrow: hrow);
            }
            pnl99_Footer.Visible = false;
            img99_Next.Visible = false;
            pnl02_Page.Visible = false;

        }


        protected void Load_HeaderRow(dsWeb.HeadersRow hrow)
        {
            Button hbtn1 = new Button();
            hbtn1.Text = hrow.Header_Title;
            hbtn1.CssClass = "btn btn-info";
            hbtn1.Font.Size = 16;
            hbtn1.BackColor = System.Drawing.Color.FromArgb(hrow.Background_Color);
            hbtn1.ToolTip = hrow.Start_Page;
            hbtn1.Width = 500;
            hbtn1.Height = 42;
            hbtn1.OnClientClick = "__doPostBack('btnHeaderClick', '" + hrow.Start_Page + "')";
            TableCell tcell1 = new TableCell();
            tcell1.Controls.Add(hbtn1);

            Button hbtn2 = new Button();
            hbtn2.Text = "info " + hrow.Header_ID;
            hbtn2.Font.Italic = true;
            hbtn2.Font.Size = 8;
            hbtn2.CssClass = "btn btn-info";
            hbtn2.Height = 42;
            hbtn2.ToolTip = hrow.Info_Page;
            hbtn2.Width = 84;
            hbtn2.OnClientClick = "__doPostBack('btnHeaderClick', '" + hrow.Info_Page + "')";

            TableCell tcell2 = new TableCell();
            tcell2.Controls.Add(hbtn2);

            TableRow trow = new TableRow();
            trow.Cells.Add(tcell1);
            trow.Cells.Add(tcell2);

            trow.ToolTip = hrow.Header_ID;
            tbl01_Header2.Rows.Add(trow);
        }
            protected void img99_Next_Click(object sender, ImageClickEventArgs e)
        {
            Find_Page(page_id: img99_Next.ToolTip);
        }


        protected void img99_Back_Click(object sender, ImageClickEventArgs e)
        {
            Find_Page(page_id: img99_Back.ToolTip);

        }

        #endregion

    }
}