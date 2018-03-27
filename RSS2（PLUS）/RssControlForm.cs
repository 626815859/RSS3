
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using NPOI.SS.UserModel;     //用于导出excel
using NPOI.HSSF.UserModel;   //用于导出excel

namespace RSS阅读器2
{
    public partial class RssControlForm : Form
    {
        public bool IsChangeDic = false;  //用于判断集合是否被修改,若为True则关闭窗体时候，更新xml  若为False  则不更新

        //用于窗体维护一个集合，操作完之后，关闭窗体时候再写到xml当中去
        Dictionary<string, string> rssDic = new Dictionary<string, string>();
        public RssControlForm()
        {
            InitializeComponent();
        }

        //重载的构造函数
        public RssControlForm(Dictionary<string,string> dic)
        {
            InitializeComponent();  
            rssDic = dic;      
        }


        //页面加载
        private void RssControlForm_Load(object sender, EventArgs e)
        {
            LoadRssNews();

        }

        /// <summary>
        /// 把传过来的集合遍历加载到listbox中
        /// </summary>
        public void LoadRssNews()
        {
            foreach (KeyValuePair<string,string> k in rssDic)
            {
                RssList.Items.Add(k.Value);
            }
        }

        /// <summary>
        /// 点击listbox中的新闻rss  显示到修改框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RssList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //显示对应的信息
            RssTitleTb.Text= rssDic.ElementAt(RssList.SelectedIndex).Value;
            RssLinkTb.Text = rssDic.ElementAt(RssList.SelectedIndex).Key;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelBt_Click(object sender, EventArgs e)
        {
            IsChangeDic = true;   //修改了，变为true

            rssDic.Remove(RssLinkTb.Text);  //移除集合中删除的

            RssList.Items.Clear();  //清空
            RssLinkTb.Clear();
            RssTitleTb.Clear();

            LoadRssNews();  //重新加载rsslist
        }



        /// <summary>
        /// 导出为Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLoadToExcelBt_Click(object sender, EventArgs e)
        {
            string rssUrl= rssDic.ElementAt(RssList.SelectedIndex).Key;      //获取url
            string rssTitle= rssDic.ElementAt(RssList.SelectedIndex).Value;  //获取title，用于保存excel

            Stream rssStream = GetXmlStream(rssUrl);  //返回rss流
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);

            IWorkbook wkbook = new HSSFWorkbook();   //创建工作簿对象  
            ISheet sheet = wkbook.CreateSheet();     //创建工作表对象


            XmlNodeList xmlNodes = rssDoc.SelectNodes("rss/channel/item");  //选中item

            for (int i = 0; i < xmlNodes.Count; i++)
            {
                IRow row = sheet.CreateRow(i);                         //创建一行
                XmlNodeList xmlitemChilren = xmlNodes[i].ChildNodes;   
                for (int j = 0; j < xmlitemChilren.Count; j++)         //根据每条新闻的标记数量创建单元格
                {
                    row.CreateCell(j).SetCellValue(xmlitemChilren[j].InnerText);
               }
            }

            //写入
            using (FileStream fsWrite = File.OpenWrite(rssTitle+".xls"))
            {
                wkbook.Write(fsWrite);
            }
            rssStream.Close();
            MessageBox.Show("导入excel成功");


        }



        /// <summary>
        /// 保存修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBt_Click(object sender, EventArgs e)
        {
            IsChangeDic = true;

            string rssUrl = rssDic.ElementAt(RssList.SelectedIndex).Key;
            rssDic[rssUrl] = RssTitleTb.Text.Trim();

            RssList.Items.Clear();  //清空
            RssLinkTb.Clear();
            RssTitleTb.Clear();
            LoadRssNews();  //重新加载rsslist


           


        }



        //关闭窗体时候把更改或者删除之后后的内容写到xml中
        private void RssControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(IsChangeDic==true)  //若为True 则更新xml
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("News.xml");
                XmlElement xmlRoot = xmlDoc.DocumentElement;  //获取根节点
                xmlRoot.RemoveAll();//删除根节点下面所有子节点

                //把集合中的写进去
                foreach (KeyValuePair<string, string> dicItems in rssDic)
                {
                    XmlElement rssLinkElement = xmlDoc.CreateElement("rsslink");
                    xmlRoot.AppendChild(rssLinkElement);

                    XmlElement link = xmlDoc.CreateElement("link");
                    link.InnerText = dicItems.Key;
                    rssLinkElement.AppendChild(link);


                    XmlElement title = xmlDoc.CreateElement("title");
                    title.InnerText = dicItems.Value;
                    rssLinkElement.AppendChild(title);

                    xmlDoc.Save("News.xml");

                }

            }         
        }

        /// <summary>
        /// 获取rssxml流
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        private Stream GetXmlStream(string rssUrl)
        {
            WebRequest myRequest = WebRequest.Create(rssUrl);
            WebResponse myResponse = myRequest.GetResponse();
            Stream rssStream = myResponse.GetResponseStream();
            return rssStream;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rssUrl = rssDic.ElementAt(RssList.SelectedIndex).Key;
            WebRequest myRequest = WebRequest.Create(rssUrl);
            WebResponse myResponse = myRequest.GetResponse();
            Stream rssStream = myResponse.GetResponseStream();
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);
            rssDoc.Save(@"../book.xml");
            MessageBox.Show("success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
