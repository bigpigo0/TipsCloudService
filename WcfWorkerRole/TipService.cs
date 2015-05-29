using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Caching;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using CsQuery;
using Newtonsoft.Json;
using NLog;

namespace WcfWorkerRole
{
    public class TipService : ITipService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly ObjectCache _cache = MemoryCache.Default;

        public Stream GetHelloMessage()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("Hello")));
        }

        public Stream GetRace(string number)
        {
            var url = "http://bet.hkjc.com/racing/getXML.aspx?type=starters&RaceNo=" + number;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            var root = GetXmlType<ROOT>(url);
            foreach (var runner in root.STARTERS.RACE.RUNNER)
            {
                if (runner.JOCKEY_CODE == "(Null)") continue;
                var dict = GetJockeyWinStat(runner.JOCKEY_CODE);
                var jockeyWinStat = new Tuple<string, string>(string.Empty, string.Empty);
                switch (root.STARTERS.VENUE)
                {
                    case "HV":
                        jockeyWinStat = dict["跑馬地_" + root.STARTERS.RACE.DISTANCE];
                        break;
                    case "ST":
                        jockeyWinStat = root.STARTERS.TRACK == "TURF" ? dict["草地跑道_" + root.STARTERS.RACE.DISTANCE] : dict["全天候跑道_" + root.STARTERS.RACE.DISTANCE];
                        break;
                }
                runner.JOCKEY_WIN_STAT = jockeyWinStat.Item1;
                runner.JOCKEY_PLA_STAT = jockeyWinStat.Item2;
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(root)));
        }

        public Stream GetMeeting()
        {
            var url = "http://bet.hkjc.com/racing/hr_bet_main_block.aspx?lang=ch&block=1";
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            var speedRequest = WebRequest.Create(url) as HttpWebRequest;
            if (speedRequest == null) return new MemoryStream();
            speedRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            int meeting = 0;
            using (var response = (HttpWebResponse)speedRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                {
                    var html = reader.ReadToEnd(); // <----- Read whole stream to string
                    CQ dom = html;
                    var a = dom.Find("td:contains('場')").Text().Split(new string[] { " " }, StringSplitOptions.None);
                    if (a.Length == 2)
                    {
                        meeting = int.Parse(a[0]); 
                    }
                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(meeting)));
        }

        public Stream GetPoolTot(string number)
        {

            var url = "http://bet.hkjc.com/racing/getXML.aspx?type=pooltot&RaceNo=" + number;
            var winUrl = "http://bet.hkjc.com/racing/getXML.aspx?type=win&RaceNo=" + number;
            var plaUrl = "http://bet.hkjc.com/racing/getXML.aspx?type=pla&RaceNo=" + number;
            var result = new Dictionary<string, Tuple<Tuple<string, string, string, string, string>, Tuple<string, string, string, string, string>>>();
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            var poolTot = GetXmlType<PoolTot>(url);
            var win = GetXmlType<Win>(winUrl);
            var pla = GetXmlType<Place>(plaUrl);
            for(int i = 0; i < win.WIN.RACE.OUT.Length; i++)
            {

                if (win.WIN.RACE.OUT[i].WILLPAY != "SCR")
                {
                    var winOdd = double.Parse(win.WIN.RACE.OUT[i].WILLPAY)/1000;
                    var plaOdd = double.Parse(pla.PLA.RACE.OUT[i].MIN_WILLPAY)/1000;
                    var winPoolTot = double.Parse(poolTot.POOL_TOT.RACE.INV[0].Value)*(1 - 0.175);
                    var plaPoolTot = double.Parse(poolTot.POOL_TOT.RACE.INV[1].Value)*(1 - 0.175);
                    var winTol = Math.Round(winPoolTot/winOdd);
                    var plaTot = Math.Round(plaPoolTot/plaOdd);
                    var winOddDrop = double.Parse(win.WIN.RACE.OUT[i].ODDSDROP) / 100;
                    var plaOddDrop = double.Parse(pla.PLA.RACE.OUT[i].ODDSDROP) / 100;
                    var oldWinTotal = winTol * (1 - winOddDrop);
                    var oldPlaTotal = plaTot * (1 - plaOddDrop);
                    var oldWinDropTot = winTol - oldWinTotal;
                    var oldPlaDropTot = plaTot - oldPlaTotal;
                    //var winDropTot = winTol - Math.Round(winPoolTot/winOdd); 
                    result[win.WIN.RACE.OUT[i].NUM] =
                        new Tuple<Tuple<string, string, string, string, string>, Tuple<string, string, string, string, string>>(
                            new Tuple<string, string, string, string, string>(winOdd.ToString(), win.WIN.RACE.OUT[i].ODDSDROP,
                                win.WIN.RACE.OUT[i].HF, winTol.ToString("##,###"), oldWinDropTot.ToString("##,###")),
                            new Tuple<string, string, string, string, string>(plaOdd.ToString(), pla.PLA.RACE.OUT[i].ODDSDROP,
                                pla.PLA.RACE.OUT[i].HF, plaTot.ToString("##,###"), oldPlaDropTot.ToString("##,###")));
                }
                else
                {
                    result[win.WIN.RACE.OUT[i].NUM] = new Tuple<Tuple<string, string, string, string, string>, Tuple<string, string, string, string, string>>(new Tuple<string, string, string, string, string>(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
    new Tuple<string, string, string, string, string>(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)); 
                }

            }

            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));
        }

        public Stream GetWin(string number)
        {

            var url = "http://bet.hkjc.com/racing/getXML.aspx?type=win&RaceNo=" + number;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return GetXmlStream<Win>(url);
        }

        public Stream GetPlace(string number)
        {

            var url = "http://bet.hkjc.com/racing/getXML.aspx?type=pla&RaceNo=" + number;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return GetXmlStream<Place>(url);
        }

        public Stream GetSpeed(string number)
        {
            var raceTip = _cache.Get("Speed_" + number) as RaceTip;

            if (raceTip == null)
            {
                raceTip = new RaceTip()
                {
                    FitnessRating = new Dictionary<string, string>(),
                    SpeedIndex = new Dictionary<string, string>(),
                    NewsPaperTip = new Dictionary<string, string>()
                };

                try
                {
                    var url = "http://www.hkjc.com/chinese/formguide/speedmap.asp?FrmRaceNum=" + (int.Parse(number) >= 10 ? number : "0" + number);
                    if (WebOperationContext.Current != null)
                        WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

                    var speedRequest = WebRequest.Create(url) as HttpWebRequest;
                    if (speedRequest == null) return new MemoryStream();
                    speedRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                    using (var response = (HttpWebResponse)speedRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                        {
                            var html = reader.ReadToEnd(); // <----- Read whole stream to string
                            CQ dom = html;
                            raceTip.ImagePath = dom.Find("img[alt*='Speed Map of meeting']").Attr("src");
                            dom.Find(".normalfont").Each((i, o) =>
                            {
                                raceTip.SpeedIndex.Add(CQ.Create(o).Find("td:eq(1)").Text().Trim(),
                                        CQ.Create(o).Find("td:eq(4)").Text().Trim());
                                raceTip.FitnessRating.Add(CQ.Create(o).Find("td:eq(1)").Text().Trim(),
                                    CQ.Create(o).Find("td:eq(5)").Find("img").Length.ToString());
                            });

                        }
                    }

                    var tipRequest = WebRequest.Create("http://hk.racing.nextmedia.com/other9tips.php") as HttpWebRequest;
                    tipRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (var response = (HttpWebResponse)tipRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                        {
                            var html = reader.ReadToEnd(); // <----- Read whole stream to string
                            CQ dom = html;
                            dom.Find(dom.Find("table.small tr")).Each((i, o) =>
                            {
                                var a = CQ.Create(o).Find("td:eq(0)").Text().Replace("\n\n", "");
                                if (!string.IsNullOrEmpty(a))
                                {
                                    var horse = new List<string>();
                                    CQ.Create(o).Find("a").Each((i1, domObject) =>
                                    {
                                        horse.Add(HttpUtility.HtmlDecode(domObject.InnerText));
                                    });
                                    raceTip.NewsPaperTip.Add(a, string.Join(",", horse.ToArray()));
                                }
                            });
                        }
                    }

                    var onccTipRequest = WebRequest.Create("http://racing.on.cc/racing/fav/current/rjfavf0301x0.html") as HttpWebRequest;
                    onccTipRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (var response = (HttpWebResponse)onccTipRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("Big5"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                        {
                            var html = reader.ReadToEnd(); // <----- Read whole stream to string
                            CQ dom = html;
                            var onccTip = new Dictionary<string, string>();
                            dom.Find(dom.Find("#alternateRowTable").Find("tr")).Each((i, o) =>
                            {
                                CQ.Create(o).Find("td:eq(1) a").Each((i1, domObject) =>
                                {
                                    onccTip[CQ.Create(domObject).Text()] = (i1 + 1).ToString();
                                });
                            });
                            raceTip.JockyTip = onccTip;
                        }
                    }

                    _cache.Add("Speed_" + number, raceTip,
                        new CacheItemPolicy() {AbsoluteExpiration = DateTimeOffset.UtcNow.AddMilliseconds(15*60*1000)});
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(raceTip)));
        }

        public Stream GetResult(string number)
        {
            var url = "http://bet.hkjc.com/racing/pages/results.aspx?date=26-04-2015&venue=ST&raceno=" + number;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            var resultRequest = WebRequest.Create(url) as HttpWebRequest;
            if (resultRequest == null) return new MemoryStream();
            resultRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var result = new Dictionary<string, string>();
            using (var response = (HttpWebResponse)resultRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
            {
                try
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                    {
                        var html = reader.ReadToEnd(); // <----- Read whole stream to string
                        CQ dom = html;
                        for (var i = 1; i <= 4; i++)
                        {
                            var horse = dom.Find("td:contains('名次'):eq(3) table tr:eq(" + i + ") td:eq(2)").Text();
                            if (dom.Find("td:contains('名次'):eq(3) table tr:eq(" + i + ") td:eq(0)").Text().Length >= 1)
                            {
                                var place = dom.Find("td:contains('名次'):eq(3) table tr:eq(" + i + ") td:eq(0)").Text().Substring(0, 1);
                                if (!string.IsNullOrEmpty(horse))
                                {
                                    result[horse] = place;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));
        }

        public Stream GetJockyFairValue()
        {
            var url = "http://racing.hkjc.com/racing/Info/jockey/Ranking/chinese";

            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            var resultRequest = WebRequest.Create(url) as HttpWebRequest;
            if (resultRequest == null) return new MemoryStream();
            resultRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var result = new Dictionary<string, Tuple<decimal, decimal>>();
            using (var response = (HttpWebResponse)resultRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                {
                    var html = reader.ReadToEnd(); // <----- Read whole stream to string
                    CQ dom = html;
                    dom.Find("table:contains('騎師榜')").Find("tr:contains('$')").Each((i, o) =>
                    {
                        var jocky = CQ.Create(o).Find("td:eq(0)").Text();
                        var first = CQ.Create(o).Find("td:eq(1)").Text();
                        var second = CQ.Create(o).Find("td:eq(2)").Text();
                        var third = CQ.Create(o).Find("td:eq(3)").Text();
                        var total = CQ.Create(o).Find("td:eq(6)").Text();
                        decimal winFairValue = decimal.Parse(first)/decimal.Parse(total);
                        decimal plaFairValue = (decimal.Parse(first) + decimal.Parse(second) + decimal.Parse(third)) / decimal.Parse(total);
                        if (winFairValue != 0)
                        {
                            winFairValue = 1 / winFairValue;
                            winFairValue = Math.Round(winFairValue, 1);  
                        }
                        if (plaFairValue != 0)
                        {
                            plaFairValue = 1 / plaFairValue;
                            plaFairValue = Math.Round(plaFairValue, 1); 
                        }
                        result[jocky] = new Tuple<decimal, decimal>(winFairValue, plaFairValue);
                    });
                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

        }

        public Stream GetBarDrawWinChance()
        {
            var url = "http://racing.hkjc.com/racing/info/meeting/Draw/chinese/Local";

            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            var resultRequest = WebRequest.Create(url) as HttpWebRequest;
            if (resultRequest == null) return new MemoryStream();
            resultRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var result = new Dictionary<string, Tuple<decimal, decimal>>();
            using (var response = (HttpWebResponse)resultRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                {
                    var html = reader.ReadToEnd(); // <----- Read whole stream to string
                    CQ dom = html;
                    dom.Find(".tdAlignC.lineH15").Each((i, o) =>
                    {
                        CQ.Create(o).Find("tr").Each((i1, domObject) =>
                        {
                            if (i1 >= 1)
                            {
                                var bar = CQ.Create(domObject).Find("td:eq(0)").Text();
                                var win = CQ.Create(domObject).Find("td:eq(6)").Text();
                                var pla = CQ.Create(domObject).Find("td:eq(8)").Text();
                                if (win != "" && pla != "")
                                {
                                    result[(i+1) + "_" + bar] = new Tuple<decimal, decimal>(decimal.Parse(win), decimal.Parse(pla));
                                }
                            }
                        });
                    });

                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

        }

        public Dictionary<string, Tuple<string, string>> GetJockeyWinStat(string jockyCode)
        {
            var result = _cache.Get(jockyCode) as Dictionary<string, Tuple<string, string>>;
            if (result == null)
            {
                var url = string.Format(
                "http://www.hkjc.com/chinese/racing/JockeyWinStat.asp?JockeyCode={0}&season=Current&view=Numbers",
                jockyCode);
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

                var resultRequest = WebRequest.Create(url) as HttpWebRequest;
                if (resultRequest == null) return null;
                resultRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                result = new Dictionary<string, Tuple<string, string>>();
                using (var response = (HttpWebResponse)resultRequest.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                {
                    try
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                        {
                            var html = reader.ReadToEnd(); // <----- Read whole stream to string
                            CQ dom = html;
                            var venue = string.Empty;
                            dom.Find(".bigborder tr").Each((i, o) =>
                            {
                                if (i > 0)
                                {
                                    var row = CQ.Create(o);

                                    if (row.Find("td").Length == 6)
                                    {
                                        venue = row.Find("td:eq(0)").Text().Trim();
                                        var distance = row.Find("td:eq(1)").Text().Trim();
                                        var win = row.Find("td:eq(2)").Text().Trim();
                                        var second = row.Find("td:eq(3)").Text().Trim();
                                        var third = row.Find("td:eq(4)").Text().Trim();
                                        var total = row.Find("td:eq(5)").Text().Trim();

                                        if (total != "0")
                                        {
                                            var winP = Math.Floor((decimal.Parse(win) / decimal.Parse(total)) * 100);
                                            var placeP = Math.Floor(((decimal.Parse(second) + decimal.Parse(third)) / decimal.Parse(total)) * 100);
                                            result[venue + "_" + distance] = new Tuple<string, string>(winP.ToString(), placeP.ToString());
                                        }
                                        else
                                        {
                                            result[venue + "_" + distance] = new Tuple<string, string>("0", "0");
                                        }

                                    }
                                    else if (row.Find("td").Length == 5)
                                    {
                                        var distance = row.Find("td:eq(0)").Text().Trim();
                                        var win = row.Find("td:eq(1)").Text().Trim();
                                        var second = row.Find("td:eq(2)").Text().Trim();
                                        var third = row.Find("td:eq(3)").Text().Trim();
                                        var total = row.Find("td:eq(4)").Text().Trim();

                                        if (total != "0")
                                        {
                                            var winP = Math.Floor((decimal.Parse(win) / decimal.Parse(total)) * 100);
                                            var placeP = Math.Floor(((decimal.Parse(second) + decimal.Parse(third)) / decimal.Parse(total)) * 100);
                                            result[venue + "_" + distance] = new Tuple<string, string>(winP.ToString(), placeP.ToString());
                                        }
                                        else
                                        {
                                            result[venue + "_" + distance] = new Tuple<string, string>("0", "0");
                                        }
                                    }
                                    else if (row.Find("td").Length == 7)
                                    {
                                        venue = row.Find("td:eq(1)").Text().Trim();
                                        var distance = row.Find("td:eq(2)").Text().Trim();
                                        var win = row.Find("td:eq(3)").Text().Trim();
                                        var second = row.Find("td:eq(4)").Text().Trim();
                                        var third = row.Find("td:eq(5)").Text().Trim();
                                        var total = row.Find("td:eq(6)").Text().Trim();

                                        if (total != "0")
                                        {
                                            var winP = Math.Floor((decimal.Parse(win) / decimal.Parse(total)) * 100);
                                            var placeP = Math.Floor(((decimal.Parse(second) + decimal.Parse(third)) / decimal.Parse(total)) * 100);
                                            result[venue + "_" + distance] = new Tuple<string, string>(winP.ToString(), placeP.ToString());
                                        }
                                        else
                                        {
                                            result[venue + "_" + distance] = new Tuple<string, string>("0", "0");
                                        }
                                    }

                                }
                            });
                            _cache.Add(jockyCode, result, DateTimeOffset.UtcNow.AddMilliseconds(1000 * 60 * 60 * 12));
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e);
                    }
                } 
            }
            return result;

        }

        #region private method
        private Stream GetXmlStream<T>(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null) return new MemoryStream();
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            T type = default (T);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                    {
                        var xml = reader.ReadToEnd(); // <----- Read whole stream to string
                        xml = xml.Replace("<?xml version='1.0'?>", "");

                        var serializer = new XmlSerializer(typeof(T));
                        using (var sReader = new StringReader(xml))
                        {

                            type = (T)serializer.Deserialize(sReader);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(type)));
        }

        private T GetXmlType<T>(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null) return default(T);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            T type = default(T);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse()) //<----- Get http responce, if this is not http respone you need to know what encoding
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet))) //<----- If not HTTP responce, then response.CharacterSet must be replaced by predefined encoding, i.e. UTF-8
                    {
                        var xml = reader.ReadToEnd(); // <----- Read whole stream to string
                        xml = xml.Replace("<?xml version='1.0'?>", "");

                        var serializer = new XmlSerializer(typeof(T));
                        using (var sReader = new StringReader(xml))
                        {

                            type = (T)serializer.Deserialize(sReader);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
            return type;
        } 
        #endregion
    }

}
