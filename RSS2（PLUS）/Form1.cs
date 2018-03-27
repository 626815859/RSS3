using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSS阅读器2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, string> dic = new Dictionary<string, string>();  //保存收藏的rss源网址

        private void RssUrlGO_Click(object sender, EventArgs e)
        {



            Stream rssStream = GetXmlStream(RssUrlTb.Text.Trim());
            XmlDocument rssDoc0 = new XmlDocument();
            rssDoc0.Load(rssStream);

            //收藏夹
            XmlNode rssTitle = rssDoc0.SelectSingleNode("rss/channel/title");


            //追加到收藏的本地xml中 再显示出来
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load("News.xml");

            XmlElement rss = rssDoc.DocumentElement;  //获取根节点


            XmlElement rssLinkElement = rssDoc.CreateElement("rsslink");          
            rss.AppendChild(rssLinkElement);

            XmlElement link = rssDoc.CreateElement("link");    //此link不是具体某条新闻的link，而是这个rss源的
            link.InnerText = RssUrlTb.Text.Trim();
            rssLinkElement.AppendChild(link);


            XmlElement title = rssDoc.CreateElement("title"); //此link不是具体某条新闻的title，而是这个rss源的
            title.InnerText = rssTitle.InnerText;
            rssLinkElement.AppendChild(title);
            rssDoc.Save("News.xml");



            dic.Clear();
            RssListTb.Items.Clear();
            rssStream.Close();


            LoadXml();


        }





        private void RssListTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RssNewsList.Nodes.Clear();   //清空


            string rssUrl= dic.ElementAt(RssListTb.SelectedIndex).Key;
            Stream rssStream = GetXmlStream(rssUrl);

          
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);



            //获得xml的根节点（根元素）
            XmlElement rootElement = rssDoc.DocumentElement;
            //先把xml的根元素加载到TreeView上
            TreeNode rootNode = RssNewsList.Nodes.Add(rootElement.Name);

            //实现递归将xml加载到TreeView中
            LoadToTreeByXmlDocument(rootElement, rootNode.Nodes);




            GetNews(rssUrl);
            newsListBox.Items.Clear();
            //把新闻标题加载到Listbox中
            foreach (KeyValuePair<string,string> item in dic2)
            {
                newsListBox.Items.Add(item.Value);
            }
           

        }

        private void LoadToTreeByXmlDocument(XmlElement rootElement, TreeNodeCollection treeNodeCollection)
        {
            //循环rootElement下的所有子元素加载到treeNodeCollection集合中
            foreach (XmlNode item in rootElement.ChildNodes)
            {
                //在继续之前需要判断一下当前节点是什么类型的节点
                if (item.NodeType == XmlNodeType.Element)
                {
                    //如果当前节点是一个“元素”节点，则把当前节点加载到TreeView上
                    TreeNode node = treeNodeCollection.Add(item.Name);
                    //递归调用
                    LoadToTreeByXmlDocument((XmlElement)item, node.Nodes);
                }
                else if (item.NodeType == XmlNodeType.Text | item.NodeType == XmlNodeType.CDATA)
                {
                    treeNodeCollection.Add(item.InnerText);
                }
            }
        }

        private void RssNewsList_AfterSelect(object sender, TreeViewEventArgs e)
        {

            newsUrl.Text = e.Node.Text;
            RssWeb.Navigate(newsUrl.Text);
        }


        Dictionary<string, string> dic2 = new Dictionary<string, string>();


        /// <summary>
        /// 获取每个频道的新闻
        /// </summary>
        /// <param name="rssUrl"></param>

        private void GetNews(string rssUrl)
        {
            dic2.Clear();

            Stream rssStream = GetXmlStream(rssUrl);
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);
            XmlNodeList xmlNodeList = rssDoc.SelectNodes("rss/channel/item");
            foreach (XmlNode item in xmlNodeList)
            {

                    string title = "";
                    string link = "";
                    XmlNodeList xmlNodeList2 = item.ChildNodes;
                    title = xmlNodeList2[0].InnerText;
                    link = xmlNodeList2[2].InnerText;
                    dic2.Add(link, title);
            }
            rssStream.Close();

        }



        /// <summary>
        /// 加载本地收藏的rss新闻源
        /// </summary>
        private void LoadXml()
        {
            XmlDocument doc = new XmlDocument();
            if(File.Exists("News.xml"))    //判断本地收藏的rss xml是否存在
            {
                doc.Load("News.xml");
                XmlNodeList xmlNodeList = doc.SelectNodes("rss/rsslink");              
                foreach (XmlNode item in xmlNodeList)
                {
                    string title = "";
                    string link = "";
                    XmlNodeList xmlNodeList2 = item.ChildNodes;
                    for (int i = 0; i <= xmlNodeList2.Count; i++)
                    {
                        if(i==0)
                        {
                            link = xmlNodeList2[0].InnerText;
                        }
                        else
                        {
                            title = xmlNodeList2[1].InnerText;
                        }                                           
                    }
                    dic.Add(link, title);
                   // list.Add(dic);
                              
                }
                //添加到最左边的listtb中
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    RssListTb.Items.Add(kvp.Value);
                }
            }
            else  //创建XML
            {
                XmlDocument doc2 = new XmlDocument();
                XmlDeclaration dec=   doc2.CreateXmlDeclaration("1.0", "utf-8", null);
                doc2.AppendChild(dec);
                XmlElement rssElement = doc2.CreateElement("rss");
                doc2.AppendChild(rssElement);
                doc2.Save("News.xml");
            }
                   
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
                     
            LoadXml();
        }

        private void ControlBt_Click(object sender, EventArgs e)
        {

            //通过Form类构造方法的重载传参。
            RssControlForm rCF = new RssControlForm(dic);
            rCF.Show();
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


        private void newsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newUrl = dic2.ElementAt(newsListBox.SelectedIndex).Key;
            RssWeb.Navigate(newUrl);
        }
    }
}
