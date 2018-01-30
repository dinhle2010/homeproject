using AutoMapper;
using Core.DataAccess.Implement;
using Core.DataAccess.Interface;
using Core.Entities;
using Core.MVC.APIWrapper;
using Dapper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tradetool.Utilities;

namespace tradetool
{
    public partial class Form1 : Form
    {
        private OrderBookRootObject _orderBookRootObject;
        private PoloOrderBookRootObject _PoloOrderBookRootObject;
        private RootObject _rootObject;
        private List<Polo> _rootPolo;
        private string Connectionstring = string.Empty;
        DataRow _lastRow;
        DataRow _firsRow;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var datacurrencyPair = new DataTable();
            datacurrencyPair.Columns.Add("Name", typeof(string));
            datacurrencyPair.Columns.Add("Value", typeof(string));
            var row = datacurrencyPair.NewRow();
            row["Name"] = "USDT_XRP_Polo";
            row["Value"] = "USDT_XRP_Polo";
            datacurrencyPair.Rows.Add(row);
            row = datacurrencyPair.NewRow();
            row["Name"] = "USDT_XRP_Bittrex";
            row["Value"] = "USDT_XRP_Bittrex";
            datacurrencyPair.Rows.Add(row);
            cmbCurrencyPair.DataSource = datacurrencyPair;
            cmbCurrencyPair.Refresh();
            //var Idbconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //_ObjRepository = new DapperRepository(Idbconnection);

        }

