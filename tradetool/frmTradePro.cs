using Core.DataAccess.Implement;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tradetool
{
    public partial class frmTradePro : Form
    {
        private DataTable _source;
        private string Connectionstring = string.Empty;
        private decimal _deltaPrice;
        public frmTradePro()
        {
            InitializeComponent();
            Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _deltaPrice = decimal.Parse(txtDeltaValue.Text);
            _source = new DataTable();
            _source.Columns.Add("Price");
            _source.Columns.Add("Limit");
            _source.Columns.Add("Stop");
            _source.Columns.Add("Type");
            _source.Columns.Add("Status");
            _source.Columns.Add("Log");
        }

        private void Start(object sender, EventArgs e)
        {
            lblStatus.Text = DateTime.Now.ToString();
            using (var repo = new DapperRepository(new SqlConnection(Connectionstring)))
            {
                try
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        btnStart.Enabled = false;
                    }));
                    var price = GetPrice();
                    StopLimit objStop = null;
                    try
                    {
                        objStop = repo.Connection.Query<StopLimit>("select * from dbo.ExchangeOrder").First();
                    }
                    catch(Exception ex) { objStop = null; }
                    
                    if (objStop == null)
                    {
                        string query = "INSERT INTO dbo.ExchangeOrder(PairExchange,CurrentPrice,LimitPrice,StopPrice,Type,Status) VALUES";
                        query += "(@PairExchange, @CurrentPrice, @LimitPrice, @StopPrice, @Type,@Status)";
                        repo.Connection.Execute(query
                            , new
                            {
                                PairExchange = "XRP_USDT",
                                CurrentPrice = price,
                                LimitPrice = price - _deltaPrice,
                                StopPrice = price,
                                Type = 1,
                                Status = "Is Open"
                            });
                    }
                    else if (price < objStop.CurrentPrice)
                    {
                        string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,LimitPrice = @LimitPrice,StopPrice=@StopPrice where ID = @ID";

                        repo.Connection.Execute(query
                            , new
                            {
                                CurrentPrice = price,
                                LimitPrice = price - _deltaPrice,
                                StopPrice = price,
                                ID = objStop.ID
                            });
                    }

                }
                catch(Exception ex)
                {
                }
                finally
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        btnStart.Enabled = true;
                    }));
                }

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Start Time: " + DateTime.Now.ToString();
            timer1.Tick += new EventHandler(Start);
            // Sets the timer interval to 5 seconds.
            timer1.Interval = 10000;
            timer1.Start();
        }

        private decimal GetPrice()
        {
            var rootPolo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Polo>>(Helpers.GetdataViaproxy("https://poloniex.com/public?command=returnTradeHistory&currencyPair=USDT_XRP&depth=10"));
            return decimal.Parse(rootPolo.First().rate);
        }

    }
    public class StopLimit
    {
        public int ID { get; set; }
        public string PairExchange { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal StopPrice { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
