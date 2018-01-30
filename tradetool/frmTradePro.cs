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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tradetool.DTO;
using tradetool.Utilities;

namespace tradetool
{
    public partial class frmTradePro : Form
    {
        private DataTable _source;
        private string Connectionstring = string.Empty;
        private decimal _deltaPriceBuy;
        private decimal _deltaPriceSell;
        private decimal _currentPrice = 0;
        public frmTradePro()
        {
            InitializeComponent();
            Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _deltaPriceBuy = decimal.Parse(txtDeltaValue.Text);
            _deltaPriceSell = decimal.Parse(txtDeltaValue.Text);
            _source = new DataTable();
            _source.Columns.Add("Price");
            _source.Columns.Add("Limit");
            _source.Columns.Add("Stop");
            _source.Columns.Add("SellPrice");
            _source.Columns.Add("Type");
            _source.Columns.Add("Status");
            _source.Columns.Add("Log");
        }

        private void StopLoss()
        {
            //var repo1 = new DapperRepository(new SqlConnection(Connectionstring));
            //repo1.Connection.Query<string>("delete from dbo.ExchangeOrder");
            while (true)
            {
                try
                {
                    using (var repo = new DapperRepository(new SqlConnection(Connectionstring)))
                    {
                        var price = GetPrice();
                        if (price == 0)
                        {
                            Thread.Sleep(1000);
                            continue;
                        }
                        _currentPrice = price;
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            lblPrice.Text = price.ToString();
                        }));


                        StopLimit objStop = null;
                        try
                        {
                            objStop = repo.Connection.Query<StopLimit>("select * from dbo.ExchangeOrder").First();
                        }
                        catch (Exception ex) { objStop = null; }

                        //type = 1 : buy 
                        if (objStop?.Status == "Is Open" && objStop.Type == "1")
                        {

                            if (price >= objStop.BuyPrice && Configs.DeltaPercent > 0)
                            {
                                //cập nhat trang thái về close báo đã khớp lện mua
                                string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,Status=@Status,SellPrice=@SellPrice,StopSellPrice=@StopSellPrice,StopLoss=@StopLoss where ID = @ID";

                                repo.Connection.Execute(query
                                    , new
                                    {
                                        CurrentPrice = price,
                                        ID = objStop.ID,
                                        Status = "Is Close",
                                        SellPrice = price + (decimal)(price * decimal.Parse((0.6 / 100).ToString())),
                                        StopSellPrice = price + (decimal)(price * decimal.Parse((0.6 / 100).ToString())) + _deltaPriceSell,
                                        StopLoss = price - (decimal)(price * decimal.Parse((0.6 / 100).ToString()))
                                    });
                                //BeginInvoke(new MethodInvoker(delegate
                                //{
                                //    lblStatus.Text = lblStatus.Text = "đã khớp lên mua ở giá " + objStop.StopPrice;
                                //}));
                            }
                        }//finish buy go to sell
                        else if (objStop?.Status == "Is Close" && objStop.Type == "1")
                        {

                            if (price >= objStop.SellPrice && objStop.IsPassSellPrice == true)
                            {
                                //cập nhat trang thái về close báo đã khớp lện mua
                                const string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,Status=@Status where ID = @ID";

                                repo.Connection.Execute(query
                                    , new
                                    {
                                        CurrentPrice = price,
                                        ID = objStop.ID,
                                        Status = "Is Finish"
                                    });
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    lblStatus.Text = lblStatus.Text = "đã khớp lên mua ở giá " + objStop.StopBuyPrice;
                                }));
                            }
                            else if (price <= objStop.StopLoss)
                            {
                                const string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,Status=@Status where ID = @ID";

                                repo.Connection.Execute(query
                                    , new
                                    {
                                        CurrentPrice = price,
                                        ID = objStop.ID,
                                        Status = "Is StopLoss"
                                    });
                            }
                        }

                    }
                    Thread.Sleep(5000);
                }

                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
        }
        private void Start(object sender, EventArgs e)
        {
            new Task(() =>
            {
                StopLoss();
            }).Start();

            bool Continue = true;
            try
            {
                //var repo1 = new DapperRepository(new SqlConnection(Connectionstring));
                //repo1.Connection.Query<string>("delete from dbo.ExchangeOrder");
                while (Continue)
                {
                    var second = int.Parse(lblStatus.Text);
                    if (second > 0) --second;
                    else
                    {
                        second = 10;
                        using (var repo = new DapperRepository(new SqlConnection(Connectionstring)))
                        {
                            var price = _currentPrice;
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                lblPrice.Text = price.ToString();
                            }));

                            if (price == 0)
                            {
                                second = 10;
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    lblStatus.Text = "10";
                                }));
                                continue;
                            }

                            StopLimit objStop = null;
                            try
                            {
                                objStop = repo.Connection.Query<StopLimit>("select * from dbo.ExchangeOrder").First();
                            }
                            catch (Exception ex) { objStop = null; }

                            if (objStop == null)
                            {
                                string query = "INSERT INTO dbo.ExchangeOrder(PairExchange,CurrentPrice,BuyPrice,StopBuyPrice,Type,Status) VALUES";
                                query += "(@PairExchange, @CurrentPrice, @BuyPrice, @StopBuyPrice, @Type,@Status)";
                                repo.Connection.Execute(query
                                    , new
                                    {
                                        PairExchange = "BTC_USDT",
                                        CurrentPrice = price,
                                        BuyPrice = price + _deltaPriceBuy,
                                        StopBuyPrice = price + _deltaPriceBuy,
                                        Type = 1,
                                        Status = "Is Open"
                                    });
                            }
                            else if (objStop.Status == "Is Close")
                            {
                                if (objStop.IsPassSellPrice == false && price >= objStop.StopSellPrice)
                                {
                                    string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,StopSellPrice=@StopSellPrice,SellPrice=@SellPrice,IsPassSellPrice=true where ID = @ID";

                                    repo.Connection.Execute(query
                                        , new
                                        {
                                            CurrentPrice = price,
                                            SellPrice = price - _deltaPriceSell,
                                            StopSellPrice = price,
                                            ID = objStop.ID
                                        });
                                }
                            }
                            else if (price < objStop.StopBuyPrice)
                            {
                                string query = "update dbo.ExchangeOrder set CurrentPrice=@CurrentPrice,BuyPrice = @BuyPrice,StopBuyPrice=@StopBuyPrice where ID = @ID";

                                repo.Connection.Execute(query
                                    , new
                                    {
                                        CurrentPrice = price,
                                        BuyPrice = price + _deltaPriceBuy,
                                        StopBuyPrice = price,
                                        ID = objStop.ID
                                    });

                            }
                            //load data
                            if (objStop != null)
                            {
                                var source = new List<StopLimit>();
                                try
                                {
                                    objStop = repo.Connection.Query<StopLimit>("select * from dbo.ExchangeOrder").First();
                                }
                                catch (Exception ex) { objStop = null; }
                                source.Add(objStop);
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    var tableSource = source.ToDataTable<StopLimit>();
                                    tableSource.Columns.Remove("ID");
                                    tableSource.Columns.Remove("Type");
                                    dataGridView1.DataSource = tableSource;
                                    dataGridView1.Refresh();
                                }));
                            }

                        }
                    }
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        lblStatus.Text = second.ToString();
                    }));

                    Thread.Sleep(1000);
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {
                //BeginInvoke(new MethodInvoker(delegate
                //{
                //    btnStart.Enabled = true;
                //}));
            }


        }



        private void btnStart_Click(object sender, EventArgs e)
        {

            new Task(() =>
            {
                Start(null, null);
            }).Start();

        }

        private decimal GetPrice()
        {
            try
            {
                var rootPolo = Newtonsoft.Json.JsonConvert.DeserializeObject<PoloPrice>(Helpers.GetdataViaproxy("https://poloniex.com/public?command=returnTicker"));
                _currentPrice = decimal.Parse(rootPolo.USDT_BTC.last);
                return (decimal.Parse(rootPolo.USDT_BTC.last));
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

    }
    public class StopLimit
    {
        public int ID { get; set; }

        public decimal CurrentPrice { get; set; }
        public decimal StopBuyPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal StopSellPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal StopLoss { get; set; }
        public bool IsPassSellPrice { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string PairExchange { get; set; }
    }
}