        private void BitrexGetDataInsertToDB()
        {
            timer2.Tick += new EventHandler((e, h) =>
            {
                if (txtURL.Text.Contains("bittrex"))
                    return;
                var objAPI = new APIClient(new HttpClient());
                using (var response = objAPI.PostObject(txtURL.Text, null))
                {
                    var rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                    using (var repo = new DapperRepository(new SqlConnection(Connectionstring)))
                    {
                        foreach (var item in rootObject?.result)
                        {
                            try
                            {
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    lblGetData.Text = "Get data: " + item.Id.ToString();
                                }));

                                repo.Connection.Execute("insert into [BittrexMarketHistory]([BTID],[TimeStampValue],[Quantity],[Price],[Total],[FillType],[OrderType])values(@BIID,@TimeStampValue,@Quantity,@Price,@Total,@FillType,@OrderType)", new
                                {
                                    BIID = item.Id,
                                    TimeStampValue = item.TimeStamp,
                                    Quantity = item.Quantity,
                                    Price = item.Price,
                                    Total = item.Total,
                                    FillType = item.FillType,
                                    OrderType = item.OrderType
                                });
                            }
                            catch
                            {
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    lblGetData.Text = "Get data: " + item.Id.ToString();
                                }));
                            }


                        }
                    }

                }

            });
            // Sets the timer interval to 5 seconds.
            timer2.Interval = 1000 * 30;
            timer2.Start();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                //volume percent
                if (Convert.ToDecimal(dataGridView1[5, e.RowIndex].Value.ToString()) > 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.Green;
                }
                else
                    dataGridView1.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.Red;
                //volume price
                if (Convert.ToDecimal(dataGridView1[3, e.RowIndex].Value.ToString()) > 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Green;
                }
                else
                    dataGridView1.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red;
                //delta order book percent
                if (Convert.ToDecimal(dataGridView1[7, e.RowIndex].Value.ToString()) > 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[7].Style.BackColor = Color.Green;
                }
                else
                    dataGridView1.Rows[e.RowIndex].Cells[7].Style.BackColor = Color.Red;
            }
            catch { }

        }



        private string PostViaProxy(string url)
        {
            string publickey = "VPK5ZJW9-BI5Q4SAP-E6X2X482-R6BP1LTN";
            string privatekey = "7f06c98f392f23e22dbe57340ae0c4e92be780f0579cedefd0b0666d6f41e4b11de406733bb500e8280ad0590d332d50bd4412b6aeeec0362f7ba3785410f5c6";

            HMACSHA512 Encryptor = new HMACSHA512();
            Encoding Encoding = Encoding.ASCII;
            Encryptor.Key = Encoding.GetBytes(privatekey);

            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("command", "returnBalances");
            postData.Add("nonce", Helpers.GetCurrentHttpPostNonce());

            var postBytes = Encoding.GetBytes(postData.ToHttpPostString());
            try
            {
                string myParam = "command=returnBalances&nonce=" + Helpers.GetCurrentHttpPostNonce();
                //var param = new PoloParam() { EndPoint = "https://poloniex.com/tradingApi", Key = "VPK5ZJW9-BI5Q4SAP-E6X2X482-R6BP1LTN", Sign = Encryptor.ComputeHash(postBytes).ToStringHex() };
                var param = new PoloParam() { EndPoint = "https://poloniex.com/tradingApi", Key = "VPK5ZJW9-BI5Q4SAP-E6X2X482-R6BP1LTN", Sign = privatekey, myParam = myParam };
                var objAPI = new APIClient(new HttpClient());
                using (var response = objAPI.Post<PoloParam>("http://207.148.66.48/api/values", param))
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }



        }


        private string Getdata(string url)
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--disable-extensions");
            //options.AddArgument("--disable-incognito");
            //options.AddArgument("----disable-notifications");
            //options.AddArgument("--disable-popup-blocking");
            //options.AddArgument("headless");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            IReadOnlyCollection<IWebElement> pres = null;
            Point originPoint = new Point(0, 0);
            using (ChromeDriver driver = new ChromeDriver(service, options))
            {
                try
                {


                    originPoint = driver.Manage().Window.Position;
                    driver.Manage().Window.Position = new Point(-2000, 0);
                    driver.Url = url;
                    DriverHelper.LoadSessionFromDB(driver, @"c:/session/", url);
                    driver.Url = url;
                    pres = driver.FindElements(By.TagName("pre"));
                    var pre = pres?.First();
                    if (pre != null)
                        return pre.Text;

                }
                catch (Exception ex)
                {
                    driver.Manage().Window.Position = originPoint;
                    driver.Url = url;
                    MessageBox.Show("Finish capcha ok to continue ");
                    pres = driver.FindElements(By.TagName("pre"));
                    var pre = pres?.First();
                    var result = pre.Text;
                    if (pre != null)
                    {
                        DriverHelper.SaveSessionToDB(@"c:/session/", driver, url);
                        return result;
                    }


                }
                finally
                {
                    DriverHelper.SaveSessionToDB(@"c:/session/", driver, url);
                    driver.Close();
                }
            }
            return string.Empty;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(lblStatus.Text))
            {
                lblStatus.Text = int.Parse(txtTickTime.Text).ToString();
                if (txtURL.Text.Contains("polo"))
                    PoloUrl();
                else
                    BittrexUrl();
                lblStatus.Text = int.Parse(txtTickTime.Text).ToString();
            }
            else if (int.Parse(lblStatus.Text) == 0)
            {
                if (txtURL.Text.Contains("polo"))
                    PoloUrl();
                else
                    BittrexUrl();
                lblStatus.Text = int.Parse(txtTickTime.Text).ToString();
            }
            else
            {
                lblStatus.Text = (int.Parse(lblStatus.Text) - 1).ToString();
            }
        }

        private void BittrexUrl()
        {
            new Task(() =>
            {
                if (string.IsNullOrEmpty(txtURL.Text))
                {
                    MessageBox.Show("Nhap dia chi API");
                    return;
                }
                BeginInvoke(new MethodInvoker(delegate
                {
                    btnStart.Enabled = false;
                }));
                try
                {
                    DataTable data = (DataTable)dataGridView1.DataSource;
                    if (data == null)
                    {
                        data = new DataTable();
                        data.Columns.Add("TotalBuy", typeof(string));
                        data.Columns.Add("TotalSell", typeof(string));
                        data.Columns.Add("CurrentPrice", typeof(decimal));
                        data.Columns.Add("DeltaPrice", typeof(decimal));
                        data.Columns.Add("Percent", typeof(decimal));
                        data.Columns.Add("DeltaPercent", typeof(decimal));
                        data.Columns.Add("OrderBookPercent", typeof(decimal));
                        data.Columns.Add("DeltaOrderBookPercent", typeof(decimal));
                        data.Columns.Add("MaxBuyQuantity", typeof(string));
                        data.Columns.Add("MaxSellQuantity", typeof(string));
                        data.Columns.Add("DateTime", typeof(DateTime));
                    }
                    var objAPI = new APIClient(new HttpClient());
                    //get order book
                    using (var response = objAPI.PostObject(txtOrderbook.Text, null))
                    {
                        if (_orderBookRootObject == null)
                            _orderBookRootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderBookRootObject>(response.Content.ReadAsStringAsync().Result);
                        else
                        {
                            var orderbook = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderBookRootObject>(response.Content.ReadAsStringAsync().Result);
                            orderbook.result.buy.ForEach(o =>
                            {
                                if (!_orderBookRootObject.result.buy.Contains(o))
                                    _orderBookRootObject.result.buy.Add(o);
                            });
                            orderbook.result.sell.ForEach(o =>
                            {
                                if (!_orderBookRootObject.result.sell.Contains(o))
                                    _orderBookRootObject.result.sell.Add(o);
                            });
                        }
                    }

                    using (var response = objAPI.PostObject(txtURL.Text, null))
                    {
                        RootObject rootObject = null;
                        if (_rootObject == null)
                        {
                            rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                            _rootObject = rootObject;
                        }
                        else
                        {
                            rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                            rootObject.result.ForEach(o =>
                            {
                                if (!_rootObject.result.Contains(o))
                                    _rootObject.result.Add(o);
                            });
                        }

                        var row = data.NewRow();
                        var totalBuy = _rootObject.result.Where(o => o.OrderType == "BUY").Sum(o => o.Quantity);
                        var totalSell = _rootObject.result.Where(o => o.OrderType == "SELL").Sum(o => o.Quantity);
                        row["TotalBuy"] = string.Format(new CultureInfo("en-US", false), "{0:n}", totalBuy);
                        row["TotalSell"] = string.Format(new CultureInfo("en-US", false), "{0:n}", totalSell); ;
                        row["CurrentPrice"] = rootObject.result.First().Price;
                        //row["LastPrice"] = rootObject.result.Last().Price;
                        row["Percent"] = (totalBuy / totalSell) * 100;
                        row["MaxBuyQuantity"] = string.Format(new CultureInfo("en-US", false), "{0:n}", rootObject.result.Where(o => o.OrderType == "BUY").Max(o => o.Quantity));
                        row["MaxSellQuantity"] = string.Format(new CultureInfo("en-US", false), "{0:n}", rootObject.result.Where(o => o.OrderType == "SELL").Max(o => o.Quantity));
                        row["DateTime"] = DateTime.Now;
                        row["OrderBookPercent"] = (_orderBookRootObject.result.buy.Sum(o => o.Quantity) / _orderBookRootObject.result.sell.Sum(o => o.Quantity)) * 100;
                        data.Rows.Add(row);
                        //data.Rows.InsertAt(row, 0);
                        var deltaOrderBookPercent = decimal.Parse(_lastRow["OrderBookPercent"].ToString()) - decimal.Parse(_firsRow["OrderBookPercent"].ToString());
                        if (data.Rows.Count > 1)
                        {
                            _firsRow = data.Rows[data.Rows.Count - 2];
                            _lastRow = data.Rows[data.Rows.Count - 1];
                            row["DeltaPercent"] = decimal.Parse(_lastRow["Percent"].ToString()) - decimal.Parse(_firsRow["Percent"].ToString());
                            row["DeltaPrice"] = decimal.Parse(_lastRow["CurrentPrice"].ToString()) - decimal.Parse(_firsRow["CurrentPrice"].ToString());
                            row["DeltaOrderBookPercent"] = deltaOrderBookPercent;
                        }

                        BeginInvoke(new MethodInvoker(delegate
                        {
                            try
                            {
                                dataGridView1.DataSource = data;
                                dataGridView1.Refresh();
                                Configs.DeltaPercent = deltaOrderBookPercent;
                            }
                            catch (Exception ex)
                            { }

                        }));
                    }




                }
                catch (Exception ex)
                {
                }
                finally
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        btnStart.Enabled = true;
                    }));
                }

            }).Start();
        }
        private void PoloUrl()
        {
            new Task(() =>
            {
                if (string.IsNullOrEmpty(txtURL.Text))
                {
                    MessageBox.Show("Nhap dia chi API");
                    return;
                }
                BeginInvoke(new MethodInvoker(delegate
                {
                    btnStart.Enabled = false;
                }));
                try
                {
                    DataTable data = (DataTable)dataGridView1.DataSource;
                    if (data == null)
                    {
                        data = new DataTable();
                        data.Columns.Add("TotalBuy", typeof(string));
                        data.Columns.Add("TotalSell", typeof(string));
                        data.Columns.Add("CurrentPrice", typeof(decimal));
                        data.Columns.Add("DeltaPrice", typeof(decimal));
                        data.Columns.Add("Percent", typeof(decimal));
                        data.Columns.Add("DeltaPercent", typeof(decimal));
                        data.Columns.Add("OrderBookPercent", typeof(decimal));
                        data.Columns.Add("DeltaOrderBookPercent", typeof(decimal));
                        data.Columns.Add("MaxBuyQuantity", typeof(string));
                        data.Columns.Add("MaxSellQuantity", typeof(string));
                        data.Columns.Add("DateTime", typeof(DateTime));
                    }
                    var objAPI = new APIClient(new HttpClient());
                    //Get orderbook

                    var response = Helpers.GetdataViaproxy(txtOrderbook.Text);
                    //get order book

                    //if (_PoloOrderBookRootObject == null)
                    _PoloOrderBookRootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PoloOrderBookRootObject>(response);
                    //else
                    //{
                    //    var orderbook = Newtonsoft.Json.JsonConvert.DeserializeObject<PoloOrderBookRootObject>(response);
                    //    orderbook.asks.ForEach(o =>
                    //    {
                    //        if (!_PoloOrderBookRootObject.asks.Exists(p => p.First() == o.First() && p.Last() == o.Last()))
                    //            _PoloOrderBookRootObject.asks.Add(o);
                    //    });
                    //    orderbook.bids.ForEach(o =>
                    //    {
                    //        if (!_PoloOrderBookRootObject.bids.Exists(p => p.First() == o.First() && p.Last() == o.Last()))
                    //            _PoloOrderBookRootObject.bids.Add(o);
                    //    });
                    //}

                    //get trade history
                    response = Helpers.GetdataViaproxy(txtURL.Text);

                    List<Polo> rootPolo = null;
                    if (_rootPolo == null)
                    {
                        rootPolo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Polo>>(response);
                        _rootPolo = rootPolo;
                    }
                    else
                    {
                        rootPolo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Polo>>(response);
                        rootPolo.ForEach(o =>
                        {
                            if (!_rootPolo.Exists(p => p.globalTradeID == o.globalTradeID))
                                _rootPolo.Add(o);
                        });
                    }
                    var currentPrice = ConvertHelper.ToDecimal(rootPolo.First().rate);
                    var bids = _PoloOrderBookRootObject.bids.Where(o => ConvertHelper.ToDecimal(o.First().ToString()) > (currentPrice - (currentPrice * (decimal)0.02)));
                    var asks = _PoloOrderBookRootObject.asks.Where(o => ConvertHelper.ToDecimal(o.First().ToString()) < (currentPrice + (currentPrice * (decimal)0.02)));
                    var row = data.NewRow();
                    var totalBuy = _rootPolo.Where(o => o.type == "buy").Sum(o => decimal.Parse(o.amount));
                    var totalSell = _rootPolo.Where(o => o.type == "sell").Sum(o => decimal.Parse(o.amount));
                    row["TotalBuy"] = string.Format(new CultureInfo("en-US", false), "{0:n}", totalBuy);
                    row["TotalSell"] = string.Format(new CultureInfo("en-US", false), "{0:n}", totalSell); ;
                    row["CurrentPrice"] = rootPolo.First().rate;
                    row["Percent"] = (totalBuy / totalSell) * 100;
                    row["MaxBuyQuantity"] = string.Format(new CultureInfo("en-US", false), "{0:n}", rootPolo.Where(o => o.type == "buy").Max(o => decimal.Parse(o.amount)));
                    row["MaxSellQuantity"] = string.Format(new CultureInfo("en-US", false), "{0:n}", rootPolo.Where(o => o.type == "sell").Max(o => decimal.Parse(o.amount)));
                    row["DateTime"] = DateTime.Now;
                    row["OrderBookPercent"] = (bids.Sum(o => ConvertHelper.ToDecimal(o.Last().ToString())) / asks.Sum(o => ConvertHelper.ToDecimal(o.Last().ToString()))) * 100;
                    data.Rows.Add(row);
                    decimal deltaOrderBookPercent = 0;
                    //data.Rows.InsertAt(row, 0);
                    if (data.Rows.Count > 1)
                    {
                        _firsRow = data.Rows[data.Rows.Count - 2];
                        _lastRow = data.Rows[data.Rows.Count - 1];
                        row["DeltaPercent"] = decimal.Parse(_lastRow["Percent"].ToString()) - decimal.Parse(_firsRow["Percent"].ToString());
                        row["DeltaPrice"] = decimal.Parse(_lastRow["CurrentPrice"].ToString()) - decimal.Parse(_firsRow["CurrentPrice"].ToString());
                        deltaOrderBookPercent = decimal.Parse(_lastRow["OrderBookPercent"].ToString()) - decimal.Parse(_firsRow["OrderBookPercent"].ToString());
                        row["DeltaOrderBookPercent"] = deltaOrderBookPercent;
                    }


                    BeginInvoke(new MethodInvoker(delegate
                    {
                        dataGridView1.DataSource = data;
                        dataGridView1.Refresh();
                        btnStart.Enabled = true;
                    }));

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);

                }
                finally
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        btnStart.Enabled = true;
                    }));
                }

            }).Start();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DataTable data = (DataTable)dataGridView1.DataSource;
            data.Clear();
            dataGridView1.DataSource = data;
            dataGridView1.Refresh();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            lblStartTime.Text = "Start Time: " + DateTime.Now.ToString();
            btnAuto.Enabled = false;
            timer1.Tick += new EventHandler(btnStart_Click);
            // Sets the timer interval to 5 seconds.
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnAuto.Enabled = true;
            timer1.Stop();
        }

        private void btnLastRow_Click(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
            }));
        }

        private void cmbCurrencyPair_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmbCurrencyPair.SelectedItem;
            string selectedValue = (string)drv.Row.ItemArray[1];
            switch (selectedValue)
            {
                case "USDT_XRP_Polo":
                    txtOrderbook.Text = "https://poloniex.com/public?command=returnOrderBook&currencyPair=USDT_BTC&depth=10000";
                    txtURL.Text = "https://poloniex.com/public?command=returnTradeHistory&currencyPair=USDT_BTC";
                    break;
                case "USDT_XRP_Bittrex":
                    txtOrderbook.Text = "https://bittrex.com/api/v1.1/public/getorderbook?market=USDT-XRP&type=both";
                    txtURL.Text = "https://bittrex.com/api/v1.1/public/getmarkethistory?market=USDT-XRP";
                    break;
                default:
                    txtOrderbook.Text = "https://bittrex.com/api/v1.1/public/getorderbook?market=USDT-XRP&type=both";
                    txtURL.Text = "https://bittrex.com/api/v1.1/public/getmarkethistory?market=USDT-XRP";
                    break;
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PostViaProxy(string.Empty));

        }
    }
}

public class Polo
{
    public int globalTradeID { get; set; }
    public int tradeID { get; set; }
    public string date { get; set; }
    public string type { get; set; }
    public string rate { get; set; }
    public string amount { get; set; }
    public string total { get; set; }

}
public class Result : BaseEntity
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Total { get; set; }
    public string FillType { get; set; }
    public string OrderType { get; set; }
}
public class BittrexMarketHistory : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Total { get; set; }
    public string FillType { get; set; }
    public string OrderType { get; set; }
}

public class RootObject
{
    public bool success { get; set; }
    public string message { get; set; }
    public List<Result> result { get; set; }

}

public class Buy
{
    public double Quantity { get; set; }
    public double Rate { get; set; }
}

public class Sell
{
    public double Quantity { get; set; }
    public double Rate { get; set; }
}

public class OrderBookResult
{
    public List<Buy> buy { get; set; }
    public List<Sell> sell { get; set; }
}

public class OrderBookRootObject
{
    public bool success { get; set; }
    public string message { get; set; }
    public OrderBookResult result { get; set; }
}

public class PoloOrderBookRootObject
{
    public List<List<object>> asks { get; set; }
    public List<List<object>> bids { get; set; }
    public string isFrozen { get; set; }
    public int seq { get; set; }
}

public class PoloParam
{
    public string EndPoint { get; set; }
    public string Key { get; set; }
    public string Sign { get; set; }
    public string myParam { get; set; }
}

